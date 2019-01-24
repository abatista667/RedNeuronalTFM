using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Test
{
    [TestFixture]
    public class LoadTest
    {
        [TestCase(@"C:\Users\ariel batista\source\repos\NeuralNetwork\NeuralNetwork\xor.dat")]
        public void LoadModelFromFileTest(string path)
        {
            var nn = new NeuralNetworkBase();
            nn.Load(path);

            Assert.AreEqual(0, nn.Predict(new double[2] { 1, 1 })[0]);
            Assert.AreEqual(1, nn.Predict(new double[2] { 0, 1 })[0]);
            Assert.AreEqual(1, nn.Predict(new double[2] { 1, 0 })[0]);
            Assert.AreEqual(0, nn.Predict(new double[2] { 0, 0 })[0]);
        }
    }
}
