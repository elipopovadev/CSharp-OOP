using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;
        private const double BaseCaloriesPerGram = 2;
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
                return BaseCaloriesPerGram * MeatModifier;
            }

            else if(toppingTypeToLower == "veggies")
            {
                return BaseCaloriesPerGram * VeggiesModifier;
            }

            else if(toppingTypeToLower == "cheese")
            {
                return BaseCaloriesPerGram * CheeseModifier;
            }

            else if(toppingTypeToLower == "sauce")
            {
                return BaseCaloriesPerGram * SauceModifier;
            }

            return 0.00;
        }
    }
}
