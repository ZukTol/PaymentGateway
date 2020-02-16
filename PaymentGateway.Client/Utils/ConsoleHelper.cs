using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Client.Utils
{
    internal static class ConsoleHelper
    {
        public static int GetIntegerInput(string text)
        {
            var input = GetTextInput(text);
            return int.Parse(input, System.Globalization.NumberStyles.Integer);
        }

        public static string GetTextInput(string text)
        {
            Console.WriteLine(text);
            var input = Console.ReadLine();
            return input;
        }
    }
}
