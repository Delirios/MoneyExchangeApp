using MediatR;
using MoneyExchangeApp.Commands;
using MoneyExchangeApp.Models;
using MoneyExchangeApp.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Handlers
{
    public class AddEntryToHistoryHandler : IRequestHandler<AddEntryToHistoryCommand>
    {
        private readonly IMoneyExchangeRepository _moneyExchangeRepository;

        public AddEntryToHistoryHandler(IMoneyExchangeRepository moneyExchangeRepository)
        {
            _moneyExchangeRepository = moneyExchangeRepository;
        }

        public async Task<Unit> Handle(AddEntryToHistoryCommand request, CancellationToken cancellationToken)
        {
            var entry = new ExchangeHistory
            {
                FromCurrency = request.FromCurrency,
                FromAmount = request.FromAmount,
                ToCurrency = request.ToCurrency,
                ToAmount = request.ToAmount,
                Date = DateTime.Now
            };
            await _moneyExchangeRepository.AddEntryToHistory(entry);

            return Unit.Value;
        }
    }
}
