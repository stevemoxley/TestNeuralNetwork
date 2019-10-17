using NeuralNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature
{
    public class NeuralNetworkOutput : Neuron
    {
        public NeuralNetworkOutput(NeuralNetworkOutputType neuralNetworkOutputType)
        {
            this.Name = neuralNetworkOutputType.ToString();
        }
    }

  
}
