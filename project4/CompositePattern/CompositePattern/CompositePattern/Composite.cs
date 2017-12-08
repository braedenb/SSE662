using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public class Cola : SoftDrink
    {
        public Cola(int calories) : base(calories) { }
    }

    public class RootBeer : SoftDrink
    {
        public RootBeer(int calories) : base(calories) { }
    }

    public class SodaWater : SoftDrink
    {
        public SodaWater(int calories) : base(calories) { }
    }
}
