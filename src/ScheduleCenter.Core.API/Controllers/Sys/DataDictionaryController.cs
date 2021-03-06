using ScheduleCenter.AspNetCore.ApiBase;
using ScheduleCenter.Dto.Sys.DataDictionary;
using ScheduleCenter.Services.Sys.DataDictionary;
using ScheduleCenter.Shared;
using ScheduleCenter.Shared.Attributes.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ScheduleCenter.Core.API.Controllers.Sys
{
    /// <summary>
    /// 数据字典管理
    /// </summary>
    [Authorize]
    [AuditedLog]
    public class DataDictionaryController : ApiControllerBase
    {

        private readonly IDataDictionaryService _dataDictionaryService;

        public DataDictionaryController(IDataDictionaryService dataDictionaryService)
        {
            _dataDictionaryService = dataDictionaryService;
        }

        /// <summary>
        /// 添加数据字典
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<AjaxResult> InsertAsync([FromBody] DataDictionaryInputDto input) 
        {
            return await _dataDictionaryService.InsertAsync(input);
        }

        /// <summary>
        /// 修改数据字典
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AjaxResult> UpdateAsync([FromBody] DataDictionaryInputDto input) 
        {
            return await _dataDictionaryService.UpdateAsync(input);
        }


        /// <summary>
        /// 删除数据字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AjaxResult> DeleteAsync(Guid id) 
        {
            return await _dataDictionaryService.DeleteAsync(id);
        }

        /// <summary>
        /// 获取数据字典树形
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<AjaxResult> GetTreeAsync() 
        {
            return await _dataDictionaryService.GetTreeAsync();
        }
    }
}
