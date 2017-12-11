using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyPattern;
using System.IO;

namespace ProxyPatternTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProxyTakeAndDeliverOrder()
        {
            NewServerProxy server = new NewServerProxy();
            server.TakeOrder("pizza");

            Assert.AreEqual("pizza", server.DeliverOrder());
        }

        [TestMethod]
        public void ProxyProcessPayment()
        {

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                NewServerProxy server = new NewServerProxy();
                server.TakeOrder("pizza");
                server.ProcessPayment(server.DeliverOrder());

                string expected = string.Format("Payment for order (pizza) processed.{0}", Environment.NewLine);
                Assert.AreEqual<string>(expected, sw.ToString());
            }
        }
    }
}
