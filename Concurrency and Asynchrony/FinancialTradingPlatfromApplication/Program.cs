using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinancialTradingPlatfromApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Method name: Main, ThreadId {Thread.CurrentThread.ManagedThreadId}");
            StockMarketTechnicalAnalysisData stockMarketTechnicalAnalysisData = new StockMarketTechnicalAnalysisData("AAPL", DateTime.Now.AddDays(-10), DateTime.Now);
            DateTime dateTimeStart = DateTime.Now;
            decimal[] data1 = stockMarketTechnicalAnalysisData.GetOpeningPrices();
            decimal[] data2 = stockMarketTechnicalAnalysisData.GetCloseingPrices();
            decimal[] data3 = stockMarketTechnicalAnalysisData.GetPriceHighs();
            decimal[] data4 = stockMarketTechnicalAnalysisData.GetPriceLows();
            decimal[] data5 = stockMarketTechnicalAnalysisData.CalculateStatistics();
            decimal[] data6 = stockMarketTechnicalAnalysisData.CalculateFastMoveingAverage();
            decimal[] data7 = stockMarketTechnicalAnalysisData.CalculateSlowMoveingAverage();
            decimal[] data8 = stockMarketTechnicalAnalysisData.CalclateUpperBandBollingBand();
            decimal[] data9 = stockMarketTechnicalAnalysisData.CalculateLowerBandBollingBand();
            DateTime dateTimeEnd = DateTime.Now;
            TimeSpan timeSpan = dateTimeEnd - dateTimeStart;
            Console.WriteLine($"Total time taken: {timeSpan.TotalMilliseconds} ms");
            DisplayDataOnChart(data1, data2, data3, data5, data6, data7, data8, data9);
            /*
             * Method name: Main, ThreadId 1
                method name: GetOpeningPrices, ThreadId: 1
                method name: GetCloseingPrices, ThreadId: 1
                method name: GetPriceHighs, ThreadId: 1
                method name: GetPriceLows, ThreadId: 1
                Total time taken: 4023,0084 ms
                Data is dispalyed On Chart
                method name: GetOpeningPrices, ThreadId: 5
                method name: GetCloseingPrices, ThreadId: 10
                method name: GetPriceHighs, ThreadId: 9
                method name: GetPriceLows, ThreadId: 11
                */

            List<Task<decimal[]>> tasks = new List<Task<decimal[]>>();
            
            Task<decimal[]> getOpeningPriceTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetOpeningPrices());
            Task<decimal[]> getCloseingPriceTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetCloseingPrices());
            Task<decimal[]> getPriceHighsTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetPriceHighs());
            Task<decimal[]> getPriceLowsTask = Task.Run(() => stockMarketTechnicalAnalysisData.GetPriceLows());
            Task<decimal[]> getStatisticsTask = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateStatistics());
            Task<decimal[]> getFastMoveingAverageTask = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateFastMoveingAverage());
            Task<decimal[]> getSlowMoveingAverageTask = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateSlowMoveingAverage());
            Task<decimal[]> getUpperBandBollingBandTask = Task.Run(() => stockMarketTechnicalAnalysisData.CalclateUpperBandBollingBand());
            Task<decimal[]> getLowerBandBollingBandTask = Task.Run(() => stockMarketTechnicalAnalysisData.CalculateLowerBandBollingBand());
            tasks.Add(getOpeningPriceTask);
            tasks.Add(getCloseingPriceTask);
            tasks.Add(getPriceHighsTask);
            tasks.Add(getPriceLowsTask);
            tasks.Add(getStatisticsTask);
            tasks.Add(getFastMoveingAverageTask);
            tasks.Add(getSlowMoveingAverageTask);
            tasks.Add(getUpperBandBollingBandTask);
            tasks.Add(getLowerBandBollingBandTask);
            Task.WaitAll(tasks.ToArray());

             data1 = tasks[0].Result;
            data2 = tasks[1].Result;
            data3 = tasks[2].Result;
            data4 = tasks[3].Result;
            data5 = tasks[4].Result;
            data6 = tasks[5].Result;
            data7 = tasks[6].Result;
            data8 = tasks[7].Result;
            data9 = tasks[8].Result;

            DateTime datetimeAfter = DateTime.Now;  

            TimeSpan timeSpan2 = datetimeAfter - dateTimeEnd;
            Console.WriteLine($"Total time taken: {timeSpan2.TotalMilliseconds} ms");
            DisplayDataOnChart(data1, data2, data3, data5, data6, data7, data8, data9);

            /*  Method name: Main, ThreadId 1
                method name: GetOpeningPrices, ThreadId: 1
                method name: GetCloseingPrices, ThreadId: 1
                method name: GetPriceHighs, ThreadId: 1
                method name: GetPriceLows, ThreadId: 1
                Total time taken: 4048,0176 ms
                Data is dispalyed On Chart
                method name: GetOpeningPrices, ThreadId: 5
                method name: GetPriceHighs, ThreadId: 9
                method name: GetCloseingPrices, ThreadId: 10
                method name: GetPriceLows, ThreadId: 11
                Total time taken: 1016,9731 ms
                Data is dispalyed On Chart
            */

            /*Method name: Main, ThreadId 1
            method name: GetOpeningPrices, ThreadId: 1
            method name: GetCloseingPrices, ThreadId: 1
            method name: GetPriceHighs, ThreadId: 1
            method name: GetPriceLows, ThreadId: 1
            method name: CalculateStatistics, ThreadId: 1
            method name: CalculateFastMoveingAverage, ThreadId: 1
            method name: CalculateSlowMoveingAverage, ThreadId: 1
            method name: CalclateUpperBandBollingBand, ThreadId: 1
            method name: CalculateLowerBandBollingBand, ThreadId: 1
            Total time taken: 39097,4023 ms
            Data is dispalyed On Chart
            method name: GetOpeningPrices, ThreadId: 11
            method name: GetCloseingPrices, ThreadId: 12
            method name: GetPriceHighs, ThreadId: 13
            method name: GetPriceLows, ThreadId: 14
            method name: CalculateStatistics, ThreadId: 15
            method name: CalculateFastMoveingAverage, ThreadId: 16
            method name: CalculateSlowMoveingAverage, ThreadId: 17
            method name: CalclateUpperBandBollingBand, ThreadId: 18
            method name: CalculateLowerBandBollingBand, ThreadId: 19
            Total time taken: 10038,6941 ms
            Data is dispalyed On Chart
            */
}
public static void DisplayDataOnChart(decimal[] data1, decimal[] data2, decimal[] data3, decimal[] data5, decimal[] data6, decimal[] data7, decimal[] data8, decimal[] data9)
{
Console.WriteLine("Data is dispalyed On Chart");
}
}

public class StockMarketTechnicalAnalysisData
{
public StockMarketTechnicalAnalysisData(string stockSymbol,DateTime dateTimeStart, DateTime dateTimeEnd)
{
//code here gets stock maret data from remote server

}
public decimal[] GetOpeningPrices()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(GetOpeningPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(1000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] GetCloseingPrices()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(GetCloseingPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(1000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] GetPriceHighs()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(GetPriceHighs)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(1000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] GetPriceLows()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(GetPriceLows)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(1000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] CalculateStatistics()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(CalculateStatistics)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(10000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] CalculateFastMoveingAverage()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(CalculateFastMoveingAverage)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(8000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] CalculateSlowMoveingAverage()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(CalculateSlowMoveingAverage)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(7000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] CalclateUpperBandBollingBand()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(CalclateUpperBandBollingBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(5000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
public decimal[] CalculateLowerBandBollingBand()
{
decimal[] data;
Console.WriteLine($"method name: {nameof(CalculateLowerBandBollingBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");

Thread.Sleep(5000);

data = new decimal[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
return data;
}
}


}
