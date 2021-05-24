namespace INStock
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var productStock = new ProductStock();
            var product = new Product("testProduct", 4.60m, 5);
            var newProduct = new Product("testProduct2", 5, 7);
            var anotherProduct = new Product("testProduct3", 4, 8);
            productStock.Add(product);
            productStock.Add(newProduct);
            productStock.Add(anotherProduct);
            Console.WriteLine(productStock[3].Label);
        }
    }
}
