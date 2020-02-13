namespace PaymentGateway.Web.Utils
{
    public static class StringHelper
    {
        public static string RemoveSpace(this string This)
        {
            return This.Trim().Replace(Constants.Ctrl.Space, string.Empty);
        }

        public static bool IsOnlyDigits(this string This)
        {
            This = This.RemoveSpace();
            foreach (char c in This)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
