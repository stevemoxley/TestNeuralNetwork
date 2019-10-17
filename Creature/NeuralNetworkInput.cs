using NeuralNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature
{
    /// <summary>
    /// This will go into the neural network when making decision
    /// </summary>
    public class NeuralNetworkInput : Neuron
    {
        public NeuralNetworkInput(NeuralNetworkInputType neuralNetworkInputType)
        {
            this.Name = neuralNetworkInputType.ToString();
        }
    }

  
}
