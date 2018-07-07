using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormTest.ViewController;
using WinFormTest.Common;
using System.Windows.Forms;
using WinFormTest.Enums;

namespace WinFormTest.Model.ControllerView
{
    public class ViewImageCV
    {

        /// <summary>
        /// 初始樹
        /// </summary>
        /// <param name="path"></param>
        public void InitTree(TreeView treeView, string rootPath)
        {
            //設定圖示
            treeView.ImageList = ImageSetUtil.FileTree();

            //根節點
            TreeNode rootNode = new TreeNode(rootPath, TreeImageEnums.DIRECTORY, TreeImageEnums.DIRECTORY);

            //根節點記錄在tree物件內
            treeView.Nodes.Add(rootNode);

            //展所有檔案的樹
            SetDirTreeNode(rootNode, rootPath);
        }



        /// <summary>
        /// 展所有檔案、資料夾樹
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="path"></param>
        public void SetDirTreeNode(TreeNode parentNode, string path)
        {
            

            //取得資料夾
            string[] dirs = FileUtil.GetDirs(path).OrderByDescending(o => o).ToArray();

            //展目錄
            foreach (string dir in dirs)
            {

                string dirPath = path + "/" + dir;

                TreeNode dirNode = new TreeNode(dir, TreeImageEnums.DIRECTORY, TreeImageEnums.DIRECTORY);

                dirNode.Name = dirPath;
                dirNode.StateImageIndex = 1;
                parentNode.Nodes.Add(dirNode);
                //dirNode.

                string[] dirDirs = FileUtil.GetDirs(dirPath);
                string[] dirFiles = FileUtil.GetFiles(dirPath);

                //該資料夾無檔案，則刪除該節點
                if (dirFiles.Length == 0 && dirDirs.Length == 0)
                {
                    parentNode.Nodes.Remove(dirNode);
                    dirNode.Nodes.Clear();
                }
            }

            /*
            string filterFile = "txt";
            //取得檔案
            string[] files = FileUtil.GetFiles(path, filterFile);
            //展目前資料夾的檔案
            foreach (string file in files)
            {
                TreeNode fileNode = new TreeNode(file, TreeImageEnums.FILE, TreeImageEnums.FILE);
                parentNode.Nodes.Add(fileNode);
            }
            */

            //return files.Length > 0;
        }
    }
}
