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
        internal abstract bool Redlist(ListItem Itm);
        internal abstract bool DeRedlist(User Itm);
        /*internal abstract bool BlackList(User ToRedlist, string Reason);*/
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
                tmp.UserType = (string)Reader["Usertype"];
                tmp.Address = !(Reader["address"] is DBNull)? (string)Reader["address"] : "";
                tmp.Uid = (int)Reader["uid"];
                tmp.LastSeen = !(Reader["lastactive"] is DBNull)? (DateTime)Reader["lastactive"] : new DateTime();
                tmp.LastMessage = !(Reader["lastmessage"] is DBNull)? (string)Reader["lastmessage"] : "";
                tmp.rain = !(Reader["rained"] is DBNull)? (double)(decimal)Reader["rained"] : 0;
                tmp.balance = !(Reader["balance"] is DBNull) ? (double)(decimal)Reader["balance"] : 0;
                tmp.times = !(Reader["times"] is DBNull) ? (int)Reader["times"] : 0;
                tmp.Listed = GetUserStatus(tmp);
                tmp.MessageFor = GetMessagesForUser(tmp);
                tmp.lastwarning = !(Reader["lastwarning"] is DBNull) ? (DateTime)Reader["lastwarning"] : new DateTime();
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

        public ListItem ListItemParser(IDataReader Reader)
        {
            ListItem tmp = null;
            {
                try
                {

                    ListItem tmp2 = new ListItem();
                    tmp2.active = (bool)Reader["active"];
                    tmp2.reason = (string)Reader["[reason]"];
                    tmp2.mutingid = (int)Reader["[user_id]"];
                    tmp2.uid = (int)Reader["[uid]"];
                    tmp2.time = (DateTime)Reader["[time]"];
                    tmp2.until = (DateTime)Reader["[until]"];
                    tmp2.oid = (int)Reader["[oid]"];
                    tmp2.redlist = (bool)Reader["[redlist]"];
                    tmp = tmp2;
                }
                catch { }
            }
            return tmp;
        }

    }
}
