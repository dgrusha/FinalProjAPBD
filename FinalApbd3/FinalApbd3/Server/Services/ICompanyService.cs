using System.Collections.Generic;
using FinalApbd3.Shared.DTO;

namespace FinalApbd3.Server.Services
{
    public interface ICompanyService
    {

        public List<CompanyDTOClient> GetCompaniesToUsers();

        public string UpdateCompaniesToUsers(CompanyDTOClient company);

        public string DeleteCompanyUser(string id);
    }
}
