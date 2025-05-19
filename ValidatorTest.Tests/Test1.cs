using LibraryDb_Gabriel_Viinikka.Services;

namespace ValidatorTest.Tests
{
    [TestClass]
    public sealed class IsbnValidatorTest
    {
        [TestMethod]
        public void IsbnInvalidTest()
        {
            #region Arrange

            var validator = new IsbnValidator();
            string notIsbn = "123";

            #endregion

            #region Act
            bool oneTwoThree = validator.Validate(notIsbn);
            #endregion

            #region Assert
            Assert.IsFalse(oneTwoThree);
            #endregion

        }

        [TestMethod]
        public void IsbnEmptyTest()
        {
            #region Arrange
            var validator = new IsbnValidator();

            string empty = string.Empty;
            #endregion

            #region Act
            bool isEmpty = validator.Validate(empty);
            #endregion

            #region Assert
            Assert.IsFalse(isEmpty);
            #endregion
        }

        [TestMethod]
        public void IsbnThirteenTest()
        {
            #region Arrange
            var validator = new IsbnValidator();
            string thirteenNumeral = "9781599325743";
            #endregion

            #region Act
            bool fuMoney = validator.Validate(thirteenNumeral);
            #endregion

            #region Assert
            Assert.IsTrue(fuMoney);
            #endregion
        }
        [TestMethod]
        public void IsbnTenTest()
        {
            #region Arrange

            var validator = new IsbnValidator();
            string tenNumeral = "9120059175";


            #endregion

            #region Act
            bool returnOfTheKing = validator.Validate(tenNumeral);
            #endregion

            #region Assert
            Assert.IsTrue(returnOfTheKing);
            #endregion
        }

    }
}
