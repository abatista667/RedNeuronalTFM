using System;

namespace NeuralNetwork
{
    public class Layer
    {
        public Layer(int nodes)
        {
            Nodes = nodes;
        }
        public int Nodes { get; set; }
        public string Activation { get; set; } ="None";
    }
}
