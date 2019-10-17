using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature
{
    /// <summary>
    /// The creature is the vessel which contains the brain
    /// It has stats which the brain uses to make decision
    /// </summary>
    public class Creature
    {

        public Creature(Brain brain)
        {
            this.Brain = brain;
        }

        public int Health { get; set; }

        public int Energy { get; set; }

        public Brain Brain { get; private set; }


    }
}
