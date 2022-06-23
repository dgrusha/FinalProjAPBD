using System.Collections.Generic;
using System.Threading.Tasks;
using FinalApbd3.Shared.Models;

namespace FinalApbd3.Server.Services
{
    public interface IPolygonService
    {

        public Task<string> getCompanyContainer(string ticker);

        public Task<string> getInfo(string ticker);

        public Task<string> getInfo5(string ticker);

        public Task<string> getInfo2(string ticker);

        public Task<string> getInfo4(string ticker);

        public Task<string> getInfo6(string ticker);
    }
}
