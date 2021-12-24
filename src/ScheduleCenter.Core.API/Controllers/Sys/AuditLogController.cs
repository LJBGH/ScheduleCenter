using ScheduleCenter.AspNetCore.ApiBase;
using ScheduleCenter.Dto.Sys.Audit;
using ScheduleCenter.Models.Entitys.Sys;
using ScheduleCenter.Services.Sys.Audit;
using ScheduleCenter.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleCenter.Core.API.Controllers.Sys
{

    /// <summary>
    /// 审计日志管理
    /// </summary>
    [Authorize]
    public class AuditLogController : ApiControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        /// <summary>
        /// 获取审计日志分页列表
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IPageResult<AuditLogEntity>> GetPageAsync([FromBody] PageRequest pageRequest) 
        {
            return await _auditLogService.GetPageAsync(pageRequest);
        }
    }
}
