namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double GramsFish = 22;
        public Fish(string name, decimal price) : base(name, price, GramsFish)
        {
        }
    }
}
