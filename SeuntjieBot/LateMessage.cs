using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    public class LateMessage
    {
        public string Message { get; set; }
        public int FromUid { get; set; }
        public int ToUid { get; set; }
        public int id { get; set; }
        public bool Sent { get; set; }
        public bool pm { get; set; }
        public DateTime MessageTime { get; set; }
        
    }
}
