namespace INStock
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class ProductStock : IEnumerable<string>
    {

        public ProductStock()
        {
            this.ProductPerLabel = new Dictionary<string, Product>();
            this.Products = new List<Product>();
            this.ProductsPerPrice = new SortedList<decimal, HashSet<Product>>(); // in descending order
            this.ProductsPerQuantity = new SortedList<int, HashSet<Product>>();
        }

        public Dictionary<string, Product> ProductPerLabel { get; }
        public List<Product> Products { get; }
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

        public Product Find(int index)
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

        public List<Product> FindAllInPriceRange(decimal priceFrom, decimal priceTo)
        {
            List<Product> resultInDescendingOrder = new List<Product>();
            IList<decimal> keys = ProductsPerPrice.Keys;

            if (keys.Contains(priceTo) == false)
            {
                return resultInDescendingOrder; // empty
            }

            if (priceTo > keys[0])
            {
                priceTo = keys[0];
            }

            if (priceFrom < keys.Last())
            {
                priceFrom = keys.Last();
            }

            foreach (decimal price in keys)
            {
                if (price <= priceTo && price >= priceFrom)
                {
                    resultInDescendingOrder.AddRange(ProductsPerPrice[price]);
                }
            }
            return resultInDescendingOrder;
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

        public Product FindMostExpensiveProducts()
        {
            return ProductsPerPrice[0].First();
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

        public IEnumerator<string> GetEnumerator()
        {
            foreach ((var label, var product) in this.ProductPerLabel)
            {
                yield return $"{label} {product.Price} {product.Quantity}";
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Product this[int index]
        {
            get
            {
                return Products[index];
            }

            set
            {
                if(index >= 0 && index <= Products.Count)
                {
                    Products[index] = value;
                }
            }
        }
    }
}
