namespace GreedyTimes
{
    public class Cash
    {
        public Cash(string currency, long quantity)
        {
            this.Currency = currency;
            this.Quantity = quantity;
        }

        public string Currency { get; set; }
        public long Quantity { get; set; }
    }
}
