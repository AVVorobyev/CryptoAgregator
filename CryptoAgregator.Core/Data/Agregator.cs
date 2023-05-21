namespace CryptoAgregator.Core.Data
{
    public abstract class Agregator
    {
        public abstract Task<Result<IEnumerable<Symbol>>> GetSymbolsAsync();
        public abstract Task<Result<SymbolPrice>> GetCurrentPriceAsync(string symbol);
    }
}
