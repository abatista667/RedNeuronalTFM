using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetwork3Layer
    {
        Matrix<double> _inputs;
        Matrix<double> _hiddenLayer;
        Matrix<double> _outputLayer;

        double _learningRate;

        int _epoch;

        Matrix<double> _totalLost;

        Func<Matrix<double>, Matrix<double>, Matrix<double>> _lostFunction;
        readonly MatrixBuilder<double> M = Matrix<double>.Build;
        bool _useBias;

        //inicializar los valores de la red neuronal
        public NeuralNetwork3Layer(int inputNodes, int hiddenNodes, int outputNodes,
            double learningRate = 0.001, int epoch = 100, string lost = "MSE", bool useBias = true)
        {
            _learningRate = learningRate;
            _epoch = epoch;
            _useBias = useBias;
            //la primera capa es la de entrada, 
            //la cantidad de nodos corresponde a la cantidad de inputs
            _inputs = M.Dense(inputNodes, 1);
            _hiddenLayer = M.Dense(hiddenNodes, inputNodes,
                            (x, y) =>
                            {
                                Random random = new MathNet.Numerics.Random.SystemRandomSource();
                                var sample = random.NextDouble();
                                return sample;
                            });
            _outputLayer = M.Dense(outputNodes, hiddenNodes,
                            (x, y) =>
                            {
                                Random random = new MathNet.Numerics.Random.SystemRandomSource();
                                var sample = random.NextDouble();
                                return sample;
                            });

            _lostFunction = Lost.GetLostFunction(lost);
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

            var hiddenInput = _hiddenLayer * input;
            var activation = Activation.GetActivationByName("Sigmoid");
            var hiddenOutput = hiddenInput.Map(activation);

            var finalInput = _outputLayer * hiddenOutput;
            var finalOutput = finalInput.Map(activation);

            //var networkLost = desired.Subtract(output);
            var outputError = _lostFunction(desired, finalOutput);
            var hiddenError = _outputLayer.Transpose() * (outputError);

            var outpuGradient = (outputError * finalOutput * (1 - finalOutput));
            outpuGradient *= hiddenOutput.Transpose();
            outpuGradient *= _learningRate;
            _outputLayer += outpuGradient;

            var hiddenGradient = hiddenOutput.PointwiseMultiply((1 - hiddenOutput));
            hiddenGradient = hiddenError.PointwiseMultiply(hiddenGradient);
            hiddenGradient *= input.Transpose();
            hiddenGradient *= _learningRate;

            _hiddenLayer += hiddenGradient;
            // back propagate the error

            /*# output layer error is the (target - actual)
                output_errors = targets - final_outputs
            # hidden layer error is the output_errors, split by weights, recombined at hidden nodes
            hidden_errors = numpy.dot(self.who.T, output_errors)

            # update the weights for the links between the hidden and output layers
                self.who += self.lr * numpy.dot((output_errors * final_outputs * (1.0 - final_outputs)), numpy.transpose(hidden_outputs))

            # update the weights for the links between the input and hidden layers
                self.wih += self.lr * numpy.dot((hidden_errors * hidden_outputs * (1.0 - hidden_outputs)), numpy.transpose(inputs)) */

            //TODO: optimizar los pesos W usando la funcion de optimizacion


        }

        private Matrix<double> FeedFordward(Matrix<double> input)
        {
            var hiddenInput = _hiddenLayer * input;
            var activation = Activation.GetActivationByName("Sigmoid");
            var hiddenOutput = hiddenInput.Map(activation);

            var finalInput = _outputLayer * hiddenOutput;
            var finalOutput = finalInput.Map(activation);

            return finalOutput;
        }



        public NeuralNetworkModel Fit(double[][] input, double[][] desiredOutPut)
        {

            for (int j = 0; j < _epoch; j++)
            {
                Randomize(input, desiredOutPut);
                _totalLost = M.Dense(1, desiredOutPut[0].Length);
                Console.WriteLine($"Epoch=[ {j + 1} / {_epoch} ]");
                for (int i = 0; i < input.Length; i++)
                {
                    Train(input[i], desiredOutPut[i]);
                }
                Console.WriteLine($"Lost= {_totalLost}");
            }

            return null;
        }


        public double[] Predict(double[] x)
        {
            var input = M.Dense(x.Length, 1, x);
            var guess = FeedFordward(input);

            return guess.ToColumnArrays()[0];
        }

        public void Print()
        {
        }

        public void Randomize(double[][] X, double[][] Y)
        {
            Random rand = new Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < X.Length - 1; i++)
            {
                int j = rand.Next(i, X.Length);
                double[] tempx = X[i];
                double[] tempy = Y[i];
                X[i] = X[j];
                X[j] = tempx;
                Y[i] = Y[j];
                Y[j] = tempy;
            }
        }


        //public void Save(string path)
        //{
        //    var model = new NeuralNetworkModel
        //    {
        //        Weigths = _weigths,
        //        Layers = _layers,
        //        Bias = _bias,
        //        UseBias = _useBias
        //    };

        //    // Persist to file
        //    FileStream stream = File.Create(path);
        //    var formatter = new BinaryFormatter();
        //    Console.WriteLine("Serializing");
        //    formatter.Serialize(stream, model);
        //    stream.Close();
        //}

        //public void Load(string path)
        //{
        //    var lines = File.ReadAllLines(path);
        //    var json = string.Join("", lines);

        //    // Restore from file
        //    var stream = File.OpenRead(path);
        //    Console.WriteLine("Deserializing vector");
        //    var formatter = new BinaryFormatter();
        //    var model = (NeuralNetworkModel)formatter.Deserialize(stream);
        //    stream.Close();

        //    _weigths = model.Weigths;
        //    _bias = model.Bias;
        //    _layers = model.Layers;
        //}
    }
}
