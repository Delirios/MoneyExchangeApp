using MoneyExchangeApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Services
{
    public interface IMoneyExchangeService
    {
        Task<Root> GetRatesFromApi();
    }
}
