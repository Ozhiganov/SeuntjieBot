using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SeuntjieBot
{

    class blockchaininfo
    {

        public static latestblock GetLatestBlock()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://blockchain.info/latestblock");

                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                latestblock block = null;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                {
                    string s = sr.ReadToEnd();
                    block = SeuntjieBot.JsonDeserialize<latestblock>(s);
                    
                }
                return block;
                    
            }
            catch
            {
                return null;
            }
        }

        public static UnconfirmedTx GetUnconfirmed()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://blockchain.info/unconfirmed-transactions?format=json");

                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                UnconfirmedTx block = null;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                {
                    string s = sr.ReadToEnd();
                    block = SeuntjieBot.JsonDeserialize<UnconfirmedTx>(s);

                }
                return block;

            }
            catch
            {
                return null;
            }
        }

        public static addresss GetAddress(string Addy)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://blockchain.info/address/"+Addy+"?format=json");

                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                addresss block = null;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                {
                    string s = sr.ReadToEnd();
                    block = SeuntjieBot.JsonDeserialize<addresss>(s);

                }
                return block;

            }
            catch
            {
                return null;
            }
        }

        public static transaction GetTx(string tx)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://blockchain.info/rawtx/"+tx);

                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                transaction block = null;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream()))
                {
                    string s = sr.ReadToEnd();
                    block = SeuntjieBot.JsonDeserialize<transaction>(s);

                }
                return block;

            }
            catch
            {
                return null;
            }
        }
    }

    public class UnconfirmedTx
    {
        public string lock_time { get; set; }
        public int ver { get; set; }
        public double size { get; set; }
        public bool double_spend { get; set; }
        public long time { get; set; }
        public long tx_index { get; set; }
        public double vin_sz { get; set; }
        public string hash { get; set; }
        public double vout_sz { get; set; }
        public string relayed_by { get; set; }
        public UnconfirmedTx[] txs { get; set; }
        //public  MyProperty { get; set; }
    }

    public class latestblock
    {
        public string has { get; set; }
        public long time { get; set; }
        public long block_index { get; set; }
        public long height { get; set; }
        public long[] txIndexes { get; set; }
    }

    public class addresss
    {
        public string hash160 { get; set; }
        public string address { get; set; }
        public int n_tx { get; set; }
        public long n_unredeemed { get; set; }
        public long total_received { get; set; }
        public long total_sent { get; set; }
        public long final_balance { get; set; }
        
    }

    public class transaction
    {
        public string hash { get; set; }
        public int ver { get; set; }
        public int vin_sz { get; set; }
        public int vout_sz { get; set; }
        public long lock_time { get; set; }
        public int size { get; set; }
        public string relayed_by { get; set; }
        public long block_height { get; set; }
        public string tx_index { get; set; }
    }
}
