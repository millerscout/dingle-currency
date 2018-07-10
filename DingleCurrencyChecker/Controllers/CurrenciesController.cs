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

        public CurrenciesController(ICurrencySource currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public Dictionary<string, string> Get() => _currencyService.GetAvailableCurrencies();
    }
}
