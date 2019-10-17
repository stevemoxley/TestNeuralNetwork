using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    /// <summary>
    /// This class models inputs and outputs for a neural network
    /// </summary>
    public class DataPoint
    {
        public List<Neuron> Inputs { get; set; } = new List<Neuron>();

        public List<Neuron> Outputs { get; set; } = new List<Neuron>();
    }
}
