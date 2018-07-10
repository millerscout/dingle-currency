using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DingleCurrencyChecker.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DingleCurrencyChecker.Tests
{
    [TestClass]
    public class CurrencyServiceTest : BaseTest
    {

        [TestMethod]
        public async Task TestMethod1()
        {
       


            var BRLToUSD = await CurrencyService.ConvertPriceGivenCurrenCurrencyToExpectedCurrency(12.50m, "BRL", "USD");

            Assert.IsTrue(BRLToUSD > 0, "O Valor Não pode ser zero ");
            Assert.IsTrue(Math.Ceiling(BRLToUSD) == Math.Ceiling(3.23m));


            var BRLToEUR = await CurrencyService.ConvertPriceGivenCurrenCurrencyToExpectedCurrency(12.50m, "BRL", "EUR");

            Assert.IsTrue(BRLToEUR > 0, "O Valor Não pode ser zero ");
            Assert.IsTrue(Math.Ceiling(BRLToEUR) == Math.Ceiling(2.75131m));
            

        }
       
    }
}
