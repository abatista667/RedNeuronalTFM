using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;
using System;
using System.Reflection;

namespace NeuralNetwork
{
    //implementacion de la funcion de activacion
    public class Activation
    {
        private static double Relu(double x)
        {
            return x < 0 ? 0 : x;
        }
        private static double Drelu(double x)
        {
            return x < 0 ? 0 : 1;
        }
        private static double None(double arg)
        {
            return arg;
        }

        private static double Step(double arg)
        {
            return arg <= 0 ? 0 : 1;
        }

        private static double Dstep(double arg)
        {
            return 1;
        }

        private static double Sigmoid(double x)
        {
            // return 2 / (1 + Math.Exp(-2 * x)) - 1;
            return  1 / (1 + Math.Pow(Math.E, -x));
        }

        private static double Dsigmoid(double x)
        {
            //var val = 1 - (Math.Pow(x, 2));

            var val = x * (1 - x);

            if(val == 0) return 1;

            return val;
        }

        private static double TanH(double x)
        {
            var e = Math.E;
            var numerator = Math.Pow(e, x) - Math.Pow(e, -x);
            var denominator = Math.Pow(e, x) + Math.Pow(e, -x);
            var tanh = numerator / denominator;

            return Math.Tanh(x);
        }

        private static double dTanH(double dx)
        {

            return 1 - Math.Pow(dx, 2);
        }

        public static Matrix<double> Softmax(Matrix<double> output)
        {
            var zout = output.Map(x =>
            {
                return Math.Exp(x - output.Enumerate(Zeros.AllowSkip).Maximum());
            });

            var summary = zout.ColumnSums().Sum();

            var softmax = zout.Map(e =>
            {
                return e / summary;
            });

            return softmax;
        }

        public static Matrix<double> DSoftmax(Matrix<double> activated)
        {
            var builder = Matrix<double>.Build;
            int rc = activated.RowCount;
            var output = builder.Dense(rc, rc);
            for (int i = 0; i < rc; i++)
            {
                for (int j = 0; j < rc; j++)
                {
                    var Si = activated[i, 0];
                    var Sj = activated[j, 0];
                    if (i == j)
                        output[i, j] = Si *(1 - Sj);
                    else
                        output[i, j] = -Sj * Si;
                }
            }

            var o = builder.Dense(output.ColumnCount,1, output.RowSums().AsArray());


            return o;
        }


        public static Func<double, double> GetActivationByName(ACTIVATION name = ACTIVATION.NONE)
        {
            Func<double, double> function;
            switch (name)
            {
                case ACTIVATION.RELU:
                    function = Relu;
                    break;
                case ACTIVATION.NONE:
                    function = None;
                    break;
                case ACTIVATION.SIGMOID:
                    function = Sigmoid;
                    break;
                case ACTIVATION.TANH:
                    function = TanH;
                    break;
                default:
                    throw new Exception("La funcion de activacion no existe");
            }

            return function;
        }

        public static Func<double, double> GetActivationDerivativeByName(ACTIVATION name = ACTIVATION.NONE)
        {
            Func<double, double> function;
            switch (name)
            {
                case ACTIVATION.RELU:
                    function = Drelu;
                    break;
                case ACTIVATION.NONE:
                    function = Dstep;
                    break;
                case ACTIVATION.SIGMOID:
                    function = Dsigmoid;
                    break;
                case ACTIVATION.TANH:
                    function = dTanH;
                    break;
                case ACTIVATION.SOFTMAX:
                    function = Dstep;
                    break;
                default:
                    throw new Exception("La funcion de activacion no existe");
            }

            return function;
        }
    }

    public enum ACTIVATION
    {
        SIGMOID,
        RELU,
        TANH,
        SOFTMAX,
        NONE
    }
}
