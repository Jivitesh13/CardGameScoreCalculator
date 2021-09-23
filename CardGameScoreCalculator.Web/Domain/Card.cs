using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGameScoreCalculator.Web.Domain
{
    public  class Card
    {
        public string Identifier { get; set; }

        public int Score { get; set; }

        public string Description { get; set; }

    }
}
