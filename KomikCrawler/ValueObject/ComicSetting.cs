using KomikCrawler.src.ComicMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerConsole1.ValueObject
{
    public class ComicSetting
    {
        public string RootPath { set; get; }
        public string LocalPath { set; get; }
        public string LogPath { set; get; }

        public List<ComicUrls> ComicList { set; get; }

        IMessage imessage = null;
        public void SetShowMessage(IMessage imessage)
        {
            this.imessage = imessage;
        }

        /// <summary>
        /// 自訂的顯示訊息
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            this.imessage.ShowMessage(message);
        }
    }
}
