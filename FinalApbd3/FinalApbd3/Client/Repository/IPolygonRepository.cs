using System.Collections.Generic;
using System.Threading.Tasks;
using FinalApbd3.Shared.DTO;
using FinalApbd3.Shared.Models;

namespace FinalApbd3.Client.Repository
{
    public interface IPolygonRepository
    {

        public Task<CompanyContainer> takePolygonStr(string ticker);

        public Task<string> AddInfo(CompanyDTOClient company);

        public  Task<DailyOC> takeDataForDaily(string ticker);//

        public Task<DataByTicker> takeDataForDetails(string ticker);//

        public Task<DataContainer> takeDataForChart(string ticker);//

        public Task<NewsContainer> takeDataForNews(string ticker);//

    }
}
