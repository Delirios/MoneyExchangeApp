using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Queries;
using MoneyExchangeApp.ViewModels;

namespace MoneyExchangeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetRatesQuery();
            var result = await _mediator.Send(query);
            var ratesList = new List<Rates>();
            ratesList.Add(result);

            return View(new MoneyExchangeViewModel
            {
                Rates = ratesList
            }
            );
        }



        public IActionResult History()
        {
            return View();
        }
    }
}
