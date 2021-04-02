using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            toppings = new List<Topping>();
            this.Dough = dough;
        }

        public string Name
        {
            get => name; 
            private set
            {
                if(string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public int NumberOfToppings => toppings.Count;

        public Dough Dough { get; set; }

        public double TotalCalories => CalculateTotalCalories();

        private double CalculateTotalCalories()
        {
            double result = Dough.CaloriesPerGram * Dough.Weight;
            foreach (var topping in toppings)
            {
                result += topping.CaloriesPerGram * topping.Weight;
            }

            return result;
        }

        public void AddTopping(Topping toppingName)
        {
            if(this.NumberOfToppings >= 0 && this.NumberOfToppings < 10)
            {
                toppings.Add(toppingName);
            }

            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
    }
}
