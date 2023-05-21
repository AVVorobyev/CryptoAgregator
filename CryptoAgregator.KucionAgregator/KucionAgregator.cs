using CryptoAgregator.Core;
using CryptoAgregator.Core.Data;
using Kucoin.Net.Interfaces.Clients;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;

namespace CryptoAgregator.KucionAgregator
{
    public class KucionAgregator : Agregator
    {
        private readonly IKucoinClient _client;
        private readonly ILogger<KucionAgregator> _logger;

        public KucionAgregator(IKucoinClient client, ILogger<KucionAgregator> logger)
        {
            _client = client;
            _logger = logger ?? NullLogger<KucionAgregator>.Instance;
        }

        public override async Task<Result<SymbolPrice>> GetCurrentPriceAsync(string symbol)
        {
            _logger.LogInformation("Getting a current symbol price: Symbol: {symbol}", symbol);

            try
            {
                var result = await _client
                    .SpotApi
                    .ExchangeData
                    .GetMarginMarkPriceAsync(symbol);

                if (result.Success)
                {
                    return Result<SymbolPrice>.Success(
                        new SymbolPrice(result.Data.Symbol, result.Data.Value));
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
            _logger.LogInformation("Getting a list of symbols. Agregator: {Agregator}", nameof(KucionAgregator));

            try
            {
                var result = await _client.SpotApi.ExchangeData.GetSymbolsAsync();

                if (result.Success)
                {
                    List<Symbol> symbolsList = new();

                    foreach (var symbol in result.Data)
                    {
                        symbolsList.Add(new Symbol(symbol.Symbol));
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