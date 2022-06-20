using FinalApbd3.Shared.DTO;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalApbd3.Client.Repository
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly HttpClient _httpClient;

        public CompanyRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            var res2 = await res.Content.ReadAsStringAsync();
            return res2;
        }

        public async Task DeleteInfo(string symbol)
        {
            var res = await _httpClient.DeleteAsync("api/company/"+symbol);
            var res2 = await res.Content.ReadAsStringAsync();
            Console.WriteLine(res2);
        }

        public async Task<List<CompanyDTOClient>> GetInfo()
        {
            var res = await _httpClient.GetAsync("api/company/");
            var res2 = await res.Content.ReadAsStringAsync();
            Console.WriteLine(res2);
            List<CompanyDTOClient> list = JsonConvert.DeserializeObject<List<CompanyDTOClient>>(res2);
            Console.WriteLine(list.Count());
            foreach (var item in list) 
            {
                Console.WriteLine(item.Name);
            }
            return list;
        }
    }
}
