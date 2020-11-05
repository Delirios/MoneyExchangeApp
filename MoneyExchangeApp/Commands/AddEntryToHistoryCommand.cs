using MediatR;
using MoneyExchangeApp.Models;
using MoneyExchangeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Commands
{
    public class AddEntryToHistoryCommand : IRequest<MoneyExchangeViewModel>
    {
        public string FromCurrency { get; set; }
        public double FromAmount { get; set; }
        public string ToCurrency { get; set; }
        public double ToAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
