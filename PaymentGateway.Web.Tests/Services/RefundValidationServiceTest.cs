using Moq;
using PaymentGateway.Api.Constants.Card;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions.Refund;
using PaymentGateway.Web.Services;
using PaymentGateway.Web.Services.Impl;
using System;
using System.Collections.Generic;
using Xunit;

namespace PaymentGateway.Web.Tests.Services
{
    public class RefundValidationServiceTest
    {
        private readonly IStorageContext _storageContext;
        private readonly IRefundValidationService _refundValidationService;

        private const string _doneOrderId = "111";
        private const string _refundOrderId = "112";

        public RefundValidationServiceTest()
        {
            _storageContext = GetStorageContextMock();
            _refundValidationService = new RefundValidationService(_storageContext);
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
            mock.Object.OperationList.Add(new Operation
            {
                AmountKop = 900,
                Card = mock.Object.CardList[0],
                OrderId = _refundOrderId,
                Status = Api.Entities.OperationStatus.Refund
            });
            return mock.Object;
        }

        [Fact]
        public void CheckOrderOk()
        {
            _refundValidationService.CheckOrder(_doneOrderId);
        }

        [Fact]
        public void CheckOrderNotExists()
        {
            var invalidOrder = _doneOrderId + "1";
            void action() => _refundValidationService.CheckOrder(invalidOrder);

            Assert.Throws<OrderNotExistsException>(action);
        }

        [Fact]
        public void CheckOrderAlreadyRefund()
        {
            void action() => _refundValidationService.CheckOrder(_refundOrderId);

            Assert.Throws<AlreadyRefundException>(action);
        }
    }
}
