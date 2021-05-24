namespace INStock
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class ProductStock : IEnumerable<Product>
    {

        public ProductStock()
        {
            this.ProductPerLabel = new Dictionary<string, Product>();
            this.Products = new List<IProduct>();
            this.ProductsPerPrice = new SortedList<decimal, HashSet<Product>>(); 
            this.ProductsPerQuantity = new SortedList<int, HashSet<Product>>();
        }

        public Dictionary<string, Product> ProductPerLabel { get; }
        public List<IProduct> Products { get; }
        public SortedList<decimal, HashSet<Product>> ProductsPerPrice { get; }
        public SortedList<int, HashSet<Product>> ProductsPerQuantity { get; }

        public void Add(Product product)
        {
            ProductPerLabel.Add(product.Label, product); // O(1)
            Products.Add(product); // O(N)
            if (ProductsPerPrice.ContainsKey(product.Price) == false)
            {
                ProductsPerPrice.Add(product.Price, new HashSet<Product>());
                ProductsPerPrice[product.Price].Add(product);
            }
            else
            {
                ProductsPerPrice[product.Price].Add(product);
            }

            if (ProductsPerQuantity.ContainsKey(product.Quantity) == false)
            {
                ProductsPerQuantity.Add(product.Quantity, new HashSet<Product>());
                ProductsPerQuantity[product.Quantity].Add(product);
            }
            else
            {
                ProductsPerQuantity[product.Quantity].Add(product);
            }
        }

        public bool Contains(Product product)
        {
            return ProductPerLabel.ContainsKey(product.Label); // O(1)
        }

        public IProduct Find(int index)
        {
            if (index < 0 && index > ProductPerLabel.Count)
            {
                throw new ArgumentOutOfRangeException("The index is invalid");
            }
            return Products[index]; // O(1)
        }

        public Product FindByLabel(string label)
        {
            Product product = ProductPerLabel.Where(p => p.Key == label).FirstOrDefault().Value; // O(1)
            if (product == null)
            {
                throw new ArgumentException("The product does not exist in Stock");
            }
            return product;
        }

        public List<IProduct> FindAllInPriceRange(decimal From, decimal To)
        {
            List<IProduct> result = new List<IProduct>();
            IList<decimal> keys = ProductsPerPrice.Keys;

            if(keys[0] > To)
            {
                return result; // Empty
            }

            var priceFrom = Math.Max(From, keys[0]);
            var priceTo = Math.Min(To, keys.Last());

            foreach (decimal price in keys)
            {
                if (price >= priceFrom && price <= priceTo)
                {
                    result.AddRange(ProductsPerPrice[price]);
                }
            }

            result.Reverse();
            return result;
        }

        public ICollection<Product> FindAllByPrice(decimal price)
        {
            var keys = ProductsPerPrice.Keys;
            if (keys.Contains(price) == false)
            {
                return new HashSet<Product>();
            }

            return ProductsPerPrice[price];
        }

        public Product FindMostExpensiveProduct()
        {
            HashSet<Product> listWithProducts = ProductsPerPrice.Values.Last();
            return listWithProducts.First();
        }

        public ICollection<Product> FindAllByQuantity(int quantity)
        {
            var keys = ProductsPerQuantity.Keys;
            if (keys.Contains(quantity) == false)
            {
                return new HashSet<Product>();
            }
            return ProductsPerQuantity[quantity];
        }

        public IEnumerator<Product> GetEnumerator()
        {
            foreach ((var label, var product) in this.ProductPerLabel)
            {
                yield return product;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IProduct this[int index]
        {
            get => this.Find(index);
            set
            {
                if(index >= 0 && index <= Products.Count)
                {
                    this.Products[index] = value;
                }
            }
        }
    }
}
