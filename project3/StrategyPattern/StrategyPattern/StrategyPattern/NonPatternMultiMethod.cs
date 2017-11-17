using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class CalculatorMultiMethod
    {
        public double CalculateAverageByMean(List<double> values)
        {
            return values.Sum() / values.Count;
        }

        public double CalculateAverageByMedian(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

            if (sortedValues.Count % 2 == 1)
            {
                return sortedValues[(sortedValues.Count - 1) / 2];
            }

            return (sortedValues[(sortedValues.Count / 2) - 1] +
                sortedValues[sortedValues.Count / 2]) / 2;
        }

        public double CalculateAverageByMode(List<double> values)
        {
            var mode = values.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            return mode;
        }

        public double CalculateAverageByGeometric(List<double> values)
        {
            double product = 1;
            for(int i = 0; i < values.Count; i++)
            {
                product *= values[i];
            }
            return Math.Pow(product, 1.0 / values.Count);
        }

        public double CalculateAverageByHarmonic(List<double> values)
        {
            double sum = 0;
            for(int i = 0; i < values.Count; i++)
            {
                sum += 1 / values[i];
            }

            return values.Count / sum;
        }
    }
}
