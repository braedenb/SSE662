using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompositePattern;
using System.Collections.Generic;

namespace CompositePatternTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalorieValues()
        {
            var colas = new Cola(210);
            colas.Flavors.Add(new VanillaCoke(215));
            colas.Flavors.Add(new CherryCoke(210));

            var lemonLime = new Sprite(185);

            var rootBeers = new RootBeer(195);
            rootBeers.Flavors.Add(new VanillaRootBeer(200));
            rootBeers.Flavors.Add(new StrawberryRootBeer(200));

            SodaWater sodaWater = new SodaWater(180);
            sodaWater.Flavors.Add(colas);
            sodaWater.Flavors.Add(lemonLime);
            sodaWater.Flavors.Add(rootBeers);

            Assert.AreEqual(210, colas.Calories);
            Assert.AreEqual(195, rootBeers.Calories);
            Assert.AreEqual(180, sodaWater.Calories);
        }

        [TestMethod]
        public void CorrectHierarchy()
        {
            var colas = new Cola(210);
            colas.Flavors.Add(new VanillaCoke(215));
            colas.Flavors.Add(new CherryCoke(210));

            var lemonLime = new Sprite(185);

            var rootBeers = new RootBeer(195);
            rootBeers.Flavors.Add(new VanillaRootBeer(200));
            rootBeers.Flavors.Add(new StrawberryRootBeer(200));

            SodaWater sodaWater = new SodaWater(180);
            sodaWater.Flavors.Add(colas);
            sodaWater.Flavors.Add(lemonLime);
            sodaWater.Flavors.Add(rootBeers);

            var expectedList = new List<SoftDrink>();
            expectedList.Add(colas);
            expectedList.Add(lemonLime);
            expectedList.Add(rootBeers);

            CollectionAssert.AreEqual(expectedList, sodaWater.Flavors);
        }
    }
}
