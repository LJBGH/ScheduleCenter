using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.Dto.Sys.Login
{
    public class LoginInputDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

    }
}
