using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkItem
{
    class DrinkItem
    {
        strink name;
        bool alcoholic;

        public DrinkItem(string itemName)
        {
            name = itemName;
        }

        public string description
        {
            get {return description;}
            set {description = value;}
        }

        public double alcoholicVolume
        {
            get {return alcoholicVolume;}
            set
            {
                if(double.IsNan(value) || value < 0)
                {
                    alcoholicVolume = 0
                    alcoholic = false;
                }
                else
                {
                    alcoholicVolume = value;
                    alcoholic = true;
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

        public bool IsAlcoholic()
        {
            return alchoholic;
        }
    }
}
