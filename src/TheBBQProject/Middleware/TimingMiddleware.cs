using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace TheBBQProject.Middleware
{
    public class TimingMiddleware
    {
        RequestDelegate _next;

        public TimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();

            using (var memoryStream = new MemoryStream())
            {
                var bodyStream = context.Response.Body;
                context.Response.Body = memoryStream;

                await _next(context);

                var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
                if (context.Response.StatusCode == 200 && isHtml.GetValueOrDefault())
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using (var streamReader = new StreamReader(memoryStream))
                    {
                        var responseBody = await streamReader.ReadToEndAsync();
                        //C# 6 DEMO
                        var newFooter = string.Format($"<footer><div id='process'>Page processed in {sw.ElapsedMilliseconds} milliseconds.</div>");
                        responseBody = responseBody.Replace("<footer>", newFooter);
                        context.Response.Headers.Add("X-ElapsedTime", new[] { sw.ElapsedMilliseconds.ToString() });
                        using (var amendedBody = new MemoryStream())
                        using (var streamWriter = new StreamWriter(amendedBody))
                        {
                            streamWriter.Write(responseBody);
                            amendedBody.Seek(0, SeekOrigin.Begin);
                            await amendedBody.CopyToAsync(bodyStream);
                        }
                    }
                }
            }
        }
    }
}
