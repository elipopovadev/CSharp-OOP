using System;

namespace INStock
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Label
        {
            get => label;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of product should not be null");
                }

                label = value;
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if(value == 0)
                {
                    throw new ArgumentOutOfRangeException("The price can not be zero");
                }

                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price can not be negative number");
                }

                price = value;
            }           
        }


        public int Quantity
        {
            get => quantity;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("The quantity can not be negative number");
                }

                quantity = value;
            }
        }
    }
}
