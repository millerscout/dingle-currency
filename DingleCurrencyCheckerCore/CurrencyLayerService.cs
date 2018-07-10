using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DingleCurrencyChecker.Core
{
    public class CurrencyLayerService : ICurrencySource
    {
        public async Task<Dictionary<string, string>> GetAvailableCurrencies()
        {

            //http://apilayer.net/api/list?access_key=aad525d185d203a74429647e1ef094f9

            await Task.Yield();
            return new Dictionary<string, string>();
        }

        public Task<Dictionary<string, decimal>> GetCurrencies()
        {
            throw new NotImplementedException();
        }
    }
}
