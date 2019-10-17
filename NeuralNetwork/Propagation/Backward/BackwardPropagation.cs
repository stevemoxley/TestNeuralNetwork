using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralNet;
using NeuralNet.Helpers;

namespace NeuralNet.Propagation.Backward
{
    /// <summary>
    /// I followed this backward prop tutorial
    /// https://mattmazur.com/2015/03/17/a-step-by-step-backpropagation-example/
    /// Its shit code. I know leave me alone. Ill fix it later
    /// </summary>
    public class BackwardPropagation
    {
        public BackwardPropagation(NeuralNetwork neuralNetwork)
        {
            this._neuralNetwork = neuralNetwork;
        }

        /// <summary>
        /// Applies backward propigation on the neural network
        /// </summary>
        public void Apply(DataPoint dataPoint, double learningRate)
        {
            //So far this does nothing but being able to print it
            //Ideally it goes down over time
            var error = GetTotalError(dataPoint);

            Console.WriteLine($"Total error:{error}");

            //This dictionary will help us keep the weights of the next layers
            var newOutputLayerSynapseWeights = GetNewOutputLayerSynapseWeights(dataPoint);

            //Now we need to calculate the weights for the hidden layer
            //We use the original weights for this
            //The weights calculated above will be used AFTER. This process is done
            var newHiddenLayerSynapseWeights = GetNewHiddenLayerSynapseWeights();
            
        }

        private Dictionary<Guid, double> GetNewOutputLayerSynapseWeights(DataPoint dataPoint)
        {
            var newOutputLayerSynapseWeights = new Dictionary<Guid, double>();

            var midStep = GetOutputLayerMidStep(dataPoint);

            //Outerlayer first. I know this code is shit
            foreach (var neuron in _neuralNetwork.GetNeuronsInOutputLayer())
            {
                var inputSynapses = _neuralNetwork.GetInputSynapses(neuron);
                foreach (var synapse in inputSynapses)
                {

                    //This is how the value of the input neuron and the synapse affected the weight
                    var dInputWRTWeight = synapse.InputNeuron.Value * synapse.Weight;

                    //Mid step is how some other shit affected the error. Go read that
                    var mid = midStep[neuron.Id];

                    //How this weight affected the total
                    var dTotalWRTWeight = mid * dInputWRTWeight;

                    //Same as above just renamed again
                    var nodeDelta = dTotalWRTWeight;

                    //The new weight of this synapse in the neural net
                    var newSynapseWeight = synapse.Weight.Value + nodeDelta.Value;

                    newOutputLayerSynapseWeights.Add(synapse.Id, newSynapseWeight);
                }
            }

            return newOutputLayerSynapseWeights;
        }

        private Dictionary<Guid, double> GetNewHiddenLayerSynapseWeights()
        {
            var newHiddenLayerSynapseWeights = new Dictionary<Guid, double>();

            var hiddenLayers = _neuralNetwork.GetHiddenLayersInReverseOrder();

            foreach(var hiddenLayer in hiddenLayers)
            {
                throw new NotImplementedException("YOU FUCK");
            }


            return newHiddenLayerSynapseWeights;

        }

        private double GetTotalError(DataPoint dataPoint)
        {
            //Iterate backwards
            var maxLayer = _neuralNetwork.GetMaxLayer();

            //Calculate the total error
            double totalError = 0;

            //Start at the output layer
            foreach (var actualNeuron in _neuralNetwork.GetNeuronsInOutputLayer())
            {
                var targetNeuron = dataPoint.Outputs.Where(n => n.Name == actualNeuron.Name).FirstOrDefault();

                double error = Math.Pow(actualNeuron.Value - targetNeuron.Value, 2);
                totalError += error;
            }

            totalError *= 0.5;

            return totalError;
        }

        /// <summary>
        /// Stores a dictionary keyed off ID, for the gradients WRT Total
        /// </summary>
        /// <param name="dataPoint"></param>
        /// <returns></returns>
        private Dictionary<Guid, double> GetOutputLayerMidStep(DataPoint dataPoint)
        {
            Dictionary<Guid, double> result = new Dictionary<Guid, double>();

            var outputNeurons = _neuralNetwork.GetNeuronsInOutputLayer();

            foreach (var neuron in outputNeurons)
            {
                var targetNeuron = dataPoint.Outputs.FirstOrDefault(n => n.Name == neuron.Name);

                //How we affected the total is the difference of the value and target
                var dTotalWRTOutput = neuron.Value - targetNeuron.Value;

                //How we affected the value with the sigmoid function
                var dOutputWRTInput = MathHelper.SigmoidPrime(neuron.Value);

                //This is the midstep we could combine these later
                var midStep = dOutputWRTInput * dTotalWRTOutput;

                result.Add(neuron.Id, midStep);
            }

            return result;
        }

        private NeuralNetwork _neuralNetwork;

    }
}
