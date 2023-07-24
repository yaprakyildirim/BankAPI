using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CohortsHW.YaprakYildirim.Business.Extensions
{
    public static class HttpRequestExtensions
    {
        // Bu metot, HttpRequest nesnesinin gövdesini asenkron olarak bir dize olarak alır.
        // Gövde daha sonra tekrar kullanılabilir olması için tekrar pozisyonlandırılır.
        public static async Task<string> GetBodyAsStringAsync(this HttpRequest request)
        {
            request.EnableBuffering();

            // İsteğin gövdesini bir StreamReader kullanarak bir dize olarak okuyoruz.
            using var reader = new StreamReader(request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var body = await reader.ReadToEndAsync();

            // Gövdeyi okuduktan sonra, isteğin gövdesini tekrar kullanılabilir yapmak için başlangıç konumuna sıfırlıyoruz.
            request.Body.Position = 0;

            return body;
        }
    }
}