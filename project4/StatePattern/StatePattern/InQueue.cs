using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class InQueue : GuestState
    {
        public void EnterQueue(ParkGuest guest)
        {
            Console.WriteLine("Request to enter queue...");
            Console.WriteLine("Already in queue.");
            Console.WriteLine();
        }

        public void GetOnRide(ParkGuest guest)
        {
            Console.WriteLine("Request to get on ride...");
            Console.WriteLine("Getting on ride.");
            guest.State = new OnRide();
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
