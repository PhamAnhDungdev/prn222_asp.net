using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsynchromousDemonstration03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly HttpClient client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

        private readonly IEnumerable<string> UrlList = new string[]
        {
            "http://docs.microsoft.com",
             "http://docs.microsoft.com/azure",
              "http://docs.microsoft.com/powershell",
              "http://docs.microsoft.com/dotnet",
              "http://docs.microsoft.com/aspnet/core",
              "http://docs.microsoft.com/windows",
        };

        private async void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            btnStartButton.IsEnabled = false;
            txtResults.Clear();
            await SumPageSizeAsync();
            txtResults.Text += $"\n Control returned to {nameof(OnStartButtonClick)}";
            btnStartButton.IsEnabled = true;
        }

        private async Task SumPageSizeAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            int total = 0;
            foreach (string url in UrlList)
            {
                int contentLength = await ProcessUrlAsync(url, client);
                total += contentLength;
            }
            stopwatch.Stop();
            txtResults.Text += $"\nTotal bytes returned: {total: #,#}";
            txtResults.Text += $"\nElapsed time:         {stopwatch.Elapsed}";
        }

        private async Task<int> ProcessUrlAsync(string url, HttpClient client)
        {
            byte[] content = await client.GetByteArrayAsync(url);
            DisplayResult(url, content);
            return content.Length;
        }

        private void DisplayResult(string url, byte[] content) => txtResults.Text += $"{url, -60} {content.Length, 10: #,#}";

        protected override void OnClosed(EventArgs e)
        {
            client.Dispose();
        }
    }
}