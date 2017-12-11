using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public interface GuestState
    {
        void EnterQueue(ParkGuest guest);
        void GetOnRide(ParkGuest guest);
        void ExitRide(ParkGuest guest);
    }
}
