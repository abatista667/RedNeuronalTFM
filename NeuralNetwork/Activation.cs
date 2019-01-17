using System;
using System.Reflection;

namespace NeuralNetwork
{
    //implementacion de la funcion de activacion
    public class Activation
    {
        private static double Relu(double arg)
        {
            throw new NotImplementedException();
        }
        private static double None(double arg)
        {
            return arg;
        }


        public static Func<double, double> GetActivationByName(string name="None")
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
                default:
                    throw new Exception("La funcion de activacion no existe");
            }

            return function;
        }
    }
}
