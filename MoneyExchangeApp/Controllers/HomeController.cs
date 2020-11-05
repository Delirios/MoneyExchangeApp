using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using MoneyExchangeApp.Commands;
using MoneyExchangeApp.DTO;
using MoneyExchangeApp.Models;
using MoneyExchangeApp.Queries;
using MoneyExchangeApp.Services;
using MoneyExchangeApp.ViewModels;

namespace MoneyExchangeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMoneyExchangeService _moneyExchangeService;
        public HomeController(IMediator mediator, IMoneyExchangeService moneyExchangeService)
        {
            _mediator = mediator;
            _moneyExchangeService = moneyExchangeService;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetRatesQuery();
            var result = await _mediator.Send(query);

            var ratesDictionary = _moneyExchangeService.CreateRatesDictionary(result);

            return View(new MoneyExchangeViewModel
            {
                RatesDictionary = ratesDictionary
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(AddEntryToHistoryCommand command)
        {
            var result = await _mediator.Send(command);
            
            return PartialView("_ExchangePartial",
            new MoneyExchangeViewModel
            {
                FromCurrency = result.FromCurrency,
                FromAmount = result.FromAmount,
                ToCurrency = result.ToCurrency,
                ToAmount = result.ToAmount,
                RatesDictionary = result.RatesDictionary,
                Ratio = result.Ratio
            });
        }

        public IActionResult History()
        {
            return View();
        }
    }
}
