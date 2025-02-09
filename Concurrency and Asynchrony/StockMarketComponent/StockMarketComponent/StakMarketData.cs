using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketComponent
{
    public  class StakMarketData
    {
        public StakMarketData()
        {
            
        }

        public async Task< string> GetDataAsync()
        {
            Task.Delay(5000);
            return "Stockmarket Data";
        }
    }
}
