using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    class MSSQL:SQLBASE
    {
        SqlConnection GetCon()
        {
            return new SqlConnection("SERVER=localhost;DATABASE=md;integrated security=true");
        }
        public override User updateUser(User ToUpdate)
        {
            User tmp = null;
            SqlConnection sqcon = GetCon();
                
            try
            {
                
                SqlCommand com = new SqlCommand("USER_EDIT", sqcon);
                sqcon.Open();
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("USERNAME", ToUpdate.Username);
                com.Parameters.AddWithValue("ADDRESS", ToUpdate.Address);
                com.Parameters.AddWithValue("TITLE", ToUpdate.Title);
                com.Parameters.AddWithValue("NOTE", ToUpdate.Note);
                com.Parameters.AddWithValue("USERTYPE", ToUpdate.UserType);
                if (ToUpdate.Uid != -1)
                {
                    com.Parameters.AddWithValue("UID", ToUpdate.Uid);
                }
                SqlDataReader Reader = com.ExecuteReader();
                if (Reader.Read())
                tmp = UserParser(Reader);
            }
            catch
            {
                
            }
            sqcon.Close();
            return tmp;
        }

        public override User Usergetbyname(string Username)
        {
            User tmp = null;
            SqlConnection sqcon = GetCon();
            try
            {
                sqcon.Open();
                SqlCommand Command = new SqlCommand("get_user_name", sqcon);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("username", Username);
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    tmp = UserParser(Reader);
                }
            }
            catch
            {

            }
            sqcon.Close();
            return tmp;
        }

        public override User UsergetbyID(int ID)
        {
            User tmp = null;
            SqlConnection sqcon = GetCon();
            try
            {
                sqcon.Open();
                SqlCommand Command = new SqlCommand("get_user_id", sqcon);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("uid", ID);
                
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    tmp = UserParser(Reader);
                }
            }
            catch
            {

            }
            sqcon.Close();
            return tmp;
        }

        public override bool Redlist(User ToRedlist, string Reason)
        {
            SqlConnection sqcon = GetCon();
            bool success = false;
            SqlCommand com = new SqlCommand("redlist_add", sqcon);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("username", ToRedlist.Uid);
            com.Parameters.AddWithValue("reason", Reason);
            try
            {
                sqcon.Open();
                com.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }
            sqcon.Close();
            return success;
        }

        public override bool DeRedlist(User ToRedlist)
        {
            SqlConnection sqcon = GetCon();
            bool success = false;
            SqlCommand com = new SqlCommand("redlist_remove", sqcon);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("username", ToRedlist.Uid);
            
            try
            {
                sqcon.Open();
                com.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }
            sqcon.Close();
            return success;
        }

        public override bool BlackList(User ToRedlist, string Reason)
        {
            SqlConnection sqcon = GetCon();
            bool success = false;
            SqlCommand com = new SqlCommand("blacklist_add", sqcon);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("username", ToRedlist.Uid);
            com.Parameters.AddWithValue("reason", Reason);
            try
            {
                sqcon.Open();
                com.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }
            sqcon.Close();
            return success;
        }

        public override bool DeBlacklist(User ToRedlist)
        {
            SqlConnection sqcon = GetCon();
            bool success = false;
            SqlCommand com = new SqlCommand("blacklist_remove", sqcon);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("username", ToRedlist.Uid);
            
            try
            {
                sqcon.Open();
                com.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }
            sqcon.Close();
            return success;
        }

        public override bool LogMessage(chat Message)
        {
            bool ret = false;
            SqlConnection sqcon = GetCon();
            try
            {
                
                SqlCommand com = new SqlCommand("CHAT_ADD", sqcon);
                com.Parameters.AddWithValue("message", Message.Message);
                com.Parameters.AddWithValue("username", Message.User);
                com.Parameters.AddWithValue("time", Message.Time);
                if (Message.UID != -1)
                    com.Parameters.AddWithValue("uid", Message.UID);
                com.CommandType = CommandType.StoredProcedure;
                sqcon.Open();
                com.ExecuteNonQuery();
                ret = true;
                
            }
            catch
            {
                ret = false;
            }
            sqcon.Close();
            return ret;
        }

        public override double[] GetTotalRained()
        {
            SqlConnection sqcon = GetCon();
            double[] tmp = new double[2];
            SqlCommand com = new SqlCommand("rains_getTotal", sqcon);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            
            try
            {
                sqcon.Open();
                SqlDataReader Reader = com.ExecuteReader();
                if (Reader.Read())
                {
                    tmp[0] = (double)(Reader["RAINED"]);
                    tmp[1] = (double)((int)Reader["TIMES"]);
                }

            }
            catch (Exception e)
            {

            }
            sqcon.Close();
            return tmp;
        }

        public override double[] GetUserRained(int uid)
        {
            SqlConnection sqcon = GetCon();
            double[] tmp = new double[2];
            SqlCommand com = new SqlCommand("user_getRAINS", sqcon);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("username", uid);
                    
            try
            {
                sqcon.Open();
                SqlDataReader Reader = com.ExecuteReader();
                if (Reader.Read())
                {
                    tmp[0] = (double)(Reader["RAINED"]);
                    tmp[1] = (double)((int)Reader["TIMES"]);
                }
                
            }
            catch (Exception e)
            {
                
            }
            sqcon.Close();
            return tmp;
        }

        
        public override bool RainAdd(double amount, int uid, DateTime Time)
        {
            string txid = "";
            bool valid = false;
            SqlConnection sqcon = GetCon();
            try
            {
                sqcon.Open();
                SqlCommand Command = new SqlCommand("Rain_ADD", sqcon);
                Command.Parameters.AddWithValue("amount", amount);
                Command.Parameters.AddWithValue("time", DateTime.UtcNow);
                Command.CommandType = CommandType.StoredProcedure;
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    txid = Reader["txID"].ToString();
                }
                Reader.Close();
                if (txid != "")
                {
                    Command = new SqlCommand("rain_user_add", sqcon);

                    Command.Parameters.AddWithValue("txid", txid);
                    Command.Parameters.AddWithValue("username", uid);
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.ExecuteNonQuery();
                    valid = true;
                }
            }
            catch (Exception e)
            {
                
                
            }
            sqcon.Close();
            return valid;
        }

        public override bool logCommand(string Message, int Uid)
        {
            //parent.AddMessage(cur.id + ": " + msg);
            SqlConnection Con = GetCon();
            bool valid = false;
            SqlCommand com = new SqlCommand("LOG_add", Con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("TIME", DateTime.Now);

            com.Parameters.AddWithValue("username", Uid);
            com.Parameters.AddWithValue("ENTRY", Message);

            try
            {
                Con.Open();
                com.ExecuteNonQuery();
                valid = true;
            }
            catch (Exception e)
            {
                //parent.dumperror(e.Message);
            }
            Con.Close();
            return valid;
        }

        public override int GetUserStatus(User GetFor)
        {
            SqlConnection sqcon = GetCon();
            int status = 0;
            SqlCommand com = new SqlCommand("getstatus", sqcon);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("uid", GetFor.Uid);
            
            try
            {
                sqcon.Open();
                SqlDataReader Reader = com.ExecuteReader();
                if (Reader.Read())
                {
                    status = (int)Reader["status"];
                }
                
            }
            catch (Exception e)
            {
                
            }
            sqcon.Close();
            return status;
        }

        public override string[] GetMessagesForUser(User ToGet)
        {
            throw new NotImplementedException();
        }

        public override string GetBlackReasonForUser(User GetFor)
        {
            string tmp = null;
            SqlConnection sqcon = GetCon();
            try
            {
                sqcon.Open();
                SqlCommand Command = new SqlCommand("blacklist_get_reason", sqcon);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("uid", GetFor.Uid);

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    tmp = (string)Reader["reason"];
                }
            }
            catch
            {

            }
            sqcon.Close();
            return tmp;
        }

        public override string GetRedReasonForUser(User GetFor)
        {
            string tmp = null;
            SqlConnection sqcon = GetCon();
            try
            {
                sqcon.Open();
                SqlCommand Command = new SqlCommand("redlist_get_reason", sqcon);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("uid", GetFor.Uid);

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    tmp = (string)Reader["reason"];
                }
            }
            catch
            {

            }
            sqcon.Close();
            return tmp;
        }
    }
}
