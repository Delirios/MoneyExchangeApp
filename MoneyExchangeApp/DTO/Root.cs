using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.DTO
{
    public class Root
    {
        public Rates rates { get; set; }
        public string date { get; set; }
    }
}
