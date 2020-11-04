using Microsoft.EntityFrameworkCore;
using MoneyExchangeApp.DbContexts;
using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Models;
using MoneyExchangeApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Repositories
{
    public class MoneyExchangeRepository : IMoneyExchangeRepository
    {
        private readonly MoneyExchangeContext _moneyExchangeContext;
        private readonly IMoneyExchangeService _moneyExchangeService;

        public MoneyExchangeRepository(MoneyExchangeContext moneyExchangeContext, IMoneyExchangeService moneyExchangeService)
        {
            _moneyExchangeContext = moneyExchangeContext;
            _moneyExchangeService = moneyExchangeService;
        }

        public async Task AddEntryToHistory(ExchangeHistory entry)
        {
            await _moneyExchangeContext.ExchangeHistory.AddAsync(entry);          
            await _moneyExchangeContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExchangeHistory>> GetHistory()
        {
            return await _moneyExchangeContext.ExchangeHistory.ToListAsync();
        }

        public async Task<Rates> GetRates()
        {
            var result = await _moneyExchangeService.GetRatesFromApi();
            return result.rates;
        }
    }
}
