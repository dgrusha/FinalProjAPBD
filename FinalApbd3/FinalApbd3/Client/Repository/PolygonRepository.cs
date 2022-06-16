using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FinalApbd3.Shared.Models;
using Newtonsoft.Json;

namespace FinalApbd3.Client.Repository
{
    public class PolygonRepository : IPolygonRepository
    {

        private readonly HttpClient _httpClient;

        public PolygonRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DataContainer> takeDataForChart(string ticker)
        {
            var res = await _httpClient.GetAsync("api/polygon/"+ticker);
            Console.WriteLine(await res.Content.ReadAsStringAsync());
            var res2 = await res.Content.ReadAsStringAsync();
            DataContainer data = JsonConvert.DeserializeObject<DataContainer>(res2);
            return data;

        }

        public async Task<string> takePolygonStr() 
        {
            var res = await _httpClient.GetAsync("api/polygon/s2");
            return await res.Content.ReadAsStringAsync();
        }

    }
}
