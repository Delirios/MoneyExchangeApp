using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Repositories
{
    public interface IMoneyExchangeRepository
    {
        Task<IEnumerable<ExchangeHistory>> GetHistory();
        Task AddEntryToHistory(ExchangeHistory entry);

        Task<Rates> GetRates();
    }
}
