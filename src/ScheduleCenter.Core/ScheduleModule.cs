using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Spi;
using ScheduleCenter.Core.Jobs;
using ScheduleCenter.Core.Quertz;
using ScheduleCenter.Core.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCenter.Core
{
    public static class ScheduleModule
    {

        /// <summary>
        /// 注入定时任务
        /// </summary>
        /// <param name="services"></param>
        public static void AddJobs(this IServiceCollection services)
        {
            //自定义Job工厂注入
            services.AddSingleton<IJobFactory, IOCJobFactory>();

            //定时任务注入
            List<Type> jobtype = new List<Type>();
            jobtype.Add(typeof(TestJob));
            foreach (var item in jobtype)
            {
                services.AddTransient(item);//Job使用瞬时依赖注入
            }
        }

        /// <summary>
        /// 开启定时任务 : 开启时，所有定时任务在程序运行时开始执行
        /// </summary>
        /// <param name="app"></param>
        public static void StartJob(this IApplicationBuilder app)
        {
            var scheduleService = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IScheduleService>();

            scheduleService.StartScheduleAsync();
        }

    }
}
