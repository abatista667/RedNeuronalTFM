using System;

namespace NeuralNetwork
{
    [Serializable]
    public class Layer
    {
        public Layer(int nodes, ACTIVATION activation = ACTIVATION.NONE)
        {
            Nodes = nodes;
            Activation = activation;
        }
        public int Nodes { get; set; }
        public ACTIVATION Activation { get; set; }
    }
}
