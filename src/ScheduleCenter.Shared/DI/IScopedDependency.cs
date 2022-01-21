using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCenter.Shared
{
    /// <summary>
    /// 实现此接口的类型将自动注册为  <see ServiceLifetime.Scoped>模式
    /// </summary>
    [IgnoreDependency]
    public interface IScopedDependency
    {

    }
}
