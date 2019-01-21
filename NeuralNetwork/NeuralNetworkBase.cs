using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetworkBase
    {
        Matrix<double> _inputs;

        List<Matrix<double>> _weigths;

        List<Matrix<double>> _bias;

        List<Layer> _layers;

        List<Matrix<double>> _layerOutput;

        double _learningRate;

        int _epoch;

        Matrix<double> _totalLost;

        Func<Matrix<double>, Matrix<double>, Matrix<double>> _lostFunction;
        readonly MatrixBuilder<double> M = Matrix<double>.Build;


        //inicializar los valores de la red neuronal
        public NeuralNetworkBase(List<Layer> layers, double learningRate = 0.001, int epoch = 100, string lost = "MSE")
        {
            _layers = layers;

            _learningRate = learningRate;
            _epoch = epoch;

            //la primera capa es la de entrada, 
            //la cantidad de nodos corresponde a la cantidad de inputs
            _inputs = M.Dense(layers.First().Nodes, 1);

            _weigths = new List<Matrix<double>>();
            _bias = new List<Matrix<double>>();
            _layerOutput = new List<Matrix<double>>();
            _lostFunction = Lost.GetLostFunction(lost);

            for (int i = 0; i < layers.Count; i++)
            {

                if (i == 0)
                {
                    continue;
                    //la capa de entrada no tiene pesos W
                }
                //inicializar las matrices de pesos
                var l = layers[i];
                var andL = layers[i - 1];

                var weights = M.Dense(l.Nodes, andL.Nodes,
                (x, y) =>
                {
                    Random random = new MathNet.Numerics.Random.SystemRandomSource();
                    var sample = random.NextDouble();
                    return sample;
                });
                _weigths.Add(weights);

                //inicializar las matrices bias

                var bias = M.Dense(l.Nodes, 1,
                            (x, y) =>
                            {
                                Random random = new MathNet.Numerics.Random.SystemRandomSource();
                                var sample = random.NextDouble();
                                return sample;
                            });
                _bias.Add(bias);
            }

        }


        /// <summary>
        /// por cada uno de los ejemplos dados ejecutar el ciclo de entrenamiento de la red,
        /// multiplicar los pesos W por los valores de entrada  I
        /// </summary>
        /// <param name="input"></param>
        /// <param name="desiredOutPut"></param>
        private void Train(double[] inputArray, double[] desiredOutPut)
        {
            _inputs = M.Dense(inputArray.Length, 1, inputArray);

            var input = M.DenseOfMatrix(_inputs);
            var desired = M.Dense(desiredOutPut.Length, 1, desiredOutPut);

            //por cada capa de la red aplicar la suma ponderada
            var output = FeedFordward(input);
            //var networkLost = desired.Subtract(output);
            var networkLost = _lostFunction(desired, output);
            BackPropagation(networkLost);

            //TODO: optimizar los pesos W usando la funcion de optimizacion
        }

        private Matrix<double> FeedFordward(Matrix<double> input)
        {
            var output = M.DenseOfMatrix(input);
            _layerOutput.Clear();
            for (int i = 0; i < _weigths.Count; i++)
            {
                output = _weigths[i] * output;
                output.Add(_bias[i]);
                //aplicar la funcion de activacion de la capa a cada uno de los valores del vector
                var outPutActivated = M.DenseOfMatrix(output);
                output.Map(Activation.GetActivationByName(), outPutActivated);
                output = M.DenseOfMatrix(outPutActivated);

                _layerOutput.Add(M.DenseOfMatrix(output));
            }

            return output;
        }
        /*
        calculate signals into final output layer
        final_inputs = numpy.dot(self.who, hidden_outputs)
        # calculate the signals emerging from final output layer
        final_outputs = self.activation_function(final_inputs)
        
        # output layer error is the (target - actual)
        output_errors = targets - final_outputs
        # hidden layer error is the output_errors, split by weights, recombined at hidden nodes
        hidden_errors = numpy.dot(self.who.T, output_errors) 
        
        # update the weights for the links between the hidden and output layers
        self.who += self.lr * numpy.dot((output_errors * final_outputs * (1.0 - final_outputs)), numpy.transpose(hidden_outputs))
        */
        private List<Matrix<double>> BackPropagation(Matrix<double> error)
        {
            var deltas = new List<Matrix<double>>();
            var e = M.DenseOfMatrix(error);

            for (int i = _layerOutput.Count - 1; i < _weigths.Count; i++)
            {
                var derivative = Activation.GetActivationDerivativeByName(_layers[i].Activation);
                var gradient = _layerOutput[i].Map(derivative);

                if (i < _layerOutput.Count - 1) //no es la capa de salida
                    e = _weigths[i + 1].Transpose() * e;

                //multiplicar la pendiente de los valores de salida de la capa por el error
                gradient.PointwiseMultiply(e);

                var inputT = _inputs.Transpose();

                if (i > 0)//no es el ultimo elemento
                {
                    inputT = _layerOutput[i - 1].Transpose();
                }

                var delta = gradient * inputT;
                delta *= _learningRate;

                deltas.Add(delta);
            }

            deltas.Reverse();
            return deltas;
        }

        public NeuralNetworkModel Fit(double[][] input, double[] desiredOutPut)
        {

            _totalLost = M.Dense(desiredOutPut.Length, 1);
            for (int j = 0; j < _epoch; j++)
            {
                //Console.WriteLine($"Epoch: {j}/{_epoch}");
                for (int i = 0; i < input.Length; i++)
                {
                    Train(input[i], desiredOutPut);
                }
                //Console.WriteLine($"Perdida total:  {_totalLost}");
            }

            this.Print();

            return new NeuralNetworkModel
            {
                Weigths = _weigths,
            };
        }


        public void Print()
        {
            //Print inputs

            Console.WriteLine(_inputs + " ");

            Console.WriteLine("");

            //print layer weights

            foreach (var item in _weigths)
            {
                Console.Write(item + " ");
            }
        }
    }
}
