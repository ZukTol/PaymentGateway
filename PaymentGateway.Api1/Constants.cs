namespace PaymentGateway.Api
{
    namespace Constants
    {
        namespace Card
        {
            public static class Card1
            {
                public const string CardholderName = "John Carmack";
                public const int Cvv = 337;
                public const int ExpireYear = 2024;
                public const int ExpiryMonth = 10;
                public const string Number = "1234123498766543";
                public const long Balance = 10000;
            }

            public static class Card2
            {
                public const string CardholderName = "Gabe Newell";
                public const int Cvv = 222;
                public const int ExpireYear = 2021;
                public const int ExpiryMonth = 3;
                public const string Number = "1234567898765432";
            }
        }

        namespace Http
        {
            internal static class Header
            {
                internal const string ContentTypeJson = "application/json";
                internal const string AcceptJson = "application/json;odata=verbose";
            }
        }
    }
}
