using System;
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
            if (res2 == "404")
            {
                res = await _httpClient.GetAsync("api/test/cont");
                res2 = await res.Content.ReadAsStringAsync();
                List<DataDTO> dataDTOs = JsonConvert.DeserializeObject<List<DataDTO>>(res2);
                List<Data> data2 = new List<Data>();
                foreach (var item in dataDTOs) 
                {
                    data2.Add(new Data() {l=item.l, c = item.c, date = item.date, h= item.h, n = item.n,
                        o = item.o, t = item.t, v = item.v, vw = item.vw });
                }
                return new DataContainer { results = data2, status = "Ok" };
            }
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
            if (res2 == "404")
            {
                res = await _httpClient.GetAsync("api/test/dbt");
                res2 = await res.Content.ReadAsStringAsync();
                DataByTickerDto data2 = JsonConvert.DeserializeObject<DataByTickerDto>(res2);
                ResultsDataV3 v3 = new ResultsDataV3() {name = data2.name, ticker= data2.ticker,
                    description= data2.description, locale = data2.locale, sic_description = data2.sic_description, 
                    homepage_url = data2.homepage_url, branding = new Branding() {logo_url = data2.logo_url } };
                return new DataByTicker { results = v3 };
            }
            DataByTicker data = JsonConvert.DeserializeObject<DataByTicker>(res2);
            return data;
        }

        public async Task<NewsContainer> takeDataForNews(string ticker)
        {
            var res = await _httpClient.GetAsync("api/polygon/s6/" + ticker);
            Console.WriteLine(await res.Content.ReadAsStringAsync());
            var res2 = await res.Content.ReadAsStringAsync();
            if (res2 == "404")
            {
                res = await _httpClient.GetAsync("api/test/news");
                res2 = await res.Content.ReadAsStringAsync();
                List<NewsDTO> newsDTOs = JsonConvert.DeserializeObject<List<NewsDTO>>(res2);
                List<News> news = new List<News>();
                foreach (var itme in newsDTOs) 
                {
                    news.Add(new News { id = itme.id, title = itme.title, author = itme.author, published_utc = itme.published_utc });
                }
                return new NewsContainer { results = news };
            }
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
