using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public class VanillaCoke : SoftDrink
    {
        public VanillaCoke(int calories) : base(calories) { }
    }

    public class CherryCoke : SoftDrink
    {
        public CherryCoke(int calories) : base(calories) { }
    }

    public class StrawberryRootBeer : SoftDrink
    {
        public StrawberryRootBeer(int calories) : base(calories) { }
    }

    public class VanillaRootBeer : SoftDrink
    {
        public VanillaRootBeer(int calories) : base(calories) { }
    }

    public class Sprite : SoftDrink
    {
        public Sprite(int calories) : base(calories) { }
    }
}
