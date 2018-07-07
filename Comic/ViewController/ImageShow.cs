using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormTest.Common;
using System.IO;

namespace WinFormTest.ViewController
{
    public partial class ImageShow : Form
    {
        string[] dirs;
        string[] images;

        string rootPath;
        string folderName;
        string imageFileName;

        #region "建構子"
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootPath">根目錄</param>
        /// <param name="folderName">目前的資料夾</param>
        /// <param name="imageFileName">圖片名稱</param>
        public ImageShow(string rootPath = null, string folderName = null, string imageFileName = null)
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(PictureBox1_MouseWheel);

            if (rootPath == null
                    || folderName == null
                    || imageFileName == null)
            {
                rootPath = @"G:\comic\一拳超人";
                folderName = @"第 099 話";
                imageFileName = @"001.jpg";
            }

            this.SetSize();

            ((Control)viewPicture).AllowDrop = true;

            this.rootPath = rootPath;
            this.folderName = folderName;
            this.imageFileName = imageFileName;

            //取得所有資料夾清單
            this.dirs = FileUtil.GetDirs(rootPath);

            string folderNoPath = rootPath + "/" + folderName;
            string imagePath = folderNoPath + "/" + imageFileName;

            //取得圖片清單
            this.images = FileUtil.GetFiles(folderNoPath);

            //設定圖片
            this.SetImage(this.viewPicture, imagePath);
        }

        private void SetSize()
        {
            int width = Screen.GetWorkingArea(this).Width;
            int height = Screen.GetWorkingArea(this).Height;
            this.Height = height - 100;

            //設定圖片panel大小
            this.imagePanel.Height = this.Height;
            this.imagePanel.Width = width - menuPanel.Width - 10;

            //menu的座標
            menuPanel.Left = width - menuPanel.Width;
        }

        #endregion

        /// <summary>
        /// 前一頁-按鍵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beforeBtn_Click(object sender, EventArgs e)
        {
            next(this.viewPicture, -1);
        }

        /// <summary>
        /// 下一頁-按鍵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void afterBtn_Click(object sender, EventArgs e)
        {
            next(this.viewPicture, 1);
        }

        //定時關閉元件
        //https://dotblogs.com.tw/puma/2009/02/06/7060

        /// <summary>
        /// 前一頁、下一頁-按鍵
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageShow_KeyUp(object sender, KeyEventArgs e)
        {
            int nextPage = 1;
            //上一頁
            if (e.KeyCode == Keys.Up
                || e.KeyCode == Keys.Left
                || e.KeyCode == Keys.PageUp)
            {
                nextPage = -1;
            }
            //下一頁
            else if (e.KeyCode == Keys.Down
                || e.KeyCode == Keys.Right
                || e.KeyCode == Keys.PageDown)
            {
                nextPage = 1;
            }

            next(this.viewPicture, nextPage);
        }

        private void ImageShow_MouseClick(object sender, MouseEventArgs e)
        {
            /*
            int nextPage = 1;
            //上一頁
            if (e.Button == MouseButtons.Right)
            {
                nextPage = -1;
            }
            //下一頁
            if (e.Button == MouseButtons.Left)
            {
                nextPage = 1;
            }

            next(this.viewPicture, nextPage);
            */
        }

        #region "拖曳相關event"

        private void PictureBox1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta != 0) {
                this.viewPicture.Top = this.viewPicture.Location.Y + e.Delta;
            }
        }

        private MouseEventArgs _pos = null;
        void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _pos = e;//按下時記錄位置
            }
        }

        /// <summary>
        /// 滑鼠拖曳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (ctrl.Capture && e.Button == MouseButtons.Left)
            {
                //超過panel時才可以移動
                if (ctrl.Height > this.imagePanel.Height)
                {
                    ctrl.Top = e.Y + ctrl.Location.Y - _pos.Y;
                }
                if (ctrl.Width > this.imagePanel.Width)
                {
                    ctrl.Left = e.X + ctrl.Location.X - _pos.X;
                }
            }
        }

        /// <summary>
        /// //存放被拖曳的控制項
        /// </summary>
        Control _ctrl = null;//存放被拖曳的控制項
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            //取出被拖曳的控制項
            _ctrl = e.Data.GetData(e.Data.GetFormats(true)[0]) as Control;
            if (_ctrl != null)
                e.Effect = (_ctrl == null) ? DragDropEffects.None : DragDropEffects.Move;
        }

        /// <summary>
        /// 決定完成拖曳時，控制項應出現的座標
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (_ctrl != null)
            {
                Point point = this.imagePanel.PointToClient(new Point(e.X, e.Y));
                _ctrl.Top = point.Y;
                _ctrl.Left = point.X;
            }
        }
        #endregion

        #region "controler 使用方法"
        /// <summary>
        /// 下一張圖片
        /// </summary>
        /// <param name="nextIdx">+1或-1</param>
        private void next(PictureBox picObj, int nextIdx)
        {
            //取得目前圖片的idx
            int imageNowIdx = Array.FindIndex(this.images, item => item.Equals(this.imageFileName)) + nextIdx;
            bool isNext = true;
            //最後一張圖
            if (nextIdx > 0 && imageNowIdx == this.images.Length)
            {
                isNext = NextFolder(nextIdx); 
                imageNowIdx = 0;
            }
            //第一張圖
            else if (nextIdx < 0 && imageNowIdx < 0)
            {
                isNext = NextFolder(nextIdx);
                imageNowIdx = this.images.Length-1;
            }

            //判斷是否要顯示下一張
            if (!isNext)
            {
                return;
            }

            //顯示圖片
            this.imageFileName = this.images[imageNowIdx];
            string imageUrl = this.rootPath + "/" + this.folderName + "/" + this.imageFileName;
            SetImage(picObj, imageUrl);
        }

        /// <summary>
        /// 下一個資料夾
        /// </summary>
        /// <param name="nextIdx"></param>
        private bool NextFolder(int nextIdx)
        {                
            //取得上一層資料夾的idx
            int folderIdx = Array.FindIndex(this.dirs, item => item.Equals(this.folderName)) + nextIdx;

            if (folderIdx < 0 || folderIdx >= this.dirs.Length)
            {
                return false;
            }

            this.folderName = this.dirs[folderIdx];
            this.images = FileUtil.GetFiles(this.rootPath + "/" + this.folderName);

            return true;
        }

        /// <summary>
        /// 設定圖片
        /// </summary>
        private void SetImage(PictureBox picObj, string imageUrl)
        {
            this.Text = imageUrl;

            // 實例化 FileStream
            using (FileStream fs = new FileStream(imageUrl, FileMode.Open))
            {
                Byte[] data = new Byte[fs.Length];
                // 把檔案讀取到位元組陣列
                fs.Read(data, 0, data.Length);
                fs.Close();
                // 實例化一個記憶體資料流 MemoryStream，將位元組陣列放入
                using (MemoryStream ms = new MemoryStream(data))
                {
                    // 將記憶體資料流的資料顯示於 PictureBox 中
                    picObj.Image = Image.FromStream(ms);
                }



                //圖片物件和圖片一樣大
                viewPicture.Height = picObj.Image.Height;
                viewPicture.Width = picObj.Image.Width;


                //換頁時設成原始座標
                viewPicture.Left = this.imagePanel.Width / 4;
                if (viewPicture.Width > this.imagePanel.Width)
                {
                    viewPicture.Left = 10;
                }
                else if (viewPicture.Width > (this.imagePanel.Width - viewPicture.Left))
                {
                    viewPicture.Left = 10;
                }


                viewPicture.Top = 0;
            }
        }

        #endregion

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
