using MathNet.Numerics.LinearAlgebra;
using System;
using System.Linq;

namespace NeuralNetwork
{
    //implementacion de la funcion de activacion
    public class Lost
    {
        readonly static MatrixBuilder<double> M = Matrix<double>.Build;

        private static Matrix<double> MSE(Matrix<double> yhat, Matrix<double> y)
        {
            var sustraction = (yhat - y);
            var powered = sustraction.PointwisePower(2);
            var vsummary = powered.RowSums();
            var summary = M.Dense(vsummary.Count, 1, vsummary.ToArray());
            var mean = summary.Divide(y.ColumnCount);

            return mean;
        }

        private static Matrix<double> MAE(Matrix<double> yhat, Matrix<double> y)
        {
            return (yhat - y).PointwiseAbs().Divide(y.RowCount);
        }
        private static Matrix<double> CrossEntropy(Matrix<double> arg1, Matrix<double> arg2)
        {
            return arg1;
        }

        private static Matrix<double> Basic(Matrix<double> arg1, Matrix<double> arg2)
        {
            return arg1 - arg2;
        }


        private static double dMSE(Matrix<double> yhat, Matrix<double> y)
        {
            return yhat.ColumnSums().ToArray().Sum() > y.ColumnSums().ToArray().Sum() ? 1 : -1; 
        }

        public static Func<Matrix<double>, Matrix<double>, Matrix<double>> GetLostFunction(LOST name = LOST.MSE)
        {
            Func<Matrix<double>, Matrix<double>, Matrix<double>> function;
            switch (name)
            {
                case LOST.BINARY_CROSS_ENTROPY:
                    function = CrossEntropy;
                    break;
                case LOST.CATEGORICAL_CROSS_ENTROPY:
                    function = CrossEntropy;
                    break;
                case LOST.MSE:
                    function = MSE;
                    break;
                case LOST.MAE:
                    function = MAE;
                    break;
                default:
                    throw new Exception("Lost Function doesn't exist");
            }

            return function;
        }


        public static Func<Matrix<double>, Matrix<double>, double> GetLostDerivationFunction(string name = "None")
        {
            Func<Matrix<double>, Matrix<double>, double> function;
            switch (name)
            {
                case "MSE":
                    function = dMSE;
                    break;
                default:
                    throw new Exception("Lost Function doesn't exist");
            }

            return function;
        }

    }

    enum LOST{
    MSE,
    MAE,
    BINARY_CROSS_ENTROPY,
    CATEGORICAL_CROSS_ENTROPY
    }
}
