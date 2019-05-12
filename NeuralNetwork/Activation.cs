using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace NeuralNetwork
{
    //implementacion de la funcion de activacion
    public class Activation
    {
        /// <summary>
        /// funcion de activacion relu
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static double Relu(double x)
        {
            return x < 0 ? 0 : x;
        }
        /// <summary>
        /// derivada de la funcion de activacion relu, commo no tiene el valor siempre sera 1, asi no se altera
        /// la multiplicacion en el calculo del gradiente
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static double Drelu(double x)
        {
            return 1;
        }
        /// <summary>
        /// sin funcion de activacion
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static double None(double x)
        {
            return x;
        }
        /// <summary>
        /// funcion de activacion step o umbral
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private static double Step(double arg)
        {
            return arg <= 0 ? 0 : 1;
        }

        /// <summary>
        /// la funcon step tampoco tiene derivada
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private static double Dstep(double arg)
        {
            return 1;
        }

        /// <summary>
        /// funcion de activacion sigmoide
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }

        /// <summary>
        /// derivada de la funcion sigmoide
        /// </summary>
        /// <param name="dx"> valor entre 0 y 1</param>
        /// <returns></returns>
        private static double Dsigmoid(double dx)
        {
            var val = dx * (1 - dx);

            if (val == 0) return 1;

            return val;
        }
        /// <summary>
        /// funcion de activacion tanh
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static double TanH(double x)
        {
            var e = Math.E;
            var numerator = Math.Pow(e, x) - Math.Pow(e, -x);
            var denominator = Math.Pow(e, x) + Math.Pow(e, -x);
            var tanh = numerator / denominator;

            return Math.Tanh(x);
        }

        /// <summary>
        /// derivada de la tanh
        /// </summary>
        /// <param name="dx"></param>
        /// <returns></returns>
        private static double dTanH(double dx)
        {

            return 1 - Math.Pow(dx, 2);
        }

        /// <summary>
        /// funcion de activacion softmax
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        internal static Matrix<double> Softmax(Matrix<double> output)
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

        /// <summary>
        /// derivada de la funcion softmax
        /// </summary>
        /// <param name="activated"></param>
        /// <returns></returns>
        internal static Matrix<double> DSoftmax(Matrix<double> activated)
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
                        output[i, j] = Si * (1 - Sj);
                    else
                        output[i, j] = -Sj * Si;
                }
            }

            var o = builder.Dense(output.ColumnCount, 1, output.RowSums().AsArray());


            return o;
        }

        /// <summary>
        /// retorna una funcion de activacion dado el nombre
        /// </summary>
        /// <param name="name">enum con el nombre de la funcion</param>
        /// <returns>funcion de activacion</returns>
        internal static Func<double, double> GetActivationByName(ACTIVATION name = ACTIVATION.NONE)
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
        /// <summary>
        /// retorna la derivada de la funcion de activacion dado el nombre
        /// </summary>
        /// <param name="name">enum con el nombre de la funcion</param>
        /// <returns>derivada de la funcion de activacion</returns>
        internal static Func<double, double> GetActivationDerivativeByName(ACTIVATION name = ACTIVATION.NONE)
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

        /// <summary>
        /// diccionario con el nombre de la funcion en string emparejado con su valor enum
        /// </summary>
        public static Dictionary<string, ACTIVATION> ByName { get; set; } = new Dictionary<string, ACTIVATION>
        {
            {"", ACTIVATION.NONE},
            {"Ninguno", ACTIVATION.NONE},
            {"Relu", ACTIVATION.RELU},
            {"Sigmoide", ACTIVATION.SIGMOID},
            {"Softmax", ACTIVATION.SOFTMAX},
            {"Tanh", ACTIVATION.TANH},
        };
    }

    //enum de las funciones de acivacion
    public enum ACTIVATION
    {
        SIGMOID,
        RELU,
        TANH,
        SOFTMAX,
        NONE
    }
}
