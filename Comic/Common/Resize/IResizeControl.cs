using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTest.Common.Resize
{
    public interface IResizeControl
    {
        /// <summary>
        /// 取得要變更的元件
        /// </summary>
        /// <returns></returns>
        ResizeControlRecord ResizeControl();
    }
}
