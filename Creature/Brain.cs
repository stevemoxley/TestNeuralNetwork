using NeuralNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature
{

    //The brain is responsible for decision making
    public class Brain
    {

        public Brain(NeuralNetwork neuralNetwork)
        {
            this.NeuralNetwork = neuralNetwork;
        }

        public NeuralNetwork NeuralNetwork { get; private set; }

        /// <summary>
        /// The brain makes decisions using the neural network
        /// </summary>
        public void MakeDecision()
        {
            //In order to make a decision we need to gather all possible inputs

            //We should already have a neural network set by now. It should have some kind of value for each possible in put in
            // the game.
        }

    }

 
}
