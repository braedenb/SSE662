using System.Collections.Generic;

namespace StrategyPattern
{
    public interface IAveragingMethod
    {
        double AverageFor(List<double> values);
    }
}
