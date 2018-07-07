using CrawlerConsole1.ValueObject;
using KomikCrawler.src.ComicMessage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomikCrawler.src.Comic
{
    public class ComicAction
    {

        string comicSetPath = null;
        public ComicAction(string comicSetPath)
        {
            this.comicSetPath = comicSetPath;
        }
        public IMessage Message { set; get; }

        string rootPath = @"http://www.cartoonmad.com/";

        public void Action()
        {
            ComicSetting setting = this.GetJsonSetting();
            setting.RootPath = rootPath;
            if(this.Message == null)
            {
                this.Message = new ConsoleMessage();
            }

            //設定要顯示的樣式
            setting.SetShowMessage(this.Message);

            new ComicDownload(setting).Action();
        }

        /// <summary>
        /// 取得json設定
        /// </summary>
        /// <returns></returns>
        private ComicSetting GetJsonSetting()
        {
            StringBuilder jsonStr = new StringBuilder();
            using (StreamReader reader = new StreamReader(comicSetPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    jsonStr.Append(line);
                }

            }

            
            return JsonConvert.DeserializeObject<ComicSetting>(jsonStr.ToString());
        }
    }
}
