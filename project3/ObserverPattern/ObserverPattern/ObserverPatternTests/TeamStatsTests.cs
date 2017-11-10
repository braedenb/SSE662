using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Tests
{
    [TestClass()]
    public class TeamStatsTests
    {
        [TestMethod()]
        public void unsubscribeTest()
        {
            MatchData matchData = new MatchData();
            TeamStats teamStats = new TeamStats(matchData);
            teamStats.unsubscribe();

            Assert.AreEqual(null, teamStats.MatchData);
        }

        [TestMethod()]
        public void updateTest()
        {
            MatchData matchData = new MatchData();
            TeamStats teamStats = new TeamStats(matchData);

            List<Player> players = new List<Player>();
            players.Add(new Player(true, true));
            matchData.Players = players;
            // This method calls update.
            matchData.notifyObservers();

            Assert.AreEqual(1, teamStats.Players.Count);
        }
    }
}