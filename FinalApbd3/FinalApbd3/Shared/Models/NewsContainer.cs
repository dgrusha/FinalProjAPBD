using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApbd3.Shared.Models
{
    public class NewsContainer
    {

        public List<News> results { get; set; }

        public string? status { get; set; }

        public string? request_id { get; set; }

        public string? count { get; set; }

        public string? next_url { get; set; }
    }
}
