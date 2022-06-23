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
        private ILocalDbService _localDbService;

        public PolygonController(HttpClient client, IPolygonService polygonService, ILocalDbService localDbService) 
        {
            _polygonService = polygonService;
            _localDbService = localDbService;
            _client = client;
        }

        [Route("s2/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo(string ticker) 
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            char[] charArr = ticker.ToCharArray();
            char nextCh = (char)((int)charArr[0] + 1);
            var test = await _client.GetAsync("https://api.polygon.io/v3/reference/tickers?ticker.gte="+charArr[0]+"&ticker.lt="+nextCh+"&active=true&sort=ticker&order=asc&limit=1000&apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B");
            if (!test.IsSuccessStatusCode)
            {
                return "404";
            }
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            
            return response;
        }

        [Route("s5/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo5(string ticker)
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var test = await _client.GetAsync("https://api.polygon.io/v3/reference/tickers/"+ticker+"?apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B");
            if (!test.IsSuccessStatusCode)
            {
                return "404";
            }
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            _localDbService.SaveV3(response);
            return response;
        }

        [Route("s6/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo6(string ticker)
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var test = await _client.GetAsync("https://api.polygon.io/v2/reference/news?ticker="+ticker+"&limit=5&apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B");
            if (!test.IsSuccessStatusCode)
            {
                return "404";
            }
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            _localDbService.SaveNews(response);
            return response;
        }

        [Route("s4/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo4(string ticker)
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            DateTime dt2 = DateTime.UtcNow.Date.AddDays(-10).AddYears(-1);
            string tmp = ticker.Substring(ticker.Length - 1);
            string ticker2 = ticker.Substring(0, ticker.Length - 1);
            int code = Int32.Parse(tmp);
            if (code == 2)
            {
                dt2 = DateTime.UtcNow.Date.AddDays(-17).AddYears(-1);
            }
            else if (code == 3)
            {
                dt2 = DateTime.UtcNow.Date.AddDays(-40).AddYears(-1);
            }
            else if (code == 4)
            {
                dt2 = DateTime.UtcNow.Date.AddDays(-100).AddYears(-1);
            }
            string dt2String = dt2.ToString("yyyy-MM-dd");
            string req = "https://api.polygon.io/v1/open-close/"+ticker2+"/"+dt2String+"?adjusted=true&apiKey=Ub9KTYEXiAeWEUQBdRFBjsNUv8Yy285B";
            var test = await _client.GetAsync(req);
            if (!test.IsSuccessStatusCode)
            {
                return "404";
            }
            test.EnsureSuccessStatusCode();
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            _localDbService.SaveDailyOc(response);
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
            if (!test.IsSuccessStatusCode)
            {
                return "404";
            }
            string response = await test.Content.ReadAsStringAsync();
            Console.WriteLine("Response" + response);
            _localDbService.SaveDataContainer(response);
            return response;
        }

    }
}
