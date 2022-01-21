using ScheduleCenter.Dto.Sys.Audit;
using ScheduleCenter.Models.Entitys.Sys;
using ScheduleCenter.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCenter.Services.Sys.Audit
{
    public interface IAuditLogService : IScopedDependency
    {

        /// <summary>
        /// 添加一条审计日志
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AjaxResult> AddAsync(AuditLogInputDto input);

        /// <summary>
        /// 分页获取审计日志
        /// </summary>
        /// <returns></returns>
        Task<IPageResult<AuditLogEntity>> GetPageAsync(PageRequest pageRequest);
  
    }
}
