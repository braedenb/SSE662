using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class OnRide : GuestState
    {
        public void EnterQueue(ParkGuest guest)
        {
            Console.WriteLine("Request to enter queue...");
            Console.WriteLine("Guest is already on the ride.");
            Console.WriteLine();
        }

        public void GetOnRide(ParkGuest guest)
        {
            Console.WriteLine("Request to get on ride...");
            Console.WriteLine("Guest is already on the ride.");
            Console.WriteLine();
        }

        public void ExitRide(ParkGuest guest)
        {
            Console.WriteLine("Request to exit ride...");
            Console.WriteLine("Exiting ride.");
            guest.State = new RoamingInPark();
            Console.WriteLine();
        }
    }
}
