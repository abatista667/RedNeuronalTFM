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

        private static Matrix<double> MSLE(Matrix<double> yhat, Matrix<double> y)
        {
            var yhat2 = yhat.Add(1).PointwiseLog();
            var y2 = y.Add(1).PointwiseLog();
            var sustraction = (yhat2 - y2);
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
        private static Matrix<double> CrossEntropy(Matrix<double> yhat, Matrix<double> y)
        {
            double notZero = 1e-15;
            Func<double, double> cleanZero = v => v == 0 ? notZero : v;
            var yhatLog = yhat.Map(cleanZero)
                               .PointwiseLog();
            var yminus = 1 - y;
            var yhatminisLog = (1 - yhat).Map(cleanZero)
                                         .PointwiseLog();
            var summary = y.PointwiseMultiply(yhatLog) + yminus.PointwiseMultiply(yhatminisLog);
            var vsummary = M.Dense(summary.RowCount, 1, summary.RowSums().ToArray());
            var mean = vsummary.Divide(y.ColumnCount);
            return mean;
        }

        private static double dMSE(Matrix<double> yhat, Matrix<double> y)
        {
            var val = yhat.ColumnSums().ToArray().Sum() > y.ColumnSums().ToArray().Sum() ? 1 : -1;
            return val;
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
                case LOST.MSLE:
                    function = MSLE;
                    break;
                default:
                    throw new Exception("Lost Function doesn't exist");
            }

            return function;
        }


        public static Func<Matrix<double>, Matrix<double>, double> GetLostDerivationFunction(LOST name = LOST.MSE)
        {
            return dMSE;
        }

    }

    public enum LOST
    {
        MSE,
        MSLE,
        MAE,
        BINARY_CROSS_ENTROPY,
        CATEGORICAL_CROSS_ENTROPY
    }
}
