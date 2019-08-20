using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralNetwork
    {
        Matrix<double> _inputs; //vector de entrada X

        List<Matrix<double>> _weigths; //list de matrices de pesos Wn

        List<Matrix<double>> _bias;    //bias

        List<Layer> _layers; //lista de capas

        List<Matrix<double>> _layerOutput; //lista de matrices de los valores de salida de cada capa

        Dictionary<int, Matrix<double>> _momentuns = new Dictionary<int, Matrix<double>>(); //
        Dictionary<int, Matrix<double>> _2momentuns = new Dictionary<int, Matrix<double>>(); //

        double _learningRate; //tasa de aprendisaje

        int _epoch;          //epoch

        Matrix<double> _totalLost; //perdida total

        Func<Matrix<double>, Matrix<double>, Matrix<double>> _lostFunction; //variable que almacena la funcion de perdida
        readonly MatrixBuilder<double> M = Matrix<double>.Build;
        bool _useBias;  //cuando sea falso omitira sumar la matriz de bias 
        int _batchSize; //tamaño de batches
        bool _shufle = true; //cuando sea falso no se reorganizaran los valores de X y Y por cada epoch

        OPTIMIZER _optimizer; //indica cual es el optimizador usado

        double _beta1, _beta2, _epsilon; //valores usado por la funcion de optimizacion ADAM

        private static Random rng = new Random(); //permite crear numeros random diferentes entre cada llamada
        private string _features;
        private string _hiddenNodes;
        private string _labels;

        public double LearningRate { set { _learningRate = value; } }
        public int BatchSize { set { _batchSize = value; } }
        public int Epoch { set { _epoch = value; } }

        public OPTIMIZER Optimizer { set { _optimizer = value; } }

        public LOSS SetLoss { set { _lostFunction = Loss.GetLostFunction(value); } }

        public string Features { get => _features; set => _features = value; }
        public string HiddenNodes { get => _hiddenNodes; set => _hiddenNodes = value; }
        public string Labels { get => _labels; set => _labels = value; }

        //inicializar los valores de la red neuronal
        public NeuralNetwork(List<Layer> layers, double learningRate = 0.001, int epoch = 100,
        LOSS lost = LOSS.MSE, bool useBias = true, int batchSize = 200, OPTIMIZER optimizer = OPTIMIZER.SGD,
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
            _shufle = shufle;
            //la primera capa es la de entrada, 
            //la cantidad de nodos corresponde a la cantidad de inputs
            _inputs = M.Dense(layers.First().Nodes, 1);

            _weigths = new List<Matrix<double>>();
            _bias = new List<Matrix<double>>();
            _layerOutput = new List<Matrix<double>>();
            _lostFunction = Loss.GetLostFunction(lost);

            //por cada capa
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

                //inicializa la matrices con nueros random
                var weights = M.Dense(l.Nodes, andL.Nodes,
                (x, y) =>
                {
                    return MathNet.Numerics.Distributions.ContinuousUniform.Sample(-1, 1);
                });
                _weigths.Add(weights);

                //inicializar las matrices bias
                var bias = M.Dense(l.Nodes, 1,
                            (x, y) =>
                            {
                                //Random random = new MathNet.Numerics.Random.SystemRandomSource();
                                //var sample = random.NextDouble();
                                //return sample;
                                return MathNet.Numerics.Distributions.ContinuousUniform.Sample(-1, 1);
                            });
                _bias.Add(bias);
            }

        }

        /// <summary>
        /// inicializa la red neuronal sin parametros, esto para cargar parametros desde un archivo en disco
        /// </summary>
        public NeuralNetwork(double beta1 = 0.9, double beta2 = 0.999, double epsilon = 1e-8, bool shufle = true)
        {
            _beta1 = beta1;
            _beta2 = beta2;
            _epsilon = epsilon;
            _shufle = shufle;
            _layerOutput = new List<Matrix<double>>();
        }


        /// <summary>
        /// por cada uno de los ejemplos dados ejecutar el ciclo de entrenamiento de la red,
        /// multiplicar los pesos W por los valores de entrada  I
        /// </summary>
        /// <param name="inputArray">lista de valores Xn</param>
        /// <param name="desiredOutPut">lista de valores Yn</param>
        /// <param name="epoch">epoch</param>
        private double Train(double[][] inputArray, double[][] desiredOutPut, int epoch)
        {
            //se deben convertir los array  en matrices
            Matrix<double> outputMatrix = null, desiredMatrix = null;

            //por cada elemneto de la primera dimension del array de entrada
            for (int i = 0; i < inputArray.Length; i++)
            {
                //se inicializa la matriz input con los valores de la segunda dimension del array de entrada
                //aunque es una matriz tiene n cantidad de filas pero 1 sola columna siempre.
                _inputs = M.Dense(inputArray[i].Length, 1, inputArray[i]);

                var input = M.DenseOfMatrix(_inputs);
                var desired = M.Dense(desiredOutPut[i].Length, 1, desiredOutPut[i]);

                //por cada capa de la red aplicar la suma ponderada y aplica la funcion de activacion
                // activacion(W * X + B)
                var output = FeedFordward(input);

                //cuando sea el primer elemento del batch
                if (outputMatrix == null)
                {
                    //inicializar las matrices con este primer elemento
                    outputMatrix = M.DenseOfMatrix(output);
                    desiredMatrix = M.DenseOfMatrix(desired);
                }
                else
                {
                    //de lo contrario agregar como una columna
                    //asi pues se formara una matriz donde cada columna corresponda a
                    //un par de valores X,Y
                    var tmpMatrix = M.Dense(output.RowCount, outputMatrix.ColumnCount + 1);
                    outputMatrix.Append(output, tmpMatrix);
                    outputMatrix = M.DenseOfMatrix(tmpMatrix);

                    desiredMatrix.Append(desired, tmpMatrix);
                    desiredMatrix = M.DenseOfMatrix(tmpMatrix);
                }

            }

            //calcular la perdida del batch
            var batchLoss = _lostFunction(desiredMatrix, outputMatrix);

            _totalLost += batchLoss;

            //optimizar la funcion de perdida
            if (_optimizer == OPTIMIZER.SGD)
                StocasticGradientDecent(batchLoss);
            else
                Adam(batchLoss, epoch);

            //retorna la perdida total del batch
            return batchLoss.RowSums().ToArray().Sum();
        }

        /// <summary>
        /// aplica la formula activacion(W * X + B) en todas las capas
        /// </summary>
        /// <param name="input">vector de entrada X</param>
        /// <returns></returns>
        private Matrix<double> FeedFordward(Matrix<double> input)
        {
            var output = M.DenseOfMatrix(input);
            _layerOutput.Clear();
            //por cada matriz de peso
            for (int i = 0; i < _weigths.Count; i++)
            {
                var newOutput = _weigths[i] * output; //W * X

                if (_useBias) newOutput.Add(_bias[i]); //suma bias

                var outPutActivated = M.DenseOfMatrix(newOutput);
                var activationName = _layers[i + 1].Activation; //optenerel nombre de la funcion de activacion de la capa

                if (activationName == ACTIVATION.SOFTMAX)
                {
                    outPutActivated = Activation.Softmax(newOutput); //la funcion softmax es vectorial recibe una matriz completa
                }
                else
                {
                    //el resto de funciones de activacion se aplica a cada elemento por separado
                    var function = Activation.GetActivationByName(activationName);
                    newOutput.Map(function, outPutActivated);
                }
                output = M.DenseOfMatrix(outPutActivated);
                _layerOutput.Add(M.DenseOfMatrix(output));
                newOutput = output;
            }

            return output; //retorna la prediccion de Y 
        }

        /// <summary>
        /// realiza la retropropagacion usando el algoritmo de gradient decent, sea batch, mini batch o estocastico
        /// </summary>
        /// <param name="error">error de la capa de salida</param>
        private void StocasticGradientDecent(Matrix<double> error)
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
                    throw new LearningRateTooHighException();

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
                delta *= _learningRate;

                _weigths[i] += delta;
                _bias[i] += gradient;

                if (_weigths[i][0, 0].Equals(double.NaN) || double.IsInfinity(_weigths[i][0, 0]))
                    throw new LearningRateTooHighException();
            }
        }

        /// <summary>
        /// realiza la retropropagacion usando el algoritmo de adam, sea batch, mini batch o estocastico
        /// </summary>
        /// <param name="error">error de la capa de salida</param>
        /// <param name="iteration">es el numero de epoch por el cual va el conteo</param>
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
                    throw new LearningRateTooHighException();

                //multiplicar la pendiente de los valores de salida de la capa por el error
                Matrix<double> gradient = null;

                gradient = outputDerivated.PointwiseMultiply(e);

                var inputT = _inputs.Transpose();

                if (i > 0)//no es el ultimo elemento
                {
                    inputT = _layerOutput[i - 1].Transpose();

                }

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

                _weigths[i] += _learningRate * newDelta;
                _bias[i] += gradient;

                if (_weigths[i][0, 0].Equals(double.NaN) || double.IsInfinity(_weigths[i][0, 0]))
                    throw new LearningRateTooHighException();
            }
        }

        public NeuralNetworkModel Fit(double[][] input, double[][] desiredOutPut,
                            BackgroundWorker worker = null)
        {
            //todo: verificar que el tamaño del vector X se corresponde con el tamaño de la capa de entrada
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

                if (_shufle)
                    ReorderList(batchOrder);
                _totalLost = M.Dense(desiredOutPut[0].Length, 1);
                //Console.WriteLine($"Epoch=[ {j + 1} / {_epoch} ]");
                foreach (var i in batchOrder)
                {
                    var e = Train(inputBatches[i], Labels[i], j);
                    tmpE.Add(e);
                }
                errors.Add(Math.Abs(tmpE.Sum()));

                if (worker != null)
                {
                    worker.ReportProgress(Convert.ToInt32(Convert.ToDouble(j) /_epoch *100),
                        new ReportProgressModel {
                            epoch = j,
                            loss = tmpE.Sum()
                        }
                        );
                }

                if(worker.CancellationPending)
                   break;
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

        //funcion que reordena el orden del numero de batch
        //para esto se crea una lista con los indices.
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

        /// <summary>
        /// funcion que crea la lista de indices de los batches
        /// </summary>
        /// <param name="batches">numero de batches</param>
        /// <returns></returns>
        private List<int> GenerateBatchOrder(int batches)
        {
            var list = new List<int>();
            for (int i = 0; i < batches; i++)
            {
                list.Add(i);
            }
            return list;
        }

        /// <summary>
        /// predice el valor de Y dado el valor de X
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double[] Predict(double[] x)
        {
            var input = M.Dense(x.Length, 1, x);
            var guess = FeedFordward(input);

            return guess.ToColumnArrays()[0];
        }

        /// <summary>
        /// guarda el modelo para su posterior uso
        /// </summary>
        /// <param name="path">ubicacion</param>
        public void Save(string path)
        {
            var model = new NeuralNetworkModel
            {
                Weigths = _weigths,
                Layers = _layers,
                Bias = _bias,
                UseBias = _useBias,
                Features = Features,
                Labels = Labels,
                HidenNodes = HiddenNodes
            };

            // Persist to file
            FileStream stream = File.Create(path);
            var formatter = new BinaryFormatter();
            Console.WriteLine("Serializing");
            formatter.Serialize(stream, model);
            stream.Close();
        }


        /// <summary>
        /// carga el modelo previamente guardado
        /// </summary>
        /// <param name="path">ubicacion</param>
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
            Features = model.Features;
            HiddenNodes = model.HidenNodes;
            Labels = model.Labels;
        }
        /// <summary>
        /// separa el array de X en multiples batches segun la variable _batchSize
        /// </summary>
        /// <param name="input"></param>
        /// <returns>retorna un array de 3 dimensiones</returns>
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
