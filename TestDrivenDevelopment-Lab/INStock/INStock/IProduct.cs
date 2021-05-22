namespace INStock
{
    public interface IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}
