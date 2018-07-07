using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlerCommon.Common
{
    public class CommonStrUtil
    {
        public static void StrToFile(string content, string path)
        {    

            // Write the text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.Write(content);
            }
        }


        /// <summary>
        /// 下載檔案
        /// </summary>
        /// <param name="fileTargetUrl"></param>
        /// <param name="ms"></param>
        public static void MemoryStreamToFile(string fileTargetUrl, MemoryStream ms)
        {
            using (FileStream fileStream = new FileStream(fileTargetUrl, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(fileStream);
            }
        }


        /// <summary>
        /// 取得前後中間的字串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string GetStr(string input, string start, string end)
        {
            string inputTmp = input.Replace("\r\n", "");
            string pattern = @"" + start + ".*?" + end + "";
            Match match = Regex.Match(inputTmp, pattern, RegexOptions.IgnoreCase);

            string noStart = Regex.Replace(match.Value, start, "");
            string noEnd = Regex.Replace(noStart, end, "");


            return noEnd;
        }


        /// <summary>
        /// 取得前後中間的字串
        /// </summary>
        /// <param name="input"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string[] GetStrAry(string input, string start, string end)
        {
            string inputTmp = input.Replace("\r\n", "");
            string pattern = @"" + start + ".*?" + end + "";
            return Regex
                    .Matches(inputTmp, pattern, RegexOptions.IgnoreCase)
                    .Cast<Match>()
                    .Select(s => {
                        string noStart = Regex.Replace(s.Value, start, "");
                        string noEnd = Regex.Replace(noStart, end, "");
                        return noEnd;
                        })
                    .ToArray();

        }



        /// <summary>
        /// 下載檔案
        /// </summary>
        /// <param name="resultUrl"></param>
        /// <param name="targetFile"></param>
        /// <param name="isShowPercent"></param>
        public static void DownloadFile(string resultUrl, string targetFile, bool isShowPercent = true)
        {
            WebClient client = new WebClient();

            var reset = new ManualResetEvent(false);

            int beforePercent = 0;
            client.DownloadProgressChanged += (s, e) => {
                if (!isShowPercent)
                {
                    return;
                }
                int percentVal = 10;
                int percent = (int)e.ProgressPercentage;

                if (percent >= percentVal
                    && percent % 10 == 0
                    && percent > beforePercent
                )
                {
                    Console.Write(percent + "%,");
                    beforePercent = percent;
                }
            };
            client.DownloadFileCompleted += (s, e) => reset.Set();
            Console.WriteLine("----Start");
            client.DownloadFileAsync(new Uri(resultUrl), targetFile);

            reset.WaitOne();
        }

        /// <summary>
        /// 取得資料夾目錄清單
        /// </summary>
        /// <param name="localPath"></param>
        public static Dictionary<string, string> GetDircetoryList(string localPath)
        {
            string[] dirs = Directory.GetDirectories(localPath);
            List<string> dirList = new List<string>();

            foreach (string item in dirs)
            {
                dirList.Add(Path.GetFileNameWithoutExtension(item));//走訪每個元素只取得目錄名稱(不含路徑)並加入dirlist集合中
            }

            return dirList.ToDictionary(k => k);
        }

        /// <summary>
        /// 依路徑取得檔名
        /// </summary>
        /// <param name="path"></param>
        public static string GetFileName(string path)
        {
            Uri uri = new Uri(path);
            if (!uri.IsFile)
            {
                return null;
            }
            return System.IO.Path.GetFileName(uri.LocalPath);
        }
        
    }
}
