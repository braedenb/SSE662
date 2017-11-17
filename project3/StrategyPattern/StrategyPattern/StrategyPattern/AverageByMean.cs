using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class AverageByMean : IAveragingMethod
    {
        public double AverageFor(List<double> values)
        {
            // sum of all values, divided by number of values.
            return values.Sum() / values.Count;
        }
    }
}
