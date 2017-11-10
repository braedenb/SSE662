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
    public class PlayerStatsTests
    {
        [TestMethod()]
        public void unsubscribeTest()
        {
            MatchData matchData = new MatchData();
            PlayerStats playerStats = new PlayerStats(matchData);
            playerStats.unsubscribe();

            Assert.AreEqual(null, playerStats.MatchData);
        }

        [TestMethod()]
        public void updateTest()
        {
            MatchData matchData = new MatchData();
            PlayerStats playerStats = new PlayerStats(matchData);

            List<Player> players = new List<Player>();
            players.Add(new Player(true, true));
            matchData.Players = players;
            // This method calls update.
            matchData.notifyObservers();

            Assert.AreEqual(1, playerStats.Players.Count);
        }
    }
}