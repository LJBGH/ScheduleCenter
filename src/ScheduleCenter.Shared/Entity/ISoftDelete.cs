using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
