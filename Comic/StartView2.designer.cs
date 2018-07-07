namespace WinFormTest
{
    partial class StartView2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.downloadLog = new System.Windows.Forms.Button();
            this.SettingBtn = new System.Windows.Forms.Button();
            this.WatchComicBtn = new System.Windows.Forms.Button();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MenuPanel.Controls.Add(this.downloadLog);
            this.MenuPanel.Controls.Add(this.SettingBtn);
            this.MenuPanel.Controls.Add(this.WatchComicBtn);
            this.MenuPanel.Controls.Add(this.DownloadBtn);
            this.MenuPanel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.MenuPanel.Location = new System.Drawing.Point(12, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(1093, 92);
            this.MenuPanel.TabIndex = 0;
            // 
            // downloadLog
            // 
            this.downloadLog.BackColor = System.Drawing.Color.Red;
            this.downloadLog.ForeColor = System.Drawing.Color.White;
            this.downloadLog.Location = new System.Drawing.Point(613, 5);
            this.downloadLog.Name = "downloadLog";
            this.downloadLog.Size = new System.Drawing.Size(354, 38);
            this.downloadLog.TabIndex = 3;
            this.downloadLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.downloadLog.UseVisualStyleBackColor = false;
            this.downloadLog.Visible = false;
            // 
            // SettingBtn
            // 
            this.SettingBtn.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SettingBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SettingBtn.Location = new System.Drawing.Point(195, 1);
            this.SettingBtn.Name = "SettingBtn";
            this.SettingBtn.Size = new System.Drawing.Size(90, 90);
            this.SettingBtn.TabIndex = 2;
            this.SettingBtn.Text = "設定";
            this.SettingBtn.UseVisualStyleBackColor = true;
            this.SettingBtn.Click += new System.EventHandler(this.OpenItem_Event);
            // 
            // WatchComicBtn
            // 
            this.WatchComicBtn.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WatchComicBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.WatchComicBtn.Location = new System.Drawing.Point(99, 0);
            this.WatchComicBtn.Name = "WatchComicBtn";
            this.WatchComicBtn.Size = new System.Drawing.Size(90, 90);
            this.WatchComicBtn.TabIndex = 1;
            this.WatchComicBtn.Text = "看漫畫";
            this.WatchComicBtn.UseVisualStyleBackColor = true;
            this.WatchComicBtn.Click += new System.EventHandler(this.OpenItem_Event);
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DownloadBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DownloadBtn.Location = new System.Drawing.Point(3, 0);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(90, 90);
            this.DownloadBtn.TabIndex = 0;
            this.DownloadBtn.Text = "下載";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownLoad_Event);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoSize = true;
            this.ContentPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ContentPanel.Location = new System.Drawing.Point(12, 98);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1093, 577);
            this.ContentPanel.TabIndex = 1;
            // 
            // StartView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1117, 674);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.MenuPanel);
            this.Name = "StartView2";
            this.Text = "StartView2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Button WatchComicBtn;
        private System.Windows.Forms.Button SettingBtn;
        private System.Windows.Forms.Button downloadLog;
    }
}