using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class WolfAdapter : Dog
    {
        Wolf wolf;

        public WolfAdapter(Wolf wolf)
        {
            this.wolf = wolf;
        }

        public string bark()
        {
            return wolf.howl();
        }

        public string run()
        {
            string output = "";

            // Assume wolf runs in short spurts.
            for (int i = 0; i < 3; i++)
                output += wolf.run();

            return output;
        }
    }
}
