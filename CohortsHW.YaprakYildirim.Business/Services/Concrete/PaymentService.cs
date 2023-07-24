using CohortsHW.YaprakYildirim.Business.Extensions;
using CohortsHW.YaprakYildirim.Business.Services.Abstract;

namespace CohortsHW.YaprakYildirim.Business.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        public string GetTotalPaymentFormatted(decimal totalAmount)
        {
            return totalAmount.ToCurrencyFormat();
        }
    }
}
