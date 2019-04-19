using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public enum OPTIMIZER
    {
        SGD,
        ADAM
    }

    public class Optimizers
    {
        public static Dictionary<string, OPTIMIZER> ByName { get; set; } = new Dictionary<string, OPTIMIZER>
        {
            {"ADAM", OPTIMIZER.ADAM},
            {"SGD", OPTIMIZER.SGD},
        };
    }
}
