using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalApbd3.Server.DTO;
using FinalApbd3.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FinalApbd3.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        public DbSet<CompanyDTO> Companies { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }


        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CompanyUser>().HasKey(cu => new { cu.IdUser, cu.IdCompany });
            
        }
    }
}
