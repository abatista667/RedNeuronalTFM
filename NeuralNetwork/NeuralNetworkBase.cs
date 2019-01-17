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

        List<Matrix<double>> _layersWeigths;

        List<Layer> _layers;

        double _learningRate;

        int _epoch;

        Matrix<double> _totalLost;


        //inicializar los valores de la red neuronal
        public NeuralNetworkBase(List<Layer> layers, double learningRate = 0.001, int epoch = 100)
        {
            var M = Matrix<double>.Build;

            _layers = layers;

            _learningRate = learningRate;
            _epoch = epoch;

            //la primera capa es la de entrada, 
            //la cantidad de nodos corresponde a la cantidad de inputs
            _inputs = M.Dense(layers.First().Nodes, 1);

            _layersWeigths = new List<Matrix<double>>();
            for (int i = 0; i < layers.Count; i++)
            {

                if (i == 0)
                {
                    continue;
                    //la capa de entrada no tiene pesos W
                }

                var l = layers[i];
                var andL = layers[i - 1];

                var weights = M.Dense(l.Nodes, andL.Nodes,
                (x, y) =>
                {
                    Random random = new MathNet.Numerics.Random.SystemRandomSource();
                    var sample = random.NextDouble();
                    return sample;
                });
                _layersWeigths.Add(weights);
            }

        }


        /// <summary>
        /// por cada uno de los ejemplos dados ejecutar el ciclo de entrenamiento de la red,
        /// multiplicar los pesos W por los valores de entrada  I
        /// </summary>
        /// <param name="input"></param>
        /// <param name="desiredOutPut"></param>
        private void Train(double[] input, double[] desiredOutPut)
        {
            var M = Matrix<double>.Build;
            _inputs = M.Dense(input.Length, 1, input);

            var outPut = M.DenseOfMatrix(_inputs);
            var desired = M.Dense(desiredOutPut.Length, 1, desiredOutPut);

            //por cada capa de la red neuronal aplicar la suma ponderada
            for (int i = 0; i < _layersWeigths.Count; i++)
            {
                Console.WriteLine("Suma ponderada de la capa: {0}", i + 1);
                Console.WriteLine(_layersWeigths[i]);
                Console.WriteLine(outPut);
                outPut = _layersWeigths[i] * outPut;
                Console.WriteLine(outPut);

                //aplicar la funcion de activacion de la capa a cada uno de los valores del vector
                var outPutActivated = M.DenseOfMatrix(outPut);
                outPut.Map(Activation.GetActivationByName(), outPutActivated);
                outPut = M.DenseOfMatrix(outPutActivated);
                Console.WriteLine("Valores de salida de la capa: {0} despues de la funcion de activacion", i + 1);
                Console.WriteLine(outPut);
            }
            //TODO: calcular funcion de perdida, temporalmente la calculare como la sumatoria de las diferencias entre output y desired
            var lost = desired.Subtract(outPut);
            _totalLost += lost;

            //TODO: optimizar los pesos W usando la funcion de optimizacion
        }

        public NeuralNetworkModel Fit(double[][] input, double[] desiredOutPut)
        {
            var V = Matrix<double>.Build;
            _totalLost = V.Dense(desiredOutPut.Length, 1);
            for (int j = 0; j < _epoch; j++)
            {
                Console.WriteLine($"Epoch: {j}/{_epoch}");
                for (int i = 0; i < input.Length; i++)
                {
                    Train(input[i], desiredOutPut);
                }
                Console.WriteLine($"Perdida total:  {_totalLost}");
            }

            this.Print();

            return new NeuralNetworkModel
            {
                Weigths = _layersWeigths,
            };
        }


        public void Print()
        {
            //Print inputs

            Console.WriteLine(_inputs + " ");

            Console.WriteLine("");

            //print layer weights

            foreach (var item in _layersWeigths)
            {
                Console.Write(item + " ");
            }
        }
    }
}
