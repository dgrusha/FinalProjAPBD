using System;
using System.Collections.Generic;
using FinalApbd3.Server.Data;
using FinalApbd3.Server.DTO;
using FinalApbd3.Shared.DTO;
using FinalApbd3.Shared.Models;
using Newtonsoft.Json;

namespace FinalApbd3.Server.Services
{
    public class LocalDbService : ILocalDbService
    {
        public MyLocalContext _localContext;
        public LocalDbService(MyLocalContext localContext) 
        {
            _localContext = localContext;
        }

        public void GetDataContainer()
        {
            throw new NotImplementedException();
        }

        public void SaveDailyOc(string content)
        {
            _localContext.dailyOCDTOs.RemoveRange(_localContext.dailyOCDTOs);

            DailyOC data = JsonConvert.DeserializeObject<DailyOC>(content);

            var res = new FinalApbd3.Shared.DTO.DailyOCDTO() 
            {
                status = data.status,
                from = data.from,
                symbol = data.symbol,
                open = data.open,
                high = data.high,
                low = data.low,
                close = data.close,
                volume = data.volume,
                afterHours = data.afterHours,
                preMarket = data.preMarket
            };
            _localContext.dailyOCDTOs.Add(res);
            _localContext.SaveChanges();
        }

        public void SaveDataContainer(string content)
        {
            _localContext.dataDTOs.RemoveRange(_localContext.dataDTOs);
            DataContainer data = JsonConvert.DeserializeObject<DataContainer>(content);
            List<FinalApbd3.Shared.Models.Data> res = data.results;
            foreach (var item in res)
            {
                var newD = new DataDTO
                {
                    h = item.h,
                    l = item.l,
                    c = item.c,
                    n = item.n,
                    o = item.o,
                    t = item.t,
                    v = item.v,
                    vw = item.vw,
                    date = DateTime.UtcNow
                };
                _localContext.dataDTOs.Add(newD);
            }
            _localContext.SaveChanges();
        }

        public void SaveNews(string content)
        {
            _localContext.newsDTOs.RemoveRange(_localContext.newsDTOs);
            NewsContainer data = JsonConvert.DeserializeObject<NewsContainer>(content);
            List<News> news = data.results;
            foreach (var item in news)
            {
                var newD = new NewsDTO
                {
                    author = item.author,
                    id = item.id,
                    published_utc = item.published_utc,
                    title = item.title
                };
                _localContext.newsDTOs.Add(newD);
            }
            _localContext.SaveChanges();
        }

        public void SaveV3(string content)
        {
            _localContext.dataByTickerDtos.RemoveRange(_localContext.dataByTickerDtos);
            DataByTicker v3 = JsonConvert.DeserializeObject<DataByTicker>(content);
            ResultsDataV3 v3_2 = v3.results;
            DataByTickerDto dto = new DataByTickerDto() 
            {
                ticker = v3_2.ticker,
                name = v3_2.name,
                market = v3_2.market,
                locale = v3_2.locale,
                primary_exchange = v3_2.primary_exchange,
                type = v3_2.type,
                active = v3_2.active,
                currency_name = v3_2.currency_name,
                cik = v3_2.cik,
                composite_figi = v3_2.composite_figi,
                share_class_figi = v3_2.share_class_figi,
                market_cap = v3_2.market_cap,
                phone_number = v3_2.phone_number,
                description = v3_2.description,
                sic_code = v3_2.sic_code,
                sic_description = v3_2.sic_description,
                ticker_root = v3_2.ticker_root,
                homepage_url = v3_2.homepage_url,
                total_employees = v3_2.total_employees,
                list_date = v3_2.list_date,
                share_class_shares_outstanding = v3_2.share_class_shares_outstanding,
                weighted_shares_outstanding = v3_2.weighted_shares_outstanding,
                logo_url = v3_2.branding.logo_url
            };
            _localContext.dataByTickerDtos.Add(dto);
            _localContext.SaveChanges();
        }

        List<DataDTO> ILocalDbService.GetDataContainer()
        {
            throw new NotImplementedException();
        }
    }
}
