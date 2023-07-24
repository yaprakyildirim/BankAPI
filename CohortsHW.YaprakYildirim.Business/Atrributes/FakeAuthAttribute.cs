using CohortsHW.YaprakYildirim.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace CohortsHW.YaprakYildirim.Business.Atrributes
{
    ///////////////Custom Attribute ile Kontrol////////////////////
    /// FakeAuthAttribute, basit bir yetkilendirme kontrolü sağlamak amacıyla kullanılan bir filtre özniteliğidir.
    public class FakeAuthAttribute : Attribute, IAuthorizationFilter
    {
        /// Yetkilendirme kontrolü gerçekleştirilirken çağrılır.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Request.Headers["User"].ToString();
            var pass = context.HttpContext.Request.Headers["Pass"].ToString();

            var userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));
            if (!userService.Login(user, pass))
            {
                // Kullanıcı adı ve şifre bilgileri doğru değilse, yetkisiz erişim hatası (401 Unauthorized) döndürür.
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
