using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputLayer = 2;

            var nn = new NeuralNetworkBase(
            new List<Layer>{
                   new Layer(inputLayer),//no tiene pesos
                   new Layer(4),
                   new Layer(1, activation:"Step"),//la ultima capa siempre sera el output
            }, epoch: 10, useBias: false);

            


            double[][] X = new double[4][];
            //System.Random random = new MathNet.Numerics.Random.SystemRandomSource();
            //var sample = random.NextDouble();


            //for (int i = 0; i < X.Length; i++)
            //{
            //    X[i] = new double[inputLayer];
            //    for (int j = 0; j < X[i].Length; j++)
            //    {
            //        X[i][j] = random.NextDouble();

            //    }
            //}

            //anxord operation

            X[0] = new double[2] { 1, 1 };
            X[1] = new double[2] { 1, 0 };
            X[2] = new double[2] { 0, 1 };
            X[3] = new double[2] { 0, 0 };

            double[][] Y = new double[4][];

            Y[0] = new double[1] { 0 };
            Y[1] = new double[1] { 1 };
            Y[2] = new double[1] { 1 };
            Y[3] = new double[1] { 0 };

            nn.Fit(X, Y);
            var filename = @"C:\Users\ariel batista\source\repos\NeuralNetwork\NeuralNetwork\xor.dat";

            //nn.Save(filename);

            Console.WriteLine("the predicted value is:");
            Console.WriteLine(nn.Predict(new double[2] { 1, 1 })[0]);
            Console.WriteLine(nn.Predict(new double[2] { 1, 0 })[0]);
            Console.WriteLine(nn.Predict(new double[2] { 0, 1 })[0]);
            Console.WriteLine(nn.Predict(new double[2] { 0, 0 })[0]);
            Console.Read();
        }
    }
}
