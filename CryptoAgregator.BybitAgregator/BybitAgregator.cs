using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using CryptoAgregator.Core;
using CryptoAgregator.Core.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace CryptoAgregator.BybitAgregator
{
    public class BybitAgregator : Agregator
    {
        private readonly IBybitClient _client;
        private readonly ILogger<BybitAgregator>? _logger;

        public BybitAgregator(IBybitClient client, ILogger<BybitAgregator> logger)
        {
            _client = client;
            _logger = logger ?? NullLogger<BybitAgregator>.Instance;
        }

        public override async Task<Result<SymbolPrice>> GetCurrentPriceAsync(string symbol)
        {
            _logger.LogInformation("Getting a current symbol price: Symbol: {symbol}", symbol);

            try
            {
                var result = await _client.SpotApiV3.ExchangeData.GetPriceAsync(symbol);

                if (result.Success)
                {
                    return Result<SymbolPrice>.Success(
                        new SymbolPrice(result.Data.Symbol, result.Data.Price));
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

        public override async Task<Result<IEnumerable<Symbol>>> GetSymbolsAsync()
        {
            _logger.LogInformation("Getting a list of symbols. Agregator: {Agregator}", nameof(BybitAgregator));

            try
            {
                var result = await _client.SpotApiV3.ExchangeData.GetSymbolsAsync();

                if (result.Success)
                {
                    List<Symbol> symbolsList = new();

                    foreach (var symbol in result.Data)
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