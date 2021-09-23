using System.Collections.Generic;

namespace CardGameScoreCalculator.Web.Models
{
    public class ScoreResultModel
    {
        public int Score { get; set; }

        public IList<string> Cards { get; } = new List<string>();
    }
}
