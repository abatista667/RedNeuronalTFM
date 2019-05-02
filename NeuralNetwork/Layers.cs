using System;

namespace NeuralNetwork
{
    /// <summary>
    /// clase que almacena la configuracion de cada capa, cantidad de nodos y funcion de activacion
    /// </summary>
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
