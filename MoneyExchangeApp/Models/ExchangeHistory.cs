﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Models
{
    public class ExchangeHistory
    {
        public int Id { get; set; }

        public string FromCurrency { get; set; }
        public double FromAmount { get; set; }
        public string ToCurrency { get; set; }
        public double ToAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
