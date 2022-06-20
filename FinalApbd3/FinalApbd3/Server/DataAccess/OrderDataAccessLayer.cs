using System.Security.Claims;
using FinalApbd3.Server.Data;
using FinalApbd3.Server.DTO;
using FinalApbd3.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalApbd3.Server.DataAccess
{
    public class OrderDataAccessLayer
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public OrderDataAccessLayer( IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public DbSet<CompanyUser> GetAllConns()
        {
            try
            {
                return _context.CompanyUsers;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteConn(string id)
        {

            var userId = _httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                CompanyUser cu = _context.CompanyUsers.Where(x => x.IdUser == userId && x.IdCompany == id).FirstOrDefault();
                _context.CompanyUsers.Remove(cu);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
