using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    /// <summary>
    /// 如果使用AutoMapper会跟官方冲突，所以在前面加了项目代号
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ScheduleCenterAutoMapperAttribute  : Attribute
    {
        public ScheduleCenterAutoMapperAttribute(params Type[] targetTypes)
        {
            targetTypes.NotNull(nameof(targetTypes));
            TargetTypes = targetTypes;
        }

        /// <summary>
        /// 类型数组
        /// </summary>
        public Type[] TargetTypes { get; private set; }

        public virtual ScheduleCenterAutoMapDirection MapDirection
        {
            get { return ScheduleCenterAutoMapDirection.From | ScheduleCenterAutoMapDirection.To; }
        }
    }
}
