using Moq;
using PaymentGateway.Api.Constants.Card;
using PaymentGateway.Api.Entities;
using PaymentGateway.Web.Controllers;
using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Services;
using PaymentGateway.Web.Services.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PaymentGateway.Web.Tests.Controllers
{
    public class PayControllerTest
    {
        private static IOperationService GetOperationService(IStorageContext storageContext)
        {
            return new OperationService(
                new CardService(new CardValidationService(), storageContext), 
                storageContext, 
                new PayValidationService(storageContext, new CardValidationService()), 
                new RefundValidationService(storageContext));
        }

        [Fact]
        public void PayTest()
        {
            var storageMock = new Mock<IStorageContext>();
            storageMock.Setup(s => s.CardList).Returns(new List<Card>
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
                } });
            storageMock.Setup(s => s.OperationList).Returns(new List<Entities.Operation>());
            var storageContext = storageMock.Object;

            var controller = new PayController(GetOperationService(storageContext), storageContext);

            var orderId = "111";
            var amount = 200;
            var result = controller.Post(new Api.Entities.PayRequest
            {
                AmountKop = amount,
                CardNumber = Card1.Number,
                Cvv = Card1.Cvv,
                ExpiryMonth = Card1.ExpiryMonth,
                ExpiryYear = Card1.ExpireYear,
                OrderId = orderId
            });

            Assert.Equal(PayResult.Ok, result);
            var expectedBalance = Card1.Balance - amount;
            Assert.Equal(expectedBalance, storageContext.CardList[0].Balance);
            Assert.Equal(1, storageContext.OperationList.Count);
            Assert.Equal(OperationStatus.Done, storageContext.OperationList[0].Status);
            Assert.Equal(orderId, storageContext.OperationList[0].OrderId);
            Assert.Equal(amount, storageContext.OperationList[0].AmountKop);
            Assert.Equal(storageContext.CardList[0], storageContext.OperationList[0].Card);
        }

        [Fact]
        public void GetStatusTest()
        {
            var orderId = "111";
            var amount = 200;

            var storageMock = new Mock<IStorageContext>();
            storageMock.Setup(s => s.CardList).Returns(new List<Card>
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
                } });
            storageMock.Setup(s => s.OperationList).Returns(new List<Entities.Operation>());

            var storageContext = storageMock.Object;
            storageContext.OperationList.Add(new Entities.Operation
            {
                AmountKop = amount,
                Card = storageContext.CardList[0],
                OrderId = orderId,
                Status = OperationStatus.Done
            });

            var controller = new PayController(GetOperationService(storageContext), storageContext);

            var result = controller.GetStatus(orderId);
            Assert.Equal(OperationStatus.Done, result);
        }

        [Fact]
        public void RefundTest()
        {
            var orderId = "111";
            var amount = 200;

            var storageMock = new Mock<IStorageContext>();
            storageMock.Setup(s => s.CardList).Returns(new List<Card>
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
                } });
            storageMock.Setup(s => s.OperationList).Returns(new List<Entities.Operation>());

            var storageContext = storageMock.Object;
            storageContext.OperationList.Add(new Entities.Operation
            {
                AmountKop = amount,
                Card = storageContext.CardList[0],
                OrderId = orderId,
                Status = OperationStatus.Done
            });

            var controller = new PayController(GetOperationService(storageContext), storageContext);

            var result = controller.Refund(new RefundRequest { OrderId = orderId });

            Assert.Equal(RefundResult.Ok, result);
            var expectedBalance = Card1.Balance + amount;
            Assert.Equal(expectedBalance, storageContext.CardList[0].Balance);
            Assert.Equal(1, storageContext.OperationList.Count);
            Assert.Equal(OperationStatus.Refund, storageContext.OperationList[0].Status);
            Assert.Equal(orderId, storageContext.OperationList[0].OrderId);
            Assert.Equal(amount, storageContext.OperationList[0].AmountKop);
            Assert.Equal(storageContext.CardList[0], storageContext.OperationList[0].Card);
        }
    }
}
