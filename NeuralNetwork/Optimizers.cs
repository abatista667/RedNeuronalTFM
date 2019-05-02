using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
/// <summary>
/// enum con los diferentes optimmizadores de la red
/// </summary>
    public enum OPTIMIZER
    {
        SGD,
        ADAM
    }

    public class Optimizers
    {
    /// <summary>
    /// diccionario con nombre de los optimizadores emparejados con su enum
    /// </summary>
        public static Dictionary<string, OPTIMIZER> ByName { get; set; } = new Dictionary<string, OPTIMIZER>
        {
            {"ADAM", OPTIMIZER.ADAM},
            {"SGD", OPTIMIZER.SGD},
        };
    }
}
