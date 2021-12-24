using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Shared
{
    public static class ListExtensions
    {
        public static bool IsNotNull<T>(this List<T> list)
        {
            return list != null && list.Count > 0;
        }
    }
}
