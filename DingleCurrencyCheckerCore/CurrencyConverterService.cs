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

        public decimal ConvertAmountGivenCurrenCurrencyToExpectedCurrency(decimal amount, string currentCurrencyCode, string expectedCurrencyCode)
        {
            var currencies = _currencySource.GetCurrencies($"{currentCurrencyCode}, {expectedCurrencyCode}");

            if (!currencies.ContainsKey(expectedCurrencyCode) || !currencies.ContainsKey(currentCurrencyCode))
            {
                throw new ArgumentException("NotFound");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("amount must be greater than zero");

            }

            var usdPrice = amount / currencies[currentCurrencyCode];

            return usdPrice * currencies[expectedCurrencyCode];
        }

    }
}
