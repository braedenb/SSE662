using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class AverageByGeometric : IAveragingMethod
    {
        public double AverageFor(List<double> values)
        {
         //multiply all values in list and raise to reciprocal of number of values
            double product = 1;
            for (int i = 0; i < values.Count; i++)
            {
                product *= values[i];
            }
            return Math.Pow(product, 1.0 / values.Count);
        }
    }
}
