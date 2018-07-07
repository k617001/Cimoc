using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormTest.Register.MenuItem;
using WinFormTest.Common.Resize;
using WinFormTest.Config;

namespace WinFormTest.Model.ControllerView
{
    public class StartViewCV
    {
        /// <summary>
        /// 切換功能方法
        /// </summary>
        /// <param name="targetPanel">目標Panel</param>
        /// <param name="itemName">功能名稱</param>
        public void ItemSwitch(Panel targetPanel, string itemName)
        {

            //設定RESize的物件
            DynamicConfig.NOW_RESIZE_CONTROL = null;
            object itemObj = MenuItemReg.GetNewItem<object>(itemName);
            if (itemObj is IResizeControl)
            {
                DynamicConfig.NOW_RESIZE_CONTROL = (IResizeControl)itemObj;
            }

            //產生form物件
            Form itemForm = MenuItemReg.GetNewItem<Form>(itemName);

            //檢查目前開啟的功能是否一樣，一樣則不重覆開啟
            /*
            if(1 == 0) {
                return;
            }
             * */

            //關閉上層控制項
            itemForm.TopLevel = false;

            //設定功能至Panel
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(itemForm);

            //子功能樣式設定
            itemForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            itemForm.Dock = DockStyle.Fill;
            itemForm.Show();

        }

        /// <summary>
        /// 變更Form的長寬，連動目前使用的功能
        /// </summary>
        public void Resize(Form thisForm, Panel targetPanel)
        {
            //計算目前的長寬的比例
            DynamicConfig.FORM_WIDTH_PERCENT = (thisForm.Width / DynamicConfig.FORM_WIDTH);
            DynamicConfig.FORM_HEIGHT_PERCENT = (thisForm.Height / DynamicConfig.FORM_HEIGHT);

            //記錄目前Form的size
            SetFormSize(thisForm);

            //變更Panel的大小
            targetPanel.Width = Convert.ToInt32(targetPanel.Width * DynamicConfig.FORM_WIDTH_PERCENT);
            targetPanel.Height = Convert.ToInt32(targetPanel.Height * DynamicConfig.FORM_HEIGHT_PERCENT);

            //重設長寬
            ResizeUtil.Resize(targetPanel.Controls[0]);

        }

        /// <summary>
        /// 記錄目前Form的size
        /// </summary>
        /// <param name="thisForm"></param>
        public void SetFormSize(Form thisForm)
        {

            //記錄目前的長寬至設定檔
            DynamicConfig.FORM_WIDTH = thisForm.Width;
            DynamicConfig.FORM_HEIGHT = thisForm.Height;
        }
    }
}
