using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
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

            return mean.PointwiseMultiply(dLoss(yhat, y));
        }

        private static Matrix<double> SE(Matrix<double> yhat, Matrix<double> y)
        {
            var sustraction = (yhat - y);
            var powered = sustraction.PointwisePower(2);
            var vsummary = powered.RowSums();
            var summary = M.Dense(vsummary.Count, 1, vsummary.ToArray());
            return summary;
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
        private static Matrix<double> BinaryCrossEntropy(Matrix<double> yhat, Matrix<double> y)
        {
            double notZero = 1e-15;
            Func<double, double> cleanZero = v => v == 0 ? notZero : v;
            var yhatLog = yhat.Map(cleanZero)
                               .PointwiseLog();
            var yminus = 1 - y;
            var yhatminisLog = (1 - yhat).Map(cleanZero)
                                         .PointwiseLog();
            var summary = y.Map(x => -x).PointwiseMultiply(yhatLog) - yminus.PointwiseMultiply(yhatminisLog);
            var vsummary = M.Dense(summary.RowCount, 1, summary.RowSums().ToArray());
            var mean = vsummary.Divide(y.ColumnCount);
            return mean.PointwiseMultiply(dLoss(yhat, y));
        }

        //private static Matrix<double> MultiClassCrossEntropy(Matrix<double> y, Matrix<double> yhat)
        //{
        //    double notZero = 1e-15;
        //    Func<double, double> cleanZero = v => v == 0 ? notZero : v;
        //    var yhatLog = yhat.Map(cleanZero)
        //                       .PointwiseLog();
        //    var summary = y.PointwiseMultiply(yhatLog).Map(x => -x);
        //    var vsummary = M.Dense(summary.RowCount, 1, summary.RowSums().ToArray());
        //    var mean = vsummary.Divide(y.ColumnCount);
        //    mean = mean.Map(x => mean.RowSums().Sum());
        //    var d = dSE(y, yhat);
        //    return mean *d;
        //}

        private static Matrix<double> MultiClassCrossEntropy(Matrix<double> y, Matrix<double> yhat)
        {
            double notZero = 1e-15;
            Func<double, double> cleanZero = v => v == 0 ? notZero : v;

            Matrix<double> summary = M.Dense(y.RowCount, y.ColumnCount);

            Func<double, double, double> map2 = (v, vy) =>
            {
                if (vy == 1)
                    return -Math.Log(v, 2);
                else
                    return -Math.Log(1 - v, 2);
            };

            yhat.Map2(map2, y, summary);

            var vsummary = M.Dense(summary.RowCount, 1, summary.RowSums().ToArray());
            var mean = vsummary.Divide(y.ColumnCount);
            var d = dLoss(y, yhat);
            return mean.PointwiseMultiply(d);
        }

        private static Matrix<double> dLoss(Matrix<double> yhat, Matrix<double> y)
        {
            var val = (yhat.RowSums() - y.RowSums()).Map(v => v < 0 ? -1d : 1);
            return M.Dense(y.RowCount, 1, val.ToArray());
        }

        public static double dSE(Matrix<double> yhat, Matrix<double> y)
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
                    function = BinaryCrossEntropy;
                    break;
                case LOST.CATEGORICAL_CROSS_ENTROPY:
                    function = MultiClassCrossEntropy;
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

    }

    public enum LOST
    {
        MSE,
        MSLE,
        MAE,
        BINARY_CROSS_ENTROPY,
        CATEGORICAL_CROSS_ENTROPY
    }

    public class Losses
    {
        public static Dictionary<string, LOST> ByName { get; set; } = new Dictionary<string, LOST>
        {
            {"MSE", LOST.MSE},
            {"MSLE", LOST.MSLE},
            {"Binary Cross Entropy", LOST.BINARY_CROSS_ENTROPY},
            {"Categorical Cross Entropy", LOST.CATEGORICAL_CROSS_ENTROPY},
        };
    }
}
