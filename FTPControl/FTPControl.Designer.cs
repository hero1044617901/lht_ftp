namespace FTPControl
{
    partial class FTPControl
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gb_driver = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslabel_upload = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_upload = new System.Windows.Forms.ToolStripProgressBar();
            this.listView_local = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_local = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip_local = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox_local = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox_local = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gb_ftp = new System.Windows.Forms.GroupBox();
            this.statusStrip_ftp = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar_down = new System.Windows.Forms.ToolStripProgressBar();
            this.listView_ftp = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip_ftp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip_ftp = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox_ftp = new System.Windows.Forms.ToolStripComboBox();
            this.上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_localback = new System.Windows.Forms.ToolStripButton();
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_down = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ftpback = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gb_driver.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip_local.SuspendLayout();
            this.toolStrip_local.SuspendLayout();
            this.gb_ftp.SuspendLayout();
            this.statusStrip_ftp.SuspendLayout();
            this.contextMenuStrip_ftp.SuspendLayout();
            this.toolStrip_ftp.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gb_driver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gb_ftp);
            this.splitContainer1.Size = new System.Drawing.Size(903, 407);
            this.splitContainer1.SplitterDistance = 458;
            this.splitContainer1.TabIndex = 0;
            // 
            // gb_driver
            // 
            this.gb_driver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_driver.Controls.Add(this.statusStrip1);
            this.gb_driver.Controls.Add(this.listView_local);
            this.gb_driver.Controls.Add(this.toolStrip_local);
            this.gb_driver.Location = new System.Drawing.Point(3, 3);
            this.gb_driver.Name = "gb_driver";
            this.gb_driver.Size = new System.Drawing.Size(452, 401);
            this.gb_driver.TabIndex = 0;
            this.gb_driver.TabStop = false;
            this.gb_driver.Text = "本地驱动器";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.tslabel_upload,
            this.toolStripProgressBar_upload});
            this.statusStrip1.Location = new System.Drawing.Point(3, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(446, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // tslabel_upload
            // 
            this.tslabel_upload.BackColor = System.Drawing.Color.Transparent;
            this.tslabel_upload.Name = "tslabel_upload";
            this.tslabel_upload.Size = new System.Drawing.Size(56, 17);
            this.tslabel_upload.Text = "上传进度";
            // 
            // toolStripProgressBar_upload
            // 
            this.toolStripProgressBar_upload.Name = "toolStripProgressBar_upload";
            this.toolStripProgressBar_upload.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar_upload.Visible = false;
            // 
            // listView_local
            // 
            this.listView_local.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_local.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_local.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_local.ContextMenuStrip = this.contextMenuStrip_local;
            this.listView_local.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_local.LabelEdit = true;
            this.listView_local.Location = new System.Drawing.Point(3, 42);
            this.listView_local.Name = "listView_local";
            this.listView_local.Size = new System.Drawing.Size(446, 331);
            this.listView_local.SmallImageList = this.imageList1;
            this.listView_local.TabIndex = 4;
            this.listView_local.UseCompatibleStateImageBehavior = false;
            this.listView_local.View = System.Windows.Forms.View.Details;
            this.listView_local.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_local_AfterLabelEdit);
            this.listView_local.DoubleClick += new System.EventHandler(this.listView_local_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "更改时间";
            this.columnHeader4.Width = 87;
            // 
            // contextMenuStrip_local
            // 
            this.contextMenuStrip_local.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.上传ToolStripMenuItem,
            this.toolStripSeparator5,
            this.剪切ToolStripMenuItem,
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.toolStripSeparator6,
            this.全选ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.重命名ToolStripMenuItem,
            this.toolStripSeparator7,
            this.删除ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip_local.Name = "contextMenuStrip1";
            this.contextMenuStrip_local.Size = new System.Drawing.Size(113, 220);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(109, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(109, 6);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(109, 6);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(20, 20);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip_local
            // 
            this.toolStrip_local.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_local,
            this.toolStripTextBox_local,
            this.toolStripButton_localback,
            this.toolStripSeparator4});
            this.toolStrip_local.Location = new System.Drawing.Point(3, 17);
            this.toolStrip_local.Name = "toolStrip_local";
            this.toolStrip_local.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_local.Size = new System.Drawing.Size(446, 25);
            this.toolStrip_local.TabIndex = 3;
            this.toolStrip_local.Text = "toolStrip3";
            // 
            // toolStripComboBox_local
            // 
            this.toolStripComboBox_local.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_local.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox_local.Name = "toolStripComboBox_local";
            this.toolStripComboBox_local.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBox_local.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_local_SelectedIndexChanged);
            // 
            // toolStripTextBox_local
            // 
            this.toolStripTextBox_local.Enabled = false;
            this.toolStripTextBox_local.Name = "toolStripTextBox_local";
            this.toolStripTextBox_local.Size = new System.Drawing.Size(320, 25);
            this.toolStripTextBox_local.Text = "***************";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // gb_ftp
            // 
            this.gb_ftp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_ftp.Controls.Add(this.statusStrip_ftp);
            this.gb_ftp.Controls.Add(this.listView_ftp);
            this.gb_ftp.Controls.Add(this.toolStrip_ftp);
            this.gb_ftp.Location = new System.Drawing.Point(3, 3);
            this.gb_ftp.Name = "gb_ftp";
            this.gb_ftp.Size = new System.Drawing.Size(435, 401);
            this.gb_ftp.TabIndex = 1;
            this.gb_ftp.TabStop = false;
            this.gb_ftp.Text = "FTP";
            // 
            // statusStrip_ftp
            // 
            this.statusStrip_ftp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripProgressBar_down});
            this.statusStrip_ftp.Location = new System.Drawing.Point(3, 376);
            this.statusStrip_ftp.Name = "statusStrip_ftp";
            this.statusStrip_ftp.Size = new System.Drawing.Size(429, 22);
            this.statusStrip_ftp.TabIndex = 5;
            this.statusStrip_ftp.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel2.Text = "下载进度";
            // 
            // toolStripProgressBar_down
            // 
            this.toolStripProgressBar_down.Name = "toolStripProgressBar_down";
            this.toolStripProgressBar_down.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar_down.Visible = false;
            // 
            // listView_ftp
            // 
            this.listView_ftp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_ftp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_ftp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader11,
            this.columnHeader12});
            this.listView_ftp.ContextMenuStrip = this.contextMenuStrip_ftp;
            this.listView_ftp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_ftp.Location = new System.Drawing.Point(3, 42);
            this.listView_ftp.Name = "listView_ftp";
            this.listView_ftp.Size = new System.Drawing.Size(429, 334);
            this.listView_ftp.SmallImageList = this.imageList2;
            this.listView_ftp.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_ftp.TabIndex = 4;
            this.listView_ftp.UseCompatibleStateImageBehavior = false;
            this.listView_ftp.View = System.Windows.Forms.View.Details;
            this.listView_ftp.DoubleClick += new System.EventHandler(this.listView_ftp_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "名称";
            this.columnHeader5.Width = 320;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "类型";
            this.columnHeader11.Width = 90;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "大小";
            // 
            // contextMenuStrip_ftp
            // 
            this.contextMenuStrip_ftp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载ToolStripMenuItem,
            this.删除ToolStripMenuItem1,
            this.新建文件夹ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenuStrip_ftp.Name = "contextMenuStrip2";
            this.contextMenuStrip_ftp.Size = new System.Drawing.Size(153, 114);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(20, 20);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // toolStrip_ftp
            // 
            this.toolStrip_ftp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_down,
            this.toolStripButton_del,
            this.toolStripButton8,
            this.toolStripComboBox_ftp,
            this.toolStripButton_ftpback});
            this.toolStrip_ftp.Location = new System.Drawing.Point(3, 17);
            this.toolStrip_ftp.Name = "toolStrip_ftp";
            this.toolStrip_ftp.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_ftp.Size = new System.Drawing.Size(429, 25);
            this.toolStrip_ftp.TabIndex = 3;
            this.toolStrip_ftp.Text = "toolStrip4";
            // 
            // toolStripComboBox_ftp
            // 
            this.toolStripComboBox_ftp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_ftp.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.toolStripComboBox_ftp.MaxDropDownItems = 1;
            this.toolStripComboBox_ftp.Name = "toolStripComboBox_ftp";
            this.toolStripComboBox_ftp.Size = new System.Drawing.Size(200, 25);
            this.toolStripComboBox_ftp.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_ftp_SelectedIndexChanged);
            // 
            // 上传ToolStripMenuItem
            // 
            this.上传ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.上传;
            this.上传ToolStripMenuItem.Name = "上传ToolStripMenuItem";
            this.上传ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.上传ToolStripMenuItem.Text = "上传";
            this.上传ToolStripMenuItem.Click += new System.EventHandler(this.上传ToolStripMenuItem_Click);
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.剪切;
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.剪切ToolStripMenuItem.Text = "剪切";
            this.剪切ToolStripMenuItem.Click += new System.EventHandler(this.剪切ToolStripMenuItem_Click);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.复制;
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.粘贴;
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.全选;
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.全选ToolStripMenuItem_Click);
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.打开;
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.重命名;
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.删除;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.退出;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // toolStripButton_localback
            // 
            this.toolStripButton_localback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_localback.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_localback.Image")));
            this.toolStripButton_localback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_localback.Name = "toolStripButton_localback";
            this.toolStripButton_localback.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_localback.Text = "toolStripButton_local";
            this.toolStripButton_localback.ToolTipText = "上级文件夹";
            this.toolStripButton_localback.Click += new System.EventHandler(this.toolStripButton_localback_Click);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.Enabled = false;
            this.下载ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.下载;
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.下载ToolStripMenuItem.Text = "下载";
            this.下载ToolStripMenuItem.Click += new System.EventHandler(this.toolStripButton_down_Click);
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Enabled = false;
            this.删除ToolStripMenuItem1.Image = global::FTPControl.Properties.Resources.删除;
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.删除ToolStripMenuItem1.Text = "删除";
            this.删除ToolStripMenuItem1.Click += new System.EventHandler(this.toolStripButton_del_Click);
            // 
            // 新建文件夹ToolStripMenuItem
            // 
            this.新建文件夹ToolStripMenuItem.Enabled = false;
            this.新建文件夹ToolStripMenuItem.Image = global::FTPControl.Properties.Resources.新建;
            this.新建文件夹ToolStripMenuItem.Name = "新建文件夹ToolStripMenuItem";
            this.新建文件夹ToolStripMenuItem.ShowShortcutKeys = false;
            this.新建文件夹ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.新建文件夹ToolStripMenuItem.Text = "新建文件夹";
            this.新建文件夹ToolStripMenuItem.Click += new System.EventHandler(this.新建文件夹ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::FTPControl.Properties.Resources.发布;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "发布";
            // 
            // toolStripButton_down
            // 
            this.toolStripButton_down.Image = global::FTPControl.Properties.Resources.下载;
            this.toolStripButton_down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_down.Name = "toolStripButton_down";
            this.toolStripButton_down.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_down.Text = "下载";
            this.toolStripButton_down.Click += new System.EventHandler(this.toolStripButton_down_Click);
            // 
            // toolStripButton_del
            // 
            this.toolStripButton_del.Image = global::FTPControl.Properties.Resources.删除;
            this.toolStripButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_del.Name = "toolStripButton_del";
            this.toolStripButton_del.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton_del.Text = "删除";
            this.toolStripButton_del.Click += new System.EventHandler(this.toolStripButton_del_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = global::FTPControl.Properties.Resources.清空;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton8.Text = "清空";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton_ftpback
            // 
            this.toolStripButton_ftpback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ftpback.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ftpback.Image")));
            this.toolStripButton_ftpback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ftpback.Name = "toolStripButton_ftpback";
            this.toolStripButton_ftpback.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ftpback.Text = "toolStripButton3";
            this.toolStripButton_ftpback.ToolTipText = "返回上一级";
            this.toolStripButton_ftpback.Click += new System.EventHandler(this.toolStripButton_ftpback_Click);
            // 
            // FTPControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FTPControl";
            this.Size = new System.Drawing.Size(903, 407);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gb_driver.ResumeLayout(false);
            this.gb_driver.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip_local.ResumeLayout(false);
            this.toolStrip_local.ResumeLayout(false);
            this.toolStrip_local.PerformLayout();
            this.gb_ftp.ResumeLayout(false);
            this.gb_ftp.PerformLayout();
            this.statusStrip_ftp.ResumeLayout(false);
            this.statusStrip_ftp.PerformLayout();
            this.contextMenuStrip_ftp.ResumeLayout(false);
            this.toolStrip_ftp.ResumeLayout(false);
            this.toolStrip_ftp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gb_driver;
        private System.Windows.Forms.ListView listView_local;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStrip toolStrip_local;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_local;
        private System.Windows.Forms.ToolStripButton toolStripButton_localback;
        private System.Windows.Forms.GroupBox gb_ftp;
        private System.Windows.Forms.ListView listView_ftp;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ToolStrip toolStrip_ftp;
        private System.Windows.Forms.ToolStripButton toolStripButton_down;
        private System.Windows.Forms.ToolStripButton toolStripButton_del;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_ftp;
        private System.Windows.Forms.ToolStripButton toolStripButton_ftpback;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_local;
        private System.Windows.Forms.ToolStripMenuItem 上传ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ftp;
        private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新建文件夹ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.StatusStrip statusStrip_ftp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tslabel_upload;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_upload;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_down;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_local;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}
