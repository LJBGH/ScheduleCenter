using ScheduleCenter.AspNetCore.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ScheduleCenter.Core.API.Startups
{
    /// <summary>
    /// 自定义中间件拓展
    /// </summary>
    public static class MiddlewareModule
    {

        public static IApplicationBuilder CustomerMiddleware (this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomerExceptionMiddleware>();
        }
    }
}
