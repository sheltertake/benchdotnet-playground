using MemoryUsage;
using Microsoft.AspNetCore.Mvc;

namespace MemoryUsageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return MemoryUsageHelper.GetString();
        }

        [HttpGet]
        [Route("empty")]
        public ActionResult<string> Empty()
        {
            return string.Empty;
        }

    }
}
