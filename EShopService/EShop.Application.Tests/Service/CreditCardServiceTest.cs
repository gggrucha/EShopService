using EShop.Application.Services;
using EShop.Domain.Exceptions.CreditCard;

namespace EShop.Application.Tests.Services
{
    public class CreditCardServiceTest
    {
        [Fact]
        public void ValidateCard_CheckCardCorrectLength_ReturnTrue()
        {
            // Arrange
            var creditCardService = new CreditCardService();
            string cardNumber = "349779658312797";

            // Act
            var result = creditCardService.ValidateCardNumber(cardNumber);

            // Assert
            Assert.True(result);
        }


        [Fact]
        public void ValidateCard_CheckExceptionsTooShortNumber_ReturnTrue()
        {
            // Arrange
            var creditCardService = new CreditCardService();
            string cardNumber = "1212";

            // Act && Assert
            Assert.Throws<CardNumberTooShortException>(() => creditCardService.ValidateCardNumber(cardNumber));
        }

        [Fact]
        public void ValidateCard_CheckExceptionsTooLongNumber_ReturnTrue()
        {
            // Arrange
            var creditCardService = new CreditCardService();
            string cardNumber = "3497 7965 8312 797 3497 7965 8312 797";

            // Act && Assert
            Assert.Throws<CardNumberTooLongException>(() => creditCardService.ValidateCardNumber(cardNumber));
        }

        [Theory]
        [InlineData("3497 7965 8312 797")]
        [InlineData("345-470-784-783-010")]
        [InlineData("378523393817437")]
        [InlineData("4024-0071-6540-1778")]
        [InlineData("4532 2080 2150 4434")]
        [InlineData("4532289052809181")]
        [InlineData("5530016454538418")]
        [InlineData("5551561443896215")]
        [InlineData("5131208517986691")]
        public void ValidateCard_CheckCardValidator_ReturnTrue(string cardNumber)
        {
            // Arrange
            var creditCardService = new CreditCardService();

            // Act
            var result = creditCardService.ValidateCardNumber(cardNumber);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("3497 7965 8312 797", "American Express")]
        [InlineData("345-470-784-783-010", "American Express")]
        [InlineData("378523393817437", "American Express")]
        [InlineData("4024-0071-6540-1778", "Visa")]
        [InlineData("4532 2080 2150 4434", "Visa")]
        [InlineData("4532289052809181", "Visa")]
        [InlineData("5530016454538418", "MasterCard")]
        [InlineData("5551561443896215", "MasterCard")]
        [InlineData("5131208517986691", "MasterCard")]
        public void ValidateCard_CheckGetCardType_ReturnTrue(string cardNumber, string cardType)
        {
            // Arrange
            var creditCardService = new CreditCardService();

            // Act
            var result = creditCardService.GetCardType(cardNumber);

            // Assert
            Assert.Equal(result, cardType);
        }

        [Fact]
        public void ValidateCard_CardNumberInvalidException_ReturnTrue()
        {
            // Arrange
            var creditCardService = new CreditCardService();
            string cardNumber = "3574-7338-8857-5590";

            // Act && Assert
            Assert.Throws<CardNumberInvalidException>(() => creditCardService.GetCardType(cardNumber));
        }
    }
}
