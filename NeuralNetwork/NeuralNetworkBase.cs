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
        Func<Matrix<double>, Matrix<double>, double> _lostDerivativeFunction;
        readonly MatrixBuilder<double> M = Matrix<double>.Build;
        bool _useBias;
        int _batchSize;

        //inicializar los valores de la red neuronal
        public NeuralNetworkBase(List<Layer> layers, double learningRate = 0.001, int epoch = 100,
        string lost = "MSE", bool useBias = true, int batchSize = 200)
        {
            _layers = layers;
            _batchSize = batchSize;
            _learningRate = learningRate;
            _epoch = epoch;
            _useBias = useBias;
            //la primera capa es la de entrada, 
            //la cantidad de nodos corresponde a la cantidad de inputs
            _inputs = M.Dense(layers.First().Nodes, 1);

            _weigths = new List<Matrix<double>>();
            _bias = new List<Matrix<double>>();
            _layerOutput = new List<Matrix<double>>();
            _lostFunction = Lost.GetLostFunction(lost);
            _lostDerivativeFunction = Lost.GetLostDerivationFunction(lost);
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
                    return MathNet.Numerics.Distributions.ContinuousUniform.Sample(0.00001, 1);
                });
                _weigths.Add(weights);

                //inicializar las matrices bias


                var bias = M.Dense(l.Nodes, 1,
                            (x, y) =>
                            {
                                //Random random = new MathNet.Numerics.Random.SystemRandomSource();
                                //var sample = random.NextDouble();
                                //return sample;
                                return MathNet.Numerics.Distributions.ContinuousUniform.Sample(0.00001, 1);
                            });
                _bias.Add(bias);
            }

        }

        public NeuralNetworkBase()
        {
            _layerOutput = new List<Matrix<double>>();
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

            if (networkLost[0, 0].Equals(double.NaN) || double.IsInfinity(networkLost[0, 0]))
                throw new LearingRateTooHighException();

            _totalLost += networkLost;
            BackPropagation(networkLost);
        }

        //use batches to train the model
        private double Train(double[][] inputArray, double[][] desiredOutPut)
        {
            Matrix<double> outputMatrix = null, desiredMatrix = null;

            for (int i = 0; i < inputArray.Length; i++)
            {
                _inputs = M.Dense(inputArray[i].Length, 1, inputArray[i]);

                var input = M.DenseOfMatrix(_inputs);
                var desired = M.Dense(desiredOutPut[i].Length, 1, desiredOutPut[i]);

                //por cada capa de la red aplicar la suma ponderada
                var output = FeedFordward(input);

                if (outputMatrix == null)
                {
                    outputMatrix = M.DenseOfMatrix(output);
                    desiredMatrix = M.DenseOfMatrix(desired);
                }
                else
                {
                    var tmpMatrix = M.Dense(output.RowCount, outputMatrix.ColumnCount + 1);
                    outputMatrix.Append(output, tmpMatrix);
                    outputMatrix = M.DenseOfMatrix(tmpMatrix);

                    desiredMatrix.Append(desired, tmpMatrix);
                    desiredMatrix = M.DenseOfMatrix(tmpMatrix);
                }

            }

            //var networkLost = desired.Subtract(output);
            var batchLoss = _lostFunction(desiredMatrix, outputMatrix);
            var lostSlope = _lostDerivativeFunction(desiredMatrix, outputMatrix);

            _totalLost += batchLoss;
            BackPropagation(batchLoss, lostSlope);

            return batchLoss.RowSums().ToArray().Sum();
        }

        private Matrix<double> FeedFordward(Matrix<double> input)
        {
            var output = M.DenseOfMatrix(input);
            _layerOutput.Clear();
            for (int i = 0; i < _weigths.Count; i++)
            {
                var newOutput = _weigths[i] * output;

                if (_useBias) newOutput.Add(_bias[i]);
                //aplicar la funcion de activacion de la capa a cada uno de los valores del vector

                var outPutActivated = M.DenseOfMatrix(newOutput);
                var function = Activation.GetActivationByName(_layers[i + 1].Activation);
                newOutput.Map(function, outPutActivated);
                output = M.DenseOfMatrix(outPutActivated);
                _layerOutput.Add(M.DenseOfMatrix(output));
                newOutput = output;
            }

            return output;
        }

        private void BackPropagation(Matrix<double> error, double lostSlope = 1)
        {
            var e = M.DenseOfMatrix(error);

            for (int i = _layerOutput.Count - 1; i >= 0; i--)
            {
                var derivative = Activation.GetActivationDerivativeByName(_layers[i + 1].Activation);
                var outputDerivated = _layerOutput[i].Map(derivative);

                if (i < _layerOutput.Count - 1) //no es la capa de salida
                    e = _weigths[i + 1].Transpose() * e;

                if (e[0, 0].Equals(double.NaN) || double.IsInfinity(e[0, 0]))
                    throw new LearingRateTooHighException();

                //multiplicar la pendiente de los valores de salida de la capa por el error
                var gradient = outputDerivated.PointwiseMultiply(e);

                var inputT = _inputs.Transpose();

                if (i > 0)//no es el ultimo elemento
                {
                    inputT = _layerOutput[i - 1].Transpose();
                }

               // var lost = Lost.GetLostFunction("MSE");

                var delta = gradient * inputT;
                delta *= _learningRate * lostSlope;

                if(lostSlope == -1)
                Console.WriteLine("");

                _weigths[i] += delta;
                _bias[i] += gradient;

                if (_weigths[i][0, 0].Equals(double.NaN) || double.IsInfinity(_weigths[i][0, 0]))
                    throw new LearingRateTooHighException();
            }
        }

        public NeuralNetworkModel Fit(double[][] input, double[][] desiredOutPut)
        {
            //todo: check if input len equals to 1st layer note

            if(input.First().Length != _layers.First().Nodes)
                throw new Exception($"El vector de entrada no concuerda con el " +
                $"numero de nodos de la primera capa, se esperan: {_layers.First().Nodes} nodos");

            var inputBatches = SplitInBatches(input);
            var Labels = SplitInBatches(desiredOutPut);
            var errors = new List<double>();

            for (int j = 0; j < _epoch; j++)
            {
                _totalLost = M.Dense(desiredOutPut[0].Length, 1);
                Console.WriteLine($"Epoch=[ {j + 1} / {_epoch} ]");
                for (int i = 0; i < inputBatches.Length; i++)
                {
                   var e = Train(inputBatches[i], Labels[i]);
                   errors.Add(e);
                }
                Console.WriteLine($"Lost= {_totalLost}");
            }


            return new NeuralNetworkModel
            {
                Weigths = _weigths,
                Layers = _layers,
                Bias = _bias,
                UseBias = _useBias,
                Errors = errors
            };
        }


        public double[] Predict(double[] x)
        {
            var input = M.Dense(x.Length, 1, x);
            var guess = FeedFordward(input);

            return guess.ToColumnArrays()[0];
        }

        public void Print()
        {
            //Print inputs

            //Console.WriteLine(_inputs + " ");

            Console.WriteLine("");

            //print layer weights

            foreach (var item in _weigths)
            {
                Console.WriteLine(item);
            }
        }


        public void Save(string path)
        {
            var model = new NeuralNetworkModel
            {
                Weigths = _weigths,
                Layers = _layers,
                Bias = _bias,
                UseBias = _useBias
            };

            // Persist to file
            FileStream stream = File.Create(path);
            var formatter = new BinaryFormatter();
            Console.WriteLine("Serializing");
            formatter.Serialize(stream, model);
            stream.Close();
        }

        public void Load(string path)
        {
            var lines = File.ReadAllLines(path);
            var json = string.Join("", lines);

            // Restore from file
            var stream = File.OpenRead(path);
            Console.WriteLine("Deserializing vector");
            var formatter = new BinaryFormatter();
            var model = (NeuralNetworkModel)formatter.Deserialize(stream);
            stream.Close();

            _weigths = model.Weigths;
            _bias = model.Bias;
            _layers = model.Layers;
        }

        private double[][][] SplitInBatches(double[][] input)
        {
            int batchesCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(input.Length) / _batchSize));
            double[][][] inputBatches = new double[batchesCount][][];

            int batchIndex = 0;
            for (int i = 0; i < input.Length; i += _batchSize)
            {
                if (batchIndex < batchesCount - 1)
                {
                    inputBatches[batchIndex] = new double[_batchSize][];
                    Array.Copy(input, i, inputBatches[batchIndex], 0, _batchSize);
                }
                else
                {
                    inputBatches[batchIndex] = new double[input.Length - i][];
                    Array.Copy(input, i, inputBatches[batchIndex], 0, inputBatches[batchIndex].Length);
                }
                batchIndex++;
            }

            return inputBatches;
        }
    }
}
