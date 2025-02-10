using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace StockMarketDataAnalysisWepApi_SAAS.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class StockMarketDataAnalisyController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            StockMarketDataAnalyst stockMarketDataAnalyst = new StockMarketDataAnalyst("Stockmarket Data");
           
            string data1 = stockMarketDataAnalyst.GetOpeningPrices();
            string data2 =  stockMarketDataAnalyst.CalculateSlowMovingAverage();
            string data3 = await stockMarketDataAnalyst.CalculateStockastics();
            string data4 = stockMarketDataAnalyst.CalculateBollingerbands();

            return Content($"{data1}, {data2}, {data3}, {data4}");
            /*
             * GetOpeningPrices - ThreadId: 9, CalculateSlowMovingAverage - ThreadId: 9, CalculateStockastics - ThreadId: 32, CalculateBollingerbands - ThreadId: 32
             */
           }
        public class StockMarketDataAnalyst
        {
            public StockMarketDataAnalyst(string data)
            {


            }

            public string GetOpeningPrices()
            {
                string data;

                Thread.Sleep(6000);

                data = $"{nameof(GetOpeningPrices)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
                return data;
            }
            public string CalculateSlowMovingAverage()
            {
                string data;

                Thread.Sleep(7000);

                data = $"{nameof(CalculateSlowMovingAverage)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
                return data;
            }
            public async Task<string> CalculateStockastics()
            {
                string data = await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    return $"{nameof(CalculateStockastics)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
                });

                return data;
            }
            public string CalculateBollingerbands()
            {
                string data;
                Thread.Sleep(5000);
                data = $"{nameof(CalculateBollingerbands)} - ThreadId: {Thread.CurrentThread.ManagedThreadId}";
                return data;
            }


        }
    }
}
