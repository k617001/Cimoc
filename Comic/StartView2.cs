using Comic.Common;
using Comic.ViewController;
using KomikCrawler.src.Comic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinFormTest.Config;
using WinFormTest.Register.MenuItem;

namespace WinFormTest
{
    public partial class StartView2 : Form
    {
        public StartView2()
        {
            InitializeComponent();
            
            //動態設定大小
            SetSize();

            //第一次設定的檢查及跳出設定頁
            InitSettingCheck();

            //預設開啟畫面
            this.OpenDownloadForm(this.DownloadBtn);
        }



        /// <summary>
        /// 開啟功能event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLoad_Event(object sender, EventArgs e)
        {
            this.OpenDownloadForm((Button)sender);
        }

        private void OpenDownloadForm(Button sender)
        {
            //產生form物件
            Download itemForm = MenuItemReg.GetNewItem<Download>(sender.Name);
            itemForm.ParentDownloadLog = downloadLog;//portal的下載log傳至download form
            this.OpenItemByForm(itemForm);

        }

        /// <summary>
        /// 開啟功能event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenItem_Event(object sender, EventArgs e)
        {
            //產生form物件
            OpenItem((Button)sender);
        }

        #region "私有方法"



        /// <summary>
        /// 初始設定檢查
        /// </summary>
        private void InitSettingCheck()
        {
            //檢查是否已存在Data的資料夾
            if (Directory.Exists(SysConfig.ROOT_DATA_PATH))
            {
                return;
            }

            //建立資料夾
            Directory.CreateDirectory(SysConfig.ROOT_DATA_PATH);

            //跳出設定頁dialog
            Form settingForm = MenuItemReg.GetNewItem<Form>("SettingBtn");
            settingForm.ShowDialog();

            settingForm.Dispose();
        }

        /// <summary>
        /// 動態調整子功能視窗
        /// </summary>
        private void SetSize()
        {
            int width = Screen.GetWorkingArea(this).Width - 30;
            int height = Screen.GetWorkingArea(this).Height;

            this.MenuPanel.Width = width;

            this.ContentPanel.Width = width;
            this.ContentPanel.Height = height - this.MenuPanel.Height - 50;

        }

        /// <summary>
        /// 開啟功能頁
        /// </summary>
        /// <param name="sender"></param>
        private void OpenItem(Button sender)
        {
            Form itemForm = MenuItemReg.GetNewItem<Form>(sender.Name);
            OpenItemByForm(itemForm);
        }


        /// <summary>
        /// 開啟功能頁
        /// </summary>
        /// <param name="sender"></param>
        private void OpenItemByForm(Form itemForm)
        {

            itemForm.Width = this.ContentPanel.Width;
            itemForm.Height = this.ContentPanel.Height;

            //關閉上層控制項
            itemForm.TopLevel = false;

            //設定功能至Panel
            this.ContentPanel.Controls.Clear();
            this.ContentPanel.Controls.Add(itemForm);

            //子功能樣式設定
            itemForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            itemForm.Dock = DockStyle.Fill;
            itemForm.Show();
        }

        #endregion
    }
}
