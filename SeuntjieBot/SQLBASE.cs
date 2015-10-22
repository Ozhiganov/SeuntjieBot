using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SeuntjieBot
{
    abstract class SQLBASE
    {
        public static SQLBASE Instance()
        {
            return new MSSQL();
        }
        
        //user
        public abstract User updateUser(User ToUpdate);
        public abstract User Usergetbyname(string Username);
        public abstract User UsergetbyID(int ID);
        public abstract bool Redlist(User ToRedlist, string Reason);
        public abstract bool DeRedlist(User ToRedlist);
        public abstract bool BlackList(User ToRedlist, string Reason);
        public abstract bool DeBlacklist(User ToRedlist);
        public abstract int GetUserStatus(User GetFor);
        public abstract string GetBlackReasonForUser(User GetFor);
        public abstract string GetRedReasonForUser(User GetFor);
        public abstract LateMessage[] GetMessagesForUser(User ToGet);
        public abstract bool AddMessageForUser(LateMessage msg);
        public abstract bool SentMessageForUser(LateMessage msg);
        public LateMessage MsgParser(IDataReader Reader)
        {
            LateMessage tmp = new LateMessage { };
            tmp.FromUid = (int)Reader["msg_from"];
            tmp.id = (int)Reader["id"];
            tmp.ToUid = (int)Reader["msg_for"];
            tmp.Message = (string)Reader["msg"];
            tmp.pm = (bool)Reader["pm"];
            tmp.Sent = (bool)Reader["sent"];
            tmp.MessageTime = (DateTime)Reader["msg_time"];
            
            return tmp;
        }
        
        public User UserParser(System.Data.IDataReader Reader)
        {
            try
            {
                User tmp = new User();
                tmp.Username = (string)Reader["username"];
                tmp.Title = !(Reader["title"] is DBNull)?(string)Reader["title"]:"";
                tmp.Note = !(Reader["note"] is DBNull)? (string)Reader["note"] : "";
                tmp.UserType = (string)Reader["usertype"];
                tmp.Address = !(Reader["address"] is DBNull)? (string)Reader["address"] : "";
                tmp.Uid = (int)Reader["uid"];
                tmp.LastSeen = !(Reader["lastactive"] is DBNull)? (DateTime)Reader["lastactive"] : new DateTime();
                tmp.LastMessage = !(Reader["lastmessage"] is DBNull)? (string)Reader["lastmessage"] : "";
                tmp.rain = !(Reader["rained"] is DBNull)? (string)Reader["rained"] : "";
                tmp.times = !(Reader["times"] is DBNull) ? (string)Reader["times"] : "";
                tmp.Listed = GetUserStatus(tmp);
                tmp.MessageFor = GetMessagesForUser(tmp);
                return tmp;
            }
            catch
            {
                return null;
            }
        }

        //message
        public abstract bool LogMessage(chat Message);

        //rain
        public abstract double[] GetTotalRained();
        public abstract double[] GetUserRained(int uid);
        public abstract bool RainAdd(double amount, int uid, DateTime Time);
        
        //command
        

        //log
        public abstract bool logCommand(string Message, int Uid);
    }
}
