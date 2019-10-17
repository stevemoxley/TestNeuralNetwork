using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNet.Helpers
{
    public static class MathHelper
    {

        public static double Sigmoid(double x)
        {
            return 1 / (1 + Math.Pow(Math.E, -x));
        }

        public static double ReLU(double x)
        {
            return Math.Max(0, x);
        }

        public static double ReLUPrime(double x)
        {
            if (x < 0)
                return 0;
            else
                return 1;
        }

        public static double SigmoidPrime(double x)
        {
            return Sigmoid(x) * Sigmoid((1 - x));
        }
    }
}
