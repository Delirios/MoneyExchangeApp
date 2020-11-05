using MediatR;
using MoneyExchangeApp.Commands;
using MoneyExchangeApp.Models;
using MoneyExchangeApp.Repositories;
using MoneyExchangeApp.Services;
using MoneyExchangeApp.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Handlers
{
    public class AddEntryToHistoryHandler : IRequestHandler<AddEntryToHistoryCommand, MoneyExchangeViewModel>
    {
        private readonly IMoneyExchangeRepository _moneyExchangeRepository;
        private readonly IMoneyExchangeService _moneyExchangeService;

        public AddEntryToHistoryHandler(IMoneyExchangeRepository moneyExchangeRepository, IMoneyExchangeService moneyExchangeService)
        {
            _moneyExchangeRepository = moneyExchangeRepository;
            _moneyExchangeService = moneyExchangeService;
        }

        public async Task<MoneyExchangeViewModel> Handle(AddEntryToHistoryCommand request, CancellationToken cancellationToken)
        {
            var ratesDictionary = _moneyExchangeService.CreateRatesDictionary(await _moneyExchangeRepository.GetRates());
            double fromAmount = request.FromAmount;
            double toAmount = request.ToAmount;
            double ratio = 0;

            var entry = new ExchangeHistory
            {
                FromCurrency = request.FromCurrency,
                FromAmount = fromAmount,
                ToCurrency = request.ToCurrency,
                ToAmount = toAmount,
                Date = DateTime.Now
            };

            var moneyExchange = new MoneyExchangeViewModel
            {
                ToAmount = toAmount,
                RatesDictionary = ratesDictionary,
                FromAmount = fromAmount
        };

            if (request.FromAmount != 0 | request.ToAmount != 0)
            {
                if (request.FromAmount == 0)
                {
                    fromAmount = _moneyExchangeService.CalculateTheRate(entry);
                    ratio = _moneyExchangeService.CalculatTheRatio(entry);

                    entry.FromAmount = fromAmount;

                    moneyExchange.FromAmount = fromAmount;
                    moneyExchange.Ratio = ratio;
                    moneyExchange.FromCurrency = ratesDictionary.FirstOrDefault(x => x.Key.ToString() == request.ToCurrency).Value;
                    moneyExchange.ToCurrency = ratesDictionary.FirstOrDefault(x => x.Key.ToString() == request.FromCurrency).Value;

                }
                else
                {
                    toAmount = _moneyExchangeService.CalculateTheRate(entry);
                    ratio = _moneyExchangeService.CalculatTheRatio(entry);

                    entry.ToAmount = toAmount;

                    moneyExchange.ToAmount = toAmount;
                    moneyExchange.Ratio = ratio;
                    moneyExchange.FromCurrency = ratesDictionary.FirstOrDefault(x => x.Key.ToString() == request.FromCurrency).Value;
                    moneyExchange.ToCurrency = ratesDictionary.FirstOrDefault(x => x.Key.ToString() == request.ToCurrency).Value;
                }
                entry.FromCurrency = ratesDictionary.FirstOrDefault(x => x.Key.ToString() == request.FromCurrency).Value;
                entry.ToCurrency = ratesDictionary.FirstOrDefault(x => x.Key.ToString() == request.ToCurrency).Value;
            }
            

            await _moneyExchangeRepository.AddEntryToHistory(entry);

            return moneyExchange;
        }
    }
}
