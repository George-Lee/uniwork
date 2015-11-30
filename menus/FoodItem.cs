using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodItem
{
    class FoodItem 
    {
        string name;

        public FoodItem(string itemName)
        {
            name = itemName;
        }
        
        public string description
        {
            get {return description;}
            set {description = value;}
        }

        public int numberServed
        {
            get {return numberServed;}
            set
            {
                if(numberServed > 0 && numberServed <=4)
                {
                }
                else
                {
                    numberServed = 0;
                }
            }
        }

        public double cost
        {
            get {return cost;}
            set
            {
                if(double.IsNaN(value) || value < 0)
                {
                    cost = 0;
                }
                else
                {
                    cost = value;
                }
            }
        }
    }
}
