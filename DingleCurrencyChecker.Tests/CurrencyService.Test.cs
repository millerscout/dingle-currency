using DingleCurrencyChecker.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DingleCurrencyChecker.Tests
{
    [TestClass]
    public class CurrencyServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new CurrencyService();

            service.PutValue(2);

            Assert.IsTrue(service.Batat == 2);
        }
    }
}
