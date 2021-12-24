using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    public interface IPageResult<T>
    {
        int Total { get; }

        IEnumerable<T> Data { get; set; }
    }
}
