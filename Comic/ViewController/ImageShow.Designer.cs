namespace WinFormTest.ViewController
{
    partial class ImageShow
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
            this.viewPicture = new System.Windows.Forms.PictureBox();
            this.beforeBtn = new System.Windows.Forms.Button();
            this.afterBtn = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.imagePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.viewPicture)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewPicture
            // 
            this.viewPicture.BackColor = System.Drawing.Color.Honeydew;
            this.viewPicture.Location = new System.Drawing.Point(11, 0);
            this.viewPicture.Name = "viewPicture";
            this.viewPicture.Size = new System.Drawing.Size(62, 66);
            this.viewPicture.TabIndex = 0;
            this.viewPicture.TabStop = false;
            this.viewPicture.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.viewPicture.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.viewPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrl_MouseDown);
            this.viewPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctrl_MouseMove);
            // 
            // beforeBtn
            // 
            this.beforeBtn.BackColor = System.Drawing.Color.White;
            this.beforeBtn.Location = new System.Drawing.Point(7, 3);
            this.beforeBtn.Name = "beforeBtn";
            this.beforeBtn.Size = new System.Drawing.Size(82, 63);
            this.beforeBtn.TabIndex = 1;
            this.beforeBtn.Text = "上一頁(←)";
            this.beforeBtn.UseVisualStyleBackColor = false;
            this.beforeBtn.Click += new System.EventHandler(this.beforeBtn_Click);
            this.beforeBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageShow_KeyUp);
            // 
            // afterBtn
            // 
            this.afterBtn.BackColor = System.Drawing.Color.White;
            this.afterBtn.Location = new System.Drawing.Point(7, 72);
            this.afterBtn.Name = "afterBtn";
            this.afterBtn.Size = new System.Drawing.Size(82, 63);
            this.afterBtn.TabIndex = 2;
            this.afterBtn.Text = "下一頁(→)";
            this.afterBtn.UseVisualStyleBackColor = false;
            this.afterBtn.Click += new System.EventHandler(this.afterBtn_Click);
            this.afterBtn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageShow_KeyUp);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.SystemColors.Window;
            this.menuPanel.Controls.Add(this.CloseBtn);
            this.menuPanel.Controls.Add(this.beforeBtn);
            this.menuPanel.Controls.Add(this.afterBtn);
            this.menuPanel.Location = new System.Drawing.Point(641, 1);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(92, 524);
            this.menuPanel.TabIndex = 3;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(8, 142);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(81, 61);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "關閉";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.Color.Black;
            this.imagePanel.Controls.Add(this.viewPicture);
            this.imagePanel.Location = new System.Drawing.Point(1, 1);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(641, 524);
            this.imagePanel.TabIndex = 4;
            // 
            // ImageShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 558);
            this.ControlBox = false;
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "ImageShow";
            this.Text = "ImageShow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ImageShow_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageShow_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.viewPicture)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.imagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox viewPicture;
        private System.Windows.Forms.Button beforeBtn;
        private System.Windows.Forms.Button afterBtn;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Button CloseBtn;
    }
}