using MathNet.Numerics.LinearAlgebra;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Test
{
    [TestFixture]
    public class LostTest
    {
        [Test]
        public void MSETest()
        {
            var func = Lost.GetLostFunction("MSE");
            MatrixBuilder<double> M = Matrix<double>.Build;

            var y = M.Dense(1, 2, new double[2] { 1, 0 });
            var yHat = M.Dense(1, 2, new double[2] { -1, 0 });

            var res = func(y, yHat);
        }
    }
}
