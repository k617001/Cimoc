using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormTest.Common;
using WinFormTest.ViewController;
using System.Windows.Forms;
using Comic.ViewController;

namespace WinFormTest.Register.MenuItem
{
    public class MenuItemReg
    {
        
        /// <summary>
        /// 註冊功能
        /// </summary>
        public static void Register()
        {
            
            ItemMap itemMap = new ItemMap();
            itemMap
                .RegisterItem<TestItem1>("Item1", "測試")
                .RegisterItem<ImageFolder>("ImageItem", "看圖片")
                .RegisterItem<Download>("DownloadBtn", "下載頁")
                .RegisterItem<ImageFolder>("WatchComicBtn", "看漫畫")


                .RegisterItem<Setting>("SettingBtn", "設定")
                ;
        }

        /// <summary>
        /// 取得功能
        /// </summary>
        /// <param name="name"></param>
        public static T GetNewItem<T>(string name)
        {
            return ItemMap.GetNewItem<T>(name);
        }
    }
}
