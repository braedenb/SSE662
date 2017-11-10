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
    public class MatchDataTests
    {
        [TestMethod()]
        public void registerObserverTest()
        {
            MatchData matchData = new MatchData();
            // This constructor calls registerObserver.
            PlayerStats playerStats = new PlayerStats(matchData);

            Assert.AreEqual(1, matchData.Observers.Count);
        }

        [TestMethod()]
        public void removeObserverTest()
        {
            MatchData matchData = new MatchData();
            PlayerStats playerStats = new PlayerStats(matchData);
            // This method calls removeObserver.
            playerStats.unsubscribe();

            Assert.AreEqual(0, matchData.Observers.Count);
        }

        [TestMethod()]
        public void notifyObserversTest()
        {
            MatchData matchData = new MatchData();
            PlayerStats playerStats = new PlayerStats(matchData);

            List<Player> players = new List<Player>();
            players.Add(new Player(true, true));
            matchData.Players = players;
            matchData.notifyObservers();

            Assert.AreEqual(1, playerStats.Players.Count);
        }
    }
}