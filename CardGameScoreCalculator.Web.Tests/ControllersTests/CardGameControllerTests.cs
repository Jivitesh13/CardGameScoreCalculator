using CardGameScoreCalculator.Web.Controllers;
using CardGameScoreCalculator.Web.Models;
using CardGameScoreCalculator.Web.Models.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CardGameScoreCalculator.Web.Tests.ControllersTests
{
    [TestClass]
    public class CardGameControllerTests
    {
        CardGameController Target;
        private Mock<IScoreResultBuilder> _scoreResultBuilder;
        private Mock<ILogger<CardGameController>> _logger;

        [TestInitialize]
        public void Setup()
        {
            _logger = new Mock<ILogger<CardGameController>>(MockBehavior.Strict);
            _scoreResultBuilder = new Mock<IScoreResultBuilder>(MockBehavior.Strict);
            Target = new CardGameController(_logger.Object, _scoreResultBuilder.Object);
        }

        [TestMethod]
        public void GivenCallToIndexActionThenReturnView()
        {
            //act
            var result = Target.Index();

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));            
        }

        [TestMethod]
        public void GivenCallToScoreActionWhenInvaidHandThenReturnIndexView()
        {
            //arrange
            Target.ModelState.AddModelError("1", "test error");

            //act
            var result = Target.Score(new CardGameModel { Hand = "1C" }) as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }


        [TestMethod]
        public void GivenCallToScoreActionWhenVaidHandThenReturnScoreView()
        {
            //arrange
            var cardGameModel = new CardGameModel { Hand = "2C" };
            var expected = new ScoreResultModel { Score = 2 };

            _scoreResultBuilder.Setup(a => a.ForHand(cardGameModel.Hand)).Returns(_scoreResultBuilder.Object);
            _scoreResultBuilder.Setup(a => a.Parse()).Returns(_scoreResultBuilder.Object);
            _scoreResultBuilder.Setup(a => a.Build()).Returns(new ScoreResultModel { Score = 2 });

            //act
            var result = Target.Score(new Models.CardGameModel { Hand = "2C" }) as ViewResult;

            //assert
            Assert.AreEqual("Score", result.ViewName);
            Assert.IsNotNull(result.Model);
        }
    }
}
