using CohortsHW.YaprakYildirim.Business.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CohortsHW.YaprakYildirim.Business.Middleware
{
    /// LogMiddleware, gelen her HTTP isteğini loglamak için kullanılır.
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// HTTP isteğini işleyen ve loglama yapan metod.
        public async Task Invoke(HttpContext context)
        {
            // Gelen HTTP isteğinin içeriğini al
            var requestBody = await context.Request.GetBodyAsStringAsync(); // Request body'yi al

            // İsteğin metodu, yolu ve içeriğini konsola yaz
            Console.WriteLine($"Actiona girildi: {context.Request.Method} - {context.Request.Path} - Body: {requestBody}");

            //sonraki middleware geç
            await _next(context);
        }
    }
}