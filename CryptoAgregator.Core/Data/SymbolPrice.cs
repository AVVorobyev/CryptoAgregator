namespace CryptoAgregator.Core.Data
{
    public class SymbolPrice : Symbol
    {
        public decimal Price { get; protected set; }

        public SymbolPrice(string name, decimal price) : base(name)
        {
            Price = price;
        }
    }
}
