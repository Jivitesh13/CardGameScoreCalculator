using CardGameScoreCalculator.Web.Models;
using CardGameScoreCalculator.Web.Models.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CardGameScoreCalculator.Web.Tests.ModelsTests.BuildersTests
{
    [TestClass]

    public class ScoreResultBuilderTests
    {
        ScoreResultBuilder Target;

        private static IEnumerable<object[]> TestData =>
            new List<object[]> {
                new object[] { "2C", new ScoreResultModel { Score = 2} },
                new object[] { "2D", new ScoreResultModel { Score = 4} },
                new object[] { "2H", new ScoreResultModel { Score = 6} },
                new object[] { "2S", new ScoreResultModel { Score = 8} },
                new object[] { "TC", new ScoreResultModel { Score = 10} },
                new object[] { "JC", new ScoreResultModel { Score = 11} },
                new object[] { "QC", new ScoreResultModel { Score = 12} },
                new object[] { "KC", new ScoreResultModel { Score = 13} },
                new object[] { "AC", new ScoreResultModel { Score = 14} },
                new object[] { "3C,4C", new ScoreResultModel { Score = 7} },
                new object[] { "TC,TD,TH,TS", new ScoreResultModel { Score = 100} },
                new object[] { "JR", new ScoreResultModel { Score = 0} },
                new object[] { "JR,JR", new ScoreResultModel { Score = 0} },
                new object[] { "2C,JR", new ScoreResultModel { Score = 4} },
                new object[] { "JR,2C,JR ", new ScoreResultModel { Score = 8} },
                new object[] { "TC,TD,JR,TH,TS", new ScoreResultModel { Score = 200} },
                new object[] { "TC,TD,JR,TH,TS,JR", new ScoreResultModel { Score = 400} }
        };

        [TestInitialize]
        public void Setup()
        {
            Target = new ScoreResultBuilder();
        }

        [TestMethod]
        [DynamicData(nameof(TestData))]
        public void GivenInvalidCardsHandThenReturnValidationError(string hand, ScoreResultModel expected)
        {
            //act
            var result = Target.ForHand(hand).Parse().Build();

            //assert
            Assert.AreEqual(expected.Score, result.Score);
        }
    }
}
