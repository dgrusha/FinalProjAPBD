﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinalApbd3.Shared.DTO;
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

        public async Task<DailyOC> takeDataForDaily(string ticker)
        {
            var res = await _httpClient.GetAsync("api/polygon/s4/"+ticker);
            Console.WriteLine(await res.Content.ReadAsStringAsync());
            var res2 = await res.Content.ReadAsStringAsync();
            if (res2 == "404") 
            {
                return new DailyOC() {status ="404" };
            }
            DailyOC data = JsonConvert.DeserializeObject<DailyOC>(res2);
            return data;
        }

        public async Task<DataByTicker> takeDataForDetails(string ticker)
        {
            var res = await _httpClient.GetAsync("api/polygon/s5/" + ticker);
            Console.WriteLine(await res.Content.ReadAsStringAsync());
            var res2 = await res.Content.ReadAsStringAsync();
            DataByTicker data = JsonConvert.DeserializeObject<DataByTicker>(res2);
            return data;
        }

        public async Task<NewsContainer> takeDataForNews(string ticker)
        {
            var res = await _httpClient.GetAsync("api/polygon/s6/" + ticker);
            Console.WriteLine(await res.Content.ReadAsStringAsync());
            var res2 = await res.Content.ReadAsStringAsync();
            NewsContainer data = JsonConvert.DeserializeObject<NewsContainer>(res2);
            return data;
        }

        public async Task<CompanyContainer> takePolygonStr(string ticker) 
        {
            var res = await _httpClient.GetAsync("api/polygon/s2/"+ticker);
            var res2 = await res.Content.ReadAsStringAsync();
            CompanyContainer cc = JsonConvert.DeserializeObject<CompanyContainer>(res2);
            return cc;
        }

        public async Task<string> AddInfo(CompanyDTOClient company)
        {
            var values = new Dictionary<string, string>
              {
                  { "Name", company.Name },
                  { "Symbol", company.Symbol },
                  { "Sector", company.Sector },
                  { "Country", company.Country },
                  { "Ceo", company.Ceo }
              };
            var content = new FormUrlEncodedContent(values);
            var res = await _httpClient.PostAsync("api/company/", content);
            return "ggg";
        }

    }
}
