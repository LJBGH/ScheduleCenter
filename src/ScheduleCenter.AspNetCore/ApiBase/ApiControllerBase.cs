using Microsoft.AspNetCore.Mvc;

namespace ScheduleCenter.AspNetCore.ApiBase
{
    [Route("schedulecenter/[controller]/[action]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {

    }
}
