using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameScoreCalculator.Web.Models.Builders
{
    public interface IScoreResultBuilder
    {
        IScoreResultBuilder ForHand(string hand);
        IScoreResultBuilder Parse();
        ScoreResultModel Build();
    }
}
