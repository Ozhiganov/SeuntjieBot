using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Net;
using System.IO.IsolatedStorage;
using Microsoft.CSharp;
using System.Runtime.Serialization.Json;

namespace CryptoPriceCore
{
    public class FinishedPricesEventArgs : EventArgs
    {
        public List<YahooPair> Fiat { get; set; }
        public object Currencies { get; set; }
        private decimal Mbtc { get; set; }


        public FinishedPricesEventArgs(List<YahooPair> Fiat, object Currencies, decimal Mbtc)
        {
            this.Fiat = Fiat;
            this.Currencies = Currencies;
            this.Mbtc = Mbtc;
        }

    }

    public class GetPrices
    {
        public DateTime LastUpdate { get; set; }
        public YahooPair[] _Fiat { get { return Fiat.ToArray(); } set { Fiat = value.ToList<YahooPair>(); } }
        public object _Currencies { get { return Currencies; } set { Currencies = value; } }
        public decimal Mbtc { get { return mbtc; } set { mbtc = value; } }
        Dictionary<string, string> _Names = new Dictionary<string, string>();
        public Dictionary<string, string> Names { get { if (_Names.Count == 0) ReloadList(); return _Names; } set { } }

        public void ReloadList()
        {
            _Names = new Dictionary<string, string>();
            _Names.Add("ADE", "United Arab Emirates Dirham");
            _Names.Add("AFN", "Afghan Afghani");
            _Names.Add("ALL", "Albanian Lek");
            _Names.Add("ANG", "Dutch Guilder");
            _Names.Add("AOA", "Angolan Kwanza");
            _Names.Add("ARS", "Argentine Peso");
            _Names.Add("AUD", "Australian Dollar");
            _Names.Add("AWG", "Aruban or Dutch Guilder");
            _Names.Add("AZN", "Azerbaijani New Manat");
            _Names.Add("BAM", "Bosnian Convertible Marka");
            _Names.Add("BBD", "Barbadian or Bajan Dollar");
            _Names.Add("BDT", "Bangladeshi Taka");
            _Names.Add("BGN", "Bulgarian Lev");
            _Names.Add("BHD", "Bahraini Dinar");
            _Names.Add("BIF", "Burundian Franc");
            _Names.Add("BMD", "Bermudian Dollar");
            _Names.Add("BND", "Bruneian Dollar");
            _Names.Add("BOB", "Bolivian Boliviano");
            _Names.Add("BRL", "Brazilian Real");
            _Names.Add("BSD", "Bahamian Dollar");
            _Names.Add("BTN", "Bhutanese Ngultrum");
            _Names.Add("BWP", "Botswana Pula");
            _Names.Add("BYR", "Belarusian Ruble");
            _Names.Add("BZD", "Belizean Dollar");
            _Names.Add("CAD", "Canadian Dollar");
            _Names.Add("CDF", "Congolese Franc");
            _Names.Add("CHF", "Swiss Franc");
            _Names.Add("CLF", "Chilean Unidad de Fomento");
            _Names.Add("CLP", "Chilean Peso");
            _Names.Add("CNY", "Chinese Yuan Renminbi");
            _Names.Add("COP", "Colombian Peso");
            _Names.Add("CRC", "Costa Rican Colon");
            _Names.Add("CUP", " Cuban Peso");
            _Names.Add("CVE", "Cape Verdean Escudo");
            _Names.Add("CYP", "Cyprus Pound");
            _Names.Add("CZK", "Czech Koruna");
            _Names.Add("DJF", "Djiboutian Franc");
            _Names.Add("DKK", "Danish Krone");
            _Names.Add("DOP", "Dominican Peso");
            _Names.Add("DZD", "Algerian Dinar");
            _Names.Add("EGP", "Egyptian Pound");
            _Names.Add("ERN", "Eritrean Nakfa");
            _Names.Add("ETB", "Ethiopian Birr");
            _Names.Add("EUR", "Euro");
            _Names.Add("FJD", "Fijian Dollar");
            _Names.Add("FKP", "Falkland Island Pound");
            _Names.Add("GBP", "British Pound");
            _Names.Add("GEL", "Georgian Lari");
            _Names.Add("GHS", "Ghanaian Cedi");
            _Names.Add("GIP", "Gibraltar Pound");
            _Names.Add("GMD", "Gambian Dalasi");
            _Names.Add("GNF", "Guinean Franc");
            _Names.Add("GTQ", "Guatemalan Quetzal");
            _Names.Add("GYD", "Guyanese Dollar");
            _Names.Add("HKD", "Hong Kong Dollar");
            _Names.Add("HNL", "Honduran Lempira");
            _Names.Add("HRK", "Croatian Kuna");
            _Names.Add("HTG", "Haitian Gourde");
            _Names.Add("HUF", "Hungarian Forint");
            _Names.Add("IDR", "Indonesian Rupiah");
            _Names.Add("ILS", "Israeli Shekel");
            _Names.Add("INR", "Indian Rupee");
            _Names.Add("IQD", "Iraqi Dinar ");
            _Names.Add("IRR", "Iranian Rial");
            _Names.Add("ISK", "Icelandic Krona");
            _Names.Add("JMD", "Jamaican Dollar");
            _Names.Add("JOD", "Jordanian Dinar");
            _Names.Add("JPY", "Japanese Yen");
            _Names.Add("KES", "Kenyan Shilling");
            _Names.Add("KGS", "Kyrgyzstani Som");
            _Names.Add("KHR", "Cambodian Riel  ");
            _Names.Add("KMF", "Comoran Franc");
            _Names.Add("KPW", "North Korean Won");
            _Names.Add("KRW", "South Korean Won");
            _Names.Add("KWD", "Kuwaiti Dinar");
            _Names.Add("KYD", "Caymanian Dollar");
            _Names.Add("KZT", "Kazakhstani Tenge");
            _Names.Add("LAK", "Lao or Laotian Kip");
            _Names.Add("LBP", "Lebanese Pound");
            _Names.Add("LKR", "Sri Lankan Rupee");
            _Names.Add("LRD", "Liberian Dollar");
            _Names.Add("LSL", "Basotho Loti");
            _Names.Add("LTL", "Lithuanian Litas");
            _Names.Add("LVL", "Latvian Lats");
            _Names.Add("LYD", "Libyan Dinar");
            _Names.Add("MAD", "Moroccan Dirham");
            _Names.Add("MDL", "Moldovan Leu");
            _Names.Add("MGA", "Malagasy Ariary");
            _Names.Add("MKD", "Macedonian Denar");
            _Names.Add("MMK", "Burmese Kyat");
            _Names.Add("MNT", "Mongolian Tughrik");
            _Names.Add("MOP", "Macau Pataca");
            _Names.Add("MRO", "Mauritanian Ouguiya");
            _Names.Add("MUR", "Mauritian Rupee");
            _Names.Add("MVR", "Maldivian Rufiyaa");
            _Names.Add("MWK", "Malawian Kwacha");
            _Names.Add("MXN", "Mexican Peso");
            _Names.Add("MXV", " Mexican Unidad De Inversion");
            _Names.Add("MYR", "Malaysian Ringgit");
            _Names.Add("MZN", "Mozambican Metica");
            _Names.Add("NAD", "Namibian Dollar");
            _Names.Add("NGN", "Nigerian Naira");
            _Names.Add("NIO", "Nicaraguan Cordoba");
            _Names.Add("NOK", "Norwegian Krone");
            _Names.Add("NPR", "Nepalese Rupee");
            _Names.Add("NZD", "New Zealand Dollar");
            _Names.Add("OMR", "Omani Rial");
            _Names.Add("PAB", "Panamanian Balboa");
            _Names.Add("PEN", "Peruvian Nuevo Sol");
            _Names.Add("PGK", "Papua New Guinean Kina");
            _Names.Add("PHP", "Philippine Peso");
            _Names.Add("PKR", "Pakistani Rupee");
            _Names.Add("PLN", "Polish Zloty");
            _Names.Add("PYG", "Paraguayan Guarani");
            _Names.Add("QAR", "Qatari Riyal");
            _Names.Add("RON", "Romanian New Leu");
            _Names.Add("RSD", "Serbian Dinar");
            _Names.Add("RUB", "Russian Ruble");
            _Names.Add("RWF", "Rwandan Franc");
            _Names.Add("SAR", "Saudi Arabian Riyal");
            _Names.Add("SBD", "Solomon Islander Dollar");
            _Names.Add("SCR", "Seychellois Rupee");
            _Names.Add("SDG", "Sudanese Pound");
            _Names.Add("SEK", "Swedish Krona");
            _Names.Add("SGD", "Singapore Dollar");
            _Names.Add("SHP", "Saint Helenian Pound");
            _Names.Add("SLL", "Sierra Leonean Leone");
            _Names.Add("SOS", "Somali Shilling");
            _Names.Add("SRD", "Suri_Namese Dollar");
            _Names.Add("STD", "Sao Tomean Dobra");
            _Names.Add("SYP", "Syrian Pound");
            _Names.Add("SZL", "Swazi Lilangeni");
            _Names.Add("THB", "Thai Baht");
            _Names.Add("TJS", "Tajikistani Somoni");
            _Names.Add("TND", "Tunisian Dinar");
            _Names.Add("TOP", "Tongan Palanga");
            _Names.Add("TRY", "Turkish Lira");
            _Names.Add("TTD", "Trinidadian Dollar");
            _Names.Add("TWD", "Taiwan New Dollar");
            _Names.Add("TZS", "Tanzanian Shilling");
            _Names.Add("UAH", "Ukrainian Hryvnia");
            _Names.Add("UGX", "Ugandan Shilling");
            _Names.Add("USD", "US Dollar");
            _Names.Add("UYU", "Uruguayan Peso");
            _Names.Add("UZS", "Uzbekistani Som");
            _Names.Add("VND", "Viet_Namese Dong");
            _Names.Add("VUV", "Ni-Vanuatu Vatu");
            _Names.Add("WST", "Samoan Tala");
            _Names.Add("XAF", "Central African CFA Franc");
            _Names.Add("1CR", "1Credit");
            _Names.Add("ABY", "ArtByte");
            _Names.Add("ADN", "Aiden");
            _Names.Add("ARCH", "AarchCoin");
            _Names.Add("BBR", "BoolBerryY");
            _Names.Add("BCN", "Bytecoin");
            _Names.Add("BELA", "BellaCoin");
            _Names.Add("BITS", "Bitstar");
            _Names.Add("BLK", "BlackCoin");
            _Names.Add("BLOCK", "Blocknet");
            _Names.Add("BTCD", "Bitcoindarm");
            _Names.Add("BTM", "Bitmark");
            _Names.Add("BTS", "Bitshares");
            _Names.Add("BURST", "Burst");
            _Names.Add("C2", "Coin2.0");
            _Names.Add("CGA", "Cryptographic Anomoly");
            _Names.Add("CLAM", "Clams");
            _Names.Add("CNMT", "Coinomati1");
            _Names.Add("CURE", "CureCoin");
            _Names.Add("DASH", "Dash");
            _Names.Add("DGB", "Digibyte");
            _Names.Add("DIEM", "CarpeDiemCoin");
            _Names.Add("DOGE", "DogeCoin");
            _Names.Add("EMC2", "Einsteinium");
            _Names.Add("EXE", "ExeCoin");
            _Names.Add("FIBRE", "FibreCoin");
            _Names.Add("FLDC", "FoldingCoin");
            _Names.Add("FLO", "FlorinCoin");
            _Names.Add("FLT", "FlutterCoin");
            _Names.Add("GAP", "GapCoin");
            _Names.Add("GEMZ", "GetGemz");
            _Names.Add("GEO", "GeoCoin");
            _Names.Add("GMC", "GameCredits");
            _Names.Add("GRC", "GridCoin Research");
            _Names.Add("GRS", "GroestlCoin");
            _Names.Add("HUC", "HunterCoin");
            _Names.Add("HYP", "HyperStake");
            _Names.Add("HZ", "Horizon");
            _Names.Add("LQD", "Liquid");
            _Names.Add("LTBC", "LTBCoin");
            _Names.Add("LTC", "LiteCoin");
            _Names.Add("MAID", "MaidSafeCoind");
            _Names.Add("MCN", "Moneta Verde");
            _Names.Add("MIL", "Millennium Coin");
            _Names.Add("MINT", "MintCoint");
            _Names.Add("MMC", "MemoryCoin");
            _Names.Add("MMNXT", "MMNXT");
            _Names.Add("MRS", "MarsCoin");
            _Names.Add("OMNI", "Omni");
            _Names.Add("_MYR", "MyriadCoin");
            _Names.Add("NAUT", "NautilusCoin");
            _Names.Add("NAV", "Navajo");
            _Names.Add("NBT", "NuBits");
            _Names.Add("NEOS", "NeosCoin");
            _Names.Add("NMC", "NameCoin");
            _Names.Add("NOBL", "NobleCoin");
            _Names.Add("NOTE", "DNotes");
            _Names.Add("NOXT", "NobleNXT");
            _Names.Add("NSR", "NuShares");
            _Names.Add("NXT", "NXT");
            _Names.Add("PIGGY", "New PiggyCoin");
            _Names.Add("PINK", "PinkCoin");
            _Names.Add("POT", "PotCoin");
            _Names.Add("PPC", "Peercoin");
            _Names.Add("PTS", "Bitshares PTS");
            _Names.Add("QBK", "Qibuck");
            _Names.Add("QORA", "Qora");
            _Names.Add("QTL", "Quatloo");
            _Names.Add("RBY", "RubyCoin");
            _Names.Add("RDD", "ReddCoin");
            _Names.Add("RIC", "RieCoin");
            _Names.Add("SDC", "Shadow");
            _Names.Add("SILK", "SilkCoin");
            _Names.Add("SJCX", "StorjCoin X");
            _Names.Add("STR", "Lumens");
            _Names.Add("SWARM", "Swarm");
            _Names.Add("SYNC", "Sync");
            _Names.Add("SYS", "Syscoin");
            _Names.Add("UNITY", "SuperNET");
            _Names.Add("VIA", "ViaCoin");
            _Names.Add("XVC", "VCash");
            _Names.Add("VRC", "VeriCoin");
            _Names.Add("VTC", "VertCoin");
            _Names.Add("WDC", "WorldCoin");
            _Names.Add("XBC", "BitcoinPlus");
            _Names.Add("XC", "XCurrency");
            _Names.Add("XCH", "ClearingHouse");
            _Names.Add("XCN", "Cryptonite");
            _Names.Add("XCP", "Counterparty");
            _Names.Add("XCR", "Crypti");
            _Names.Add("XDN", "DigitalNote");
            _Names.Add("XDP", "DogeParty");
            _Names.Add("XEM", "New Economy Movement");
            _Names.Add("XMG", "Magi");
            _Names.Add("XMR", "Monero");
            _Names.Add("XPB", "PebbleCoin");
            _Names.Add("XPM", "PrimeCoin");
            _Names.Add("XRP", "Ripple");
            _Names.Add("XST", "StealthCoin");
            _Names.Add("XUSD", "CoinoUSD");
            _Names.Add("YACC", "YacCoin");
            _Names.Add("IOC", "IO Digital Currency");
            _Names.Add("INDEX", "CoinoIndex");
            _Names.Add("ETH", "Ethereum");
            _Names.Add("SC", "SiaCoin");
            _Names.Add("BCY", "BitCrystals");
            _Names.Add("EXP", "Expanse");
            _Names.Add("FCT", "Factom");
            _Names.Add("BITUSD", "BitUSD");
            _Names.Add("BITCNY", "BitCNY");
            _Names.Add("RADS", "Radium");
            _Names.Add("AMP", "Synerro AMP");
            _Names.Add("BTC", "Bitcoin");
            _Names.Add("ZAR", "South-African Rand");
        }

