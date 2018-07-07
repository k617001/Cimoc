using Comic.Data.DAO;
using Comic.Data.Entity;
using Comic.Data.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comic.ViewController
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();


            SettingDAO settingDAO = new SettingDaoImpl();
            SettingEntity entity = settingDAO.Find();

            this.ComicTxt.Text = entity.ComicUrl;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.ComicTxt.Text))
            {
                MessageBox.Show(this.label1.Text + " 是必填喔!!!!!!!");
                return;
            }

            SettingDAO settingDAO = new SettingDaoImpl();
            settingDAO.SaveComicUrl(this.ComicTxt.Text);

            this.Close();
        }
    }
}
