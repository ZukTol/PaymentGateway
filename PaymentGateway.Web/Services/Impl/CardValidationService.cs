using PaymentGateway.Web.Exceptions.Pay;
using PaymentGateway.Web.Utils;
using System;

namespace PaymentGateway.Web.Services.Impl
{
    internal class CardValidationService : ICardValidationService
    {
        public void CheckCard(string cardNumber, int expiryMonth, int expiryYear)
        {
            CheckNumber(cardNumber);
            CheckExpiryMonth(expiryMonth);
            CheckExpiryYear(expiryYear);
        }

        private void CheckExpiryYear(int expiryYear)
        {
            if (!IsCorrectYear(expiryYear))
            {
                throw new InvalidCardInfoException();
            }
        }

        private void CheckExpiryMonth(int expiryMonth)
        {
            if (!IsCorrectMonth(expiryMonth))
            {
                throw new InvalidCardInfoException();
            }
        }

        private void CheckNumber(string cardNumber)
        {
            if(IsEmpty(cardNumber) || !IsCorrectNumberLength(cardNumber) || !cardNumber.IsOnlyDigits())
            {
                throw new InvalidCardInfoException();
            }
        }

        private bool IsCorrectNumberLength(string cardNumber)
        {
            return cardNumber.RemoveSpace().Length == Constants.CardParam.NumberLength;
        }

        private static bool IsEmpty(string cardNumber)
        {
            return string.IsNullOrEmpty(cardNumber);
        }

        private static bool IsCorrectMonth(int month)
        {
            return month > 0 && month <= 12;
        }

        private static bool IsCorrectYear(int year)
        {
            try
            {
                var date = new DateTime(year, 1, 1);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
