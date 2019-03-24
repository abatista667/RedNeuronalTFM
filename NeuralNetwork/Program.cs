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

            var layers = new List<Layer>(){
            new Layer(2),
            new Layer(4, ACTIVATION.RELU),
            new Layer(4, ACTIVATION.SOFTMAX)
            };
            var nn = new NeuralNetworkBase(layers, 0.00001, 1000, LOST.BINARY_CROSS_ENTROPY, false);

            double[][] X = new double[4][];


            //anxord operation

            X[3] = new double[2] { 1, 1 };
            X[2] = new double[2] { 1, 0 };
            X[1] = new double[2] { 0, 1 };
            X[0] = new double[2] { 0, 0 };

            double[][] Y = new double[4][];

            Y[3] = new double[4] { 0, 0, 0, 1 };
            Y[2] = new double[4] { 0, 1, 0, 0 };
            Y[1] = new double[4] { 0, 0, 1, 0 };
            Y[0] = new double[4] { 1, 0, 0, 0 };

            Console.WriteLine("the predicted value before fit is:");
            Console.WriteLine(nn.Predict(new double[2] { 1, 1 }).Max());
            Console.WriteLine(nn.Predict(new double[2] { 1, 0 }).Max());
            Console.WriteLine(nn.Predict(new double[2] { 0, 1 }).Max());
            Console.WriteLine(nn.Predict(new double[2] { 0, 0 }).Max());

            var error = nn.Fit(X, Y).Errors;

            Console.WriteLine("the predicted value after fit is:");
            Console.WriteLine(nn.Predict(new double[2] { 1, 1 }).Max());
            Console.WriteLine(nn.Predict(new double[2] { 1, 0 }).Max());
            Console.WriteLine(nn.Predict(new double[2] { 0, 1 }).Max());
            Console.WriteLine(nn.Predict(new double[2] { 0, 0 }).Max());
            Console.WriteLine(error);
            Console.Read();

            

            var filename = @"C:\Users\ariel batista\source\repos\NeuralNetwork\NeuralNetwork\xor.dat";

            //nn.Save(filename);

            //var nn2 = new NeuralNetworkBase();
            //nn2.Load(filename);

            //Console.WriteLine("the predicted value is:");
            //Console.WriteLine(nn2.Predict(new double[2] { 1, 1 })[0]);
            //Console.WriteLine(nn2.Predict(new double[2] { 1, 0 })[0]);
            //Console.WriteLine(nn2.Predict(new double[2] { 0, 1 })[0]);
            //Console.WriteLine(nn2.Predict(new double[2] { 0, 0 })[0]);
            //Console.Read();
        }
    }
}
