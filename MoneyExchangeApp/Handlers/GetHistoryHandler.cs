using MediatR;
using MoneyExchangeApp.Models;
using MoneyExchangeApp.Queries;
using MoneyExchangeApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Handlers
{
    public class GetHistoryHandler : IRequestHandler<GetHistoryQuery, IEnumerable<ExchangeHistory>>
    {
        private readonly IMoneyExchangeRepository _moneyExchangeRepository;

        public GetHistoryHandler(IMoneyExchangeRepository moneyExchangeRepository)
        {
            _moneyExchangeRepository = moneyExchangeRepository;
        }

        public async Task<IEnumerable<ExchangeHistory>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _moneyExchangeRepository.GetHistory();
        }
    }
}
