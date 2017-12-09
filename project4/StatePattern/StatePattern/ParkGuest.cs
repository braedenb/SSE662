using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class ParkGuest
    {
        public ParkGuest(GuestState state)
        {
            State = state;
            Console.WriteLine("Create object of ParkGuest class with initial State, RoamingInPark.");
        }

        public GuestState State { get; set; }

        public void EnterQueue()
        {
            State.EnterQueue(this);
        }

        public void GetOnRide()
        {
            State.GetOnRide(this);
        }

        public void ExitRide()
        {
            State.ExitRide(this);
        }
    }
}
