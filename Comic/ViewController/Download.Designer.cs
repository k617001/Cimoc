namespace Comic.ViewController
{
    partial class Download
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
            this.components = new System.ComponentModel.Container();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newDownLoadTreeView = new System.Windows.Forms.TreeView();
            this.bookPanel = new System.Windows.Forms.Panel();
            this.bookListView = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeReLoad = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.bookPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(12, 12);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(121, 38);
            this.downloadBtn.TabIndex = 1;
            this.downloadBtn.Text = "點我下載";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newDownLoadTreeView);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 354);
            this.panel1.TabIndex = 2;
            // 
            // newDownLoadTreeView
            // 
            this.newDownLoadTreeView.Location = new System.Drawing.Point(1, 0);
            this.newDownLoadTreeView.Name = "newDownLoadTreeView";
            this.newDownLoadTreeView.Size = new System.Drawing.Size(206, 270);
            this.newDownLoadTreeView.TabIndex = 0;
            this.newDownLoadTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_Click);
            // 
            // bookPanel
            // 
            this.bookPanel.BackColor = System.Drawing.Color.White;
            this.bookPanel.Controls.Add(this.bookListView);
            this.bookPanel.Location = new System.Drawing.Point(225, 57);
            this.bookPanel.Name = "bookPanel";
            this.bookPanel.Size = new System.Drawing.Size(478, 354);
            this.bookPanel.TabIndex = 3;
            // 
            // bookListView
            // 
            this.bookListView.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.bookListView.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bookListView.Location = new System.Drawing.Point(0, 0);
            this.bookListView.Name = "bookListView";
            this.bookListView.Size = new System.Drawing.Size(121, 97);
            this.bookListView.TabIndex = 0;
            this.bookListView.UseCompatibleStateImageBehavior = false;
            this.bookListView.View = System.Windows.Forms.View.List;
            this.bookListView.VirtualListSize = 2;
            this.bookListView.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // treeReLoad
            // 
            this.treeReLoad.Location = new System.Drawing.Point(139, 13);
            this.treeReLoad.Name = "treeReLoad";
            this.treeReLoad.Size = new System.Drawing.Size(116, 36);
            this.treeReLoad.TabIndex = 4;
            this.treeReLoad.Text = "重新整理";
            this.treeReLoad.UseVisualStyleBackColor = true;
            this.treeReLoad.Click += new System.EventHandler(this.treeReLoad_Click);
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 675);
            this.Controls.Add(this.treeReLoad);
            this.Controls.Add(this.bookPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.downloadBtn);
            this.Name = "Download";
            this.Text = "Download";
            this.panel1.ResumeLayout(false);
            this.bookPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView newDownLoadTreeView;
        private System.Windows.Forms.Panel bookPanel;
        private System.Windows.Forms.ListView bookListView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button treeReLoad;
    }
}