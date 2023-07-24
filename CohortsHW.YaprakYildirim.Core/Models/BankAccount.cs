namespace CohortsHW.YaprakYildirim.Core.Models
{
    public class BankAccount
    {
        public int AccountNumber { get; set; }
        public int CustomerNumber { get; set; }
        public string AccountName { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Balance { get; set; }
    }
}
