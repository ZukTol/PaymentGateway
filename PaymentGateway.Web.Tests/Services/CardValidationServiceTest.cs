using PaymentGateway.Web.Exceptions.Pay;
using PaymentGateway.Web.Services;
using PaymentGateway.Web.Services.Impl;
using System;
using Xunit;

namespace PaymentGateway.Web.Tests.Services
{
    public class CardValidationServiceTest
    {
        private const string _validCardNumber = "1111111111111111";
        private readonly static int _validMonth = DateTime.Today.Month;
        private readonly static int _validYear = DateTime.Today.Year;

        private ICardValidationService _cardValidationService = new CardValidationService();


        [Fact]
        public void CheckCardNumberValid()
        {
            _cardValidationService.CheckCard(_validCardNumber, _validMonth, _validYear);
        }

        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("11")]
        [InlineData("111")]
        [InlineData("1111")]
        [InlineData("11111")]
        [InlineData("111111")]
        [InlineData("1111111")]
        [InlineData("11111111")]
        [InlineData("111111111")]
        [InlineData("1111111111")]
        [InlineData("11111111111")]
        [InlineData("111111111111")]
        [InlineData("1111111111111")]
        [InlineData("11111111111111")]
        [InlineData("111111111111111")]
        [InlineData("11111111111111111")]
        public void CheckCardNumberLengthInvalid(string cardNumber)
        {
            void action() => _cardValidationService.CheckCard(cardNumber, _validMonth, _validYear);

            Assert.Throws<InvalidCardNumberException>(action);
        }

        [Theory]
        [InlineData("111111111111111a")]
        [InlineData("111111111111111 ")]
        [InlineData("111111111111111^")]
        public void CheckCardNumberOnlyDigitsInvalid(string cardNumber)
        {
            void action() => _cardValidationService.CheckCard(cardNumber, _validMonth, _validYear);

            Assert.Throws<InvalidCardNumberException>(action);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        public void CheckMonthInvalid(int month)
        {
            void action() => _cardValidationService.CheckCard(_validCardNumber, month, _validYear);

            Assert.Throws<InvalidCardExpiryDateException>(action);
        }

        [Theory]
        [InlineData(0)]
        public void CheckYearInvalid(int year)
        {
            void action() => _cardValidationService.CheckCard(_validCardNumber, _validYear, year);

            Assert.Throws<InvalidCardExpiryDateException>(action);
        }

        [Fact]
        public void CheckDateInvalid()
        {
            var date = DateTime.Today.AddMonths(-1);
            void action() => _cardValidationService.CheckCard(_validCardNumber, date.Month, date.Year);

            Assert.Throws<InvalidCardExpiryDateException>(action);
        }
    }
}
