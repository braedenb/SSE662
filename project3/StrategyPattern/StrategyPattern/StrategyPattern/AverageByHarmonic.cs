using System.Collections.Generic;

namespace StrategyPattern
{
    public class AverageByHarmonic : IAveragingMethod
    {
        public double AverageFor(List<double> values)
        {
        //Sum the reciprocals of values in list and divide number of items in list by sum 
            double sum = 0;
            for (int i = 0; i < values.Count; i++)
            {
                sum += 1 / values[i];
            }

            return values.Count / sum;
        }
    }
}
