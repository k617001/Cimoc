using CrawlerCommon.Helper.ConvertObject;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.CSVLoad
{
    /// <summary>
    /// csv資料轉型用
    /// </summary>
    public class CSVLoadConvert
    {
        string[] csvData = null;
        public Dictionary<string, int> TitleIdxMapData {set; get; }

        /// <summary>
        /// 設定title
        /// </summary>
        /// <param name="titleAry"></param>
        public void SetTitle(string[] titleAry)
        {
            this.TitleIdxMapData = SetTitleIndex(titleAry);
        }

        /// <summary>
        /// 設定資料
        /// </summary>
        /// <param name="arrayData"></param>
        public void SetData(string[] arrayData)
        {
            this.csvData = arrayData;
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <typeparam name="T">基本型別，不提供物件型別</typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Get<T>(string name)
        {
            return ConvertObjectHelper.To<T>(this.getData(name));
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <typeparam name="T">基本型別，不提供物件型別</typeparam>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DateTime GetDateTime(string columnName, string formatter)
        {
            string dateStr = this.Get<string>(columnName);
            return DateTime.ParseExact(dateStr, formatter, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <typeparam name="T">基本型別，不提供物件型別</typeparam>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DateTime GetDateTime(string columnName1, string columnName2, string formatter)
        {
            string dateStr1 = this.Get<string>(columnName1);
            string dateStr2 = this.Get<string>(columnName2);
            return DateTime.ParseExact(dateStr1 + dateStr2, formatter, CultureInfo.InvariantCulture);
        }



        /// <summary>
        /// 設定欄位對應index
        /// </summary>
        /// <param name="titles"></param>
        /// <returns></returns>
        private static Dictionary<string, int> SetTitleIndex(string[] titles)
        {
            Dictionary<string, int> csvTitleIdxMap = new Dictionary<string, int>();
            foreach (string title in titles)
            {
                string titleName = title
                                    .Trim()
                                    .ToUpper()
                                    .Replace("\"", "");
                csvTitleIdxMap.Add(titleName, csvTitleIdxMap.Count());
            }
            return csvTitleIdxMap;
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string getData(string name)
        {
            string nameKey = name.ToUpper();
            if (!this.TitleIdxMapData.ContainsKey(nameKey))
            {
                string titleNames = string.Join(", ", TitleIdxMapData.Keys.ToArray());
                throw new Exception("csv無此定義的title名稱 => " + nameKey + "(" + titleNames + ")");
            }

            int titleIdx = this.TitleIdxMapData[nameKey];
            return this.csvData[titleIdx];
        }
    }
}
