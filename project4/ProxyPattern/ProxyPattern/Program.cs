using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create proxy object
            NewServerProxy server = new NewServerProxy();

            // Perform proxy methods
            server.TakeOrder("fish sticks");
            Console.WriteLine(server.DeliverOrder());
            server.ProcessPayment(server.DeliverOrder());

            string actual = Console.ReadLine();
            Console.WriteLine(actual);
        }
    }
}
