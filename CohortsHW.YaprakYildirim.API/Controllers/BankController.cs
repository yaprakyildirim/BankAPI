using CohortsHW.YaprakYildirim.Business.Atrributes;
using CohortsHW.YaprakYildirim.Business.Services.Abstract;
using CohortsHW.YaprakYildirim.Business.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CohortsHW.YaprakYildirim.API.Controllers
{
    [ApiController]
    [Route("sipy/api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;

        public BankController(IUserService userService, IPaymentService paymentService)
        {
            _userService = userService;
            _paymentService = paymentService;
        }

        [HttpGet]    
        public ActionResult<string> Get(string username, string password)
        {
         var boolvalue =   _userService.Login(username, password);
            if(boolvalue)
            {
              return  Ok("Giriş Başarılı");
            }
           return BadRequest("Kullanıcı bilgileri yanlıştır");           
        }

        [HttpGet("TotalFormatted")]
        public ActionResult<string> GetTotalPayment([FromQuery] decimal totalAmount)
        {
            var formattedTotal = _paymentService.GetTotalPaymentFormatted(totalAmount);
            return Ok(formattedTotal);
        }
    } 
}