using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DingleCurrencyChecker.Core
{
    public class CurrencyConverterService
    {
        private ICurrencySource _currencySource;

        public CurrencyConverterService(ICurrencySource currencySource)
        {

            _currencySource = currencySource;
        }

        public async Task<decimal> ConvertPriceGivenCurrenCurrencyToExpectedCurrency(decimal actualPrice, string currentCurrencyCode, string expectedCurrencyCode)
        {
            var currencies = await _currencySource.GetCurrencies();

            if (!currencies.ContainsKey(expectedCurrencyCode) || !currencies.ContainsKey(currentCurrencyCode))
            {
                throw new ArgumentException("NotFound");
            }

            var usdPrice = actualPrice / currencies[currentCurrencyCode];

            return usdPrice * currencies[expectedCurrencyCode];
        }

    }
}
