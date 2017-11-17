using System.Collections.Generic;

namespace StrategyPattern
{
    public class Calculator
    {
        public static int Main(string[] args)
        {
            return 0;
        }
        public double CalculateAverageFor(List<double> values, IAveragingMethod averagingMethod)
        {
            return averagingMethod.AverageFor(values);
        }
    }
}
