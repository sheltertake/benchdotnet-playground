using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MemoryUsageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        public static int Mega = 1024 * 1024;
        public static byte[] Data = new byte[0];
        public static Dictionary<int, byte[]> Dic = new Dictionary<int, byte[]>();
        // GET api/values

        [HttpGet]
        [Route("V/{num}")]
        public ActionResult<object> V(int num)
        {

            var watch = Stopwatch.StartNew();
            var data = new byte[num * Mega];
            watch.Stop();
            return new
            {
                Ms = watch.ElapsedMilliseconds,
                D = Dic.Sum(x => x.Value.Length / Mega),
                S = (Data.Length / Mega),
                V = data.Length / Mega
            };

        }

        //[HttpGet]
        //[Route("RandomV/{num}")]
        //public ActionResult<object> RandomV(int num)
        //{

        //    var watch = Stopwatch.StartNew();
        //    var randomGenerator = new RandomBufferGenerator(num * Mega);
        //    var data = randomGenerator.GenerateBufferFromSeed(num * Mega);
        //    watch.Stop();

        //    return new
        //    {
        //        //data = data,
        //        Ms = watch.ElapsedMilliseconds,
        //        D = Dic.Sum(x => x.Value.Length / Mega),
        //        S = (Data.Length / Mega),
        //        V = data.Length / Mega
        //    };

        //}


        [HttpGet]
        [Route("S/{num}")]
        public ActionResult<object> S(int num)
        {

            var watch = Stopwatch.StartNew();
            //var randomGenerator = new RandomBufferGenerator(num * Mega);
            //Data = randomGenerator.GenerateBufferFromSeed(num * Mega);
            Data = new byte[num * Mega];
            watch.Stop();

            return new
            {
                Ms = watch.ElapsedMilliseconds,
                D = Dic.Sum(x => x.Value.Length / Mega),
                S = (Data.Length / Mega),
                V = string.Empty
            };

        }

        [HttpGet]
        [Route("D/{id}/{num}")]
        public ActionResult<object> D(int id, int num)
        {

            var watch = Stopwatch.StartNew();
            //var randomGenerator = new RandomBufferGenerator(num * Mega);
            //Dic[id] = randomGenerator.GenerateBufferFromSeed(num * Mega);
            Dic[id] = new byte[num * Mega];
            watch.Stop();
            return new
            {
                Ms = watch.ElapsedMilliseconds,
                D = Dic.Sum(x => x.Value.Length / Mega),
                S = (Data.Length / Mega),
                V = string.Empty
            };

        }

        [HttpGet]
        [Route("empty")]
        public ActionResult<string> Empty()
        {
            return string.Empty;
        }

    }

    //public class RandomBufferGenerator
    //{
    //    private readonly Random _random = new Random();
    //    private readonly byte[] _seedBuffer;

    //    public RandomBufferGenerator(int maxBufferSize)
    //    {
    //        _seedBuffer = new byte[maxBufferSize];

    //        _random.NextBytes(_seedBuffer);
    //    }

    //    public byte[] GenerateBufferFromSeed(int size)
    //    {
    //        int randomWindow = _random.Next(0, size);

    //        byte[] buffer = new byte[size];

    //        Buffer.BlockCopy(_seedBuffer, randomWindow, buffer, 0, size - randomWindow);
    //        Buffer.BlockCopy(_seedBuffer, 0, buffer, size - randomWindow, randomWindow);

    //        return buffer;
    //    }
    //}
}