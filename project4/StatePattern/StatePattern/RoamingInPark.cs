using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class RoamingInPark : GuestState
    {
        public void EnterQueue(ParkGuest guest)
        {
            Console.WriteLine("Request to enter queue...");
            Console.WriteLine("Entering queue.");
            guest.State = new InQueue();
            Console.WriteLine();
        }

        public void GetOnRide(ParkGuest guest)
        {
            Console.WriteLine("Request to get on ride...");
            Console.WriteLine("Guest is not in queue.");
            Console.WriteLine();
        }

        public void ExitRide(ParkGuest guest)
        {
            Console.WriteLine("Request to exit ride...");
            Console.WriteLine("Guest is not on ride.");
            Console.WriteLine();
        }
    }
}
