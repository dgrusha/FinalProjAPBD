using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApbd3.Shared.Models
{
    public class News
    {
        public string? id { get; set; }

        public Publisher? publisher { get; set; }

        public string? title { get; set; }

        public string? author { get; set; }

        public string? published_utc { get; set; }

        public string? article_url { get; set; }

        public List<string>? tickers { get; set; }

        public string? amp_url { get; set; }

        public string? image_url { get; set; }

        public string? description { get; set; }

    }
}
