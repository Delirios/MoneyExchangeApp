using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyExchangeApp.Queries;
using MoneyExchangeApp.Services;

namespace MoneyExchangeApp.Controllers
{
    
    public class HistoryController : Controller
    {
        private readonly IMediator _mediator;
        public HistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetHistoryQuery();
            var result = await _mediator.Send(query);
            return View(result.ToList());
        }
    }
}
