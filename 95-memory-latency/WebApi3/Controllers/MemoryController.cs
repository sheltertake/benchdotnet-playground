using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi3.Controllers
{
    [ApiController]
    public class MemoryController : ControllerBase
    {
        class X
        {
            public int Num1;
        }
        struct Y
        {
            public int Num1;
        }

        static int ClassesRequests = 0;
        static int StructsRequests = 0;

        private const int N = 100001;

        [HttpGet("memory/report")]
        public object Report(int num)
        {
            return new
            {
                Classes = ClassesRequests,
                Structs = StructsRequests,
            };
        }


        [HttpGet("memory/classes")]
        public int Classes()
        {
            ClassesRequests++;
            int a = 0;
            for (int i = 0; i < N; i++)
            {
                var obj = new X { Num1 = i };
                a += obj.Num1;
            }
            return a;
        }

        [HttpGet("memory/structs")]
        public int Structs()
        {
            StructsRequests++;
            int a = 0;
            for (int i = 0; i < N; i++)
            {
                var obj = new Y { Num1 = i };
                a += obj.Num1;
            }
            return a;
        }

    }
}