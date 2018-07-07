using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.CSVLoad
{
    public class Sample
    {
        string path = @"D:\marketData\PROG_TWF_1min_Part2_19980722_20150325.txt";

        public void Action()
        {
            List<MarketData> data = new List<MarketData>();
            CSVLoadHelper.LoadCsv(path, (row, convert) =>
            {
                string date = convert.Get<string>("date");
                string time = convert.Get<string>("time");
                string dt = date + " " + (time.Length > 5 ? time : time + ":00");

                if(row > 100000 && row % 100000 == 0) {
                    Console.WriteLine(row);
                }
                
                data.Add(new MarketData()
                {
                    Date = Convert.ToDateTime(dt),
                    Open = convert.Get<int>("Open"),
                    High = convert.Get<int>("High"),
                    Low = convert.Get<int>("Low"),
                    Close = convert.Get<int>("Close"),
                    Volume = convert.Get<int>("Volume"),
                });

            });

        }
    }

    class MarketData
    {
        public DateTime Date { set; get; }
        public int Open { set; get; }
        public int High { set; get; }
        public int Low { set; get; }
        public int Close { set; get; }
        public int Volume { set; get; }
    }
}
