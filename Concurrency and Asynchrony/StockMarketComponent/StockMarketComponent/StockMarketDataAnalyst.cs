using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketComponent
{
    public class StockMarketDataAnalyst
    {
        public StockMarketDataAnalyst(string data) {
        
            
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
