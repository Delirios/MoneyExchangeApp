using Microsoft.EntityFrameworkCore;
using MoneyExchangeApp.Models;

namespace MoneyExchangeApp.DbContexts
{
    public class MoneyExchangeContext : DbContext
    {
        public MoneyExchangeContext(DbContextOptions<MoneyExchangeContext> options) : base(options)
        {
        }
        public DbSet<ExchangeHistory> ExchangeHistory { get; set; }
    }
}
