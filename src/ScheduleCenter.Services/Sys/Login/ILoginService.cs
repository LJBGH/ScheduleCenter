using ScheduleCenter.Dto.Sys.Login;
using ScheduleCenter.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleCenter.Services.Sys.Login
{
    public interface ILoginService : IScopedDependency
    {

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        Task<AjaxResult> SignInAsync(LoginInputDto input);


        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        Task<AjaxResult> SignOutAsync();


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        Task<AjaxResult> UpdatePasswordAsync(PasswordDto input);


        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AjaxResult> RefreshAccessTokenAsync(RefreshTokenDto input);
    }
}
