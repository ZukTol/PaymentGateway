﻿using System;

namespace PaymentGateway.Web.Utils
{
    public class CheckHelper
    {
        public static void CheckNull([ValidatedNotNull] object value, string arg)
        {
            if (value == null)
            {
                throw new ArgumentNullException(arg);
            }
        }

        private class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}