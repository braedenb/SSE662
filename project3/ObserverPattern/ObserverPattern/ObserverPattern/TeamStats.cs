using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class TeamStats : Observer
    {
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

        public void update()
        {

        }
    }
}
