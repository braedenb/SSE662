using System.Collections.Generic;
using System.Linq;


namespace StrategyPattern
{
    public class AverageByMode : IAveragingMethod
    {
        public double AverageFor(List<double> values)
        {
            //Group same values in List and select group with most values
            var mode = values.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            return mode;
        }
    }
}
