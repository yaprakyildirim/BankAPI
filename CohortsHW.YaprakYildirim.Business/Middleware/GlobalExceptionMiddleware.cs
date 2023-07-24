using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CohortsHW.YaprakYildirim.Business.Middleware
{
    /// GlobalExceptionMiddleware, tüm projedeki istisnaları (exception) yakalamak için kullanılan global bir middleware'dir.
    /// Herhangi bir hata oluştuğunda bu middleware otomatik olarak devreye girer ve genel bir hata mesajı döndürür.
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Loglama işlemi (Burada sadece konsola yazdırıyoruz)
            Console.WriteLine($"Global Hata Yakalandı: {exception.Message}");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                status = context.Response.StatusCode,
                message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz."
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}