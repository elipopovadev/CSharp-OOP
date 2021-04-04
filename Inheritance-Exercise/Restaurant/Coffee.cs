namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double  CoffeMilliliteres = 50;
        private const decimal CofeePrice = 3.50m;

        public Coffee(string name, double caffeine) : base(name, CofeePrice, CoffeMilliliteres)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
