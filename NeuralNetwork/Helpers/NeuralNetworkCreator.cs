using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Helpers
{
    public static class NeuralNetworkCreator
    {
        /// <summary>
        /// Creates a neural network and initialized the values of all the synapses by
        /// Doing one round of forward propigation
        /// </summary>
        /// <param name="inputLayer"></param>
        /// <param name="outputLayer"></param>
        /// <param name="numberOfHiddenLayers"></param>
        /// <param name="numberOfNeuronsPerHiddenLayer"></param>
        /// <returns></returns>
        public static NeuralNetwork CreateNeuralNetwork(DataPoint dataPoint, int numberOfHiddenLayers, int numberOfNeuronsPerHiddenLayer)
        {
            var net = new NeuralNetwork();

            int currentLayer = 0;
            //Add the input layer to the net
            dataPoint.Inputs.ForEach(n => n.Layer = currentLayer);
            net.Neurons.AddRange(dataPoint.Inputs);
            
            //Create the hidden layers
            for (int i = 0; i < numberOfHiddenLayers; i++)
            {
                currentLayer++;
                for (int j = 0; j < numberOfNeuronsPerHiddenLayer; j++)
                {
                    net.Neurons.Add(new Neuron
                    {
                        Name = $"Hidden {currentLayer},{j}",
                        Layer = currentLayer
                    });
                }
            }

            //Add the outputlayer
            currentLayer++;
            dataPoint.Outputs.ForEach(n => n.Layer = currentLayer);

            foreach(var outputNeuron in dataPoint.Outputs)
            {
                var newOutputNeuron = new Neuron
                {
                    Value = outputNeuron.Value,
                    Layer = currentLayer,
                    Name = outputNeuron.Name
                };

                net.Neurons.Add(newOutputNeuron);
            }

            var connectionHelper = new SynapseConnectionHelper();
            net.Synapses =  connectionHelper.CreateSynapses(net);

            return net;
        }
    }
}
