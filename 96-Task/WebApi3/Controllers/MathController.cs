using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi3.Controllers
{
    [ApiController]
    public class MathController : ControllerBase
    {
        private static int SyncRequests = 0;
        private static int AsyncRequests = 0;
        
        [HttpGet("math/report")]
        public object Report(int num)
        {
            return new
            {
                Sync = SyncRequests,
                Async = AsyncRequests,

            };
        }


        [HttpGet("math/sync/{num}")]
        public int Sync(int num)
        {
            SyncRequests++;
            return IsPrime(num) ? num : 0; //2147483647
        }

        [HttpGet("math/async/{num}")]
        public async Task<int> Async(int num)
        {
            AsyncRequests++;
            var ret = await IsPrimeAsync(num);
            return ret ? num : 0;
        }

        // It's not the fastest algorithm,
        // but we will optimize it later.
        public static bool IsPrime(int n)
        {
            for (int i = 2; i <= n - 1; i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        // It's not the fastest algorithm,
        // but we will optimize it later.
        public static async Task<bool> IsPrimeAsync(int n)
        {
            return await Task.Factory.StartNew(() =>
             {
                 return IsPrime(n);
             });
        }
    }
}