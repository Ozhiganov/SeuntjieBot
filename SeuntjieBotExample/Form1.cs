using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;
using SeuntjieBot;
using Noesis.Javascript;

namespace SeuntjieBotExample
{
    public partial class Form1 : Form
    {
        SeuntjieBot.SeuntjieBot seuntjie;
        WebSocket tmp;
        int id = 0;
        DateTime lastmessage = DateTime.UtcNow;
        public Form1()
        {
            InitializeComponent();
        }
        public static string CurrentDate()
        {
            TimeSpan dt = DateTime.UtcNow - DateTime.Parse("1970/01/01 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
            double mili = dt.TotalMilliseconds;
            return ((long)mili).ToString();

        }

        /// <summary>
        /// Converts to current date and time for local time zone
        /// </summary>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string milliseconds)
        {
            DateTime tmpDate = DateTime.Parse("1970/01/01 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
            tmpDate = tmpDate.AddMilliseconds(long.Parse(milliseconds));
            tmpDate += (DateTime.Now - DateTime.UtcNow);
            return tmpDate;
        }
        void connectSocket()
        {
            //-1&sid=mDP2w-pcIQUxoaSfAANK
            HttpWebRequest
                            req = (HttpWebRequest)HttpWebRequest.Create("https://ws.magicaldice.com/socket.io/?EIO=3&transport=polling&t=" + CurrentDate() + "-0");
            req.CookieContainer = cookies;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            string s = new StreamReader(resp.GetResponseStream()).ReadToEnd();
            Cookie c = null;
            foreach (Cookie c2 in resp.Cookies)
            {
                if (c2.Name == "io")
                    c = c2;
            }

            req = (HttpWebRequest)HttpWebRequest.Create("https://ws.magicaldice.com/socket.io/?EIO=3&transport=polling&t=" + CurrentDate() + "-1&sid=" + c.Value);
            req.CookieContainer = cookies;

            resp = (HttpWebResponse)req.GetResponse();
            s = new StreamReader(resp.GetResponseStream()).ReadToEnd();

            if (c != null)
            {
                try
                {
                    req = (HttpWebRequest)HttpWebRequest.Create("https://ws.magicaldice.com/socket.io/?EIO=3&transport=polling&t=" + CurrentDate() + "-2&sid=" + c.Value);
                    req.CookieContainer = cookies;
                    req.Method = "POST";
                    string body = "45:42[\"auth\",\"" + authkey + "\"]";
                    //body = body.Length+body;
                    req.ContentLength = body.Length;
                    using (StreamWriter SW = new StreamWriter(req.GetRequestStream()))
                    {
                        SW.Write(body);
                    }
                    resp = (HttpWebResponse)req.GetResponse();
                    s = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                    if (s == "ok")
                    {

                        req = (HttpWebRequest)HttpWebRequest.Create("https://ws.magicaldice.com/socket.io/?EIO=3&transport=polling&t=" + CurrentDate() + "-3&sid=" + c.Value);
                        req.CookieContainer = cookies;
                        resp = (HttpWebResponse)req.GetResponse();
                        s = new StreamReader(resp.GetResponseStream()).ReadToEnd();

                        List<KeyValuePair<string, string>> cookies2 = new List<KeyValuePair<string, string>>();
                        List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();

                        foreach (Cookie c2 in cookies.GetCookies(new Uri("https://magicaldice.com")))
                        {
                            cookies2.Add(new KeyValuePair<string, string>(c2.Name, c2.Value));
                        }
                        headers.Add(new KeyValuePair<string, string>("origin", "magicaldice.com"));
                        headers.Add(new KeyValuePair<string, string>("upgrade", "websocket"));
                        headers.Add(new KeyValuePair<string, string>("connection", "upgrade"));
                        headers.Add(new KeyValuePair<string, string>("user-agent", "SeuntjieBot"));
                        headers.Add(new KeyValuePair<string, string>("accept-language", "en-GB,en-US;q=0.8,en;q=0.6"));

                        //tmp = new WebSocket("wss://ws.magicaldice.com/socket.io/?EIO=3&transport=websocket&sid=" + c.Value);
                        tmp = new WebSocket("wss://ws.magicaldice.com/socket.io/?EIO=3&transport=websocket&sid=" + c.Value, "", cookies2, headers, "SeuntjieBot", "magicaldice.com", WebSocketVersion.Rfc6455);
                        /*tmp.Compression = CompressionMethod.None;
                        tmp.SetCookie(new WebSocketSharp.Net.Cookie("io", c.Value));
                        tmp.OnOpen += tmp_OnOpen;
                        tmp.OnMessage += tmp_OnMessage;
                        tmp.OnClose += tmp_OnClose;
                        tmp.OnError += tmp_OnError;*/
                        lastmessage = DateTime.Now;
                        //tmp.Connect();
                        tmp.Opened += tmp_Opened;
                        tmp.Error += tmp_Error;
                        tmp.Closed += tmp_Closed;
                        tmp.MessageReceived += tmp_MessageReceived;
                        tmp.Open();

                        while (tmp.State == WebSocketState.Connecting)
                        {
                            Thread.Sleep(100);
                        }
                        if (tmp.State == WebSocketState.Open)
                        {
                            /*seuntjie = new seuntjiebot(this);
                            if (seuntjie != null)
                            {
                                seuntjie.tmrRain.Enabled = true;

                            }*/
                            /*timer3.Enabled = true;
                            tmrDesync.Enabled = true;*/
                        }
                    }
                }
                catch (WebException e)
                {
                    if (e.Response != null)
                    {
                        string ssss = new StreamReader(e.Response.GetResponseStream()).ReadToEnd();
                    }
                }

            }
        }

        void tmp_MessageReceived(object sender, MessageReceivedEventArgs e)
        {

            if (e.Message == "3probe")
            {
                tmp.Send("5");
            }
            else
            {

                if (e.Message != "3")
                {

                    if (e.Message.StartsWith("42[\"chat\","))
                    {
                        
                        string msg = e.Message.Substring("42[\"chat\",".Length);
                        msg = msg.Substring(0, msg.LastIndexOf("]"));
                        msg = msg.Replace("\"to\":0,", "\"to\":null,");
                        mdchat tmpChat = SeuntjieBot.SeuntjieBot.JsonDeserialize<mdchat>(msg);
                        if (tmpChat.type == "text" || tmpChat.type == "private")
                        {
                            chat tmpChat2 = tmpChat.ToChat();
                            if (seuntjie!=null)
                            seuntjie.ReceiveMessage(tmpChat2);
                        }
                    }
                }
            }
            //throw new NotImplementedException();
        }

        void tmp_Closed(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void tmp_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void tmp_Opened(object sender, EventArgs e)
        {
            tmp.Send("2probe");
            //throw new NotImplementedException();
        }
        CookieContainer cookies = null;
        private HttpClientHandler ClientHandlr;
        private HttpClient Client;
        private int cflevel;
        public void Login(string Username, string Password, string twofa)
        {

            //get the cloudflare and site headers
            cookies = new CookieContainer();
            ClientHandlr = new HttpClientHandler { UseCookies = true, CookieContainer = cookies };
            Client = new HttpClient(ClientHandlr) { BaseAddress = new Uri("https://magicaldice.com/") };

            string s1 = "";

            try
            {
                HttpResponseMessage resp = Client.GetAsync("").Result;
                if (resp.IsSuccessStatusCode)
                {
                    s1 = resp.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    if (resp.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        s1 = resp.Content.ReadAsStringAsync().Result;
                        cflevel = 0;
                        System.Threading.Tasks.Task.Factory.StartNew(() =>
                        {
                            System.Windows.Forms.MessageBox.Show("MagicalDice.com has their cloudflare protection on HIGH\n\nThis will cause a slight delay in logging in. Please allow up to a minute.");
                        });
                        if (!doCFThing(s1))
                        {

                            return;
                        }

                    }
                }
            }
            catch (AggregateException e)
            {
                if (e.InnerException.Message.Contains("503"))
                {
                    //doCFThing(e.InnerException);
                }
            }



            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("user_name", Username));
            pairs.Add(new KeyValuePair<string, string>("user_password", Password));
            FormUrlEncodedContent Content = new FormUrlEncodedContent(pairs);
            try
            {
                string sEmitResponse = Client.PostAsync("", Content).Result.Content.ReadAsStringAsync().Result;

            }
            catch (AggregateException e)
            {

            }


            try
            {
                s1 = Client.GetStringAsync("ajax.php?a=get_authkey").Result;

                //make auth key from s1*/
                MDAuthKey au = SeuntjieBot.SeuntjieBot.JsonDeserialize<MDAuthKey>(s1);
                //set auth key
                authkey = au.auth_key;
                //get user stats
                //disect html to get stats*/

                //get balance

                s1 = Client.GetStringAsync("ajax.php?a=get_balance").Result;
                balance = double.Parse(s1.Replace("\"", ""), System.Globalization.NumberFormatInfo.InvariantInfo);



            }
            catch (AggregateException e)
            {

            }
            catch (Exception e)
            {

            }
        }
        string authkey;
        string csrf;
        double balance = 0;
        bool doCFThing(string Response)
        {
            Thread.Sleep(4000);
            JavascriptContext JSC = new JavascriptContext();

            string s1 = Response;//new StreamReader(Response.GetResponseStream()).ReadToEnd();
            string Script = "";
            string jschl_vc = s1.Substring(s1.IndexOf("jschl_vc"));
            jschl_vc = jschl_vc.Substring(jschl_vc.IndexOf("value=\"") + "value=\"".Length);
            jschl_vc = jschl_vc.Substring(0, jschl_vc.IndexOf("\""));
            string pass = s1.Substring(s1.IndexOf("pass"));
            pass = pass.Substring(pass.IndexOf("value=\"") + "value=\"".Length);
            pass = pass.Substring(0, pass.IndexOf("\""));

            //do the CF bypass thing and get the headers
            Script = s1.Substring(s1.IndexOf("var t,r,a,f,") + "var t,r,a,f, ".Length);
            string Script1 = "var " + Script.Substring(0, Script.IndexOf(";") + 1);
            string varName = Script.Substring(0, Script.IndexOf("="));
            string varNamep2 = Script.Substring(Script.IndexOf("\"") + 1);
            varName += "." + varNamep2.Substring(0, varNamep2.IndexOf("\""));
            Script1 += Script.Substring(Script.IndexOf(varName));
            Script1 = Script1.Substring(0, Script1.IndexOf("f.submit()"));
            Script1 = Script1.Replace("t.length", "magicaldice.com".Length + "");
            Script1 = Script1.Replace("a.value", "var answer");
            JSC.Run(Script1);
            string answer = JSC.GetParameter("answer").ToString();

            try
            {
                HttpResponseMessage Resp = Client.GetAsync("cdn-cgi/l/chk_jschl?jschl_vc=" + jschl_vc + "&pass=" + pass.Replace("+", "%2") + "&jschl_answer=" + answer).Result;
                bool Found = false;

                foreach (Cookie c in ClientHandlr.CookieContainer.GetCookies(new Uri("https://magicaldice.com")))
                {
                    if (c.Name == "cf_clearance")
                    {
                        Found = true;
                        break;
                    }
                }
                /*if (ClientHandlr.CookieContainer.Count==3)
                {
                    Thread.Sleep(2000);
                }*/
                if (!Found && cflevel++ < 5)
                    Found = doCFThing(Resp.Content.ReadAsStringAsync().Result);
                return Found;

            }
            catch (AggregateException e)
            {

            }
            return false;
        }

        public decimal GetBalance()
        {
            return (decimal)balance;
        }

        public bool rain(decimal amount, string User)
        {

            string s1 = Client.GetStringAsync("ajax.php?a=get_csrf").Result;
            MDCsrf tmp = SeuntjieBot.SeuntjieBot.JsonDeserialize<MDCsrf>(s1);
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("a", "tip_user"));
            pairs.Add(new KeyValuePair<string, string>("user_id", User));
            pairs.Add(new KeyValuePair<string, string>("amount", amount.ToString(System.Globalization.NumberFormatInfo.InvariantInfo)));
            pairs.Add(new KeyValuePair<string, string>("csrf", tmp.csrf));


            FormUrlEncodedContent Content = new FormUrlEncodedContent(pairs);
            try
            {
                string sEmitResponse = Client.PostAsync("ajax.php", Content).Result.Content.ReadAsStringAsync().Result;
                return true;
            }
            catch (AggregateException e)
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login(txtUsername.Text, txtPassword.Text, "");            
            connectSocket();
            timer1.Enabled = true;
            if (tmp.State == WebSocketState.Open)
            {
                seuntjie = new SeuntjieBot.SeuntjieBot();
                seuntjie.ActiveUsersChanged += seuntjie_ActiveUsersChanged;
                seuntjie.GetBalance += seuntjie_GetBalance;
                seuntjie.SendMessage += seuntjie_SendMessage;
                seuntjie.SendRain += seuntjie_SendRain;
            }

        }

        bool seuntjie_SendRain(User RainOn, double Amount)
        {
            string s1 = Client.GetStringAsync("ajax.php?a=get_csrf").Result;
            MDCsrf tmp = SeuntjieBot.SeuntjieBot.JsonDeserialize<MDCsrf>(s1);
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
            pairs.Add(new KeyValuePair<string, string>("a", "tip_user"));
            pairs.Add(new KeyValuePair<string, string>("user_id", RainOn.Uid.ToString()));
            pairs.Add(new KeyValuePair<string, string>("amount", Amount.ToString(System.Globalization.NumberFormatInfo.InvariantInfo)));
            pairs.Add(new KeyValuePair<string, string>("csrf", tmp.csrf));


            FormUrlEncodedContent Content = new FormUrlEncodedContent(pairs);
            try
            {
                string sEmitResponse = Client.PostAsync("ajax.php", Content).Result.Content.ReadAsStringAsync().Result;
                return true;
            }
            catch (AggregateException e)
            {
                return false;
            }
        }
        DateTime lastCsrf = DateTime.Now;
        void seuntjie_SendMessage(SendMessage Message)
        {
            if (tmp.State == WebSocketState.Open)
            {
                if (csrf == "" || csrf == null)
                {
                    string s1 = Client.GetStringAsync("ajax.php?a=get_csrf").Result;
                    MDCsrf csr = SeuntjieBot.SeuntjieBot.JsonDeserialize<MDCsrf>(s1);
                    csrf = csr.csrf;
                    lastCsrf = DateTime.Now;
                }
                List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>();
                pairs.Add(new KeyValuePair<string, string>("text", Message.Message));
                pairs.Add(new KeyValuePair<string, string>("a", "submit_chat"));
                pairs.Add(new KeyValuePair<string, string>("csrf", csrf));
                pairs.Add(new KeyValuePair<string, string>("user_id", Message.Pm?Message.ToUser.Uid.ToString():"0"));
                FormUrlEncodedContent Content = new FormUrlEncodedContent(pairs);
                try
                {
                    string sEmitResponse = Client.PostAsync("ajax.php", Content).Result.Content.ReadAsStringAsync().Result;
                    string s1 = Client.GetStringAsync("ajax.php?a=get_csrf").Result;
                    MDCsrf csr = SeuntjieBot.SeuntjieBot.JsonDeserialize<MDCsrf>(s1);
                    csrf = csr.csrf;
                    lastCsrf = DateTime.Now;
                }
                catch (AggregateException e)
                {

                }
            }
        }

        double seuntjie_GetBalance()
        {
            return balance;
        }

        void seuntjie_ActiveUsersChanged(User[] ActiveUsers)
        {
            
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tmp != null)
                if (tmp.State == WebSocketState.Open)
                    if ((DateTime.Now - lastmessage).TotalSeconds >= 25)
                    {
                        tmp.Send("2");
                        lastmessage = DateTime.Now;
                    }
        }

    }

    public class MDAuthKey
    {
        public string auth_key { get; set; }
        public string user_id { get; set; }
        public string expires { get; set; }
    }

    
    public class MDCsrf
    {
        public string csrf { get; set; }
    }

    public class mdchat
    {
        public long time { get; set; }
        public mdfrom from { get; set; }
        public string msg { get; set; }
//        public int to { get; set; }
        public mdfrom to { get; set; }
        public string type { get; set; }
        public SeuntjieBot.chat ToChat()
        {
            SeuntjieBot.chat tmp = new SeuntjieBot.chat
            {
                Message = msg,
                Time = Form1.ToDateTime((time).ToString()),
                UID = long.Parse(from.user_id),
                User = from.user_name,
                Type = (to == null? "" : "pm")
            };
            return tmp;
        }
    }
    
    public class mdfrom
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string user_permissions { get; set; }
    }
}
