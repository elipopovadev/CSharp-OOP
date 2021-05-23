namespace INStock
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stock = new ProductStock();
            var peach = new Product("peach", 4, 5);
            var appricot = new Product("appricot", 3, 5);
            stock.Add(peach);
            stock.Add(appricot);
            foreach (var product in stock)
            {
                Console.WriteLine(product);
            }
        }
    }
}
