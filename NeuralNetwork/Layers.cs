using System;

namespace NeuralNetwork
{
    [Serializable]
    public class Layer
    {
        public Layer(int nodes, string activation = "None")
        {
            Nodes = nodes;
            Activation = activation;
        }
        public int Nodes { get; set; }
        public string Activation { get; set; }
    }
}
