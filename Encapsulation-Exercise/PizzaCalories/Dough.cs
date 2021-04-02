using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double baseCaloriesPerGram = 2;
        private const double whiteModifier = 1.5;
        private const double wholegrainModifier = 1.0;
        private const double crispyModifier = 0.9;
        private const double chewyModifier = 1.1;
        private const double homemadeModifier = 1.0;
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get => flourType;
            set
            {
                string valueToLower = value.ToLower();
                if (valueToLower == "white" || valueToLower == "wholegrain")
                {
                    flourType = value;
                }

                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        private string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                string valueToLower = value.ToLower();
                if (valueToLower == "crispy" || valueToLower == "chewy" || valueToLower == "homemade")
                {
                    bakingTechnique = value;
                }

                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

                weight = value;
            }
        }

        public double CaloriesPerGram => this.CalculateTotalCalories();

        private double CalculateTotalCalories()
        {
            string flourTypeToLower = this.FlourType.ToLower();
            string bakingTechniqueToLower = this.BakingTechnique.ToLower();
            if (flourTypeToLower == "white" && bakingTechniqueToLower == "crispy")
            {
                return baseCaloriesPerGram * whiteModifier * crispyModifier;
            }

            else if (flourTypeToLower == "white" && bakingTechniqueToLower == "chewy")
            {
                return baseCaloriesPerGram * whiteModifier * chewyModifier;
            }

            else if (flourTypeToLower == "white" && bakingTechniqueToLower == "homemade")
            {
                return baseCaloriesPerGram * whiteModifier * homemadeModifier;
            }

            else if (flourTypeToLower == "wholegrain" && bakingTechniqueToLower == "crispy")
            {
                return baseCaloriesPerGram * wholegrainModifier * crispyModifier;
            }

            else if (flourTypeToLower == "wholegrain" && bakingTechniqueToLower == "chewy")
            {
                return baseCaloriesPerGram * wholegrainModifier * chewyModifier;
            }

            else if (flourTypeToLower == "wholegrain" && bakingTechniqueToLower == "homemade")
            {
                return baseCaloriesPerGram * wholegrainModifier * homemadeModifier;
            }

            return 0.0;
        }
    }
}
