using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Client
{
    namespace TextConstants
    {
        internal static class MainMenu
        {
            public const string P1 = "1 - Список доступных карт";
            public const string P2 = "2 - Список операций";
            public const string P3 = "3 - Провести операцию (Pay)";
            public const string P4 = "4 - Статус операции";
            public const string P5 = "5 - Откатить операцию (Refund)";
            public const string P6 = "6 - Выход";
        }


        namespace Payment
        {
            internal static class Menu
            {
                public const string EnterData = "Введите данные операции";
                public const string EnterOrderId = "Введите номер заказа";
                public const string EnterAmount = "Введите сумму заказа";
                public const string EnterCardNumber = "Введите номер карты (16 цифр)";
                public const string EnterExpiryMonth = "Введите месяц окончания действия карты числом";
                public const string EnterExpiryYear = "Введите год окончания действия карты числом (4 цифры)";
                public const string EnterCvv = "Введите проверочный код карты CVV (3 цифры)";
                public const string OperationResultFormat = "Результат операции: {0}";
            }

            internal static class PayResult
            {
                public const string Ok = "OK";
                public const string InvalidCardNumber = "Некорректный номер карты";
                public const string OrderExists = "Данный заказ уже проведён";
                public const string NotEnoughMoney = "Недостаточно средств для проведения операции";
                public const string InvalidCvv = "Некорректный код подтверждения";
                public const string InvalidExpiryDate = "Срок действия карты истёк";
                public const string OrderIdEmpty = "Номер заказа не может быть пустым";
                public const string Unknown = "Неизвестная ошибка";
            }
        }

        namespace Refund
        {
            internal static class Menu
            {
                public const string EnterOrderId = "Введите номер заказа";
                public const string OperationResultFormat = "Результат операции: {0}";
            }

            internal static class RefundResult
            {
                public const string Ok = "OK";
                public const string OrderNotFound = "Заказ не найден";
                public const string AlreadyDone = "Заказ уже возвращён";
                public const string Unknown = "Неизвестная ошибка";
            }
        }

        namespace Status
        {
            internal static class Menu
            {
                public const string EnterOrderId = "Введите номер заказа";
                public const string OperationResultFormat = "Статус заказа: {0}";
            }

            internal static class OperationStatus
            {
                public const string Done = "OK";
                public const string NotFound = "Заказ не найден";
                public const string Refund = "Заказ возвращён";
                public const string Unknown = "Неизвестная ошибка";
            }
        }
    }
}