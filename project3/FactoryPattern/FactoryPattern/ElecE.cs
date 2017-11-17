using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class ElecE : IMajor
    {
        public void DeclareGraduation(int gradYear)
        {
            Console.WriteLine("Declared major as Electrical Engineer graduating in " + gradYear);
        }
    }
}
