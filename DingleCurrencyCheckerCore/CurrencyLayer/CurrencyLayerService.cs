using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DingleCurrencyChecker.Core.CurrencyLayer;
using RestSharp;

namespace DingleCurrencyChecker.Core
{
    public class CurrencyLayerService : ICurrencySource
    {
        private string _apikey;

        public CurrencyLayerService(string apikey)
        {
            _apikey = apikey;
        }
        public RestClient RestClient { get; }

        public Dictionary<string, string> GetAvailableCurrencies()
        {

            var client = new RestClient("http://apilayer.net/api/");

            var request = new RestRequest($"list?access_key={_apikey}", Method.GET);


            client.Execute(request);

            var response2 = client.Execute<CurrencyLayerListResponse>(request);

            return response2.Data.Currencies;

        }

        public Dictionary<string, decimal> GetCurrencies(string currencyCodes)
        {
            var client = new RestClient("http://apilayer.net/api/");

            var request = new RestRequest($"live?access_key={_apikey}&currencies={currencyCodes}", Method.GET);


            client.Execute(request);

            var response2 = client.Execute<CurrencyLayerCurrenciesResponse>(request);

            return RemoveSourceFromCurrencyKey(response2);
        }

        private static Dictionary<string, decimal> RemoveSourceFromCurrencyKey(IRestResponse<CurrencyLayerCurrenciesResponse> response2)
        {
            return response2.Data.Quotes.ToDictionary(q => q.Key.Substring(3, 3), q => q.Value);
        }
    }
}
