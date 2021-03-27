namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double  coffeMilliliteres = 50;
        private const decimal cofeePrice = 3.50m;

        public Coffee(string name, double caffeine) : base(name, cofeePrice, coffeMilliliteres)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
