using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FinalApbd3.Server.Services;
using FinalApbd3.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinalApbd3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolygonController : ControllerBase
    {

        private HttpClient _client;
        IPolygonService _polygonService;

        public PolygonController(HttpClient client, IPolygonService polygonService) 
        {
            _polygonService = polygonService;
            _client = client;
        }
        [Route("s2")]
        [HttpGet]
        public async Task<string> GetInfo() 
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var test = await _client.GetAsync("https://api.polygon.io/v3/reference/tickers?active=true&sort=ticker&order=asc&limit=100000&apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B&next_url");
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            
            return response;
        }
        [Route("{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo2(string ticker)
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string tmp = ticker.Substring(ticker.Length - 1);
            int code = Int32.Parse(tmp);
            string dt1 = DateTime.UtcNow.Date.AddDays(-10).AddYears(-1).ToString("yyyy-MM-dd");
            DateTime dt2 = DateTime.UtcNow.Date.AddDays(-10).AddYears(-1);
            string intervalOption = "/range/1/minute/";
            if (code == 2)
            {
                dt2 = DateTime.UtcNow.Date.AddDays(-17).AddYears(-1);
                intervalOption = "/range/1/day/";
            }
            else if (code == 3)
            {
                dt2 = DateTime.UtcNow.Date.AddDays(-40).AddYears(-1);
                intervalOption = "/range/1/day/";
            }
            else if (code == 4)
            {
                dt2 = DateTime.UtcNow.Date.AddDays(-100).AddYears(-1);
                intervalOption = "/range/1/week/";
            }
            string tickerRes = ticker.Substring(0, ticker.Length - 1);
            string dt2String = dt2.ToString("yyyy-MM-dd");
            string req = "https://api.polygon.io/v2/aggs/ticker/" + tickerRes + intervalOption + dt2String + "/" + dt1 + "?adjusted=true&sort=asc&limit=120&apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B";
            var test = await _client.GetAsync(req);
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            return response;
        }

    }
}
