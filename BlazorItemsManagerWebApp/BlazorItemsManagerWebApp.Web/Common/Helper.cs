using System.Globalization;

namespace BlazorItemsManagerWebApp.Web.Common
{
    public static class Helper
    {
        public static string DecimalPoinFixer(string value)
        {
            string newString = value.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            newString = newString.Replace(".",
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            return newString;
        }
    }
}
