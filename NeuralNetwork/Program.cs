﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var nn = new NeuralNetworkBase(
            new List<Layer>{
                   new Layer(2),//la ultima capa siempre sera el output
                   new Layer(2),//la ultima capa siempre sera el output
                   new Layer(1),
            }, epoch: 1);

            nn.Print();


            double[][] X = new double[10][];
            System.Random random = new MathNet.Numerics.Random.SystemRandomSource();
            var sample = random.NextDouble();


            for (int i = 0; i < X.Length; i++)
            {
                X[i] = new double[2];
                for (int j = 0; j < X[i].Length; j++)
                {
                    X[i][j] = random.NextDouble();
     
                }
            }

            nn.Fit(X, new double[1] { 1});

            Console.Read();
        }
    }
}
