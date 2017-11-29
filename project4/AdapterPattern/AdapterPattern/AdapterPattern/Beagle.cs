using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class Beagle : Dog
    {
        public string bark()
        {
            return "BARK";
        }

        public string run()
        {
            return "Run a lot.";
        }
    }
}
