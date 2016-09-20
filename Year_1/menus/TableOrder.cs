using System;

namespace TableOrder
{
    class TableOrder
    {
        int tableNumber;
        public List<FoodItem> OrderedFood = new List<FoodItem>();
        public List<DrinkItem> OrderedDrink = new List<FoodItem>();

        public int NumberOfPatrons
        {
            get {return NumberOfPatrons;}
            set
            {
                if(value < 0)
                {
                    NumberOfPatrons=value;
                }
            }
        }

        public TableOrder(int table, int patrons)
        {
            tableNumber = table;
            numberOfPatrons = patrons;
        }

        public void AddFood(FoodItem food)
        {
            OrderedFood.Add(food);
        }

        public void AddDrink(DrinkItem drink)
        {
            OrderedDrink.Add(drink);
        }
    }
}
