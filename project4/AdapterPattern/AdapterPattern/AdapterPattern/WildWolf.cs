using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class WildWolf : Wolf
    {
        public string howl()
        {
            return "HOWL";
        }

        public string run()
        {
            return "Run a little.";
        }
    }
}
