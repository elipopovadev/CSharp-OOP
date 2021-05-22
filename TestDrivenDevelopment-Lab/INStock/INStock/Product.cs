using System;

namespace INStock
{
    public class Product : IProduct
    {
        private string name;
        private decimal price;
        private int quantity;
        public Product(string name, decimal price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name of product should not be null");
                }

                name = value;
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
