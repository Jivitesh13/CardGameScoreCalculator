//using CardGameScoreCalculator.Web.Models;
using CardGameScoreCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameScoreCalculator.Web.Controllers
{
    public class CardGameController : Controller
    {
        private readonly ILogger<CardGameController> _logger;

        public CardGameController(ILogger<CardGameController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CardGameModel());
        }

        [HttpPost]
        public IActionResult Score(CardGameModel cardGameModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(this.Index));
            }

            ModelState.AddModelError("1", "Test error");
            return View();
        }       
    }
}
