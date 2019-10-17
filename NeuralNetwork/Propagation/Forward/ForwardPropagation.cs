using NeuralNet.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Propagation.Forward
{
    public class ForwardPropagation
    {

        public ForwardPropagation(NeuralNetwork neuralNet)
        {
            _neuralNet = neuralNet;
        }

        /// <summary>
        /// Applies forward propigation to the neural network
        /// </summary>
        public void Apply()
        {
            //Go through each layer
            var layers = _neuralNet.GetLayers();
            foreach (var layer in layers)
            {
                //We dont do this to the first layer
                if(layer > 0)
                {
                    var currentLayerNeurons = _neuralNet.GetAllNeuronsInLayer(layer);

                    foreach(var neuron in currentLayerNeurons)
                    {
                        //Get the synapses that connect to this neuron
                        var inputSynapses = _neuralNet.GetInputSynapses(neuron);

                        double value = 0;
                        foreach (var inputSynapse in inputSynapses)
                        {
                            value += inputSynapse.InputNeuron.Value * inputSynapse.Weight.Value;
                        }

                        //Add the bias
                        value += neuron.Bias;

                        //Apply sigmoid to layers 1 and max layer
                        //Apply relu to hidden layer
                        if (layer == 1 || layer == _neuralNet.GetMaxLayer())
                            value = MathHelper.Sigmoid(value);
                        else
                            value = MathHelper.ReLU(value);


                        neuron.Value = value;
                    }
                }
            }
        }

        private NeuralNetwork _neuralNet;
    }
}
