using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Services
{
    public interface IMoneyExchangeService
    {
        Task<Root> GetRatesFromApi();
        double CalculateTheRate(ExchangeHistory exchangeHistory);
        Dictionary<double, string> CreateRatesDictionary(Rates rates);

        double CalculatTheRatio(ExchangeHistory exchangeHistory);
    }
}
