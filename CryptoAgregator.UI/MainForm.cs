using CryptoAgregator.Core.Data;

namespace CryptoAgregator.UI
{
    public partial class MainForm : Form
    {
        private readonly BinanceAgregator.BinanceAgregator _binanceAgregator;
        private readonly BybitAgregator.BybitAgregator _bybitAgregator;
        private readonly MexcAgregator.MexcAgregator _mexcAgregator;
        private readonly KucionAgregator.KucionAgregator _kucionAgregator;

        private CancellationToken _binanceCancellationToken;
        private CancellationTokenSource _binanceCancellationTokenSource;

        private CancellationToken _kucoinCancellationToken;
        private CancellationTokenSource _kucoinCancellationTokenSource;

        private CancellationToken _bybitCancellationToken;
        private CancellationTokenSource _bybitCancellationTokenSource;

        private CancellationToken _mexcCancellationToken;
        private CancellationTokenSource _mexcCancellationTokenSource;

        public MainForm(
            BinanceAgregator.BinanceAgregator binanceAgregator,
            BybitAgregator.BybitAgregator bybitAgregator,
            MexcAgregator.MexcAgregator mexcAgregator,
            KucionAgregator.KucionAgregator kucionAgregator)
        {
            _binanceAgregator = binanceAgregator;
            _bybitAgregator = bybitAgregator;
            _mexcAgregator = mexcAgregator;
            _kucionAgregator = kucionAgregator;

            _binanceCancellationTokenSource = new CancellationTokenSource();
            _mexcCancellationTokenSource = new CancellationTokenSource();
            _bybitCancellationTokenSource = new CancellationTokenSource();
            _kucoinCancellationTokenSource = new CancellationTokenSource();

            InitializeComponent();

            _ = InitSymbolsList(_bybitAgregator, binanceSymbolsList);
            _ = InitSymbolsList(_mexcAgregator, mexcSymbolsList);
            _ = InitSymbolsList(_bybitAgregator, bybitSymbolsList);
            _ = InitSymbolsList(_kucionAgregator, kucoinSymbolsList);
        }

        private async void binanceSymbolsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_binanceCancellationToken.CanBeCanceled)
            {
                _binanceCancellationTokenSource.Cancel();
            }

            _binanceCancellationTokenSource = new CancellationTokenSource();

            _binanceCancellationToken = _binanceCancellationTokenSource.Token;

            var symbol = binanceSymbolsList.SelectedItem.ToString();

            if (symbol == null)
            {
                return;
            }

            await GetPriceAsync(_binanceAgregator, symbol, binanceSymbolPriceTextBox, _binanceCancellationToken);
        }

        private async void bybitSymbolsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_bybitCancellationToken.CanBeCanceled)
            {
                _bybitCancellationTokenSource.Cancel();
            }

            _bybitCancellationTokenSource = new CancellationTokenSource();

            _bybitCancellationToken = _bybitCancellationTokenSource.Token;

            var symbol = bybitSymbolsList.SelectedItem.ToString();

            if (symbol == null)
            {
                return;
            }

            await GetPriceAsync(_bybitAgregator, symbol, bybitSymbolPriceTextBox, _bybitCancellationToken);
        }

        private async void kucoinSymbolsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_kucoinCancellationToken.CanBeCanceled)
            {
                _kucoinCancellationTokenSource.Cancel();
            }

            _kucoinCancellationTokenSource = new CancellationTokenSource();

            _kucoinCancellationToken = _kucoinCancellationTokenSource.Token;

            var symbol = kucoinSymbolsList.SelectedItem.ToString();

            if (symbol == null)
            {
                return;
            }

            await GetPriceAsync(_kucionAgregator, symbol, kucoinSymbolPriceTextBox, _kucoinCancellationToken);
        }

        private async void mexcSymbolsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_mexcCancellationToken.CanBeCanceled)
            {
                _mexcCancellationTokenSource.Cancel();
            }

            _mexcCancellationTokenSource = new CancellationTokenSource();

            _mexcCancellationToken = _mexcCancellationTokenSource.Token;

            var symbol = mexcSymbolsList.SelectedItem.ToString();

            if (symbol == null)
            {
                return;
            }

            await GetPriceAsync(_mexcAgregator, symbol, mexcSymbolPriceTextBox, _mexcCancellationToken);
        }

        private static async Task GetPriceAsync(Agregator agregator, string symbolName, TextBox textBox, CancellationToken token)
        {
            while (true)
            {
                var result = await agregator.GetCurrentPriceAsync(symbolName);

                if (result.Succeeded)
                {
                    textBox.Text = $"{result.Model?.Name}: {result.Model?.Price}";
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage);
                }

                await Task.Delay(5000, CancellationToken.None);

                if (token.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        private static async Task InitSymbolsList(Agregator agregator, ListBox symbolsListBox)
        {
            symbolsListBox.Items.Add("Please, wait...");

            var result = await agregator.GetSymbolsAsync();

            if (result.Succeeded)
            {
                symbolsListBox.Items.Clear();

                symbolsListBox.Items.AddRange(result.Model!
                    .Select(s => s.Name).ToArray());

                symbolsListBox.Enabled = true;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
        }
    }
}
