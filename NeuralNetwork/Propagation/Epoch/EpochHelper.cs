using NeuralNet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Propagation.Epoch
{
    public class EpochHelper
    {
        public EpochHelper(NeuralNetwork neuralNetwork, DataPool dataPool)
        {
            this._neuralNetwork = neuralNetwork;
            this._dataPool = dataPool;
        }



        private NeuralNetwork _neuralNetwork;
        private DataPool _dataPool;


    }
}
