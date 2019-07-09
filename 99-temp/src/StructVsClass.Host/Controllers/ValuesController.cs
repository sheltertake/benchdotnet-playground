using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Lib = StructVsClassLib;

namespace StructVsClass.Host.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private Lib.StructVsClass Lib;

        public ValuesController()
        {
            Lib = new Lib.StructVsClass();
        }
        // GET api/values
        [HttpGet]
        [Route("classes")]
        public ActionResult<IEnumerable<string>> Classes(int amount)
        {
            return Lib.PeopleEmployeedWithinLocation_Classes(amount);
        }
        [HttpGet]
        [Route("structs")]
        public ActionResult<IEnumerable<string>> Structs(int amount)
        {
            return Lib.PeopleEmployeedWithinLocation_Structs(amount);
        }
        [HttpGet]
        [Route("pools")]
        public ActionResult<IEnumerable<string>> ArrayPools(int amount)
        {
            return Lib.PeopleEmployeedWithinLocation_ArrayPoolStructs(amount);
        }
    }
}
