using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Propagation.Epoch
{
    public class Epoch
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Which epoch this is
        /// </summary>
        public int Value { get; set; }
    }
}
