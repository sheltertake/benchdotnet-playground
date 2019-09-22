using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi3.Controllers {
    [ApiController]
    public class FileController : ControllerBase {

        [HttpGet ("file/sync")]
        public string Sync () {
            return System.IO.File.ReadAllText ("file.txt");
        }

        [HttpGet ("file/async")]
        public async Task<string> Async () {
            return await System.IO.File.ReadAllTextAsync("file.txt");
        }

    }
}