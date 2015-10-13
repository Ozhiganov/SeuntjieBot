using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    public class Command
    {
        public string sCommand { get; set; }
        public string Response { get; set; }
        public bool Enabled { get; set; }
        public Command(string Command, string Response, string Enabled)
        {
            this.sCommand = Command;
            this.Response = Response;
            this.Enabled = (Enabled == "1");
        }
    }
}
