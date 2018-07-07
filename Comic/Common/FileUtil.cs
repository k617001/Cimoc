using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WinFormTest.Config;

namespace WinFormTest.Common
{
    public class FileUtil
    {
        public static string GerUrlDelLast(string path)
        {
            int lastIdx = path.LastIndexOf('/');

            if(lastIdx == path.Length-1)
            {
                path = path.Substring(0, lastIdx);
            }

            return path;
        }

        /// <summary>
        /// 取得資料夾
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetDirs(string path)
        {

            return Directory.GetDirectories(path)
                .Select(s => s.Substring(s.LastIndexOf("\\") + 1))
                .OrderBy(o => o)
                .ToArray();
        }

        /// <summary>
        /// 取得檔名
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetFiles(string path, string filter = null)
        {
            if (filter == null)
            {
                filter = SysConfig.FILTER_FILENAME_EXTENSION;
            }

            Func<string, bool> predicate = (x) => 1 == 1;

            if (!string.IsNullOrEmpty(filter))
            {
                predicate = (x) => x.Substring(x.LastIndexOf(".") + 1).Equals(filter);
            }

            return Directory.EnumerateFiles(path)
                .Select(s => s.Substring(s.LastIndexOf("\\") + 1))
                .Where(predicate)
                .OrderBy(o => o)
                .ToArray();
        }
    }
}
