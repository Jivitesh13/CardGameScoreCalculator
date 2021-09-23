using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameScoreCalculator.Web.Models
{
    public class CardGameModel
    {
        [Required(ErrorMessage = "Cards Missing")]
        [DisplayName("Enter your cards")]
        public string Hand { get; set; }

        public string Description =>
            $"1.The list of cards must be given as a comma separated list.{Environment.NewLine}" +
            $"2.Each card must use a two-character representation as follows:{Environment.NewLine}" +
            $"  a) The first character represents the card’s value:" +
            $"      2-9 for the card values 2 through 9{Environment.NewLine}" +
            $"      T for 10{Environment.NewLine}" +
            $"      J for a Jack{Environment.NewLine}" +
            $"      Q for a Queen{Environment.NewLine}" +
            $"      K for a King{Environment.NewLine}" +
            $"      A for an Ace{Environment.NewLine}" +
            $"  b) The second character represents the card’s suit:{Environment.NewLine}" +
            $"      C for Clubs{Environment.NewLine}" +
            $"      D for Diamonds{Environment.NewLine}" +
            $"      H for Hearts{Environment.NewLine}" +
            $"      S for Spades{Environment.NewLine}" +
            $"  c) E.g. “AS” would be the Ace of Spades, '4C' would be the 4 of Clubs etc.{Environment.NewLine}" +
            $"  d) A Joker is represented by two-character code 'JR'{Environment.NewLine}";

    }
}
