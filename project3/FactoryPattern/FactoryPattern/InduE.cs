using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class InduE : IMajor
    {
        public void DeclareGraduation(int gradYear)
        {
            Console.WriteLine("Declared major as Industrial Engineer graduating in " + gradYear);
        }
    }
}
