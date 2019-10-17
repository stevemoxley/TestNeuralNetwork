using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    public class Neuron
    {

        //The id of this neuron
        public Guid Id { get; private set; }

        public string Name { get; set; }

        //The current value of this neuron
        public double Value { get; set; } = 0;

        public int Layer { get; set; }

        public double Bias { get; set; }

        public Neuron()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{Name}:{Value}";
        }
    }

}
