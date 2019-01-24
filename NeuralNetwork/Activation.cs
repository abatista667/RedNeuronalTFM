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
            return 0;
        }

        private static double Sigmoid(double x)
        {
            return 2 / (1 + Math.Exp(-2 * x)) - 1;
        }

        private static double Dsigmoid(double x)
        {
            return 1 - (Math.Pow(x, 2));
        }


        public static Func<double, double> GetActivationByName(string name = "None")
        {
            Func<double, double> function;
            switch (name)
            {
                case "Relu":
                    function = Relu;
                    break;
                case "None":
                    function = None;
                    break;
                case "Step":
                    function = Step;
                    break;
                case "Sigmoid":
                    function = Sigmoid;
                    break;
                default:
                    throw new Exception("La funcion de activacion no existe");
            }

            return function;
        }

        public static Func<double, double> GetActivationDerivativeByName(string name = "None")
        {
            Func<double, double> function;
            switch (name)
            {
                case "Relu":
                    function = Drelu;
                    break;
                case "None":
                    function = Dstep;
                    break;
                case "Step":
                    function = Dstep;
                    break;
                case "Sigmoid":
                    function = Dsigmoid;
                    break;
                default:
                    throw new Exception("La funcion de activacion no existe");
            }

            return function;
        }
    }
}
