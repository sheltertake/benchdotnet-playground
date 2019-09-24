using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi3.Controllers
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
