using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Helpers
{
    public class SynapseConnectionHelper
    {

        /// <summary>
        /// Takes a neural net and creates new synapses for it
        /// </summary>
        /// <param name="net"></param>
        /// <returns></returns>
        public List<Synapse> CreateSynapses(NeuralNetwork net)
        {
            List<Synapse> result = new List<Synapse>();

            var layers = net.GetLayers();

            foreach(var layer in layers)
            { 
                var currentLayerNeurons = net.GetAllNeuronsInLayer(layer);
                var nextLayerNeurons = net.GetAllNeuronsInNextLayer(layer);

                foreach (var currentLayerNeuron in currentLayerNeurons)
                {
                    //Get the next layer
                    foreach (var nextlayerNeuron in nextLayerNeurons)
                    {
                        //Create a synapse
                        var synapse = new Synapse(currentLayerNeuron, nextlayerNeuron);

                        //Randomize the weight
                        synapse.Weight = GetRandomWeight();

                        result.Add(synapse);
                    }
                }
            }

            return result;
        }

        private double GetRandomWeight()
        {
            return (double)((double)_random.Next(-10, 11) / 10);
        }

        private readonly Random _random = new Random();
    }
}
