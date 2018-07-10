using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DingleCurrencyChecker.Core.CurrencyLayer
{
    public class BaseCurrencyResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("terms")]
        public string Terms { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }
    }
}
