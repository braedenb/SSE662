using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Player
    {
        public bool HomeTeam { get; set; }
        public bool OnField { get; set; }
        public int MinutesPlayed { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        
        public Player(bool homeTeam, bool starting)
        {
            HomeTeam = homeTeam;
            OnField = starting;
            MinutesPlayed = 0;
            Goals = 0;
            Assists = 0;
        }
    }
}
