using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public interface IEventBus : IEventPublisher, IEventSubscriber
    {

    }
}
