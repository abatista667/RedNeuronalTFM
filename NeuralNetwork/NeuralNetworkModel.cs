using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace NeuralNetwork
{
    [Serializable]
    public class NeuralNetworkModel
    {
        public List<Matrix<double>> Weigths { get; internal set; }

        public List<Layer> Layers { get; internal set; }

        public List<Matrix<double>> Bias { get; internal set; }

        public bool UseBias { get; set; }
    }
}
