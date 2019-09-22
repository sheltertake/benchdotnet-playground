using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi3.Controllers {
    [ApiController]
    public class MathController : ControllerBase {

        static int SyncRequests = 0;
        static int AsyncRequests = 0;

        [HttpGet("math/report")]
        public object Report(int num)
        {
            return new
            {
                Sync = SyncRequests,
                Async = AsyncRequests,
            };
        }


        [HttpGet ("math/sync/{num}")]
        public int Sync (int num) {
            if (SyncRequests == 10)
                num = 2147483647;
            SyncRequests++;
            return IsPrime (num) ? num : 0; //2147483647
        }

        [HttpGet ("math/async/{num}")]
        public Task<int> Async (int num) {
            if (AsyncRequests == 10)
                num = 2147483647;
            AsyncRequests++;
            return Task.FromResult (IsPrime (num) ? num : 0); //2147483647
        }

        // It's not the fastest algorithm,
        // but we will optimize it later.
        public static bool IsPrime (int n) {
            for (int i = 2; i <= n - 1; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}