using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class PlayerStats : Observer
    {
        public Subject MatchData { get; set; }
        public List<Player> Players { get; set; }
        public Player MostMinutesPlayed { get; set; }
        public Player MostGoals { get; set; }
        public Player MostAssists { get; set; }

        public PlayerStats(Subject MatchData)
        {
            this.MatchData = MatchData;
            MatchData.registerObserver(this);
        }

        public void unsubscribe()
        {
            MatchData.removeObserver(this);
            MatchData = null;
        }

        public void update(List<Player> Players, int Minutes)
        {
            this.Players = Players;
            MostMinutesPlayed = Players.OrderByDescending(player => player.MinutesPlayed).First();
            MostGoals = Players.OrderByDescending(player => player.Goals).First();
            MostGoals = Players.OrderByDescending(player => player.Assists).First();
        }
    }
}
