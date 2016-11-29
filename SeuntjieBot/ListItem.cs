using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    class ListItem
    {
        public int oid { get; set; }
        public DateTime time { get; set; }//= DateTime.Parse('1 jan 1970');
        public DateTime until { get; set; }
        public int uid { get; set; }
        public string reason { get; set; }
        public int mutingid { get; set; }
        public bool active { get; set; }
        public bool redlist { get; set; }
        public bool blacklist { get; set; }
    }
}
