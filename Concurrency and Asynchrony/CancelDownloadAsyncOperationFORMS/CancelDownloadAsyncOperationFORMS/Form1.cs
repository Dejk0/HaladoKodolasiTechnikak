using System.Diagnostics;

namespace CancelDownloadAsyncOperationFORMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                s_cts.CancelAfter(3500);
                await SumPageSizesAsync();
            }
            catch (OperationCanceledException)
            {
                AddListItem("The operation was canceled");
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            s_cts.Cancel(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
         readonly CancellationTokenSource s_cts = new CancellationTokenSource();

         readonly HttpClient s_client = new HttpClient
        {
            MaxResponseContentBufferSize = 1_000_000
        };

         readonly IEnumerable<string> s_urlList = new string[]
        {
    "https://learn.microsoft.com",
    "https://learn.microsoft.com/aspnet/core",
    "https://learn.microsoft.com/azure",
    "https://learn.microsoft.com/azure/devops",
    "https://learn.microsoft.com/dotnet",
    "https://learn.microsoft.com/dynamics365",
    "https://learn.microsoft.com/education",
    "https://learn.microsoft.com/enterprise-mobility-security",
    "https://learn.microsoft.com/gaming",
    "https://learn.microsoft.com/graph",
    "https://learn.microsoft.com/microsoft-365",
    "https://learn.microsoft.com/office",
    "https://learn.microsoft.com/powershell",
    "https://learn.microsoft.com/sql",
    "https://learn.microsoft.com/surface",
    "https://learn.microsoft.com/system-center",
    "https://learn.microsoft.com/visualstudio",
    "https://learn.microsoft.com/windows",
    "https://learn.microsoft.com/maui"
        };
        private void AddListItem(string text)
        {

            ListViewItem listViewItem = new ListViewItem();
            TextBox textBox = new TextBox();
            textBox.Text = text;
            listViewItem.Text = textBox.Text;
            listView1.Items.Add(listViewItem);


        }
        private async Task SumPageSizesAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            int total = 0;
            foreach (string url in s_urlList)
            {
                int contentLength = await ProcessUrlAsync(url, s_client, s_cts.Token);
                total += contentLength;
            }

            stopwatch.Stop();

            AddListItem($"Total bytes returned:  {total:#,#}");
            AddListItem($"Elapsed time:          {stopwatch.Elapsed}");
        }
        private async Task<int> ProcessUrlAsync(string url, HttpClient client, CancellationToken token)
        {
            HttpResponseMessage response = await client.GetAsync(url, token);
            byte[] content = await response.Content.ReadAsByteArrayAsync(token);
            AddListItem($"{url,-60} {content.Length,10:#,#}");
            
            return content.Length;
        }

    }
}
