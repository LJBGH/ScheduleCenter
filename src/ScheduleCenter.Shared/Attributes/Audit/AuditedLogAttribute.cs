using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared.Attributes.Audit
{
    /// <summary>
    /// 开启审计日志
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class AuditedLogAttribute : Attribute
    {

    }
}
