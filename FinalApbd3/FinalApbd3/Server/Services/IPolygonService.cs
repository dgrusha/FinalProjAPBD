using System.Collections.Generic;
using System.Threading.Tasks;
using FinalApbd3.Shared.Models;

namespace FinalApbd3.Server.Services
{
    public interface IPolygonService
    {

        public Task<string> getCompanyContainer(string ticker);
    
    }
}
