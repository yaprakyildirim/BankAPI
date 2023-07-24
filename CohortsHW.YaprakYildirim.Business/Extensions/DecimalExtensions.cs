namespace CohortsHW.YaprakYildirim.Business.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToCurrencyFormat(this decimal amount, string currencySymbol = "TL")
        {
            // TL için formatlama (Örnek: "1.234,56 TL")
            return string.Format(System.Globalization.CultureInfo.GetCultureInfo("tr-TR"), "{0:N2} {1}", amount, currencySymbol);
        }
    }
}
