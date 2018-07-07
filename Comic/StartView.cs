using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormTest.Register.MenuItem;
using WinFormTest.Model.ControllerView;
using WinFormTest.Common.Resize;

namespace WinFormTest
{
    public partial class StartView : Form
    {
        StartViewCV cv = new StartViewCV();

        public StartView()
        {
            InitializeComponent();

            //設定長寬
            cv.SetFormSize(this);
        }

        private void Item1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            //開啟功能方法
            cv.ItemSwitch(controlPanel, item.Name);
        }

        /// <summary>
        /// 重設長寬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartView_Resize(object sender, EventArgs e)
        {
            cv.Resize(this, controlPanel);
        }
    }
}
