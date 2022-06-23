using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApbd3.Shared.DTO
{
    public class NewsDTO
    {
        [Key]
        public string id { get; set; }

        public string title { get; set; }

        public string author { get; set; }

        public string published_utc { get; set; }


    }
}
