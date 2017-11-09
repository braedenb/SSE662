using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class PlayerStats : Observer
    {
        public Player MostMinutesPlayed { get; set; }
        public Player MostGoals { get; set; }
        public Player MostAssists { get; set; }

        public void update()
        {

        }
    }
}
