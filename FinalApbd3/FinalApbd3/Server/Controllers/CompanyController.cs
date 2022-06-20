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

namespace FinalApbd3.Server.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public CompanyController(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompaniesToUsers()
        {
            var userId = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var us2 = _context.Users.FirstOrDefault();
            List<CompanyDTOClient> listOfComp = (from us in _context.Users
                                                 join cu in _context.CompanyUsers on us.Id equals cu.IdUser
                                                 join co in _context.Companies on cu.IdCompany equals co.Symbol
                                                 where cu.IdUser == userId
                                                 select new CompanyDTOClient { Name = co.Name, Ceo = co.Ceo, Country = co.Country, Sector = co.Sector, Symbol = co.Symbol }).ToList();
            return Ok(listOfComp);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompaniesToUsers(CompanyDTOClient company)
        {
            var us2 = _context.Users.FirstOrDefault();
            var userId = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            int countCompany = _context.Companies.Where(c => c.Symbol == company.Symbol).Count();
            if (countCompany == 0)
            {
                _context.Companies.Add(new CompanyDTO { Name = company.Name, Ceo = company.Ceo, Country = company.Country, Sector = company.Sector, Symbol = company.Symbol });
                _context.SaveChanges();
            }
            int countCompUser = (from us in _context.Users
                                 join cu in _context.CompanyUsers on us.Id equals cu.IdUser
                                 join co in _context.Companies on cu.IdCompany equals co.Symbol
                                 where cu.IdUser == userId && cu.IdCompany == company.Symbol
                                 select cu.IdCompany).Count();
            if (countCompUser == 0)
            {
                _context.CompanyUsers.Add(new CompanyUser { IdCompany = company.Symbol, IdUser = userId });
                _context.SaveChanges();
            }
            else
            {
                return Ok("It is already on your wishlist!");
            }

            return Ok("It was added to your wishlist!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyUser(string id) 
        {

            var userId = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            CompanyUser companyUser = _context.CompanyUsers.Where(x => x.IdUser == userId && x.IdCompany == id).FirstOrDefault();
            _context.Remove(companyUser);
            _context.SaveChanges();
            return Ok("Deleted");
        }

    }
}
