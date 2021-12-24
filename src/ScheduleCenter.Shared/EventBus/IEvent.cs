using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    /// <summary>
    /// 事件基类
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// 事件唯一Id
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// 事件触发时间
        /// </summary>
        DateTime Timestamp { get; }
    }
}
