using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormTest.Config;

namespace WinFormTest.Common.Resize
{
    public class ResizeUtil
    {
        public static void Resize(Control nowControl)
        {
            //取得要改變大小的物件
            if (DynamicConfig.NOW_RESIZE_CONTROL == null)
            {
                return;
            }
            ResizeControlRecord resizeData = DynamicConfig.NOW_RESIZE_CONTROL.ResizeControl();

            //重新設定長、寬
            ResizeUtil.SetSize(nowControl, resizeData.AllControls, c =>
            {
                
                c.Width = Convert.ToInt32(DynamicConfig.FORM_WIDTH_PERCENT * c.Width);
                c.Height = Convert.ToInt32(DynamicConfig.FORM_HEIGHT_PERCENT * c.Height);


            });

            //重新設定寬
            ResizeUtil.SetSize(nowControl, resizeData.WidthControls, c =>
            {
                c.Width = Convert.ToInt32(DynamicConfig.FORM_WIDTH_PERCENT * c.Width);
            });

            //重新設定長
            ResizeUtil.SetSize(nowControl, resizeData.HeightControls, c =>
            {
                c.Height = Convert.ToInt32(DynamicConfig.FORM_HEIGHT * c.Height);
            });
        }

        private static void SetSize(Control nowControl, Control[] controls, Action<Control> setSize)
        {
            if (controls == null)
            {
                return;
            }
            foreach (Control control in controls)
            {
                Control c = (nowControl.Controls.Find(control.Name, true))[0];
                setSize(c);
            }
        }
    }
}