        public GetPrices()
        {
            

        }

        public void GeneratePoloniexClass()
        {

        }

        public void WriteFile()
        {
            this.LastUpdate = DateTime.Now;
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                //myIsolatedStorage.DeleteFile("data.json");
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("data.json", FileMode.Create, myIsolatedStorage))
                {
                    using (StreamWriter tmp = new StreamWriter(isoStream))
                    {
                        tmp.Write(json.JsonSerializer<GetPrices>(this));
                    }
                }
            }
        }

        public static GetPrices LoadFromFile()
        {
            GetPrices tmp = new GetPrices();
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists("data.json"))
                {
                    IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("data.json", FileMode.Open);
                    using (StreamReader reader = new StreamReader(isoFileStream))
                    {
                        string s = reader.ReadToEnd();
                        tmp = json.JsonDeserialize<GetPrices>(s);
                    }
                }
            }
            return tmp;
        }

        List<YahooPair> Fiat = new List<YahooPair>();
        object Currencies = null;
        private decimal mbtc;

        bool PolDone =false;
        bool btcafgdone = false;
        bool yahooDone = false;

        public delegate void dHavePrices(object sender, FinishedPricesEventArgs e);
        public event dHavePrices HavePrices;
        CSharpCodeProvider tmp = new CSharpCodeProvider();
        System.CodeDom.Compiler.CompilerResults tmpRes = null;
        void TriggerEvent()
        {
            if (PolDone && btcafgdone && yahooDone && HavePrices != null)
            { HavePrices(this, new FinishedPricesEventArgs(Fiat, Currencies, mbtc)); }
        }
        static DateTime LastClassUpdate = DateTime.Today.AddDays(-1);
        private void Poloniex(IAsyncResult Result)
        {
            try
            {
                //RequestState myRequestState = (RequestState)Result.AsyncState;
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)Result.AsyncState;
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(Result);

                string sEmitResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if ((DateTime.Now-LastClassUpdate).TotalSeconds>(24.0*60.0*60.0))
                {
                    LastClassUpdate = DateTime.Today;
                    string s = sEmitResponse;
                    string[] parts = s.Split(new string[] { "BTC_" }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> Names = new List<string>();
                    foreach (string t in parts)
                    {
                        Names.Add(t.Substring(0, t.IndexOf("\"")));
                    }
                    string outs = "using CryptoPriceCore; namespace poloniex { public class poloniexMarket\n{\n";
                    foreach (string t in Names)
                    {
                        if (t != "{")
                            outs += "public PoloniexPair BTC_" + t + " { get; set; }\n";
                    }
                    outs += @"public static poloniexMarket CreateFromString(string msg)
        {
            return CryptoPriceCore.json.JsonDeserialize<poloniexMarket>(msg);
        }
} 
}";

                    //update classes


                    tmpRes =
                tmp.CompileAssemblyFromSource(
                    new System.CodeDom.Compiler.CompilerParameters() { GenerateInMemory = true, GenerateExecutable = false, ReferencedAssemblies = { "CryptoPriceCore.dll" } }, outs);
                }
                //Currencies = json.JsonDeserialize<poloniexMarket>(sEmitResponse.Replace("return", "returns"));
                Type[] tps = tmpRes.CompiledAssembly.GetTypes();
                Type x = tmpRes.CompiledAssembly.GetType("poloniex.poloniexMarket", true);
                Currencies = x.GetMethod("CreateFromString").Invoke(null, new object[] { sEmitResponse.Replace("return", "returns") });

            }
            catch { }
            PolDone = true;
            TriggerEvent();
        }
        private void btvAvg(IAsyncResult Result)
        {
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)Result.AsyncState;
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(Result);

                string sEmitResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                btcPrice btc = json.JsonDeserialize<btcPrice>(sEmitResponse);
                this.mbtc = (btc.last);
                
            }
            catch
            { }
            btcafgdone = true;
            TriggerEvent();
        }
        private void Yahoo(IAsyncResult Result)
        {
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)Result.AsyncState;
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.EndGetResponse(Result);

                string sEmitResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                sEmitResponse = sEmitResponse.Replace("N/A", "0");
                //dumperror("yahoo" + sEmitResponse);
                List<YahooPairRaw> tmp = json.JsonDeserialize<YahooRequest>(sEmitResponse).query.results.rate;
                //Fiat = JsonDeserialize<YahooRequest>(sEmitResponse).query.results.rate;
                foreach (YahooPairRaw t in tmp)
                {
                    bool found = false;
                    if (t.id.ToLower().Contains("zar"))
                    {

                    }
                    for (int i = 0; i < Fiat.Count; i++)
                    {
                        if (t.id == Fiat[i].id)
                        {
                            double ask = 0;
                            double bid = 0;
                            double.TryParse(t.Ask, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out ask);
                            double.TryParse(t.Bid, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out bid);

                            Fiat[i] = new YahooPair() { Ask=ask, Bid=bid, id=t.id,Rate=t.Rate };
                            found = true;
                    
                            break;
                        }

                    }
                    if (!found)
                    {

                        double ask = 0;
                        double bid = 0;
                        double.TryParse(t.Ask, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out ask);
                        double.TryParse(t.Bid, System.Globalization.NumberStyles.Any,System.Globalization.NumberFormatInfo.InvariantInfo, out bid);
                        Fiat.Add(new YahooPair() { Ask =ask, Bid = bid, id = t.id, Rate = t.Rate });
                    }
                }
            }
            catch (WebException e)
            {
                
            }
            catch (Exception e)
            {

            }
            yahooDone = true;
            TriggerEvent();
        }

        public void getprices()
        {
            PolDone = false;
            yahooDone = false;
            btcafgdone = false;
            try
            {
                var tmprequest = (HttpWebRequest)HttpWebRequest.Create("https://poloniex.com/public?command=returnTicker");
                /*HttpWebResponse EmitResponse = (HttpWebResponse)*/tmprequest.BeginGetResponse(new AsyncCallback(Poloniex), tmprequest);
                
                

            }
            catch (Exception e)
            {
                //dumperror(e.Message);
            }
            try
            {
                var tmprequest = (HttpWebRequest)HttpWebRequest.Create("https://api.bitcoinaverage.com/ticker/global/USD/");
                
                /*HttpWebResponse EmitResponse = (HttpWebResponse)*/tmprequest.BeginGetResponse(new AsyncCallback(btvAvg), tmprequest);
                
            }
            catch (Exception e)
            {
                //dumperror(e.Message);
            }
            try
            {
                string tmpURL = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20yahoo.finance.xchange%20where%20pair%20in%20(\"USDAED\",\"USDAFN\",\"USDALL\",\"USDANG\",\"USDAOA\",\"USDARS\",\"USDAUD\",\"USDAWG\",\"USDAZN\",\"USDBAM\",\"USDBBD\",\"USDBDT\",\"USDBGN\",\"USDBHD\",\"USDBIF\",\"USDBMD\",\"USDBND\",\"USDBOB\",\"USDBRL\",\"USDBSD\",\"USDBTN\",\"USDBWP\",\"USDBYR\",\"USDBZD\",\"USDCAD\",\"USDCDF\",\"USDCHF\",\"USDCLF\",\"USDCLP\",\"USDCNY\",\"USDCOP\",\"USDCRC\",\"USDCUP\",\"USDCVE\",\"USDCYP\",\"USDCZK\",\"USDDJF\",\"USDDKK\",\"USDDOP\",\"USDDZD\",\"USDEGP\",\"USDERN\",\"USDETB\",\"USDEUR\",\"USDFJD\",\"USDFKP\",\"USDGBP\",\"USDGEL\",\"USDGHS\",\"USDGIP\",\"USDGMD\",\"USDGNF\",\"USDGTQ\",\"USDGYD\",\"USDHKD\",\"USDHNL\",\"USDHRK\",\"USDHTG\",\"USDHUF\",\"USDIDR\",\"USDILS\",\"USDINR\",\"USDIQD\",\"USDIRR\",\"USDISK\",\"USDJMD\",\"USDJOD\",\"USDJPY\",\"USDKES\",\"USDKGS\",\"USDKHR\",\"USDKMF\",\"USDKPW\",\"USDKRW\",\"USDKWD\",\"USDKYD\",\"USDKZT\",\"USDLAK\",\"USDLBP\",\"USDLKR\",\"USDLRD\",\"USDLSL\",\"USDLTL\",\"USDLVL\",\"USDLYD\",\"USDMAD\",\"USDMDL\",\"USDMGA\",\"USDMKD\",\"USDMMK\",\"USDMNT\",\"USDMOP\",\"USDMRO\",\"USDMUR\",\"USDMVR\",\"USDMWK\",\"USDMXN\",\"USDMXV\",\"USDMYR\",\"USDMZN\",\"USDNAD\",\"USDNGN\",\"USDNIO\",\"USDNOK\",\"USDNPR\",\"USDNZD\",\"USDOMR\",\"USDPAB\",\"USDPEN\",\"USDPGK\",\"USDPHP\",\"USDPKR\",\"USDPLN\",\"USDPYG\",\"USDQAR\",\"USDRON\",\"USDRSD\",\"USDRUB\",\"USDRWF\",\"USDSAR\",\"USDSBD\",\"USDSCR\",\"USDSDG\",\"USDSEK\",\"USDSGD\",\"USDSHP\",\"USDSLL\",\"USDSOS\",\"USDSRD\",\"USDSTD\",\"USDSYP\",\"USDSZL\",\"USDTHB\",\"USDTJS\",\"USDTND\",\"USDTOP\",\"USDTRY\",\"USDTTD\",\"USDTWD\",\"USDTZS\",\"USDUAH\",\"USDUGX\",\"USDUSD\",\"USDUYU\",\"USDUZS\",\"USDVND\",\"USDVUV\",\"USDWST\",\"USDXAF\",\"USDXAG\",\"USDXAU\",\"USDXCD\",\"USDXDR\",\"USDXOF\",\"USDXPD\",\"USDXPF\",\"USDXPT\",\"USDYER\",\"USDZAR\",\"USDZMK\")&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";
                var tmprequest = (HttpWebRequest)HttpWebRequest.Create(tmpURL);
                /*HttpWebResponse EmitResponse = (HttpWebResponse)*/tmprequest.BeginGetResponse(new AsyncCallback(Yahoo), tmprequest);
               
            }
            catch (Exception e)
            {
                //dumperror("yahoo" + e.Message);
            }

        }

        public string GetCurrency(string Currency)
        {
            try
            {
                PoloniexPair tmp = (PoloniexPair)Currencies.GetType().GetProperty("BTC_" + Currency.ToUpper()).GetValue(Currencies, null);
                if (tmp != null)
                {
                    return string.Format("Current {0}/Btc at Poloniex: Highest Bid: {1} Btc, Lowest Ask: {2} Btc.", Currency, tmp.highestBid, tmp.lowestAsk);
                }
            }
            catch (Exception e)
            {
                //dumperror(e.Message);

            }
            return "-1";
        }

        double getCurrencyValue(string Currency)
        {
            try
            {
                PoloniexPair tmp = (PoloniexPair)Currencies.GetType().GetProperty("BTC_" + Currency.ToUpper()).GetValue(Currencies, null);
                if (tmp != null)
                {
                    return double.Parse(tmp.last);
                }
            }
            catch
            {
                if (Currency.ToLower() == "btc")
                    return 1.0;
                if (Currency.ToLower() == "usd")
                {
                    return 1.0 / (double)mbtc;
                }
                foreach (YahooPair yp in Fiat)
                {
                    if (yp.id.Substring(3).ToLower() == Currency.ToLower())
                    {
                        return (1.0 / yp.Rate) / (double)mbtc;
                    }
                }
            }
            return -1;
        }

        YahooPair getCurrencyFullValue(string Currency)
        {
            try
            {
                PoloniexPair tmp = (PoloniexPair)Currencies.GetType().GetProperty("BTC_" + Currency.ToUpper()).GetValue(Currencies, null);
                if (tmp != null)
                {
                    return new YahooPair() { Ask=double.Parse(tmp.lowestAsk, System.Globalization.NumberFormatInfo.InvariantInfo), Bid= double.Parse(tmp.highestBid, System.Globalization.NumberFormatInfo.InvariantInfo), id=Currency, Rate = double.Parse(tmp.last, System.Globalization.NumberFormatInfo.InvariantInfo) };
                }
            }
            catch
            {
                if (Currency.ToLower() == "btc")
                    return new YahooPair() { Ask =1, Bid = 1, id = Currency, Rate = 1 };
                if (Currency.ToLower() == "usd")
                {
                    return new YahooPair() { Ask = 1.0 / (double)mbtc, Bid = 1.0 / (double)mbtc, id = Currency, Rate = 1.0 / (double)mbtc };//1.0 / (double)mbtc;
                }
                foreach (YahooPair yp in Fiat)
                {
                    if (yp.id.Substring(3).ToLower() == Currency.ToLower())
                    {
                        return new YahooPair() { Ask = (1.0 / yp.Ask) / (double)mbtc, Bid = (1.0 / yp.Bid) / (double)mbtc, id = Currency, Rate=(1.0 / yp.Rate) / (double)mbtc };//(1.0 / yp.Rate) / (double)mbtc;
                    }
                }
            }
            return null;
        }

        public string[] GetString()
        {
            List<string> AllCurrencies = new List<string>();
            
            foreach (YahooPair tmp in Fiat)
            {
                AllCurrencies.Add(tmp.id.Substring(3).ToLower());
            }
            PropertyInfo[] alts = Currencies.GetType().GetProperties();
            foreach (PropertyInfo x in alts)
            {
                AllCurrencies.Add(x.Name.Substring(4));
            }
            return AllCurrencies.ToArray();
        }

        public YahooPair GetFullDetails(string From, string To, double iamount)
        {
            YahooPair tmpPair = new YahooPair(); 

            YahooPair from = getCurrencyFullValue(From);
            YahooPair to = getCurrencyFullValue(To);
            if (from!=null&&to!=null)
            {
                tmpPair.Rate = (from.Rate / to.Rate)*iamount;
                tmpPair.Bid = (from.Bid / to.Bid)*iamount;
                tmpPair.Ask = (from.Ask / to.Ask)*iamount;
                tmpPair.id = (From + "-" + To);
            }
            return tmpPair;
        }

        public string Convert(string from, string to, double iamount)
        {

            double From = getCurrencyValue(from);
            double To = getCurrencyValue(to);
            if (From == -1 || To == -1)
            {
                return "Invalid Currency";
            }
            else
            {
                return string.Format("{0:0.########} {1} = {2:0.########} {3}", iamount, from, (From / To) * iamount, to);
            }
        }

        

    }
}
