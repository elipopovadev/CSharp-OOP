using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name
        { 
            get => name; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName));
                }

                name = value;
            }
        }

        public int Portion
        {
            get => portion;
            set
            {
                if(portion <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPortion));
                }

                portion = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if(price <= 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPrice));
                }

                price = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string value = $"{this.Name}: {this.Portion}g - {this.Price:F2}";
            sb.AppendLine(value);
            return sb.ToString().TrimEnd();
        }
    }
}
