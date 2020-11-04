using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.ViewModels
{
    public class MoneyExchangeViewModel
    {
        public ExchangeHistory ExchangeHistory { get; set; }
        public IEnumerable<Rates> Rates { get; set; }
    }
}
