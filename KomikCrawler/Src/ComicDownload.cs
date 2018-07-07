using CrawlerCommon.Common;
using CrawlerConsole1.ValueObject;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KomikCrawler.src.Comic
{
    public class ComicDownload
    {
        ComicSetting setting = null;
        StringBuilder newLog = new StringBuilder();
        public ComicDownload(ComicSetting setting)
        {
            this.setting = setting;
        }

        public void Action()
        {
            foreach(ComicUrls comicUrl in setting.ComicList)
            {
                //是否要更新
                if(!comicUrl.isUpdate)
                {
                    continue;
                }

                this.DownloadComic(comicUrl);
            }

            //記錄log
            NewUpdateLog(newLog.ToString());
        }

        /// <summary>
        /// 下載漫畫
        /// </summary>
        /// <param name="comicUrl"></param>
        private void DownloadComic(ComicUrls comicUrl)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(new WebClient().DownloadString(comicUrl.Url));


            //取得關鍵層
            HtmlDocument contentHtml = new HtmlDocument();
            contentHtml.LoadHtml(doc.DocumentNode.SelectSingleNode(@"/html[1]/body[1]/table[1]/tr[1]/td[1]/td[1]/table[1]/tr[4]/td[1]/table[1]/tr[2]/td[2]/table[3]/tr[1]/td[1]").InnerHtml);

            //建立要存放的位置
            string titlePath = setting.LocalPath + Title(contentHtml) + "/";
            Directory.CreateDirectory(titlePath);
            setting.ShowMessage("下載中 =>" + titlePath);

            HtmlNode[] nodes = contentHtml.DocumentNode.SelectNodes("//a").ToArray();

            //產生圖片
            ComicImage comicImage = new ComicImage(setting);
            foreach (HtmlNode href in nodes)
            {
                //話數路徑
                string noName = href.InnerText;
                string noNamePath = titlePath + noName;
                
                //filter已產生的話數
                Dictionary<string, string> filterMap = CommonStrUtil.GetDircetoryList(titlePath);
                if (filterMap.ContainsKey(noName))
                {
                    continue;
                }

                newLog.Append(noNamePath + "\r\n");

                string url = href.GetAttributeValue("href", "");

                //取得話數
                Console.WriteLine("\n" + href.InnerText);
                Directory.CreateDirectory(noNamePath);

                comicImage.Action(noNamePath + "/", url);
            }
        }




        private string Title(HtmlDocument contentHtml)
        {
            return contentHtml.DocumentNode.Descendants().Where(w => w.Name.Equals("legend")).Single().InnerHtml
                .Replace("&nbsp;", "")
                .Replace("漫畫線上觀看", "")
                ;
        }

        /// <summary>
        /// 記錄目前有更新漫畫的Log
        /// </summary>
        /// <param name="conetnt"></param>
        private void NewUpdateLog(string conetnt)
        {
            if(string.IsNullOrEmpty(conetnt))
            {

                return;
            }

            string path = this.setting.LocalPath + "_Log/";
            string filaName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".log";
            Directory.CreateDirectory(path);

            using (StreamWriter file = new StreamWriter(path + filaName))
            {

                file.WriteLine(conetnt);
            }
        }
    }
}
