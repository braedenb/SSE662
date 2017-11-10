using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class MatchData : Subject
    {
        public List<Observer> Observers { get; set; }
        public List<Player> Players { get; set; }
        public int Minutes { get; set; }

        public MatchData()
        {
            Observers = new List<Observer>();
            Players = new List<Player>();
            Minutes = 0;
        }

        public void registerObserver(Observer o)
        {
            Observers.Add(o);
        }

        public void removeObserver(Observer o)
        {
            Observers.Remove(o);
        }

        public void notifyObservers()
        {
            foreach (Observer o in Observers)
                o.update(Players, Minutes);
        }

        // Increment the total number of minutes the match has been played for.
        // If the Player is currently on the field, increment the number of minutes he has played.
        public void incrementMinutes()
        {
            Minutes++;

            foreach (Player p in Players)
            {
                if (p.OnField)
                    p.MinutesPlayed++;
            }

            notifyObservers();
        }

        // g is the Player who scored the goal.
        // a is the Player who recorded the assist (if a is not passed in, no player recorded an assist).
        public void goalScored(Player g, Player a = null)
        {
            int scorer = Players.IndexOf(g);
            Players[scorer].Goals++;

            if (a != null)
            {
                int assister = Players.IndexOf(a);
                Players[assister].Assists++;
            }

            notifyObservers();
        }
    }
}
