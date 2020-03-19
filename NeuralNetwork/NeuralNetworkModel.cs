using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace NeuralNetwork
{
    /// <summary>
    /// modelo que sirve para gurdar y recrear la configuracion de la red
    /// </summary>
    [Serializable]
    public class NeuralNetworkModel
    {
        public List<Matrix<double>> Weigths { get; internal set; }

        public List<Layer> Layers { get; internal set; }

        public List<Matrix<double>> Bias { get; internal set; }

        public bool UseBias { get; set; }

        public List<double> Errors { get; internal set; }

        public string Features { get; set; }

        public string Labels { get; set; }

        public string HidenNodes { get; set; }

        public ModelLabel[] LabelMapping{ get; set; }
    }

    public class ReportProgressModel {

        public int epoch { get; set; }
        public double loss { get; set; }
    }
}
