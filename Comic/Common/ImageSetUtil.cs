using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Comic.Common;

namespace WinFormTest.Common
{
    public class ImageSetUtil
    {
        static string ROOT_PATH = CommonUtilss.GetRootPath();

        /// <summary>
        /// 檔案樹使用的圖片
        /// </summary>
        /// <returns></returns>
        public static ImageList FileTree()
        {
            ImageList imageList = new ImageList();

            imageList.Images.Add(Image.FromFile(ROOT_PATH + "/Images/directory.jpg"));
            imageList.Images.Add(Image.FromFile(ROOT_PATH + "/Images/directoryOpen.jpg"));
            imageList.Images.Add(Image.FromFile(ROOT_PATH + "/Images/page.jpg"));

            return imageList;
        }
    }
}
