using CardGameScoreCalculator.Web.Domain;
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
            return View();
        }

        [HttpPost]
        public IActionResult Score(CardGameModel cardGameModel)
        {
            var pack = CardsPack.Cards;

            if (!ModelState.IsValid)
            {
                return View(nameof(this.Index));
            }

            var cards = cardGameModel.Hand.Split(",").Select(c => c.Trim().ToLower()).ToList();

            var score = from cardInHand in cards
            join cardInPack in CardsPack.Cards on cardInHand equals cardInPack.Identifier.ToLower()
            select new { Card = cardInPack.Description, score = cardInPack.Score };

            var numberOfJokers = cards.Where(c => c.Equals(CardsPack.JokerCard.ToLower())).Count();
            var totalScore = score.Sum(s => s.score) * (numberOfJokers > 0 ? numberOfJokers * 2 : 1) ;

            var scoreModel = new ScoreResultModel
            {
                Score = totalScore
            };

            score.ToList().ForEach(c => scoreModel.Cards.Add(c.Card));
            return View(scoreModel);
        }       
    }
}
