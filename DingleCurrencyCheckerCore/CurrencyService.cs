using System;
using System.Collections.Generic;
using System.Text;

namespace DingleCurrencyChecker.Core
{
    public class CurrencyService
    {
        public int Batat { get; set; }

        public void PutValue(int x)
        {
            Batat = x;
        }
    }
}
