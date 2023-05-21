using CryptoAgregator.Core;
using CryptoAgregator.Core.Data;
using Mexc.Net.Interfaces.Clients.SpotApi;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CryptoAgregator.MexcAgregator
{
    public class MexcAgregator : Agregator
    {
        private readonly IMexcClientSpotApi _client;
        private readonly ILogger<MexcAgregator>? _logger;

        public MexcAgregator(IMexcClientSpotApi client, ILogger<MexcAgregator> logger)
        {
            _client = client;
            _logger = logger ?? NullLogger<MexcAgregator>.Instance;
        }

        public override async Task<Result<SymbolPrice>> GetCurrentPriceAsync(string symbol)
        {
            _logger.LogInformation("Getting a current symbol price: Symbol: {symbol}", symbol);

            try
            {
                var result = await _client.ExchangeData.GetPriceAsync(symbol);

                if (result.Success)
                {
                    return Result<SymbolPrice>.Success(
                        new SymbolPrice(result.Data.Symbol, (decimal)result.Data.Price!));
                }
                else
                {
                    return Result<SymbolPrice>.Fail(
                        new Exception(result.Error!.Message), result.Error.Message);
                }
            }
            catch (Exception e)
            {
                return Result<SymbolPrice>.Fail(e, e.Message);
            }
        }

        public async override Task<Result<IEnumerable<Symbol>>> GetSymbolsAsync()
        {
            _logger.LogInformation("Getting a list of symbols");

            try
            {
                var result = await _client.ExchangeData.GetExchangeInfoAsync();

                if (result.Success)
                {
                    List<Symbol> symbolsList = new();

                    foreach (var symbol in result.Data.Symbols)
                    {
                        symbolsList.Add(new Symbol(symbol.Name));
                    }

                    return Result<IEnumerable<Symbol>>.Success(symbolsList);
                }
                else
                {
                    return Result<IEnumerable<Symbol>>.Fail(
                        new Exception(result.Error!.Message), result.Error.Message);
                }
            }
            catch (Exception e)
            {
                return Result<IEnumerable<Symbol>>.Fail(e, e.Message);
            }
        }
    }
}