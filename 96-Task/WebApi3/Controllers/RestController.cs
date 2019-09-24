using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WebApi3.Controllers
{
    
    public class RestController
    {
        private readonly HttpClient _httpClient;

        public RestController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        }

        [HttpGet("rest/helper")]
        public int Helper()
        {
            return 0;
        }
        [HttpGet("rest/sync")]
        public string Sync()
        {
            var client = new RestClient("http://localhost:5000/");
            var request = new RestRequest("rest/helper", Method.GET);
            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        [HttpGet("rest/async")]
        public async  Task<string> Async()
        {
            return await _httpClient.GetStringAsync("rest/helper");
        }
    }
}
