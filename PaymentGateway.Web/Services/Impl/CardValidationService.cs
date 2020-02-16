using PaymentGateway.Web.Entities;
using PaymentGateway.Web.Exceptions.Pay;
using PaymentGateway.Web.Utils;
using System;

namespace PaymentGateway.Web.Services.Impl
{
    public class CardValidationService : ICardValidationService
    {
        public void CheckCard(string cardNumber, int expiryMonth, int expiryYear)
        {
            CheckNumber(cardNumber);
            CheckExpiryDate(expiryMonth, expiryYear);
        }

        public void CheckEnoughMoney(Card card, long amountKop)
        {
            if (!IsEnoughMoney(card, amountKop))
            {
                throw new NotEnoughMoneyException();
            }
        }

        private void CheckExpiryDate(int expiryMonth, int expiryYear)
        {
            if (!IsCorrectDate(expiryMonth, expiryYear))
            {
                throw new InvalidCardExpiryDateException();
            }
        }

        private void CheckNumber(string cardNumber)
        {
            if(IsEmpty(cardNumber) || !IsCorrectNumberLength(cardNumber) || !cardNumber.IsOnlyDigits())
            {
                throw new InvalidCardNumberException();
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

        private static bool IsCorrectDate(int expiryMonth, int year)
        {
            try
            {
                var date = new DateTime(year, expiryMonth, 1).AddMonths(1);
                return DateTime.Now < date;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsEnoughMoney(Card card, long amountKop)
        {
            return card.IsUnlimited || card.Balance > amountKop;
        }
    }
}
