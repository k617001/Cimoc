using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormTest.Common.Resize;
using WinFormTest.Config;

namespace WinFormTest.ViewController
{
    public partial class TestItem1 : Form, IResizeControl
    {
        TestObj t = new TestObj();
        public TestItem1()
        {
            InitializeComponent();
            //重設長寬
            ResizeUtil.Resize(this);

            t.c = this.button1; ;
            TestObj.CC = this.button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 記錄要變更長寬的元件
        /// </summary>
        /// <returns></returns>
        public ResizeControlRecord ResizeControl()
        {
            return new ResizeControlRecord()
            {
                
                AllControls = new Control[]
                {
                    this.button1
                }, 
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.button1.Width = 100;
            MessageBox.Show(this.button1.Width + "," + this.button1.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button1.Width = 100;
            this.button1.Height = 100;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Panel targetPanel = (Panel)this.Parent;
            Control c = (targetPanel.Controls.Find("button1", true))[0];
            c.Width = 150;
            c.Height = 150;
        }
    }

    public class TestObj
    {
        public Control c { set; get; }
        public static Control CC = null;
    }
}
