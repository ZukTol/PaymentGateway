using Moq;
using PaymentGateway.Api.Constants.Card;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions.Pay;
using PaymentGateway.Web.Services;
using PaymentGateway.Web.Services.Impl;
using System;
using System.Collections.Generic;
using Xunit;

namespace PaymentGateway.Web.Tests.Services
{
    public class PayValidationServiceTest
    {
        private readonly IStorageContext _storageContext;
        private readonly IPayValidationService _payValidationService;

        private const string _doneOrderId = "111";

        public PayValidationServiceTest()
        {
            _storageContext = GetStorageContextMock();
            _payValidationService = new PayValidationService(_storageContext, new CardValidationService());
        }

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
                Balance = Card1.Balance
            },
                new Card
            {
                Id = Guid.NewGuid(),
                Cvv = Card2.Cvv,
                ExpireYear = Card2.ExpireYear,
                ExpiryMonth = Card2.ExpiryMonth,
                Number = Card2.Number,
                IsUnlimited = true
            }
            });
            mock.Setup(s => s.OperationList).Returns(new List<Operation>());
            mock.Object.OperationList.Add(new Operation
            {
                AmountKop = 1000,
                Card = mock.Object.CardList[0],
                OrderId = _doneOrderId,
                Status = Api.Entities.OperationStatus.Done
            });
            return mock.Object;
        }

        [Fact]
        public void CheckOrderExists()
        {
            void action() => _payValidationService.CheckOrder(_doneOrderId);

            Assert.Throws<OrderExistsException>(action);
        }

        [Fact]
        public void CheckOrderIdEmpty()
        {
            void action() => _payValidationService.CheckOrder(string.Empty);

            Assert.Throws<OrderIdEmptyException>(action);
        }

        [Fact]
        public void CheckOrderNotExists()
        {
            _payValidationService.CheckOrder(_doneOrderId + "1");
        }

        [Fact]
        public void CheckPayNotEnoughMoney()
        {
            void action() => _payValidationService.CheckPay(_storageContext.CardList[0], _storageContext.CardList[0].Balance + 1, _storageContext.CardList[0].Cvv);

            Assert.Throws<NotEnoughMoneyException>(action);
        }

        [Fact]
        public void CheckPayEnoughMoney()
        {
            _payValidationService.CheckPay(_storageContext.CardList[0], _storageContext.CardList[0].Balance - 1, _storageContext.CardList[0].Cvv);
        }

        [Fact]
        public void CheckPayInvalidCvv()
        {
            var invalidCvv = _storageContext.CardList[0].Cvv - 1;
            void action() => _payValidationService.CheckPay(_storageContext.CardList[0], _storageContext.CardList[0].Balance - 1, invalidCvv);

            Assert.Throws<InvalidCvvException>(action);
        }

        [Fact]
        public void CheckPayValidCvv()
        {
            _payValidationService.CheckPay(_storageContext.CardList[0], _storageContext.CardList[0].Balance - 1, _storageContext.CardList[0].Cvv);
        }
    }
}
