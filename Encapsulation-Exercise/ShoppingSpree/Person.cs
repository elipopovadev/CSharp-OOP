using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        public Person(string name, decimal money)
        {
            this.Name = name; // property
            this.Money = money; // property
            this.bagOfProducts = new List<Product>(); // field
        }

        public string Name
        {
            get 
            {
                return name; // field
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;  // field
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }


        public IReadOnlyCollection<Product> BagOfProducts 
        {
            get
            {
                return bagOfProducts.AsReadOnly();
            }
        }

        public void AddProduct(Product product)
        {
            if(this.Money >= product.Cost)
            {
                bagOfProducts.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }

            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);
            sb.Append(" - ");
            if (this.bagOfProducts.Count == 0)
            {
                sb.Append("Nothing bought");
            }

            else
            {
                sb.Append(string.Join(", ", this.bagOfProducts.Select(pr => pr.Name)));
            }
           
            return sb.ToString();
        }
    }
}
