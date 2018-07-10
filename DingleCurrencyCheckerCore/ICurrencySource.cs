using System.Collections.Generic;
using System.Threading.Tasks;

namespace DingleCurrencyChecker.Core
{
    public interface ICurrencySource
    {
        Task<Dictionary<string, string>> GetAvailableCurrencies();
        Task<Dictionary<string, decimal>> GetCurrencies();
    }
}
