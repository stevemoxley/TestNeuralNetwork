using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet
{
    public class NeuralNetwork
    {
       /// <summary>
       /// A dictionary for holding neurons. The int is the layer
       /// </summary>
        public List<Neuron> Neurons { get; set; } = new List<Neuron>();

        /// <summary>
        /// Holds the synapses that connect the neurons
        /// The int is the layer
        /// </summary>
        public List<Synapse> Synapses { get; set; } = new List<Synapse>();

        public NeuralNetwork()
        {
        }


        /// <summary>
        /// Returns all the neurons located in the given layer
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public List<Neuron> GetAllNeuronsInLayer(int layer)
        {
              return Neurons.Where(n => n.Layer == layer).ToList();
        }

        /// <summary>
        /// Gets the neurons in layer+1 layer
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public List<Neuron> GetAllNeuronsInNextLayer(int layer)
        {
            return GetAllNeuronsInLayer(layer + 1);
        }

        /// <summary>
        /// Gets the neurons in layer-1 layer
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        public List<Neuron> GetAllNeuronsInPreviousLayer(int layer)
        {
            return GetAllNeuronsInLayer(layer - 1);
        }

        public int GetMaxLayer()
        {
            return Neurons.Select(n => n.Layer).Max();
        }

        public List<Neuron> GetNeuronsInInputLayer()
        {
            return GetAllNeuronsInLayer(0);
        }

        public List<Neuron> GetNeuronsInOutputLayer()
        {
            return GetAllNeuronsInLayer(GetMaxLayer());
        }

        public List<Neuron> GetNeuronsInHiddenLayer(int layer)
        {
            if (layer == GetMaxLayer() || layer == 0)
                throw new InvalidOperationException("Hidden layers can only be found on layers 1 > maxLayer - 1");

            return GetAllNeuronsInLayer(layer);
        }

        public List<List<Neuron>> GetHiddenLayersInReverseOrder()
        {
            List<List<Neuron>> result = new List<List<Neuron>>();

            int firstHiddenLayer = GetMaxLayer() - 1;

            //Reverse order
            for (int layer = firstHiddenLayer; layer >= 1; layer--)
            {
                var neurons = GetNeuronsInHiddenLayer(layer);
                result.Add(neurons);
            }

            return result;
        }



        public List<int> GetLayers()
        {
            return Neurons.Select(n => n.Layer).Distinct().ToList();
        }

        public List<Synapse> GetInputSynapses(Neuron neuron)
        {
            return Synapses.Where(s => s.OutputNeuron.Id == neuron.Id).ToList();
        }

        /// <summary>
        /// Returns a list of outputneurons from a list of inputneurons
        /// Change the values on the inputNeurons to change the prediction of the network
        /// </summary>
        /// <param name="inputNeurons"></param>
        /// <returns></returns>
        public List<Neuron> GetPrediction(List<Neuron> inputNeurons)
        {
            throw new NotImplementedException();
        }
    }
}
