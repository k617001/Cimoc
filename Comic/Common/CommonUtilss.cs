using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comic.Common
{
    public class CommonUtilss
    {
        /// <summary>
        /// 取得根目錄路徑
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath(string appendUrl = "")
        {
            return System.Windows.Forms.Application.StartupPath + appendUrl;
        }
    }
}
