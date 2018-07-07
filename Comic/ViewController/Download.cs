using Comic.Common;
using Comic.Config;
using Comic.Data.DAO;
using Comic.Data.Entity;
using Comic.Data.Impl;
using KomikCrawler.src.Comic;
using KomikCrawler.src.ComicMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormTest.Common;
using WinFormTest.Config;
using WinFormTest.Model.ControllerView;
using WinFormTest.ViewController;

namespace Comic.ViewController
{
    public partial class Download : Form
    {
        public Button ParentDownloadLog { set; get; }
        public Download()
        {
            InitializeComponent();

            SetSize();

            //展開log樹
            LoadTree();
        }


        /// <summary>
        /// 設定視窗大小
        /// </summary>
        private void SetSize()
        {
            int width = Screen.GetWorkingArea(this).Width - 120;
            int height = Screen.GetWorkingArea(this).Height - 50;


            this.panel1.Height = height;
            this.newDownLoadTreeView.Height = this.panel1.Height;

            //設定bookPanel大小
            this.bookPanel.Height = height;
            this.bookPanel.Width = width;

            //設定圖片panel大小
            this.bookListView.Height = this.bookPanel.Height;
            this.bookListView.Width = this.bookPanel.Width;
        }

        /// <summary>
        /// 展開log樹
        /// </summary>
        private void LoadTree()
        {

            //查詢檔案清單
            NewComicLogDAO comicLogDao = new NewComicLogDaoImpl();
            List<NewComicLogEntity> list = comicLogDao.FindList();

            DownLoadLogCV cv = new DownLoadLogCV();
            cv.InitTree(this.newDownLoadTreeView, comicLogDao.GetRootPath(), list);
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (DownloadFlag.DOWNLOAD_FLAG == DownloadEnum.ING)
            {
                return;
            }


            ParentDownloadLog.Visible = true;
            ParentDownloadLog.Text = "下載中...";

            Thread myThread = new Thread(DownloadComicBook);
            myThread.Start();

            DownloadFlag.DOWNLOAD_FLAG = DownloadEnum.ING;
        }


        private void treeView_Click(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;

            string path = node.FullPath;

            this.bookListView.Items.Clear();

            int i = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {               
                    string newComicNoPath = sr.ReadLine();//取得下載的清單

                    this.bookListView.Items.Add(newComicNoPath);


                    ListViewItem item = this.bookListView.Items[i];
                    item.SubItems.Add(newComicNoPath);
                    item.SubItems.Add(path);
                    item.ImageIndex = i;//圖片
                    i++;
                }

            }

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.bookListView.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem item = this.bookListView.SelectedItems[0];


            string path = FileUtil.GerUrlDelLast(item.Text);

            string imageFile = FileUtil.GetFiles(path)[0];

            int startIdx = path.LastIndexOf('/');
            int endIdx = path.Length - startIdx;
            string lastFolder = path.Substring(startIdx, endIdx).Replace("/", "");
            string inPath = path.Substring(0, startIdx);


            ImageShow customForm = new ImageShow(inPath, lastFolder, imageFile);
            customForm.ShowDialog();

        }

        /// <summary>
        /// 重新整理樹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeReLoad_Click(object sender, EventArgs e)
        {
            //展開log樹
            LoadTree();
        }

        /// <summary>
        /// 下載漫畫
        /// </summary>
        private void DownloadComicBook()
        {
            ComicAction comicAction = new ComicAction(SysConfig.COMIC_SET_BOOK_URL);
            comicAction.Message = new DownloadLogMessage(ParentDownloadLog);
            comicAction.Action();

            ControlThreadActionHelper threadAction = new ControlThreadActionHelper();

            //portal的下載鍵
            threadAction.Handler(ParentDownloadLog, downloadLog =>
            {
                downloadLog.Text = "下載完成...";
            });

            DownloadFlag.DOWNLOAD_FLAG = DownloadEnum.NONE;
        }
    }

    public class DownloadLogMessage : IMessage
    {
        Button ParentDownloadLog = null;
        public DownloadLogMessage(Button ParentDownloadLog)
        {
            this.ParentDownloadLog = ParentDownloadLog;
        }
        public void ShowMessage(string message)
        {
            ControlThreadActionHelper threadAction = new ControlThreadActionHelper();

            //portal的下載鍵
            threadAction.Handler(ParentDownloadLog, downloadLog =>
            {
                downloadLog.Text = message.Replace(@"\n", "");
            });
        }
    }
}
