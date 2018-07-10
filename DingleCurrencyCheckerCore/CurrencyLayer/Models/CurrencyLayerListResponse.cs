using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DingleCurrencyChecker.Core.CurrencyLayer
{
    public class CurrencyLayerListResponse : BaseCurrencyResponse
    {
        [JsonProperty("currencies")]
        public Dictionary<string, string> Currencies { get; set; }
    }
}
