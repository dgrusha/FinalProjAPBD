using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApbd3.Shared.Models
{
    public class Data
    {
        public float c { get; set; }

        public float h { get; set; }


        public float l { get; set; }


        public float n { get; set; }


        public float o { get; set; }


        public long t { get;  set; }

        public DateTime GetDate() 
        {
            return DateTime.UnixEpoch.AddMilliseconds(t);
        }

        public DateTime? date { get; set; }
        public long v { get; set; }

        public float vw { get; set; }

    }
}
