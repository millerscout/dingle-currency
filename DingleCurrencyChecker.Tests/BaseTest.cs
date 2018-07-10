using System;
using System.Collections.Generic;
using System.Text;
using DingleCurrencyChecker.Core;
using Moq;

namespace DingleCurrencyChecker.Tests
{
    public class BaseTest
    {
        public Dictionary<string, string> AvailableLanguages = new Dictionary<string, string> {
                {"BRL","Brazilian Real"},
                {"EUR","Euro"},
                {"USD","United States Dollar"},
            };

        public BaseTest()
        {
            var currency = new Mock<ICurrencySource>();

            currency.Setup(q => q.GetCurrencies())
                .ReturnsAsync(new Dictionary<string, decimal> {
                    { "BRL", 3.86371m }, { "USD", 1 }, { "EUR", 0.85042m }
                });

            CurrencyService = new CurrencyConverterService(currency.Object);

        }

        public CurrencyConverterService CurrencyService { get; }
    }
}
