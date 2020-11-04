using MediatR;
using MoneyExchangeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Queries
{
    public class GetHistoryQuery : IRequest<IEnumerable<ExchangeHistory>> 
    {
    }
}
