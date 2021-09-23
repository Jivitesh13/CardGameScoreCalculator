using CardGameScoreCalculator.Web.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameScoreCalculator.Web.Validators
{
    public class CardsHandValidationAttribute : ValidationAttribute
    {
        // validation rules
        Func<string, bool> isLengthEqualTo2 = (s) => s.Length == 2;
        Func<List<string>, bool> hasOnlyOneCard = (cards) => cards.Count() == 1;
        Func<List<string>, bool> hasAnyCardWithLengthNot2 = (cards) => cards.Any(c => c.Length != 2);

        Func<List<string>, bool> hasDuplicateCards = (cards) =>
                                        cards
                                        .Where(c => !c.Equals(CardsPack.JokerCard.ToLower()))
                                        .GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .ToDictionary(x => x.Key, y => y.Count()).Count() > 0;

        Func<List<string>, bool> hasMoreThan2Jokers = (cards) =>
                                        cards.Where(c => c.Equals(CardsPack.JokerCard.ToLower()))
                                         .Count() > 2;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var hand = ((string)value).Trim();

            if (isLengthEqualTo2(hand))
            {
                if (!IsValidCard(hand))
                {
                    return new ValidationResult("Card not recognised");
                }
            }
            else
            {
                //split the hand
                var cards = hand.Split(",").Select(s => s.Trim().ToLower()).ToList();

                if (hasOnlyOneCard(cards))
                {
                    if (!IsValidCard(cards.First()))
                    {
                        return new ValidationResult("Invalid input string");
                    }
                }

                if (hasAnyCardWithLengthNot2(cards))
                {
                    return new ValidationResult("Invalid input string");
                }

                if (cards.Any(c => !IsValidCard(c)))
                {
                    return new ValidationResult($"Card not recognised");
                }

                if (hasDuplicateCards(cards))
                {
                    return new ValidationResult("Cards cannot be duplicated");
                }

                if (hasMoreThan2Jokers(cards))
                {
                    return new ValidationResult("A hand cannot contain more than two Jokers");
                }
            }

            return ValidationResult.Success;
        }

        public bool IsValidCard(string card)
        {
            return CardsPack.Cards.ToList().Exists(c => c.Identifier.ToLower().Equals(card.Trim().ToLower()));
        }
    }
}
