using CrawlerCommon.Common;
using CrawlerConsole1.ValueObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KomikCrawler.src.Comic
{
    public class ComicImage
    {
        ComicSetting setting;
        public ComicImage(ComicSetting setting)
        {
            this.setting = setting;
        }

        public void Action(string fileTargetUrl, string url)
        {
            string path = setting.RootPath + url;
            string html = new WebClient().DownloadString(path);

            string[] options = GetOption(html);


            foreach (string optionValue in options)
            {

                string pp = @"/comic/" + optionValue;
                string pageHtml = new WebClient().DownloadString(setting.RootPath + pp);

                string imageUrl = this.GetImageUrl(pageHtml);
                
                if(string.IsNullOrEmpty(imageUrl))
                {
                    continue;
                }

                downloadImage(fileTargetUrl, imageUrl);
            }

            //this.Str2File(contentHtml.DocumentNode.InnerHtml);
        }

        private string GetImageUrl(string input)
        {
            string imageUrl = "http://web";
            string start = @"<a href="".*?""><img src=""" + imageUrl;
            string end = @""" border=""0"" oncontextmenu='return false' ";
            string result =  (imageUrl + CommonStrUtil.GetStr(input, start, end));
            if(imageUrl.Equals(result))
            {
                return string.Empty;
            }
            return result;
        }

        private string[] GetOption(string input)
        {
            string start = @" <select name=""jump"".*?</option>";
            string end = "</select>";
            string optionHtml = CommonStrUtil.GetStr(input, start, end);

            string opStart = @"<option value=""";
            string opEnd = @""">.*?</option>";
            return CommonStrUtil.GetStrAry(optionHtml, opStart, opEnd);
        }

        public void downloadImage(string fileTargetUrl, string imageUrl)
        {
            string fileName = Path.GetFileName(imageUrl);

            setting.ShowMessage(fileName + ",");

            WebClient client = new WebClient();
            try
            {
                using (MemoryStream ms = new MemoryStream(client.DownloadData(imageUrl)))
                {
                    CommonStrUtil.MemoryStreamToFile(fileTargetUrl + fileName, ms);
                }
            }
            catch(Exception)
            {
                //網站沒放圖時就不鳥他
            }
        }
    }
}
