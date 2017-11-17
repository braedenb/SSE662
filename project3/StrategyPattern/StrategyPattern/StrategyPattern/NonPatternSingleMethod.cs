using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern
{
    public class CalculatorSingleMethod
    {
        public enum AveragingMethod
        {
            Mean,
            Median,
            Mode,
            Geometric,
            Harmonic
        }

        public double CalculateAverage(List<double> values, AveragingMethod averagingMethod)
        {
            switch (averagingMethod)
            {
                case AveragingMethod.Mean:
                    return values.Sum() / values.Count;

                case AveragingMethod.Median:
                    var sortedValues = values.OrderBy(x => x).ToList();

                    if (sortedValues.Count % 2 == 1)
                    {
                        return sortedValues[(sortedValues.Count - 1) / 2];
                    }

                    return (sortedValues[(sortedValues.Count / 2) - 1] +
                        sortedValues[sortedValues.Count / 2]) / 2;

                case AveragingMethod.Mode:
                    var mode = values.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                    return mode;

                case AveragingMethod.Geometric:
                    double product = 1;
                    for (int i = 0; i < values.Count; i++)
                    {
                        product *= values[i];
                    }
                    return Math.Pow(product, 1.0 / values.Count);

                case AveragingMethod.Harmonic:
                    double sum = 0;
                    for (int i = 0; i < values.Count; i++)
                    {
                        sum += 1 / values[i];
                    }

                    return values.Count / sum;

                default:
                    throw new ArgumentException("Invalid averagingMethod value");
            }
        }
    }
}