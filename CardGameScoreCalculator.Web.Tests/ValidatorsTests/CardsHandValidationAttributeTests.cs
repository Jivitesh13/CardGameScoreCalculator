using CardGameScoreCalculator.Web.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace CardGameScoreCalculator.Web.Tests.ValidatorsTests
{
    [TestClass]
    public class CardsHandValidationAttributeTests
    {
        CardsHandValidationAttribute Target;

        [TestInitialize]
        public void Setup()
        {
            Target = new CardsHandValidationAttribute();
        }

        [DataTestMethod]
        [DataRow("1S", "Card not recognised")]
        [DataRow("2B", "Card not recognised")]
        [DataRow("2S,1S", "Card not recognised")]
        [DataRow("3H,3H", "Cards cannot be duplicated")]
        [DataRow("4D,5D,4D", "Cards cannot be duplicated")]
        [DataRow("JR,JR,JR", "A hand cannot contain more than two Jokers")]
        [DataRow("2S|3D", "Invalid input string")]
        public void GivenInvalidCardsHandThenReturnValidationError(string hand, string expectedMessage = null)
        {
            //act
            var validationError = Target.GetValidationResult(hand, new ValidationContext(hand));

            //assert
            Assert.AreEqual(expectedMessage, validationError.ErrorMessage);
        }

        [DataTestMethod]
        [DataRow("JR")]
        [DataRow("JR,JR")]
        [DataRow("2C,JR")]
        [DataRow("JR,2C,JR")]
        [DataRow("TC,TD,JR,TH,TS")]
        [DataRow("TC,TD,JR,TH,TS,JR")]
        public void GivenValidCardsHandThenDoNotReturnValidationError(string hand)
        {
            //act
            var validationError = Target.GetValidationResult(hand, new ValidationContext(hand));

            //assert
            Assert.IsNull(validationError);
        }
    }
}
