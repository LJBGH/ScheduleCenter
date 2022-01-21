using Microsoft.Extensions.DependencyInjection;
using ScheduleCenter.SqlSugar.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.SqlSugar
{
    public static class SqlSugarMoudle
    {
        public static void AddSqlSugar(this IServiceCollection service) 
        {

            //SqlSugar泛型仓储注入
            service.AddSingleton(typeof(ISqlSugarRepository<>), typeof(SqlSugarRepository<>));
        }
    }
}
