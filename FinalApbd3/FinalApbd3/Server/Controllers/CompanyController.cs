using System.Security.Claims;
using System.Threading.Tasks;
using FinalApbd3.Server.Data;
using FinalApbd3.Server.Models;
using FinalApbd3.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using FinalApbd3.Server.DTO;
using FinalApbd3.Shared.DTO;
using System.Collections.Generic;
using System;

namespace FinalApbd3.Server.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService )
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompaniesToUsers()
        {
            
            return Ok(_companyService.GetCompaniesToUsers());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompaniesToUsers(CompanyDTOClient company)
        {
            return Ok(_companyService.UpdateCompaniesToUsers(company));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyUser(string id) 
        {

            return Ok(_companyService.DeleteCompanyUser(id));
        }

    }
}
