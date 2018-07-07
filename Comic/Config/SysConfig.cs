using Comic.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormTest.Config
{
    /// <summary>
    /// 系統的config，寫死的資料
    /// </summary>
    public class SysConfig
    {
        /// <summary>
        /// 存放資料的資料夾，初始頁檢查沒有時，則會跑設定畫面
        /// </summary>
        public static readonly string ROOT_DATA_PATH = CommonUtilss.GetRootPath(@"\Data") + @"\";

        //public static readonly string ROOT_PATH = @"G:\comic";

        /// <summary>
        /// 副檔名filter
        /// </summary>
        public static readonly string FILTER_FILENAME_EXTENSION = @"jpg";
        public static readonly string FILTER_FILENAME_EXTENSION_LOG = @"log";


        public static readonly string COMIC_SET_BOOK_URL = ROOT_DATA_PATH + "Comic.json";
    }
}
