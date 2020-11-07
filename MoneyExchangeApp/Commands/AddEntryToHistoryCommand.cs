using MediatR;
using MoneyExchangeApp.ViewModels;
using System;

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
