using System.Collections.Generic;

namespace CardGameScoreCalculator.Web.Domain
{
    /// <summary>
    /// This class represents pack of all cards. 52 cards and their score + 1 joker, though 2 jokers are allowed but we don't need to add duplicate
    /// </summary>
    public class CardsPack
    {
        public static IList<Card> Cards { get; } = new List<Card>();
        public static string JokerCard = "JR";

        static CardsPack()
        {
            BuildFullPack();
        }

        private static void BuildFullPack()
        {
            BuildCardsOfType(CardType.Club);
            BuildCardsOfType(CardType.Diamond);
            BuildCardsOfType(CardType.Heart);
            BuildCardsOfType(CardType.Spade);

            Cards.Add(new Card { Identifier = JokerCard, Description = "Joker" });
        }

        private static void BuildCardsOfType(CardType cardType)
        {
            char cardIdentifier = cardType.ToString()[0];
            int cardFaceValue = (int)cardType;

            for (var i = 2; i <= 9; i++)
            {
                Cards.Add(new Card { Identifier = $"{i}{cardIdentifier}", Score = i * cardFaceValue, Description = $"{i} of {cardType}" });
            }

            Cards.Add(new Card { Identifier = $"T{cardIdentifier}", Description = $"10 of {cardType}", Score = 10  * cardFaceValue });
            Cards.Add(new Card { Identifier = $"J{cardIdentifier}", Description = $"Jake of {cardType}", Score = 11 * cardFaceValue });
            Cards.Add(new Card { Identifier = $"Q{cardIdentifier}", Description = $"Quene of {cardType}", Score = 12 * cardFaceValue });
            Cards.Add(new Card { Identifier = $"K{cardIdentifier}", Description = $"King of {cardType}", Score = 13 * cardFaceValue });
            Cards.Add(new Card { Identifier = $"A{cardIdentifier}", Description = $"Ace of {cardType}", Score = 14 * cardFaceValue });
        }
    }
}
