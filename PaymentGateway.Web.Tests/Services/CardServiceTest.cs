using Moq;
using PaymentGateway.Api.Constants.Card;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions.Pay;
using PaymentGateway.Web.Services;
using PaymentGateway.Web.Services.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PaymentGateway.Web.Tests.Services
{
    public class CardServiceTest
    {
        private IStorageContext GetStorageContextMock()
        {
            var mock = new Mock<IStorageContext>();
            mock.Setup(s => s.CardList).Returns(new List<Card>
            {
                new Card
                {
                    Id = Guid.NewGuid(),
                    Cvv = Card1.Cvv,
                    ExpireYear = Card1.ExpireYear,
                    ExpiryMonth = Card1.ExpiryMonth,
                    Number = Card1.Number,
                    Balance = Card1.Balance,
                    IsUnlimited = false
                },
                new Card
                {
                    Id = Guid.NewGuid(),
                    Cvv = Card2.Cvv,
                    ExpireYear = Card2.ExpireYear,
                    ExpiryMonth = Card2.ExpiryMonth,
                    Number = Card2.Number,
                    Balance = Card2.Balance,
                    IsUnlimited = true
                }
            });
            return mock.Object;
        }

        [Fact]
        public void CheckDecreaseBalanceLimitedCardOk()
        {
            var storageContext = GetStorageContextMock();
            var cardService = new CardService(new CardValidationService(), storageContext);

            var card = storageContext.CardList[0];
            var amount = card.Balance - 1;
            cardService.Decrease(card.Id, amount);

            Assert.Equal(1, card.Balance);
        }

        [Fact]
        public void CheckDecreaseBalanceLimitedCardNotEnoughMoney()
        {
            var storageContext = GetStorageContextMock();
            var cardService = new CardService(new CardValidationService(), storageContext);

            var card = storageContext.CardList[0];
            var amount = card.Balance + 1;
            void action() => cardService.Decrease(card.Id, amount);

            Assert.Throws<NotEnoughMoneyException>(action);
        }

        [Fact]
        public void CheckDecreaseBalanceUnLimitedCardOk()
        {
            var storageContext = GetStorageContextMock();
            var cardService = new CardService(new CardValidationService(), storageContext);

            var card = storageContext.CardList[1];
            var amount = card.Balance + 1;
            cardService.Decrease(card.Id, amount);

            Assert.Equal(-1, card.Balance);
        }

        [Fact]
        public void CheckIncreaseBalanceCardOk()
        {
            var storageContext = GetStorageContextMock();
            var cardService = new CardService(new CardValidationService(), storageContext);

            var card = storageContext.CardList[0];
            var oldBalance = card.Balance;
            var amount = 100;
            cardService.Increase(card.Id, amount);

            Assert.Equal(oldBalance + 100, card.Balance);
        }
    }
}
