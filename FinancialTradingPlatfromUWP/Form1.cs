using StockMarketComponent;
namespace FinancialTradingPlatfromUWP
{
    public partial class Form1 : Form
    {
        string _data = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddListItem($"Fast Local Operation Complated - ThreadId - {Thread.CurrentThread.ManagedThreadId}");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AddListItem(string item)
        {
            ListViewItem listViewItem = new ListViewItem();
            TextBox textBox = new TextBox();
            textBox.Text = item;
            listViewItem.Text = textBox.Text;
            listView1.Items.Add(listViewItem);


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_data))
            {
                StakMarketData stakMarketData = new StakMarketData();
                _data = await stakMarketData.GetDataAsync();
            }

            StockMarketDataAnalyst stockMarketDataAnalyst = new StockMarketDataAnalyst(_data);
            List<Task<string>> tasks = new List<Task<string>>();
            tasks.Add(Task.Run(() => stockMarketDataAnalyst.GetOpeningPrices()));
            tasks.Add(Task.Run(() => stockMarketDataAnalyst.CalculateStockastics()));
            tasks.Add(Task.Run(() => stockMarketDataAnalyst.CalculateBollingerbands()));
            tasks.Add(Task.Run(() => stockMarketDataAnalyst.CalculateSlowMovingAverage()));

            //Task.WaitAll(tasks.ToArray());
            await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);

            AddListItem(tasks[0].Result);
            AddListItem(tasks[1].Result);
            AddListItem(tasks[2].Result);
            AddListItem(tasks[3].Result);
        }
        private void DisplayDataOnChart(string data1, string data2, string data3 , string data4 )
        {
            
        }
    }
}
