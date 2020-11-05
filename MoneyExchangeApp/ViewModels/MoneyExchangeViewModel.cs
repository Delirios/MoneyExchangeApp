using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.ViewModels
{
    public class MoneyExchangeViewModel
    {
        [Display(Name = "From currency")]
        public string FromCurrency { get; set; }
        [Display(Name = "From amount")]
        public double FromAmount { get; set; }
        [Display(Name = "To currency")]
        public string ToCurrency { get; set; }
        [Display(Name = "To amount")]
        
        public double ToAmount { get; set; }
        public double Ratio { get; set; }

        public Dictionary<double, string> RatesDictionary { get; set; }
    }
}
