using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    /// <summary>
    /// 事件订阅器
    /// </summary>
    public interface IEventSubscriber : IDisposable
    {
        void Subscribe();
    }
}
