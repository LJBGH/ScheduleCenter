using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    /// <summary>
    /// 如果使用AutoMapper会跟官方冲突，所以在前面加了项目代号
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class LiliyaAutoMapperAttribute  : Attribute
    {
        public LiliyaAutoMapperAttribute(params Type[] targetTypes)
        {
            targetTypes.NotNull(nameof(targetTypes));
            TargetTypes = targetTypes;
        }

        /// <summary>
        /// 类型数组
        /// </summary>
        public Type[] TargetTypes { get; private set; }

        public virtual LiliyaAutoMapDirection MapDirection
        {
            get { return LiliyaAutoMapDirection.From | LiliyaAutoMapDirection.To; }
        }
    }
}
