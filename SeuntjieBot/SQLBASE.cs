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
        internal abstract User updateUser(User ToUpdate);
        internal abstract User Usergetbyname(string Username);
        internal abstract User UsergetbyID(int ID);
        internal abstract bool Redlist(User ToRedlist, string Reason);
        internal abstract bool DeRedlist(User ToRedlist);
        internal abstract bool BlackList(User ToRedlist, string Reason);
        internal abstract bool DeBlacklist(User ToRedlist);
        internal abstract int GetUserStatus(User GetFor);
        internal abstract string GetBlackReasonForUser(User GetFor);
        internal abstract string GetRedReasonForUser(User GetFor);
        internal abstract LateMessage[] GetMessagesForUser(User ToGet);
        internal abstract bool AddMessageForUser(LateMessage msg);
        internal abstract bool SentMessageForUser(LateMessage msg);
        internal LateMessage MsgParser(IDataReader Reader)
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
        
        internal User UserParser(System.Data.IDataReader Reader)
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
                tmp.rain = !(Reader["rained"] is DBNull)? (double)(decimal)Reader["rained"] : 0;
                tmp.balance = !(Reader["balance"] is DBNull) ? (double)(decimal)Reader["balance"] : 0;
                tmp.times = !(Reader["times"] is DBNull) ? (int)Reader["times"] : 0;
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
        internal abstract bool LogMessage(chat Message);

        //rain
        internal abstract double[] GetTotalRained();
        internal abstract double[] GetUserRained(int uid);
        internal abstract bool RainAdd(double amount, int uid, DateTime Time, int Instigator, bool forced);
        
        //command
        

        //log
        internal abstract bool logCommand(string Message, int Uid);

        internal abstract decimal getTotalUsersBalance();


        internal abstract void ReduceUserBalance(long p, decimal Amount);


        internal abstract void ReceivedTip(long p, double Amount, DateTime Time);
        
    }
}
