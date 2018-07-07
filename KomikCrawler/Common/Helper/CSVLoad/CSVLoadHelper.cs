using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CrawlerCommon.Helper.CSVLoad
{
    public class CSVLoadHelper
    {

        /// <summary>
        /// 讀取csv主要方法
        /// </summary>
        /// <param name="loadAction"></param>
        public static void LoadCsv(string filePath, Action<int, CSVLoadConvert> loadAction)
        {
            CSVLoadConvert csvLoadConvert = new CSVLoadConvert();

            using (StreamReader SR = new StreamReader(filePath, System.Text.Encoding.Default))
            {
                int row = 0;
                string line;
                while ((line = SR.ReadLine()) != null)
                {
                    string[] dataAry = line.Split(',');
                    //設定title
                    if (row++ == 0)
                    {
                        csvLoadConvert.SetTitle(dataAry);
                        continue;
                    }

                    if (dataAry.Length != csvLoadConvert.TitleIdxMapData.Keys.Count)
                    {
                        continue;
                    }

                    csvLoadConvert.SetData(dataAry);
                    //由外部自行定義
                    loadAction(row, csvLoadConvert);
                }
            }
        }

        
    }
}
