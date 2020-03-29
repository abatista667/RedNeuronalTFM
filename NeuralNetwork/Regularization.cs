using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public static class Regularization
    {
        private static MatrixBuilder<double> M = Matrix<double>.Build;
        public static Matrix<double> CalcL1(double C, Matrix<double> W)
        {
            var result = M.Dense(W.RowCount, 1);
            for (int i = 0; i < W.RowCount; i++)
            {
                double sum =0d;
                for (int j = 0; j < W.ColumnCount; j++)
                {
                    sum += Math.Pow(W[i, j], 2);
                }

                result[i, 0] = C * sum;
            }
            return result;
        }

        public static Matrix<double> CalcL2(double C, Matrix<double> W)
        {
            var result = M.Dense(W.RowCount, 1);
            for (int i = 0; i < W.RowCount; i++)
            {
                double sum = 0d;
                for (int j = 0; j < W.ColumnCount; j++)
                {
                    sum += Math.Abs(W[i, j]);
                }

                result[i, 0] = C * sum;
            }
            return result;
        }
    }

    public enum REGULARIZATION
    {
        NONE,
        L1,
        L2
    }
}
