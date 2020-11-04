using MediatR;
using MoneyExchangeApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyExchangeApp.Queries
{
    public class GetRatesQuery : IRequest<Rates>
    {
    }
}
