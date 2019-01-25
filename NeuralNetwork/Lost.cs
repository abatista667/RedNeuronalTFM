using MathNet.Numerics.LinearAlgebra;
using System;
using System.Reflection;

namespace NeuralNetwork
{
    //implementacion de la funcion de activacion
    public class Lost
    {
        private static Matrix<double> MSE(Matrix<double> yhat, Matrix<double> y)
        {
            //return (yhat - y).PointwisePower(2).Divide(y.ColumnCount);
            return yhat - y;
        }
        private static Matrix<double> CrossEntropy(Matrix<double> arg1, Matrix<double> arg2)
        {
            return arg1;
        }

        private static Matrix<double> Basic(Matrix<double> arg1, Matrix<double> arg2)
        {
            return arg1 - arg2;
        }


        public static Func<Matrix<double>, Matrix<double>, Matrix<double>> GetLostFunction(string name="None")
        {
            Func<Matrix<double>, Matrix<double>, Matrix<double>> function;
            switch (name)
            {
                case "CrossEntropy":
                    function = CrossEntropy;
                    break;
                case "MSE":
                    function = MSE;
                    break;
                case "Basic":
                    function = Basic;
                    break;
                default:
                    throw new Exception("Lost Function doesn't exist");
            }

            return function;
        }

    }
}
