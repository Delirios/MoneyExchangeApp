using MediatR;
using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Queries;
using MoneyExchangeApp.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Handlers
{
    public class GetRatesHandler : IRequestHandler<GetRatesQuery, Rates>
    {
        private readonly IMoneyExchangeRepository _moneyExchangeRepository;

        public GetRatesHandler(IMoneyExchangeRepository moneyExchangeRepository)
        {
            _moneyExchangeRepository = moneyExchangeRepository;
        }
        public async Task<Rates> Handle(GetRatesQuery request, CancellationToken cancellationToken)
        {
            return await _moneyExchangeRepository.GetRates();
        }
    }
}
