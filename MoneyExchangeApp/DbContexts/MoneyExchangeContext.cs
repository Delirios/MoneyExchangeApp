using Microsoft.EntityFrameworkCore;
using MoneyExchangeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
