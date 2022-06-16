using System;
using WebSocket4Net;
using System.Security.Authentication;
using System.Collections.Generic;
using FinalApbd3.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Threading;

namespace FinalApbd3.Server.Services
{
    public class PolygonioService:IPolygonService
    {
        private HttpClient _client;
        public PolygonioService(HttpClient client) 
        {
            _client = client;
        }

        public async Task<string> getCompanyContainer(string ticker)
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var test = await _client.GetAsync("https://api.polygon.io/v2/aggs/ticker/A/range/1/day/2021-07-22/2021-07-29?adjusted=true&sort=asc&limit=120&apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B");
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            return response;
        }

        
    }
}
