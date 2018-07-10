using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DingleCurrencyChecker.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DingleCurrencyChecker.Controllers
{
    [Produces("application/json")]
    [Route("api/Currencies")]
    public class CurrenciesController : Controller
    {
        private ICurrencySource _currencyService;
        private CurrencyConverterService _currencyConverterService;

        public CurrenciesController(ICurrencySource currencyService, CurrencyConverterService currencyConverterService)
        {
            _currencyService = currencyService;
            _currencyConverterService = currencyConverterService;
        }

        [HttpGet]
        [HttpGet("list")]
        public Dictionary<string, string> Get() => _currencyService.GetAvailableCurrencies();

        [HttpGet]
        [HttpGet("{from}/{to}/{amount}")]
        public decimal Convert(string from, string to, decimal amount)
        {
            return _currencyConverterService.ConvertAmountGivenCurrenCurrencyToExpectedCurrency(amount, from, to);
        }
    }
}
