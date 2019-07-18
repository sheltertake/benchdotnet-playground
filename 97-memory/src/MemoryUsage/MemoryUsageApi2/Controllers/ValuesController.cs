using Microsoft.AspNetCore.Mvc;

namespace MemoryUsageApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("{num}")]
        public ActionResult<object> Get(int num)
        {
            var data = new byte[num * 1024 * 1024];
            return new
            {
                a = data.Length,
                //g0 = GC.CollectionCount(0),
                //g1 = GC.CollectionCount(1),
                //g2 = GC.CollectionCount(2),
            };
        }

        [HttpGet]
        [Route("empty")]
        public ActionResult<string> Empty()
        {
            return string.Empty;
        }

    }
}
