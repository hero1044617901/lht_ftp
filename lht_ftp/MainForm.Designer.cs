namespace lht_ftp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tb_web = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tb_ftp = new System.Windows.Forms.TabPage();
            this.MyFTPControl = new FTPControl.FTPControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_home = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ftp = new System.Windows.Forms.ToolStripButton();
            this.tBtn_back = new System.Windows.Forms.ToolStripButton();
            this.tBtn_forward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tabTask = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewEx1 = new ListViewEx.ListViewEx(this.components);
            this.listViewEx2 = new ListViewEx.ListViewEx(this.components);
            this.文件 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.上传进度 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl.SuspendLayout();
            this.tb_web.SuspendLayout();
            this.tb_ftp.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tb_web);
            this.tabControl.Controls.Add(this.tb_ftp);
            this.tabControl.Controls.Add(this.tabTask);
            this.tabControl.Location = new System.Drawing.Point(0, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(943, 507);
            this.tabControl.TabIndex = 0;
            // 
            // tb_web
            // 
            this.tb_web.Controls.Add(this.pictureBox1);
            this.tb_web.Controls.Add(this.webBrowser1);
            this.tb_web.Location = new System.Drawing.Point(4, 22);
            this.tb_web.Name = "tb_web";
            this.tb_web.Padding = new System.Windows.Forms.Padding(3);
            this.tb_web.Size = new System.Drawing.Size(935, 481);
            this.tb_web.TabIndex = 0;
            this.tb_web.Text = "私有云";
            this.tb_web.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(-4, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(943, 474);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://192.168.2.34", System.UriKind.Absolute);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.webBrowser1_NewWindow);
            // 
            // tb_ftp
            // 
            this.tb_ftp.Controls.Add(this.MyFTPControl);
            this.tb_ftp.Location = new System.Drawing.Point(4, 22);
            this.tb_ftp.Name = "tb_ftp";
            this.tb_ftp.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ftp.Size = new System.Drawing.Size(935, 481);
            this.tb_ftp.TabIndex = 1;
            this.tb_ftp.Text = "FTP";
            this.tb_ftp.UseVisualStyleBackColor = true;
            // 
            // MyFTPControl
            // 
            this.MyFTPControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyFTPControl.Location = new System.Drawing.Point(-4, 3);
            this.MyFTPControl.Name = "MyFTPControl";
            this.MyFTPControl.Size = new System.Drawing.Size(939, 478);
            this.MyFTPControl.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_home,
            this.toolStripSeparator1,
            this.toolStripButton_ftp,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.tBtn_back,
            this.tBtn_forward,
            this.toolStripSeparator4,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(943, 48);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripButton_home
            // 
            this.toolStripButton_home.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_home.Image = global::lht_ftp.Properties.Resources.home;
            this.toolStripButton_home.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_home.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_home.Name = "toolStripButton_home";
            this.toolStripButton_home.Size = new System.Drawing.Size(52, 45);
            this.toolStripButton_home.Text = "主页";
            this.toolStripButton_home.Click += new System.EventHandler(this.toolStripButton_home_Click);
            // 
            // toolStripButton_ftp
            // 
            this.toolStripButton_ftp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ftp.Image = global::lht_ftp.Properties.Resources.ftp;
            this.toolStripButton_ftp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ftp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ftp.Name = "toolStripButton_ftp";
            this.toolStripButton_ftp.Size = new System.Drawing.Size(52, 45);
            this.toolStripButton_ftp.Text = "FTP";
            this.toolStripButton_ftp.Click += new System.EventHandler(this.toolStripButton_ftp_Click);
            // 
            // tBtn_back
            // 
            this.tBtn_back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtn_back.Image = global::lht_ftp.Properties.Resources.backword;
            this.tBtn_back.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tBtn_back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtn_back.Name = "tBtn_back";
            this.tBtn_back.Size = new System.Drawing.Size(52, 45);
            this.tBtn_back.Text = "后退";
            this.tBtn_back.Click += new System.EventHandler(this.tBtn_back_Click);
            // 
            // tBtn_forward
            // 
            this.tBtn_forward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBtn_forward.Image = global::lht_ftp.Properties.Resources.forwardt;
            this.tBtn_forward.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tBtn_forward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tBtn_forward.Name = "tBtn_forward";
            this.tBtn_forward.Size = new System.Drawing.Size(52, 45);
            this.tBtn_forward.Text = "向前";
            this.tBtn_forward.Click += new System.EventHandler(this.tBtn_forward_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::lht_ftp.Properties.Resources.power_off;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(52, 45);
            this.toolStripButton4.Text = "退出";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::lht_ftp.Properties.Resources.Task_Schedule;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 45);
            this.toolStripButton1.Text = "我的任务";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::lht_ftp.Properties.Resources.web;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(172, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(591, 410);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 48);
            // 
            // tabTask
            // 
            this.tabTask.Controls.Add(this.splitContainer1);
            this.tabTask.Location = new System.Drawing.Point(4, 22);
            this.tabTask.Name = "tabTask";
            this.tabTask.Padding = new System.Windows.Forms.Padding(3);
            this.tabTask.Size = new System.Drawing.Size(935, 481);
            this.tabTask.TabIndex = 2;
            this.tabTask.Text = "tabPage1";
            this.tabTask.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(929, 475);
            this.splitContainer1.SplitterDistance = 469;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listViewEx1);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 469);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "我的上传";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listViewEx2);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 469);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "我的下载";
            // 
            // listViewEx1
            // 
            this.listViewEx1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.文件,
            this.上传进度,
            this.时间});
            this.listViewEx1.Location = new System.Drawing.Point(6, 20);
            this.listViewEx1.Name = "listViewEx1";
            this.listViewEx1.OwnerDraw = true;
            this.listViewEx1.ProgressColumnIndex = -1;
            this.listViewEx1.Size = new System.Drawing.Size(449, 443);
            this.listViewEx1.TabIndex = 0;
            this.listViewEx1.UseCompatibleStateImageBehavior = false;
            this.listViewEx1.View = System.Windows.Forms.View.Details;
            // 
            // listViewEx2
            // 
            this.listViewEx2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewEx2.Location = new System.Drawing.Point(6, 20);
            this.listViewEx2.Name = "listViewEx2";
            this.listViewEx2.OwnerDraw = true;
            this.listViewEx2.ProgressColumnIndex = -1;
            this.listViewEx2.Size = new System.Drawing.Size(436, 443);
            this.listViewEx2.TabIndex = 0;
            this.listViewEx2.UseCompatibleStateImageBehavior = false;
            this.listViewEx2.View = System.Windows.Forms.View.Details;
            // 
            // 文件
            // 
            this.文件.Text = "文件";
            this.文件.Width = 80;
            // 
            // 上传进度
            // 
            this.上传进度.Text = "上传进度";
            this.上传进度.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.上传进度.Width = 207;
            // 
            // 时间
            // 
            this.时间.Text = "时间";
            this.时间.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.时间.Width = 160;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件";
            this.columnHeader1.Width = 82;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "下载进度";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 191;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "时间";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 161;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 534);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "FTP客户端";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tb_web.ResumeLayout(false);
            this.tb_ftp.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabTask.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tb_web;
        private System.Windows.Forms.TabPage tb_ftp;
        private FTPControl.FTPControl MyFTPControl;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_home;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_ftp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tBtn_back;
        private System.Windows.Forms.ToolStripButton tBtn_forward;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabPage tabTask;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ListViewEx.ListViewEx listViewEx1;
        private System.Windows.Forms.ColumnHeader 文件;
        private System.Windows.Forms.ColumnHeader 上传进度;
        private System.Windows.Forms.ColumnHeader 时间;
        private ListViewEx.ListViewEx listViewEx2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

