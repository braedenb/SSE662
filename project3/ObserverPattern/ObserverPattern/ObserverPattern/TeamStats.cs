using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class TeamStats : Observer
    {
        public Subject MatchData { get; set; }
        public List<Player> Players { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public int Minutes { get; set; }

        public TeamStats(Subject MatchData)
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
            HomeGoals = 0;
            AwayGoals = 0;
            this.Players = Players;

            foreach (Player p  in Players)
            {
                if (p.HomeTeam)
                    HomeGoals += p.Goals;
                else
                    AwayGoals += p.Goals;
            }

            this.Minutes = Minutes;
        }
    }
}
