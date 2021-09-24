using CardGameScoreCalculator.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameScoreCalculator.Web.Models.Builders
{
    /// <summary>
    /// Builder class to parse the cards and calculate the score
    /// </summary>
    public class ScoreResultBuilder : IScoreResultBuilder
    {
        private IList<string> _cards;
        private int _totalScore;
        private string _hand;

        public IScoreResultBuilder ForHand(string hand)
        {
            _hand = hand;
            return this;
        }

        public IScoreResultBuilder Parse()
        {
            _cards = _hand.Split(",").Select(c => c.Trim().ToLower()).ToList();
            return this;
        }

        public ScoreResultModel Build()
        {
            // Joins enterd list of cards with full pack of cards to find out score of each card
            var cardsDetail = from cardInHand in _cards
                        join cardInPack in CardsPack.Cards on cardInHand equals cardInPack.Identifier.ToLower()
                        select new { Card = cardInPack.Description, score = cardInPack.Score };

            var numberOfJokers = _cards.Where(c => c.Equals(CardsPack.JokerCard.ToLower())).Count();
            
            _totalScore = cardsDetail.Sum(s => s.score) * (numberOfJokers > 0 ? numberOfJokers * 2 : 1);

            var scoreModel = new ScoreResultModel
            {
                Score = _totalScore
            };

            cardsDetail.ToList().ForEach(c => scoreModel.Cards.Add(c.Card));

            return scoreModel;
        }
    }
}
