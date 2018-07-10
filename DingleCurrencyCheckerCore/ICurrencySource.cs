using System.Collections.Generic;
using System.Threading.Tasks;

namespace DingleCurrencyChecker.Core
{
    public interface ICurrencySource
    {
        Dictionary<string, string> GetAvailableCurrencies();

        Dictionary<string, decimal> GetCurrencies(string currencyCodes);
    }
}
