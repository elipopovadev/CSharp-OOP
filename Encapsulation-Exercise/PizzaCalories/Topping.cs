using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double meatModifier = 1.2;
        private const double veggiesModifier = 0.8;
        private const double cheeseModifier = 1.1;
        private const double sauceModifier = 0.9;
        private const double baseCaloriesPerGram = 2;
        private string toppingType;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        private string ToppingType
        {
            get => toppingType;
            set
            {
                string valueToLower = value.ToLower();
                if(valueToLower == "meat"|| valueToLower == "veggies" || valueToLower == "cheese" || valueToLower == "sauce")
                {
                    toppingType = value;
                }

                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                }
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if(value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                else
                {
                    weight = value; 
                }              
            }
        }

        public double CaloriesPerGram => CalculateTotalCalories();

        private double CalculateTotalCalories()
        {
            string toppingTypeToLower = this.ToppingType.ToLower();
            if(toppingTypeToLower == "meat")
            {
                return baseCaloriesPerGram * meatModifier;
            }

            else if(toppingTypeToLower == "veggies")
            {
                return baseCaloriesPerGram * veggiesModifier;
            }

            else if(toppingTypeToLower == "cheese")
            {
                return baseCaloriesPerGram * cheeseModifier;
            }

            else if(toppingTypeToLower == "sauce")
            {
                return baseCaloriesPerGram * sauceModifier;
            }

            return 0.00;
        }
    }
}
