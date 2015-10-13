using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeuntjieBot
{
    public class btcPrice
    {
        public decimal last { get; set; }
    }

    public class marketthingy
    {
        public returns returns { get; set; }
    }

    public class returns
    {
        public markets markets { get; set; }
    }

    public class markets
    {
        public BaseMarket BTC { get; set; }
        public BaseMarket DOGE { get; set; }
    }


    public class BaseMarket
    {
        public string marketid { get; set; }
        public string label { get; set; }
        public string lasttradeprice { get; set; }
    }

    public class poloniexMarket
    {
        public PoloniexPair BTC_ETH { get; set; }
        public PoloniexPair BTC_CLAM { get; set; }
        public PoloniexPair BTC_DOGE { get; set; }
        public PoloniexPair BTC_HUC { get; set; }
        public PoloniexPair BTC_XMR { get; set; }

        public PoloniexPair BTC_1CR { get; set; }
        public PoloniexPair BTC_ABY { get; set; }
        public PoloniexPair BTC_ACH { get; set; }

        public PoloniexPair BTC_ADN { get; set; }
        public PoloniexPair BTC_BALLS { get; set; }
        public PoloniexPair BTC_BBR { get; set; }

        public PoloniexPair BTC_BCN { get; set; }
        public PoloniexPair BTC_BELA { get; set; }
        public PoloniexPair BTC_BITS { get; set; }

        public PoloniexPair BTC_BLK { get; set; }
        public PoloniexPair BTC_BLOCK { get; set; }
        public PoloniexPair BTC_BTCD { get; set; }

        public PoloniexPair BTC_BTM { get; set; }
        public PoloniexPair BTC_BTS { get; set; }
        public PoloniexPair BTC_BURST { get; set; }

        public PoloniexPair BTC_C2 { get; set; }
        public PoloniexPair BTC_CCN { get; set; }
        public PoloniexPair BTC_CGA { get; set; }

        public PoloniexPair BTC_CHA { get; set; }
        public PoloniexPair BTC_CINNI { get; set; }
        public PoloniexPair BTC_CNMT { get; set; }

        public PoloniexPair BTC_CNOTE { get; set; }
        public PoloniexPair BTC_CURE { get; set; }
        public PoloniexPair BTC_CYC { get; set; }

        public PoloniexPair BTC_DGB { get; set; }
        public PoloniexPair BTC_DIEM { get; set; }
        public PoloniexPair BTC_DASH { get; set; }

        public PoloniexPair BTC_EMC2 { get; set; }
        public PoloniexPair BTC_EXE { get; set; }
        public PoloniexPair BTC_FIBRE { get; set; }

        public PoloniexPair BTC_FLDC { get; set; }
        public PoloniexPair BTC_FLO { get; set; }
        public PoloniexPair BTC_FLT { get; set; }

        public PoloniexPair BTC_FRAC { get; set; }
        public PoloniexPair BTC_GAP { get; set; }
        public PoloniexPair BTC_GDN { get; set; }

        public PoloniexPair BTC_GEMZ { get; set; }
        public PoloniexPair BTC_GEO { get; set; }
        public PoloniexPair BTC_GMC { get; set; }

        public PoloniexPair BTC_GML { get; set; }
        public PoloniexPair BTC_GOLD { get; set; }
        public PoloniexPair BTC_GRCX { get; set; }

        public PoloniexPair BTC_GRS { get; set; }
        public PoloniexPair BTC_HIRO { get; set; }
        public PoloniexPair BTC_HYP { get; set; }

        public PoloniexPair BTC_HZ { get; set; }
        public PoloniexPair BTC_JLH { get; set; }
        public PoloniexPair BTC_LQD { get; set; }

        public PoloniexPair BTC_LTBC { get; set; }
        public PoloniexPair BTC_LTC { get; set; }
        public PoloniexPair BTC_MAID { get; set; }

        public PoloniexPair BTC_MCN { get; set; }
        public PoloniexPair BTC_MIL { get; set; }
        public PoloniexPair BTC_MINT { get; set; }

        public PoloniexPair BTC_MMC { get; set; }
        public PoloniexPair BTC_MMNXT { get; set; }
        public PoloniexPair BTC_MMXIV { get; set; }


        public PoloniexPair BTC_MNS1 { get; set; }
        public PoloniexPair BTC_MRS { get; set; }
        public PoloniexPair BTC_MSC { get; set; }

        public PoloniexPair BTC_MYR { get; set; }
        public PoloniexPair BTC_NAUT { get; set; }
        public PoloniexPair BTC_NAV { get; set; }

        public PoloniexPair BTC_NBT { get; set; }
        public PoloniexPair BTC_NEOS { get; set; }
        public PoloniexPair BTC_NMC { get; set; }

        public PoloniexPair BTC_NOBL { get; set; }
        public PoloniexPair BTC_NOTE { get; set; }
        public PoloniexPair BTC_NOXT { get; set; }

        public PoloniexPair BTC_NRS { get; set; }
        public PoloniexPair BTC_NSR { get; set; }
        public PoloniexPair BTC_NXT { get; set; }

        public PoloniexPair BTC_NXTI { get; set; }
        public PoloniexPair BTC_OPAL { get; set; }
        public PoloniexPair BTC_PIGGY { get; set; }

        public PoloniexPair BTC_PINK { get; set; }
        public PoloniexPair BTC_POT { get; set; }
        public PoloniexPair BTC_PPC { get; set; }

        public PoloniexPair BTC_PRC { get; set; }
        public PoloniexPair BTC_PTS { get; set; }
        public PoloniexPair BTC_QBK { get; set; }

        public PoloniexPair BTC_QORA { get; set; }
        public PoloniexPair BTC_QTL { get; set; }
        public PoloniexPair BTC_RBY { get; set; }

        public PoloniexPair BTC_RDD { get; set; }
        public PoloniexPair BTC_RIC { get; set; }
        public PoloniexPair BTC_SDC { get; set; }


        public PoloniexPair BTC_SILK { get; set; }
        public PoloniexPair BTC_SJCX { get; set; }
        public PoloniexPair BTC_SQL { get; set; }

        public PoloniexPair BTC_SRCC { get; set; }
        public PoloniexPair BTC_SSD { get; set; }
        public PoloniexPair BTC_STR { get; set; }

        public PoloniexPair BTC_SWARM { get; set; }
        public PoloniexPair BTC_SYNC { get; set; }
        public PoloniexPair BTC_SYS { get; set; }

        public PoloniexPair BTC_TAC { get; set; }
        public PoloniexPair BTC_UIS { get; set; }
        public PoloniexPair BTC_ULTC { get; set; }

        public PoloniexPair BTC_UNITY { get; set; }
        public PoloniexPair BTC_URO { get; set; }
        public PoloniexPair BTC_VIA { get; set; }

        public PoloniexPair BTC_VNL { get; set; }
        public PoloniexPair BTC_VRC { get; set; }
        public PoloniexPair BTC_VTC { get; set; }

        public PoloniexPair BTC_WDC { get; set; }
        public PoloniexPair BTC_WOLF { get; set; }
        public PoloniexPair BTC_XAI { get; set; }

        public PoloniexPair BTC_XAP { get; set; }
        public PoloniexPair BTC_XBC { get; set; }
        public PoloniexPair BTC_XC { get; set; }

        public PoloniexPair BTC_XCH { get; set; }
        public PoloniexPair BTC_XCN { get; set; }
        public PoloniexPair BTC_XCP { get; set; }

        public PoloniexPair BTC_XCR { get; set; }
        public PoloniexPair BTC_XDN { get; set; }
        public PoloniexPair BTC_XDP { get; set; }


        public PoloniexPair BTC_XMG { get; set; }

        public PoloniexPair BTC_XPB { get; set; }
        public PoloniexPair BTC_XPM { get; set; }
        public PoloniexPair BTC_XRP { get; set; }

        public PoloniexPair BTC_XST { get; set; }
        public PoloniexPair BTC_XUSD { get; set; }
        public PoloniexPair BTC_YACC { get; set; }
    }

    public class PoloniexPair
    {
        public string last { get; set; }
        public string lowestAsk { get; set; }
        public string highestBid { get; set; }
        public string percentChange { get; set; }
        public string baseVolume { get; set; }
        public string quoteVolume { get; set; }
        public string isFrozen { get; set; }
        public string high24hr { get; set; }
        public string low24hr { get; set; }

    }
    public class YahooRequest
    {
        public YahooRequest query { get; set; }
        public YahooMarket results { get; set; }
    }
    public class YahooMarket
    {
        public List<YahooPair> rate = new List<YahooPair>();
    }
    public class YahooPair
    {
        public string id { get; set; }
        public double Rate { get; set; }
    }
}
