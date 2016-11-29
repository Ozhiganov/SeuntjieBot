using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    public class chat
    {

        private long id;

        public long UID
        {
            get { return id; }
            set { id = value; }
        }

        //public long ID { get; set; }
        public string User { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool insert()
        {
            return MSSQL.Instance().LogMessage(this);
        }
        public string room { get; set; }
    }
}
