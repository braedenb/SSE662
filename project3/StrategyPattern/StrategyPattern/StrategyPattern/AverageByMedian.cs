using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class AverageByMedian : IAveragingMethod
    {
        public double AverageFor(List<double> values)
        {
            // Median average is the middle value of the values in the list.
            var sortedValues = values.OrderBy(x => x).ToList();

            // Determine if number of values is even or odd
            if (sortedValues.Count % 2 == 1)
            {
                // Number of values is odd.
                return sortedValues[(sortedValues.Count - 1) / 2];
            }

            // Number of values is even.
            return (sortedValues[(sortedValues.Count / 2) - 1] +
                sortedValues[sortedValues.Count / 2]) / 2;
        }
    }
}
