using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Test
{
    [TestFixture]
    public class RegressionTest
    {
        [Test]
        public void AdvertisingDataSetTest()
        {

            string path = @"C:\Users\ariel batista\Documents\dataset\Advertising.csv";
            List<double> X, Y;
            var lines = File.ReadAllLines(path);
            X = new List<double>();
            Y = new List<double>();
            var Ypre = new List<double>();
            foreach (var line in lines.Skip(1))//skipt the header
            {
                var fields = line.Split(',');
                X.Add(double.Parse(fields[0]));
                Y.Add(double.Parse(fields[3]));
            }

            var layers = new List<Layer>(){
            new Layer(1),
            new Layer(2),
            new Layer(2),
            new Layer(5)
            };
            var nn = new NeuralNetworkBase(layers, 0.0000000000001, 50, "MSE", false);

            var xArr = arrayToMatrixArray(X.ToArray());
            nn.Fit(xArr, arrayToMatrixArray(Y.ToArray()));

            foreach (var x in xArr)
            {
                Ypre.Add(nn.Predict(x)[0]);
            }
        }

        double[][] arrayToMatrixArray(double[] original)
        {
            double[][] arr = new double[original.Length][];
            for (int i = 0; i < original.Length; ++i)
            {
                arr[i] = new double[1] { original[i] };
            }

            return arr;
        }
    }
}
