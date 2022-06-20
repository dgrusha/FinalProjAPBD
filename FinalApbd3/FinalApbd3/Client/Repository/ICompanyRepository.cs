using System.Collections.Generic;
using System.Threading.Tasks;
using FinalApbd3.Shared.DTO;

namespace FinalApbd3.Client.Repository
{
    public interface ICompanyRepository
    {

        public Task<string> AddInfo(CompanyDTOClient company);

        public Task<List<CompanyDTOClient>> GetInfo();

        public Task DeleteInfo(string symbol);

    }
}
