using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalApbd3.Server.DTO
{
    public class CompanyDTO
    {
        [Required]
        public string Name { get; set; }
        [Key]
        public string Symbol { get; set; }
        [Required]
        public string Sector { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Ceo { get; set; }

        public virtual ICollection<CompanyUser> CompanyUsers { get; set; }
    }
}
