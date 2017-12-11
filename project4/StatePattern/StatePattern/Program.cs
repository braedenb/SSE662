using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkGuest guest = new ParkGuest(new RoamingInPark());
            Console.WriteLine();

            guest.EnterQueue();

            guest.EnterQueue();
            guest.ExitRide();
            guest.GetOnRide();

            guest.EnterQueue();
            guest.GetOnRide();
            guest.ExitRide();

            guest.GetOnRide();
            guest.ExitRide();
            guest.EnterQueue();
        }
    }
}
