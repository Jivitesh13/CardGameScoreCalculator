using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameScoreCalculator.Web.Models
{
    public class ScoreResultModel
    {
        public int Score { get; set; }

        public IList<string> Cards { get; } = new List<string>();
    }
}
