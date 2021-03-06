﻿using System;
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
        public async Task ConvertendoMoedaBRLToUSD()
        {
            var BRLToUSD = CurrencyService.ConvertAmountGivenCurrenCurrencyToExpectedCurrency(12.50m, "BRL", "USD");

            Assert.IsTrue(BRLToUSD > 0, "O Valor Não pode ser zero ");
            Assert.IsTrue(Math.Ceiling(BRLToUSD) == Math.Ceiling(3.23m));

            var BRLToEUR = CurrencyService.ConvertAmountGivenCurrenCurrencyToExpectedCurrency(12.50m, "BRL", "EUR");

            Assert.IsTrue(BRLToEUR > 0, "O Valor Não pode ser zero ");
            Assert.IsTrue(Math.Ceiling(BRLToEUR) == Math.Ceiling(2.75131m));
        }

        [TestMethod]
        public async Task ConvertendoMoedaBRLToEUR()
        {
            var BRLToEUR = CurrencyService.ConvertAmountGivenCurrenCurrencyToExpectedCurrency(12.50m, "BRL", "EUR");

            Assert.IsTrue(BRLToEUR > 0, "O Valor Não pode ser zero ");
            Assert.IsTrue(Math.Ceiling(BRLToEUR) == Math.Ceiling(2.75131m));
        }

        [TestMethod]
        public async Task ConvertendoMoedaComValorNulo()
        {
            Assert.ThrowsException<ArgumentException>(() =>
             CurrencyService.ConvertAmountGivenCurrenCurrencyToExpectedCurrency(0m, "BRL", "USD"), "O Valor Não pode ser Zero");
        }

        [TestMethod]
        public async Task ConvertendoMoedaComValorNegativo()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                  CurrencyService.ConvertAmountGivenCurrenCurrencyToExpectedCurrency(-500m, "BRL", "USD"), "O Valor Não pode ser Zero");
        }

        [TestMethod]
        public async Task ConvertendoMoedaComAlgumaCurrencyInexistente()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                  CurrencyService.ConvertAmountGivenCurrenCurrencyToExpectedCurrency(-500m, "", "USD"), "O Valor Não pode ser Zero");
        }

        [TestMethod]
        public async Task VerificaEndPoint()
        {

            //TODO: Validate status returns
            var t = new Mock<CurrencyLayerService>("aad525d185d203a74429647e1ef094f9");

            t.Object.GetAvailableCurrencies();

            t.Object.GetCurrencies("BRL");
        }
    }
}
