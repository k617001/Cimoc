using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WinFormTest.Common;
using WinFormTest.Enums;
using WinFormTest.ExceptionHandle.CustomException;
using WinFormTest.Model.ControllerView;
using WinFormTest.Config;
using WinFormTest.Common.Resize;
using Comic.Data.DAO;
using Comic.Data.Impl;
using Comic.Data.Entity;

namespace WinFormTest.ViewController
{
    public partial class ImageFolder : Form
    {

        ViewImageCV cv = new ViewImageCV();

        public ImageFolder()
        {
            InitializeComponent();
            //查詢根目錄
            SettingDAO settingDAO = new SettingDaoImpl();
            SettingEntity settingEntity = settingDAO.Find();
            string rootPath = settingEntity.ComicUrl;

            //初始化檔案樹
            cv.InitTree(this.treeView, rootPath);

            this.treeView.ExpandAll();

            //動態設定大小
            SetSize();
        }

        private void SetSize()
        {
            int width = Screen.GetWorkingArea(this).Width - 120;
            int height = Screen.GetWorkingArea(this).Height - 50;


            this.panel2.Height = height;
            this.treeView.Height = this.panel2.Height;

            //設定圖片panel大小
            this.panel3.Height = height;
            this.panel3.Width = width;

            //設定圖片panel大小
            this.listView1.Height = this.panel3.Height;
            this.listView1.Width = this.panel3.Width;
        }

        private void treeView_Click(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;


            //設定image到imageList
            string path = node.FullPath;
            string[] imageFiles = FileUtil.GetFiles(path);

            this.listView1.Items.Clear();
            this.imageList.Images.Clear();

            int i = 0;
            foreach(string imageFile in imageFiles) {
                string filePath = path + "\\" + imageFile;
                //this.imageList.Images.Add(filePath, Image.FromFile(filePath));

                //文字資料
                this.listView1.Items.Add(imageFile);
                ListViewItem item = this.listView1.Items[i];
                item.SubItems.Add(filePath);
                item.SubItems.Add(path);

                //圖片
                item.ImageIndex = i;


                i++;
            }



            if (node.GetNodeCount(true) > 0)
            {
                return;
            }

            //展節點
            cv.SetDirTreeNode(node, path);
            this.treeView.ExpandAll();


        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem item = this.listView1.SelectedItems[0];

            string imageFile = item.Text;
            string path = item.SubItems[2].Text;

            int startIdx = path.LastIndexOf('\\') + 1;
            int endIdx = path.Length - (path.LastIndexOf('\\') + 1);
            string lastFolder = path.Substring(startIdx, endIdx);
            string inPath = path.Substring(0, startIdx);


            ImageShow customForm = new ImageShow(inPath, lastFolder, imageFile);
            customForm.ShowDialog();

        }
    }
}
