using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApbd3.Shared.DTO
{
    public class DataDTO
    {
        
        public float c { get; set; }
        [Key]
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
