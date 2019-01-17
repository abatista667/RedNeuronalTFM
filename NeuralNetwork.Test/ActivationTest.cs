using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork.Test
{
    [TestFixture]
    public class ActivationTest
    {
        [TestCase("Relu")]
        public void GetActivationByNameTest(string name)
        {
            var func = Activation.GetActivationByName(name);

            func(5);
        }
    }
}
