using PaymentGateway.Api.Constants.Card;
using PaymentGateway.Web.Entities;
using System;
using System.Collections.Generic;

namespace PaymentGateway.Web.Services.Impl
{
    internal class StorageContext : IStorageContext
    {
        public IList<Card> CardList { get; } = new List<Card>();
        public IList<Operation> OperationList { get; } = new List<Operation>();

        public StorageContext()
        {
            InitCardList();
        }

        private void InitCardList()
        {
            CardList.Add(new Card
            {
                Id = Guid.NewGuid(),
                Cvv = Card1.Cvv,
                ExpireYear = Card1.ExpireYear,
                ExpiryMonth = Card1.ExpiryMonth,
                Number = Card1.Number,
                Balance = Card1.Balance
            });

            CardList.Add(new Card
            {
                Id = Guid.NewGuid(),
                Cvv = Card2.Cvv,
                ExpireYear = Card2.ExpireYear,
                ExpiryMonth = Card2.ExpiryMonth,
                Number = Card2.Number,
                IsUnlimited = true
            });
        }
    }
}
