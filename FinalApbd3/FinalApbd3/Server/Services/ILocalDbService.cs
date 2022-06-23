using System.Collections.Generic;
using FinalApbd3.Shared.DTO;

namespace FinalApbd3.Server.Services
{
    public interface ILocalDbService
    {
        public void SaveDataContainer(string content);

        public void SaveDailyOc(string content);

        public void SaveV3(string content);

        public void SaveNews(string content);

        public List<DataDTO> GetDataContainer();
    }
}
