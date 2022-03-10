using ScheduleCenter.Core.Quertz;
using ScheduleCenter.Core.ScheduleCenter;
using ScheduleCenter.Dto.Schedule;
using ScheduleCenter.Models.Entitys.Schedule;
using ScheduleCenter.Shared;
using ScheduleCenter.SqlSugar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleCenter.Core.Schedule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleCenter _scheduleCenter;

        private readonly ISqlSugarRepository<ScheduleEntity> _scheduleRepository;

        public ScheduleService(IScheduleCenter scheduleCenter, ISqlSugarRepository<ScheduleEntity> scheduleRepository)
        {
            _scheduleCenter = scheduleCenter;
            _scheduleRepository = scheduleRepository;

        }


        /// <summary>
        /// 获取所有计划任务
        /// </summary>
        /// <returns></returns>
        public async Task<List<ScheduleOutDto>> GetAllASync()
        {
            var list = await _scheduleRepository.GetAllAsync();

            var data = list.MapToList<ScheduleOutDto>();

            return data.ToList();
        }


        /// <summary>
        /// 开启任务调度
        /// </summary>
        /// <param name="schedules"></param>
        /// <returns></returns>
        public async Task<AjaxResult> StartScheduleAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();
            var list = schedules.Where(x => x.JobStatus == JobStatus.Enabled).ToList();
            var result = await _scheduleCenter.StartScheduleAsync(list);

            return new AjaxResult(result.Success == true ? "开启任务调度成功" : "开启任务调度失败", result.Success == true ? AjaxResultType.Success : AjaxResultType.Error);
        }

        /// <summary>
        /// 停止任务调度
        /// </summary>
        /// <param name="schedules"></param>
        /// <returns></returns>
        public async Task<AjaxResult> StopScheduleAsync()
        {
            var result = await _scheduleCenter.StopScheduleAsync();

            return new AjaxResult(result.Success == true ? "停止任务调度成功" : "停止任务调度失败", result.Success == true ? AjaxResultType.Success : AjaxResultType.Error);
        }

        /// <summary>
        /// 添加一条任务计划
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<AjaxResult> InsertAsync(ScheduleInputDto inputDto)
        {
            var entity = inputDto.MapTo<ScheduleEntity>();
            return await _scheduleRepository.InsertAsync(entity);
        }


        /// <summary>
        /// 执行任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AjaxResult> ExecuteAsync(Guid id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);
            if (schedule == null)
                return new AjaxResult("未找到该任务", AjaxResultType.Success);

            ScheduleManage.Instance.AddScheduleList(schedule);

            QuartzNetResult result;

            //自定义定时任务
            if (schedule.TriggerType == TriggerType.Simple)
            {
                result = await _scheduleCenter.RunSchedule<ScheduleManage>(schedule.JobName, schedule.JobGroup);
                //result = SchedulerCenter.Instance.RunScheduleJob<>
            }
            //Cron定时
            else
            {
                result = await _scheduleCenter.RunSchedule<ScheduleManage>(schedule.JobName, schedule.JobGroup);
            }

            if (result.Success == true)
            {
                schedule.JobStatus = JobStatus.Enabled;
                await _scheduleRepository.UpdateAsync(schedule);
            }
            return new AjaxResult(result.Success == true ? "执行成功" : "执行失败", result.Success == true ? AjaxResultType.Success : AjaxResultType.Error);
        }

        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AjaxResult> StopAsync(Guid id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);
            if (schedule == null)
                return new AjaxResult("未找到该任务", AjaxResultType.Success);

            var result = await _scheduleCenter.StopScheduleJob<ScheduleManage>(schedule.JobName, schedule.JobGroup);
            if (result.Success == true)
            {
                schedule.JobStatus = JobStatus.Stoped;
                await _scheduleRepository.UpdateAsync(schedule);
            }
            return new AjaxResult(result.Success == true ? "停止任务成功" : "停止任务失败", result.Success == true ? AjaxResultType.Success : AjaxResultType.Error);
        }

        /// <summary>
        /// 恢复任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AjaxResult> ResumeAsync(Guid id)
        {
            var scheduleEntity = await _scheduleRepository.GetByIdAsync(id);
            if (scheduleEntity == null)
                return new AjaxResult("未找到该任务", AjaxResultType.Success);

            var schedule = await _scheduleRepository.GetByIdAsync(id);
            if (schedule == null)
                return new AjaxResult("未找到该任务", AjaxResultType.Success);

            var result = await _scheduleCenter.ResumeJob(schedule.JobName, schedule.JobGroup);

            if (result.Success == true)
            {
                schedule.JobStatus = JobStatus.Enabled;
                await _scheduleRepository.UpdateAsync(schedule);
            }
            return new AjaxResult(result.Success == true ? "恢复任务成功" : "恢复任务失败", result.Success == true ? AjaxResultType.Success : AjaxResultType.Error);
        }

        /// <summary>
        /// 获取所有计划任务
        /// </summary>
        /// <returns></returns>
        public async Task<AjaxResult> GetAllAsync()
        {
            var list = await _scheduleRepository.GetAllAsync();
            var result = list.MapToList<ScheduleOutDto>();

            return new AjaxResult(ResultMessage.LoadSucces, result, AjaxResultType.Success);
        }
    }
}
