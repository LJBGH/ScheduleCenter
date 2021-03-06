using ScheduleCenter.Models.Entitys.Sys;
using ScheduleCenter.Shared;
using ScheduleCenter.SqlSugar.Repository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ScheduleCenter.Core.API.Event
{
    /// <summary>
    /// 测试事件
    /// </summary>
    public class TestEventHander : IEventHandler<TestEvent>
    {
        private readonly ISqlSugarRepository<UserEntity> _userRepository;

        public TestEventHander(ISqlSugarRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// 是否可以处理
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public bool CanHandle(IEvent @event) => @event.GetType().Equals(typeof(TestEvent));


        public async Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default)
        {
            var iscanHandle = CanHandle(@event);
            if (iscanHandle)
            {
                return await HandleAsync((TestEvent)@event, cancellationToken);
            }
            return false;
        }


        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> HandleAsync(TestEvent @event, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            Console.WriteLine(@event.Id);
            Console.WriteLine(@event.Timestamp);

            //UserEntity user = new UserEntity
            //{
            //    Account = "测试",
            //    Name = "测试"
            //};
            //await _userRepository.InsertAsync(user);

            var table = _userRepository.DbContext().Ado.SqlQuery<decimal>("", new List<SugarParameter>
            {
                new SugarParameter("@name", "张三"),
                new SugarParameter("@age",20)
            });

            var table1 = _userRepository.DbContext().Ado.UseStoredProcedure().SqlQuery<decimal>("", new List<SugarParameter>
            {
                new SugarParameter("@name", "张三"),
                new SugarParameter("@age",20)
            });

            return true;
        }



     
    }
}
