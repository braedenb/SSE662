using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdapterPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Tests
{
    [TestClass()]
    public class WolfAdapterTests
    {
        [TestMethod()]
        public void wolfTest()
        {
            WildWolf wolf = new WildWolf();
            Assert.AreEqual("HOWL", wolf.howl());
            Assert.AreEqual("Run a little.", wolf.run());
        }

        [TestMethod()]
        public void dogTest()
        {
            Beagle dog = new Beagle();
            Assert.AreEqual("BARK", dog.bark());
            Assert.AreEqual("Run a lot.", dog.run());
        }

        [TestMethod()]
        public void adapterTest()
        {
            WildWolf wolf = new WildWolf();
            Dog wolfAdapter = new WolfAdapter(wolf);
            Assert.AreEqual("HOWL", wolfAdapter.bark());
            Assert.AreEqual("Run a little.Run a little.Run a little."
                , wolfAdapter.run());
        }
    }
}