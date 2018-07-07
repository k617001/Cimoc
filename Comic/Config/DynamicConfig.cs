using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormTest.Common.Resize;
using System.Windows.Forms;

namespace WinFormTest.Config
{
    /// <summary>
    /// 動態設定的config，會動態改變，並影響整個系統
    /// </summary>
    public class DynamicConfig
    {
        //form的size
        public static double FORM_WIDTH = 0;
        public static double FORM_HEIGHT = 0;

        //form 長寬的比例
        public static double FORM_WIDTH_PERCENT = 1;
        public static double FORM_HEIGHT_PERCENT = 1;

        //記錄目前會改變form的物件指標，
        //每次切功能時會重新assign，
        //若功能未實做IResizeControl，則給null
        //好處是不用每次去Panel重抓目前功能
        public static IResizeControl NOW_RESIZE_CONTROL = null;
    }
}
