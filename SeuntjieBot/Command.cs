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
    public class CommandState
    {
        public string name { get; set; }
        public bool enabled { get; set; }
        public bool show { get; set; }
        public CommandState(string name, bool enabled, bool show)
        {
            this.name = name;
            this.enabled = enabled;
            this.show = show;
        }
    }
    
}
