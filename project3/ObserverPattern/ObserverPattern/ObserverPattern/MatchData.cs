using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class MatchData : Subject
    {
        public List<Player> Players { get; set; }

        public void registerObserver()
        {

        }

        public void removeObserver()
        {

        }

        public void notifyObserver()
        {

        }

        public List<Player> getPlayers()
        {
            return Players;
        }
    }
}
