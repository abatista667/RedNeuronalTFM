using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    //implementacion de la funcion de perdida
    public class Loss
    {
    /// <summary>
    /// variable que sirve para instaciar matrices
    /// </summary>
        readonly static MatrixBuilder<double> M = Matrix<double>.Build;

        /// <summary>
        /// funcion de perdida Error cuadratico medio
        /// </summary>
        /// <param name="yhat">valor predicho</param>
        /// <param name="y">valor esperado</param>
        /// <returns></returns>
        private static Matrix<double> MSE(Matrix<double> yhat, Matrix<double> y)
        {
            var sustraction = (yhat - y);
            var powered = sustraction.PointwisePower(2);
            var vsummary = powered.RowSums();
            var summary = M.Dense(vsummary.Count, 1, vsummary.ToArray());
            var mean = summary.Divide(y.ColumnCount);

            return mean.PointwiseMultiply(dLoss(yhat, y));
        }


        /// <summary>
        /// funcion de perdida error logaritmico cuadriatico medio
        /// </summary>
        /// <param name="yhat">valor predicho</param>
        /// <param name="y">valor esperado</param>
        /// <returns></returns>
        private static Matrix<double> MSLE(Matrix<double> yhat, Matrix<double> y)
        {
            var yhat2 = yhat.Add(1).PointwiseLog();
            var y2 = y.Add(1).PointwiseLog();
            var sustraction = (yhat2 - y2);
            var powered = sustraction.PointwisePower(2);
            var vsummary = powered.RowSums();
            var summary = M.Dense(vsummary.Count, 1, vsummary.ToArray());
            var mean = summary.Divide(y.ColumnCount);

            return mean.PointwiseMultiply(dLoss(yhat, y));
        }

        /// <summary>
        /// funcion de perdida error absoluto medio
        /// </summary>
        /// <param name="yhat"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static Matrix<double> MAE(Matrix<double> yhat, Matrix<double> y)
        {
            var sustraction = (yhat - y);
            var abs = sustraction.PointwiseAbs();
            var vsummary = abs.RowSums();
            var summary = M.Dense(vsummary.Count, 1, vsummary.ToArray());
            var mean = summary.Divide(y.ColumnCount);

            return mean.PointwiseMultiply(dLoss(yhat, y));
        }
        /// <summary>
        /// funcion de perdida cross entropia binaria
        /// </summary>
        /// <param name="yhat"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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

        /// <summary>
        /// valor de perdida cross entropia multiclase
        /// </summary>
        /// <param name="y"></param>
        /// <param name="yhat"></param>
        /// <returns></returns>
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

        /// <summary>
        /// funcion que determina el signo de la perdida + o - en cada uno de los nodos
        /// </summary>
        /// <param name="yhat"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static Matrix<double> dLoss(Matrix<double> yhat, Matrix<double> y)
        {
            var val = (yhat.RowSums() - y.RowSums()).Map(v => v < 0 ? -1d : 1);
            return M.Dense(y.RowCount, 1, val.ToArray());
        }

        /// <summary>
        /// devuelve la funcion de activacion dado el nombre
        /// </summary>
        /// <param name="name">enum con el nombre</param>
        /// <returns></returns>
        public static Func<Matrix<double>, Matrix<double>, Matrix<double>> GetLostFunction(LOSS name = LOSS.MSE)
        {
            Func<Matrix<double>, Matrix<double>, Matrix<double>> function;
            switch (name)
            {
                case LOSS.BINARY_CROSS_ENTROPY:
                    function = BinaryCrossEntropy;
                    break;
                case LOSS.CATEGORICAL_CROSS_ENTROPY:
                    function = MultiClassCrossEntropy;
                    break;
                case LOSS.MSE:
                    function = MSE;
                    break;
                case LOSS.MAE:
                    function = MAE;
                    break;
                case LOSS.MSLE:
                    function = MSLE;
                    break;
                default:
                    throw new Exception("Lost Function doesn't exist");
            }

            return function;
        }

    }

    /// <summary>
    /// enum con los nombres de las funciones de perdida
    /// </summary>
    public enum LOSS
    {
        MSE,
        MSLE,
        MAE,
        BINARY_CROSS_ENTROPY,
        CATEGORICAL_CROSS_ENTROPY
    }

    public class Losses
    {
    /// <summary>
    /// diccionario que empareja el nombre en formato string con su valor enum
    /// </summary>
        public static Dictionary<string, LOSS> ByName { get; set; } = new Dictionary<string, LOSS>
        {
            {"MSE", LOSS.MSE},
            {"MSLE", LOSS.MSLE},
            {"MAE", LOSS.MAE},
            {"BinaryCrossEntropy", LOSS.BINARY_CROSS_ENTROPY},
            {"CategoricalCrossEntropy", LOSS.CATEGORICAL_CROSS_ENTROPY},
        };
    }
}
