using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalApbd3.Server.DTO;
using Microsoft.AspNetCore.Identity;

namespace FinalApbd3.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<CompanyUser> CompanyUsers { get; set; }
    }
}
