using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WebSocket4Net;
using SeuntjieBot;
//using Noesis.Javascript;

namespace SeuntjieBot
{
    public partial class Ui : UserControl
    {
        public SeuntjieBot seuntjie;
        
        protected DateTime lastmessage = DateTime.UtcNow;
        public Ui()
        {
            InitializeComponent();
        }
        public static string CurrentDate()
        {
            TimeSpan dt = DateTime.UtcNow - DateTime.Parse("1970/01/01 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
            double mili = dt.TotalMilliseconds;
            return ((long)mili).ToString();
            
        }

        protected virtual bool LogIn(string username, string password, string ga){throw new NotImplementedException();}
        

        /// <summary>
        /// Converts to current date and time for local time zone
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string milliseconds)
        {
            try
            {
                DateTime tmpDate = DateTime.Parse("1970/01/01 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
                tmpDate = tmpDate.AddSeconds(long.Parse(milliseconds));
                tmpDate += (DateTime.Now - DateTime.UtcNow);
                return tmpDate;
            }
            catch (Exception e)
            {
                try
                {
                    DateTime tmpDate = DateTime.Parse("1970/01/01 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
                    tmpDate = tmpDate.AddMilliseconds(long.Parse(milliseconds));
                    tmpDate += (DateTime.Now - DateTime.UtcNow);
                    return tmpDate;
                }
                catch
                {
                    //string s = milliseconds.ToLower().Replace("z", " ").Replace("t", " ");
                    DateTime dotNetDate = DateTime.Parse(milliseconds);
                    dotNetDate = dotNetDate.AddHours((DateTime.Now - DateTime.UtcNow).Hours);
                    return dotNetDate;
                }
            }
        }
        

        delegate void dAddMessage(string s);
        protected void AddMessage(string Message)
        {
            if (InvokeRequired)
            {
                Invoke(new dAddMessage(AddMessage), Message);
                return;
            }
            lstChat.Items.Insert(0, Message);
            if (lstChat.Items.Count > 300)
            {
                lstChat.Items.RemoveAt(lstChat.Items.Count - 1);
            }
        }

        protected string ConnectionString = "";

        protected virtual void button1_Click(object sender, EventArgs e)
        {
            if (LogIn(txtUsername.Text, txtPassword.Text, ""))
            {

                              
                seuntjie = new SeuntjieBot(1261);
                seuntjie.ConnectionString = ConnectionString;
                seuntjie.RainMode = (RainType)(rdbNat.Checked ? 0 : rdbUser.Checked ? 1 : 2);
                seuntjie.MinRain = nudMinRain.Value;
                seuntjie.RainPercentage = nudRainPerc.Value / 100m;
                seuntjie.RainInterval = new TimeSpan(0, 0, (int)(nudRainTime.Value * 60m));
                seuntjie.LogOnly = chkLogOnly.Checked;
                seuntjie.RainScore = (int)numericUpDown1.Value;
                seuntjie.ActiveUsersChanged += seuntjie_ActiveUsersChanged;
                seuntjie.GetBalance += GetBalance;
                seuntjie.SendMessage += seuntjie_SendMessage;
                seuntjie.SendRain += seuntjie_SendRain;
                seuntjie.CommandsUpdated += seuntjie_CommandsUpdated;
                seuntjie.loadCommands();
                seuntjie.maxMessage = 250;
                
            }

        }
        delegate void dCommandsUpdated(object sender,List<Command> Commands);
        void CommandsUpdated(object sender, List<Command> Commands)
        {
            clbCommands.Items.Clear();
            foreach (Command c in Commands)
            {
                clbCommands.Items.Add(c.sCommand, c.Enabled);
            }
        }
        void seuntjie_CommandsUpdated(object sender, Command[] Commands)
        {
            if (InvokeRequired)
            {
                Invoke(new dCommandsUpdated(CommandsUpdated),this, Commands.ToList());
                return;
            }
            else
            {
                clbCommands.Items.Clear();
                foreach (Command c in Commands)
                {
                    clbCommands.Items.Add(c.sCommand, c.Enabled);
                }
            }
        }

        protected virtual bool seuntjie_SendRain(object sender, User RainOn, double Amount)
        {
            throw new NotImplementedException();
        }

        protected virtual void seuntjie_SendMessage(object sender, SendMessage Message)
        {
            throw new NotImplementedException();
        }

        private double GetBalance(object sender)
        {
            
            if (InvokeRequired)
            {
                return (double)Invoke(new SeuntjieBot.dGetBalance(GetBalance));
            }
            else
            {
                double tmp = seuntjie_GetBalance();
                lblBalance.Text = tmp.ToString();
                return tmp;
            }
        }

        protected virtual double seuntjie_GetBalance()
        {
            throw new NotImplementedException();
        }

        delegate void ActiveChanged(object sender, List<User> ActiveUsers);
        void seuntjie_ActiveUsersChanged(object sender,List<User> ActiveUsers)
        {
            lbActive.Items.Clear();
            lbEligible.Items.Clear();
            foreach (User u in ActiveUsers)
            {
                if (u.getscore() >= seuntjie.RainScore)
                {
                    lbEligible.Items.Add(u.Username + "(" + u.Uid + ") <"+ u.getscore()+">");
                }
                else
                {
                    lbActive.Items.Add(u.Username + "(" + u.Uid + ") <" + u.getscore() + ">");
                }
            }
        }
        
        void seuntjie_ActiveUsersChanged(object sender, User[] ActiveUsers)
        {
            if (InvokeRequired)
            {
                User[] Users = ActiveUsers;
                Invoke(new ActiveChanged(seuntjie_ActiveUsersChanged),this, Users.ToList<User>());
                return;
            }
           
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void clbCommands_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clbCommands.SelectedIndex == e.Index)
            {
                seuntjie.UpdateCommand(clbCommands.Items[e.Index].ToString(), e.NewValue == CheckState.Checked);
            }
        }

        private void nudMinRain_ValueChanged(object sender, EventArgs e)
        {
            if (seuntjie!=null)
            {
                seuntjie.MinRain = nudMinRain.Value;
            }
        }

        private void nudRainPerc_ValueChanged(object sender, EventArgs e)
        {
            if (seuntjie != null)
            {
                seuntjie.RainPercentage = nudRainPerc.Value;
            }
        }

        private void nudRainTime_ValueChanged(object sender, EventArgs e)
        {
            if (seuntjie != null)
            {
                seuntjie.RainInterval = new TimeSpan(0, 0, (int)(nudRainTime.Value*60m));
            }
        }

        private void btnRain_Click(object sender, EventArgs e)
        {
            seuntjie.Rain(true);
        }

        private void rdbComb_CheckedChanged(object sender, EventArgs e)
        {
            if (seuntjie != null)
            {

                if ((sender as RadioButton).Checked)
                {
                    switch ((sender as RadioButton).Name)
                    {
                        case "rdbUser": seuntjie.RainMode = RainType.user; break;
                        case "rdbNat": seuntjie.RainMode = RainType.natural; break;
                        case "rdbComb": seuntjie.RainMode = RainType.combination; break;
                        default: seuntjie.RainMode = RainType.combination;break;
                    }
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (seuntjie!=null)
            {
                seuntjie.RainScore = (int)numericUpDown1.Value;
            }
        }

        private void chkLogOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (seuntjie!=null)
            {
                seuntjie.LogOnly = chkLogOnly.Checked;
            }
        }

        private void tmrRainTime_Tick(object sender, EventArgs e)
        {
            if (seuntjie != null)
            {
                lblTimeNext.Text = (seuntjie.RainInterval - (DateTime.Now - seuntjie.LastRain)).ToString();
            }
        }

        private void nudRainPerc_ValueChanged_1(object sender, EventArgs e)
        {
            seuntjie.RainPercentage = nudRainPerc.Value*100m;
        }

        private void nudRainTime_ValueChanged_1(object sender, EventArgs e)
        {
            if (nudRainTime.Value>0m)
                seuntjie.RainInterval = new TimeSpan(0, (int)nudRainTime.Value, 0);
        }

    }

   
}
