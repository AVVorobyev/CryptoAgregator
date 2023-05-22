using Binance.Net.Clients;
using Bybit.Net.Clients;
using Kucoin.Net.Clients;
using Mexc.Net.Clients.SpotApi;
using Mexc.Net.Objects;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace CryptoAgregator.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            var serilogLogger = new LoggerConfiguration()
                .WriteTo.File("log.txt")
                .CreateLogger();

            var binanceLogger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger<BinanceAgregator.BinanceAgregator>();

            var binanceAgregator = new BinanceAgregator.BinanceAgregator(new BinanceClient(), binanceLogger);

            var mexcLogger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger<MexcAgregator.MexcAgregator>();

            var mexcAgrregator = new MexcAgregator.MexcAgregator(
                new MexcClientSpotApi(
                    new CryptoExchange.Net.Logging.Log("mexcLog"), new MexcClientOptions()),
                    mexcLogger);

            var bybitLogger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger<BybitAgregator.BybitAgregator>();

            var bybitAgregator = new BybitAgregator.BybitAgregator(
                new BybitClient(), bybitLogger);

            var kucoinLogger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger<KucionAgregator.KucionAgregator>();

            var kucoinAgregator = new KucionAgregator.KucionAgregator(
                new KucoinClient(), kucoinLogger);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(
                binanceAgregator,
                bybitAgregator,
                mexcAgrregator,
                kucoinAgregator
                ));
        }
    }
}