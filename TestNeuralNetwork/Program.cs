using NeuralNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Creature;
using NeuralNet.Helpers;

namespace TestNeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputcsvParser = new InputCSVParser(1, 3);
            var dataPoints = inputcsvParser.GetNeuralNetDataPool("testNet.txt");

            //Create an initial network
            var net = NeuralNetworkCreator.CreateNeuralNetwork(dataPoints.DataPoints[0], 1, 3);

            foreach (var item in dataPoints.DataPoints)
            {
                //Run each bit of data through the forward and propigation once to keep training the network


            }

            PrintNeuralNet(net);

            Console.ReadLine();

        }

        private static void GetPrediction(NeuralNetwork net)
        {
            //var sleepInputNeuron = net.Neurons.Where(n => n.Name == NeuralNetworkInputType.SleepLevel.ToString()).FirstOrDefault();
            //var hungerFoodInputNeuron = net.Neurons.Where(n => n.Name == NeuralNetworkInputType.HungerLevel.ToString()).FirstOrDefault();

            //Console.WriteLine("Enter an input for the amount of hunger value:");
            //int amountOfHunger = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter an input for the amount of sleep value:");
            //int amountOfSleep = int.Parse(Console.ReadLine());

            //sleepInputNeuron.Value = amountOfSleep;
            //hungerFoodInputNeuron.Value = amountOfHunger;

            //var outputNeurons = net.GetPrediction(new List<Neuron>() { sleepInputNeuron, hungerFoodInputNeuron });
            //var topSuggestion = outputNeurons.OrderByDescending(n => n.Value).FirstOrDefault();

            //foreach (var n in outputNeurons)
            //{
            //    Console.WriteLine($"N:{n.Name} V:{n.Value} E:{n.Gradient}");
            //}

            //Console.WriteLine($"I suggest { topSuggestion.Name.ToString() }");
        }


        private static void PrintNeuralNet(NeuralNetwork neuralNet)
        {
            foreach (var neuron in neuralNet.Neurons)
            {
                Console.WriteLine(neuron.ToString());
            }
        }

    }
}
