using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    public class User
    {
        public User()
        {
            Score = new List<score>();
            CommandScore = new List<score>();
        }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public string UserType { get; set; }
        public string Address { get; set; }
        private long _id = -1;
        public long Uid { get { return _id; } set { _id = value; } }

        public DateTime LastSeen { get; set; }
        public DateTime LastActive { get; set; }
        public List<score> CommandScore { get; set; }
        public string LastMessage { get; set; }
        public LateMessage[] MessageFor { get; set; }
        public List<score> Score { get; set; }
        public double rain { get; set; }
        public int times { get; set; }
        public int Listed { get; set; }
        public DateTime Warning { get; set; }
        public double balance { get; set; }
        public int getscore()
        {
            int scr = 0;
            foreach (score s in Score)
            {
                scr += s.val;
            }
            return scr;
        }
        public int getCommandscore()
        {
            int scr = 0;
            foreach (score s in CommandScore)
            {
                scr += s.val;
            }
            return scr;
        }

        public bool Equals(User other)
        {
            try
            {
                if (other.Username.ToLower() == Username.ToLower())
                    return true;
            }
            catch
            {

            }
            try
            {
                if (other.Uid == Uid && Uid != -1)
                    return true;

            }
            catch { }
            return false;

        }

        public bool Equals(string other)
        {
            if (other.ToLower() == Username.ToLower())
                return true;
            return false;
        }
        public User updateuser()
        {
            return SQLBASE.Instance().updateUser(this);
        }
        public static User updateuser(User user)
        {
            return SQLBASE.Instance().updateUser(user);
        }
        public static User FindUser(string user)
        {
            return SQLBASE.Instance().Usergetbyname(user);
        }
        public static User FindUser(int user)
        {
            return SQLBASE.Instance().UsergetbyID(user);
        }
        public string GetRedReason()
        {
            return MSSQL.Instance().GetRedReasonForUser(this);
        }
        public string GetBlackReason()
        {
            return MSSQL.Instance().GetBlackReasonForUser(this);
        }
    }
    public class score
    {
        public score(int val, DateTime time)
        {
            this.val = val;
            this.time = time;
        }
        public int val { get; set; }
        public DateTime time { get; set; }
    }
    public class SendMessage
    {
        public string Message { get; set; }
        public bool Pm { get; set; }
        public User ToUser { get; set; }
    }
    
}
