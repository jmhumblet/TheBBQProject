using Microsoft.AspNet.Builder;

namespace TheBBQProject.Middleware
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseTimingMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TimingMiddleware>();
        }
    }
}
