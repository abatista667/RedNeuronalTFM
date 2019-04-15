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
        private LOST _lost;
        Dictionary<int, Matrix<double>> _momentuns = new Dictionary<int, Matrix<double>>();
        Dictionary<int, Matrix<double>> _2momentuns = new Dictionary<int, Matrix<double>>();

        double _learningRate;

        int _epoch;

        Matrix<double> _totalLost;

        Func<Matrix<double>, Matrix<double>, Matrix<double>> _lostFunction;
        Func<Matrix<double>, Matrix<double>, double> _lostDerivativeFunction;
        readonly MatrixBuilder<double> M = Matrix<double>.Build;
        bool _useBias;
        int _batchSize;

        OPTIMIZER _optimizer;

        double _beta1, _beta2, _epsilon;
        private static Random rng = new Random();

        //inicializar los valores de la red neuronal
        public NeuralNetworkBase(List<Layer> layers, double learningRate = 0.001, int epoch = 100,
        LOST lost = LOST.MSE, bool useBias = true, int batchSize = 200, OPTIMIZER optimizer = OPTIMIZER.SGD,
        double beta1 = 0.9, double beta2 = 0.999, double epsilon = 1e-8, bool shufle = true)
        {
            _layers = layers;
            _batchSize = batchSize;
            _learningRate = learningRate;
            _epoch = epoch;
            _useBias = useBias;
            _optimizer = optimizer;
            _beta1 = beta1;
            _beta2 = beta2;
            _epsilon = epsilon;
            //la primera capa es la de entrada, 
            //la cantidad de nodos corresponde a la cantidad de inputs
            _inputs = M.Dense(layers.First().Nodes, 1);

            _weigths = new List<Matrix<double>>();
            _bias = new List<Matrix<double>>();
            _layerOutput = new List<Matrix<double>>();
            _lost = lost;
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
        private double Train(double[][] inputArray, double[][] desiredOutPut, int epoch)
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

            if (_optimizer == OPTIMIZER.SGD)
                StocasticGradientDecent(batchLoss, lostSlope);
            else
                Adam(batchLoss, lostSlope, epoch);

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
                var activationName = _layers[i + 1].Activation;

                if (activationName == ACTIVATION.SOFTMAX)
                {
                    outPutActivated = Activation.Softmax(newOutput);
                }
                else
                {
                    var function = Activation.GetActivationByName(activationName);
                    newOutput.Map(function, outPutActivated);
                }
                output = M.DenseOfMatrix(outPutActivated);
                _layerOutput.Add(M.DenseOfMatrix(output));
                newOutput = output;
            }

            return output;
        }

        private void StocasticGradientDecent(Matrix<double> error, double lostSlope = 1)
        {
            var e = M.DenseOfMatrix(error);

            for (int i = _layerOutput.Count - 1; i >= 0; i--)
            {
                Matrix<double> outputDerivated = null;
                var activationName = _layers[i + 1].Activation;
                if (activationName == ACTIVATION.SOFTMAX)
                {
                    outputDerivated = M.Dense(_layerOutput[i].RowCount, _layerOutput[i].ColumnCount, 1);
                }
                else
                {
                    var derivative = Activation.GetActivationDerivativeByName(activationName);
                    outputDerivated = _layerOutput[i].Map(derivative);
                }

                if (i < _layerOutput.Count - 1) //no es la capa de salida
                    e = _weigths[i + 1].Transpose() * e;

                if (e[0, 0].Equals(double.NaN) || double.IsInfinity(e[0, 0]))
                    throw new LearingRateTooHighException();

                //multiplicar la pendiente de los valores de salida de la capa por el error
                Matrix<double> gradient = null;

                gradient = outputDerivated.PointwiseMultiply(e);


                var inputT = _inputs.Transpose();

                if (i > 0)//no es el ultimo elemento
                {
                    inputT = _layerOutput[i - 1].Transpose();
                }

                // var lost = Lost.GetLostFunction("MSE");

                var delta = gradient * inputT;
                delta *= _learningRate * lostSlope;

                _weigths[i] += delta;
                _bias[i] += gradient;

                if (_weigths[i][0, 0].Equals(double.NaN) || double.IsInfinity(_weigths[i][0, 0]))
                    throw new LearingRateTooHighException();
            }
        }

        private void Adam(Matrix<double> error, double lostSlope = 1, int iteration = 0)
        {
            var e = M.DenseOfMatrix(error);

            for (int i = _layerOutput.Count - 1; i >= 0; i--)
            {
                Matrix<double> outputDerivated = null;
                var activationName = _layers[i + 1].Activation;
                if (activationName == ACTIVATION.SOFTMAX)
                {
                    outputDerivated = Activation.DSoftmax(_layerOutput[i]);
                }
                else
                {
                    var derivative = Activation.GetActivationDerivativeByName(activationName);
                    outputDerivated = _layerOutput[i].Map(derivative);
                }

                if (i < _layerOutput.Count - 1) //no es la capa de salida
                    e = _weigths[i + 1].Transpose() * e;

                if (e[0, 0].Equals(double.NaN) || double.IsInfinity(e[0, 0]))
                    throw new LearingRateTooHighException();

                //multiplicar la pendiente de los valores de salida de la capa por el error
                Matrix<double> gradient = null;

                gradient = outputDerivated.PointwiseMultiply(e);

                var inputT = _inputs.Transpose();

                if (i > 0)//no es el ultimo elemento
                {
                    inputT = _layerOutput[i - 1].Transpose();

                }

               
                // var lost = Lost.GetLostFunction("MSE
                Matrix<double> m = null;
                Matrix<double> v = null;
                var delta = gradient * inputT;

                if (_momentuns.ContainsKey(i))
                {
                    m = _momentuns[i];
                    v = _2momentuns[i];
                }
                else
                {
                    //add momentun
                    m = M.Dense(delta.RowCount, delta.ColumnCount, 0);
                    v = M.Dense(delta.RowCount, delta.ColumnCount, 0);
                    _momentuns.Add(i, m);
                    _2momentuns.Add(i, v);
                }
                m = _beta1 * m + (1 - _beta1) * delta;
                v = _beta2 * v + (1 - _beta2) * delta.PointwisePower(2);

                var m_hat = m / (1 - Math.Pow(_beta1, iteration + 1));
                var v_hat = v / (1 - Math.Pow(_beta2, iteration + 1));

                _momentuns[i] = m;
                _2momentuns[i] = v;

                var newDelta = m_hat.PointwiseDivide(v_hat.PointwiseSqrt() + _epsilon);

                //            vdw[j] = beta1 * vdw[j] + (1 - beta1) * dw
                //            sdw[j] = beta2 * sdw[j] + (1 - beta2) * pow(dw, 2)
                //            vdw_corrected = vdw[j] / (1 - pow(beta1, epoch + 1))
                //            sdw_corrected = sdw[j] / (1 - pow(beta2, epoch + 1))
                //            w[j] = w[j] + learningRate * (vdw_corrected / (np.sqrt(sdw_corrected) + epsilon))

                _weigths[i] += _learningRate * newDelta;
                _bias[i] += gradient;

                if (_weigths[i][0, 0].Equals(double.NaN) || double.IsInfinity(_weigths[i][0, 0]))
                    throw new LearingRateTooHighException();
            }
        }

        public NeuralNetworkModel Fit(double[][] input, double[][] desiredOutPut)
        {
            //todo: check if input len equals to 1st layer note

            if (input.First().Length != _layers.First().Nodes)
                throw new Exception($"El vector de entrada no concuerda con el " +
                $"numero de nodos de la primera capa, se esperan: {_layers.First().Nodes} nodos");

            var inputBatches = SplitInBatches(input);
            var Labels = SplitInBatches(desiredOutPut);
            var errors = new List<double>();
            var batchOrder = GenerateBatchOrder(inputBatches.Length);

            for (int j = 0; j < _epoch; j++)
            {
                var tmpE = new List<double>();
                ReorderList(batchOrder);
                _totalLost = M.Dense(desiredOutPut[0].Length, 1);
                //Console.WriteLine($"Epoch=[ {j + 1} / {_epoch} ]");
                foreach (var i in batchOrder)
                {
                    var e = Train(inputBatches[i], Labels[i], j);
                    tmpE.Add(e);
                }
                errors.Add(tmpE.Sum());
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

        private void ReorderList(List<int> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private List<int> GenerateBatchOrder(int v)
        {
            var list = new List<int>();
            for (int i = 0; i < v; i++)
            {
                list.Add(i);
            }
            return list;
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

            //Console.WriteLine("");

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
