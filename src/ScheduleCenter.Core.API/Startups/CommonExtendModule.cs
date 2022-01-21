using Microsoft.Extensions.DependencyInjection;
using ScheduleCenter.Swagger;
using Microsoft.AspNetCore.Builder;
using ScheduleCenter.AutoMapper;
using Microsoft.Extensions.Configuration;
using ScheduleCenter.Redis;
using System;
using ScheduleCenter.WebSockets;
using ScheduleCenter.SqlSugar;
using ScheduleCenter.WebSockets.WebSockets;
using ScheduleCenter.Shared;
using ScheduleCenter.Core.Quertz;
using Quartz.Spi;
using System.Collections.Generic;
using ScheduleCenter.Core.Jobs;

namespace ScheduleCenter.Core.API.Startups
{

    public static class CommonExtendModule
    {
        /// <summary>
        /// 公共拓展模块注入
        /// </summary>
        public static void AddCommonService(this IServiceCollection services, IConfiguration configuration) 
        {
            //自动注入拓展
            services.AddDependencyInjection();

            //swagger注入
            services.AddSwaggerService();

            //授权认证注入
            services.AddAuthService(configuration);

            //AutoMapper注入
            services.AddAutoMapperService();

            ////CRedis注入
            //service.AddCRedis();

            //使用分布式缓存
            services.AddDistributeRedis();

            //Sqlsugar服务注入
            services.AddSqlSugar();

            //事件总线注入
            services.AddEventBus();

            //WebSocket注入
            services.AddWebSocket();


            //定时任务注入
            services.AddJobs();
        }


        //公共中间件
        public static IApplicationBuilder UseCommonExtension(this IApplicationBuilder app) 
        {
            //Consul服务注册发现配置
            //app.UseConsul();

            //Swagger配置
            app.UseSwaggerService();

            //使用事件总线
            app.UseEventBus();

            //自定义异常中间件
            app.CustomerMiddleware();

            //开启定时任务
            //app.StartJob();

            //使用静态文件
            app.UseStaticFiles();

            //配置WebSocket中间件
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
            };
            app.UseWebSockets(webSocketOptions);
            app.UseMiddleware<WebSocketHandlerMiddleware>();

            return app;
        }
    }
}
