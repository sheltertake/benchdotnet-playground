using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webapi2.Controllers
{
    [Route("helloworld")]
    public class HelloWorldController
    {
        // GET api/values
        [HttpGet]
        public int Get()
        {
            return 0;
        }

    }
}
