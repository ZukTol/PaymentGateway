using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Web.Services.Impl
{
    internal class CardValidationService : ICardValidationService
    {
        public void CheckCard(string cardNumber, int expiryMonth, int expiryYear)
        {
            CheckNumber(cardNumber);
        }

        private void CheckNumber(string cardNumber)
        {
            if(IsEmpty(cardNumber) || IsCorrectNumberLength(cardNumber))
            {
                throw new InvalidCardNumberException();
            }
        }

        private bool IsCorrectNumberLength(string cardNumber)
        {
            return cardNumber.Replace(" ", string.Empty).Length == Constants.CardParam.NumberLength;
        }

        private static bool IsEmpty(string cardNumber)
        {
            return string.IsNullOrEmpty(cardNumber);
        }
    }
}
