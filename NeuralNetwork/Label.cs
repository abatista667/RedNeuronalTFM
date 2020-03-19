using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    [Serializable]
    public class ModelLabel
    {
        public string Folder { get; set; }
        public string Label { get; set; }
    }
}
