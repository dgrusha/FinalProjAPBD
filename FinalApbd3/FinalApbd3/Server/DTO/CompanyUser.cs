using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalApbd3.Server.Models;

namespace FinalApbd3.Server.DTO
{
    public class CompanyUser
    {
        public string IdUser { get; set; }
        public string IdCompany { get; set; }

        [ForeignKey("IdUser")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("IdCompany")]
        public CompanyDTO CompanyProj{ get; set; }
    }
}
