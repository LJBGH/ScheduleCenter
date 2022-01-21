using Quartz;
using ScheduleCenter.Models.Entitys.Schedule;
using ScheduleCenter.SqlSugar.Repository;
using Serilog;
using System;
using System.Threading.Tasks;

namespace ScheduleCenter.Core.Jobs
{
    public class TestJob : IJob
    {
        //private readonly ILogger _logger;
        //private readonly ISqlSugarRepository<ScheduleEntity> _scheduelRepository;

        //public TestJob(ILogger logger, ISqlSugarRepository<ScheduleEntity> scheduelRepository)
        //{
        //    _logger = logger;
        //    _scheduelRepository = scheduelRepository;
        //}

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.CompletedTask;
            Console.WriteLine("测试Job执行成功");
        }
    }
}
