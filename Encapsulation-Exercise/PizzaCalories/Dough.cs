using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseCaloriesPerGram = 2;
        private const double WhiteModifier = 1.5;
        private const double WholegrainModifier = 1.0;
        private const double CrispyModifier = 0.9;
        private const double ChewyModifier = 1.1;
        private const double HomemadeModifier = 1.0;
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
                return BaseCaloriesPerGram * WhiteModifier * CrispyModifier;
            }

            else if (flourTypeToLower == "white" && bakingTechniqueToLower == "chewy")
            {
                return BaseCaloriesPerGram * WhiteModifier * ChewyModifier;
            }

            else if (flourTypeToLower == "white" && bakingTechniqueToLower == "homemade")
            {
                return BaseCaloriesPerGram * WhiteModifier * HomemadeModifier;
            }

            else if (flourTypeToLower == "wholegrain" && bakingTechniqueToLower == "crispy")
            {
                return BaseCaloriesPerGram * WholegrainModifier * CrispyModifier;
            }

            else if (flourTypeToLower == "wholegrain" && bakingTechniqueToLower == "chewy")
            {
                return BaseCaloriesPerGram * WholegrainModifier * ChewyModifier;
            }

            else if (flourTypeToLower == "wholegrain" && bakingTechniqueToLower == "homemade")
            {
                return BaseCaloriesPerGram * WholegrainModifier * HomemadeModifier;
            }

            return 0.0;
        }
    }
}
