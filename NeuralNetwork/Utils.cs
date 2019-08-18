using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public static class Utils
    {
        public static double Sum(double[] unidimensional, bool abs = true)
        {
            double total = 0;
            foreach (var val in unidimensional)
            {
                total += Convert.ToDouble(Math.Abs(val));
            }
            return total;
        }
        public static double Sum(double[][] bidimensional, bool abs = true)
        {
            double total = 0;

            foreach (var row in bidimensional)
            {
                total += Sum(row, abs);
            }

            return total;
        }


        public static double Mean(double[][] bidimensional, bool abs = true)
        {
            double total = Sum(bidimensional);
            return total / (double)bidimensional.Length;
        }
    }
}
