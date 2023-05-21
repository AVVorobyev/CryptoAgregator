using Binance.Net.Interfaces.Clients;
using CryptoAgregator.Core;
using CryptoAgregator.Core.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CryptoAgregator.BinanceAgregator
{
    public class BinanceAgregator : Agregator
    {
        private readonly IBinanceClient _client;
        private readonly ILogger<BinanceAgregator> _logger;

        public BinanceAgregator(IBinanceClient client, ILogger<BinanceAgregator> logger)
        {
            _client = client;
            _logger = logger ?? NullLogger<BinanceAgregator>.Instance;
        }

        public override async Task<Result<SymbolPrice>> GetCurrentPriceAsync(string symbol)
        {
            _logger.LogInformation("Getting a current symbol price: Symbol: {symbol}", symbol);

            try
            {
                var result = await _client
                    .SpotApi
                    .ExchangeData
                    .GetPriceAsync(symbol);

                if (result.Success)
                {
                    return Result<SymbolPrice>.Success(
                    new SymbolPrice(result.Data.Symbol, result.Data.Price));
                }
                else
                {
                    return Result<SymbolPrice>.Fail(
                        new Exception(result.Error!.Message),
                        result.Error.Message);
                }
            }
            catch (Exception e)
            {
                return Result<SymbolPrice>.Fail(e, e.Message);
            }
        }

        public override async Task<Result<IEnumerable<Symbol>>> GetSymbolsAsync()
        {
            _logger.LogInformation("Getting a list of symbols. Agregator: {Agregator}", nameof(BinanceAgregator));

            try
            {
                var result = await _client.SpotApi.ExchangeData.GetTickersAsync();

                if (!result.Success)
                {
                    return Result<IEnumerable<Symbol>>.Fail(
                        new Exception(result.Error!.Message),
                        result.Error.Message);
                }

                List<Symbol> symbols = new();

                foreach (var symbol in result.Data)
                {
                    symbols.Add(new Symbol(symbol.Symbol));
                }

                return Result<IEnumerable<Symbol>>.Success(symbols);
            }
            catch (Exception e)
            {
                return Result<IEnumerable<Symbol>>.Fail(e, e.Message);
            }
        }
    }
}