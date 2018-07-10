using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DingleCurrencyChecker.Core.CurrencyLayer
{
    public class CurrencyLayerCurrenciesResponse : BaseCurrencyResponse
    {

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, decimal> Quotes { get; set; }
    }
}
