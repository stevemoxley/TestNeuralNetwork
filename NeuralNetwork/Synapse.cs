using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    public class Synapse
    {
        public Synapse(Neuron inputNeuron, Neuron outputNeuron)
        {
            this.InputNeuron = inputNeuron;
            this.OutputNeuron = outputNeuron;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public double? Weight { get; set; }

        public Neuron InputNeuron { get; private set; }

        public Neuron OutputNeuron { get; private set; }
    }
}
