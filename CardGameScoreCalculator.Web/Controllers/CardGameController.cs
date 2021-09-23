using CardGameScoreCalculator.Web.Models;
using CardGameScoreCalculator.Web.Models.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardGameScoreCalculator.Web.Controllers
{
    public class CardGameController : Controller
    {
        private readonly ILogger<CardGameController> _logger;
        private readonly IScoreResultBuilder _scoreResultBuilder;

        public CardGameController(ILogger<CardGameController> logger, IScoreResultBuilder scoreResultBuilder)
        {
            _logger = logger;
            _scoreResultBuilder = scoreResultBuilder;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Score(CardGameModel cardGameModel)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(this.Index));
            }

            // we are here means validations has been passed
            var model = _scoreResultBuilder
                        .ForHand(cardGameModel.Hand)
                        .Parse()
                        .Build();

            return View(model); ;
        }       
    }
}
