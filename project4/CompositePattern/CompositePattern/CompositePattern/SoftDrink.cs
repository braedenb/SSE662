using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public abstract class SoftDrink
    {
        public int Calories { get; set; }
        
        public List<SoftDrink> Flavors { get; set; }

        public SoftDrink(int calories)
        {
            Calories = calories;
            Flavors = new List<SoftDrink>();
        }

        public void DisplayCalories()
        {
            Console.WriteLine(this.GetType().Name + ": " + this.Calories.ToString() + " calories.");
            foreach (var drink in this.Flavors)
            {
                drink.DisplayCalories();
            }
            
        }
    }
}
