using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
/// <summary>
/// excepcion de que la tasa de aprendisaje es muy alta
/// </summary>
    public class LearningRateTooHighException : Exception
    {
        public LearningRateTooHighException()
        : base("Se ha producido un error debido a que la tasa de aprendisaje es muy alta") { }
    }
}
