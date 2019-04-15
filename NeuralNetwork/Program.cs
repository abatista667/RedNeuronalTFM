using MathNet.Numerics.LinearAlgebra;
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
            Matrix<double> output, desired;
            MatrixBuilder<double> M = Matrix<double>.Build;

            output = M.Dense(3,1, new double[]{0.2, 0.3, 0.5});
            desired = M.Dense(3, 1, new double[] { 0, 1, 0 });

            var loss = Lost.GetLostFunction(LOST.CATEGORICAL_CROSS_ENTROPY)(desired, output);
            Console.WriteLine(loss);
            //var dloss = Lost.dSE(desired, output);
            Console.Read();
        }
    }
}
