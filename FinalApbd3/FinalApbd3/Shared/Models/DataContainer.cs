using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApbd3.Shared.Models
{
    public class DataContainer
    {
        public bool adjusted { get; set; }

        public int queryCount { get; set; }

        public string request_id { get; set; }

        public List<Data> results { get; set; }

        public int resultsCount { get; set; }

        public string status { get; set; }

        public string ticker { get; set; }


    }
}
