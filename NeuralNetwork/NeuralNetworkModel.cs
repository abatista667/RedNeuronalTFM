using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace NeuralNetwork
{
    public class NeuralNetworkModel
    {
        public List<Matrix<double>> Weigths { get; internal set; }
    }
}