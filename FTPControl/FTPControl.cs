using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
namespace FTPControl
{
    public partial class FTPControl : UserControl
    {
        BaseClass bc = new BaseClass();
        private string ftpHost, ftpUserName, ftpPassword;
        public string BDFolderName = "";
        #region 自定义事件
        public delegate void BeforPostEventHandler(object sender, Operation operation);
        public event BeforPostEventHandler OnBeforPostEvent;

        public delegate void FinishedPostEventHandler(object sender, Operation operation);
        public event FinishedPostEventHandler OnFinishedPostEvent;
        #endregion
        public FTPControl()
        {
            InitializeComponent();
            bc.listFolders(toolStripComboBox_local);
            contextMenuStrip_local.Items[0].Enabled = false;
            toolStripTextBox_local.Text = toolStripComboBox_local.Text;
        }
        public void LoadUser(object info)
        {
            string[] infoArray = (string[])info;
            ftpHost = infoArray[0];
            ftpUserName = infoArray[1];
            ftpPassword = infoArray[2];
            gb_ftp.Text = "FTP服务器(" + ftpHost + ")[当前用户" + ftpUserName + "]";
            listView_ftp.Items.Clear();
            bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, "");
            int i = imageList2.Images.Count;
            contextMenuStrip_local.Items[0].Enabled = true;
            this.Text = "HappyTime FTP V1.0-[" + ftpHost + ",状态：已连接]";
            //toolStripStatusLabel3.Text = "[当前登录用户" + ftpUserName + "]";

            toolStripComboBox_ftp.Items.Add("/" + ftpUserName);
            toolStripComboBox_ftp.SelectedIndex = 0;
            contextMenuStrip_ftp.Items[0].Enabled = true;
            contextMenuStrip_ftp.Items[1].Enabled = true;
            contextMenuStrip_ftp.Items[2].Enabled = true;
        }

        private void listView_local_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string pp = listView_local.SelectedItems[0].Text;
                bc.GetPath(pp.Trim(), imageList1, listView_local, 1);
                toolStripTextBox_local.Text = bc.Mpath();
            }
            catch
            {
                MessageBox.Show("无法打开此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton_localback_Click(object sender, EventArgs e)
        {
            bc.GOBack(listView_local, imageList1, toolStripComboBox_local.Text);
            toolStripTextBox_local.Text = bc.Mpath();
        }

        #region 下载文件夹
        public string name;
        public bool DownLoadDir(string aimPath)
        {
            DirectoryInfo di;
            try
            {
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += "/";
                string path = "";
                if (aimPath == name + "/")
                {
                    path = bc.Mpath() + aimPath.Remove(aimPath.LastIndexOf("/"));
                    di = new DirectoryInfo(path);
                    di.Create();
                }
                string[] fileList = bc.GetFTPList(ftpHost, ftpUserName, ftpPassword, aimPath);
                if (fileList == null)
                {
                    return false;
                }
                else
                {
                    foreach (string file in fileList)
                    {
                        //先当作目录处理如果存在这个目录就递归该目录下面的文件
                        string[] f = file.Split(' ');
                        string m = f[f.Length - 1];
                        path = aimPath + m;
                        path = path.Replace("//", "\\");
                        path = bc.Mpath() + path;
                        path = path.Replace("/", "\\");
                        if (file.IndexOf("DIR") != -1)
                        {

                            di = new DirectoryInfo(path);
                            di.Create();
                            DownLoadDir(aimPath + m);
                        }
                        else
                        {
                            if(!bc.Download(path.Remove(path.LastIndexOf("\\")), m, ftpHost, ftpUserName, ftpPassword, toolStripProgressBar_down,aimPath))
                                return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        #endregion

        #region 获取FTP目录
        public static string servePath = "";//---------

        public void GetPath(string path, int ppath)//-------
        {
            if (ppath == 0)
            {
                if (servePath != path)
                {
                    servePath = path;
                }
            }
            else
            {
                servePath = servePath + path + "/";
            }
        }
        #endregion

        #region 删除文件夹
        public void DeleteDir(string aimPath)
        {
            try
            {
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += "/";
                string[] fileList = bc.GetFTPList(ftpHost, ftpUserName, ftpPassword, aimPath);
                // 遍历所有的文件和目录
                if (fileList == null)
                {
                    aimPath = aimPath.Remove(aimPath.LastIndexOf("/"));
                    bc.delDir(aimPath, ftpHost, ftpUserName, ftpPassword);
                }
                else
                {
                    foreach (string file in fileList)
                    {
                        //先当作目录处理如果存在这个目录就递归Delete该目录下面的文件
                        string[] f = file.Split(' ');
                        string m = f[f.Length - 1];
                        if (file.IndexOf("DIR") != -1)
                        {
                            DeleteDir(aimPath + m);
                        }
                        // 否则直接Delete文件
                        else
                        {
                            bc.DeleteFileName(m, ftpHost, ftpUserName, ftpPassword, aimPath);
                        }
                    }
                    //删除文件夹
                    aimPath = aimPath.Remove(aimPath.LastIndexOf("/"));
                    bc.delDir(aimPath, ftpHost, ftpUserName, ftpPassword);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        #endregion

        #region 本地磁盘的右键菜单
        private string path;
        private static string MyPath;
        private int T = 0;
        private static ArrayList al = new ArrayList();

        #endregion


        private void toolStripButton_down_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnBeforPostEvent != null)
                {
                    OnBeforPostEvent(sender, Operation.DownLoad);
                }
                if (listView_ftp.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < listView_ftp.SelectedItems.Count; i++)
                    {
                        string filename = listView_ftp.SelectedItems[i].Text;
                        string filetype = listView_ftp.SelectedItems[0].SubItems[1].Text;
                        if (filetype == "文件夹")
                        {
                            for (int j = 0; j < listView_local.Items.Count; j++)
                            {
                                if (listView_local.Items[j].ToString() == filename)
                                {
                                    MessageBox.Show("本地目录中存在此文件夹", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            name = filename;
                            if (DownLoadDir(filename))
                            {
                                if (OnFinishedPostEvent != null)
                                {
                                    OnFinishedPostEvent(filename, Operation.DownLoad);
                                }
                            }
                            bc.GetListViewItem(bc.Mpath(), imageList1, listView_local);
                        }
                        else
                        {
                            toolStripProgressBar_down.Visible = true;
                            if (bc.Download(bc.Mpath(), filename, ftpHost, ftpUserName, ftpPassword, toolStripProgressBar_down, servePath))
                            {
                                if (OnFinishedPostEvent != null)
                                {
                                    OnFinishedPostEvent(filename, Operation.DownLoad);
                                }
                            }
                            bc.GetListViewItem(bc.Mpath(), imageList1, listView_local);
                        }
                    }
                    toolStripProgressBar_down.Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripButton_del_Click(object sender, EventArgs e)
        {
            if (listView_ftp.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除的项目", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                try
                {
                    for (int i = 0; i < listView_ftp.SelectedItems.Count; i++)
                    {

                        string filename = servePath + listView_ftp.SelectedItems[i].Text;
                        string filetype = listView_ftp.SelectedItems[i].SubItems[1].Text;

                        if (filetype == "文件夹")
                        {
                            DeleteDir(filename);
                        }
                        else
                        {
                            bc.DeleteFileName(listView_ftp.SelectedItems[i].Text, ftpHost, ftpUserName, ftpPassword, servePath);
                        }
                    }
                    listView_ftp.Items.Clear();
                    bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, servePath);

                    if (OnFinishedPostEvent != null)
                    {
                        OnFinishedPostEvent(sender, Operation.Delete);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                al.Clear();
                path = bc.Mpath() + "\\" + listView_local.SelectedItems[0].Text;
                for (int i = 0; i < listView_local.SelectedItems.Count; i++)
                {
                    al.Add(bc.Mpath() + "\\" + listView_local.SelectedItems[i].Text);
                }
                System.Collections.Specialized.StringCollection files = new System.Collections.Specialized.StringCollection();
                files.Add(path);
                Clipboard.SetFileDropList(files);
                MyPath = path;
                T = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (T == 0)
            {
                try
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        string name1 = al[i].ToString().Substring(al[i].ToString().LastIndexOf("\\") + 1, al[i].ToString().Length - al[i].ToString().LastIndexOf("\\") - 1);
                        string paths = bc.Mpath() + "\\" + name1;
                        if (File.Exists(al[i].ToString()))
                        {
                            if (al[i].ToString() != paths)
                            {
                                File.Move(al[i].ToString(), paths);
                            }
                        }
                        if (Directory.Exists(al[i].ToString()))
                        {
                            bc.Files_Copy(paths, al[i].ToString());
                            DirectoryInfo di = new DirectoryInfo(al[i].ToString());
                            di.Delete(true);
                        }
                    }
                    listView_local.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView_local);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < al.Count; i++)
                    {
                        string name1 = al[i].ToString().Substring(al[i].ToString().LastIndexOf("\\") + 1, al[i].ToString().Length - al[i].ToString().LastIndexOf("\\") - 1);
                        string paths = bc.Mpath() + "\\" + name1;
                        if (File.Exists(al[i].ToString()))
                        {
                            if (al[i].ToString() != paths)
                            {
                                File.Copy(al[i].ToString(), paths, false);
                            }
                        }
                        if (Directory.Exists(al[i].ToString()))
                        {
                            bc.Files_Copy(paths, al[i].ToString());
                        }
                    }
                    listView_local.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView_local);
                }
                catch { }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView_local.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < listView_local.SelectedItems.Count; i++)
                    {
                        string path = bc.Mpath() + "\\" + listView_local.SelectedItems[i].Text;
                        if (File.GetAttributes(path).CompareTo(FileAttributes.Directory) == 0)
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(path);
                            dinfo.Delete(true);
                        }
                        else
                        {
                            string path1 = bc.Mpath() + "\\" + listView_local.SelectedItems[i].Text;
                            FileInfo finfo = new FileInfo(path1);
                            finfo.Delete();
                        }
                    }
                    listView_local.Items.Clear();
                    bc.GetListViewItem(bc.Mpath(), imageList1, listView_local);
                }
            }
            catch
            { }
        }

        #region  返回上一级目录
        /// <summary>
        /// 返回上一级目录
        /// </summary>
        /// <param dir="string">目录</param>
        /// <returns>返回String对象</returns>
        public string UpAndDown_Dir(string dir)
        {
            string Change_dir = "";
            Change_dir = Directory.GetParent(dir).FullName;
            return Change_dir;
        }
        #endregion

        /// <summary>
        /// 遍历本地文件夹上传整个文件夹到FTP
        /// </summary>z
        /// <param name="path"></param>
        public static string NPath = servePath;
        public string GFolder;
        public static string FolderN;
        public static string path1;
        public bool UpDir(string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加之
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar)
                    aimPath += Path.DirectorySeparatorChar;
                if (NPath == "" || NPath == null)
                {
                    NPath = NPath + FolderN;
                    bc.MakeDir(NPath, ftpHost, ftpUserName, ftpPassword);
                }
                // 得到源目录的文件列表，里面是包含文件以及目录路径的一个数组
                string[] fileList = Directory.GetFileSystemEntries(aimPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    string[] a = file.Split('\\');
                    string fname = a[a.Length - 1];
                    NPath = file.Remove(0, GFolder.Length).Replace("\\", "//");
                    if (NPath.StartsWith("//"))
                    {
                        NPath = NPath.Remove(0, 2);
                    }
                    // 先当作目录处理如果存在这个目录就递归Delete该目录下面的文件
                    if (Directory.Exists(file))
                    {
                        string aa = file;
                        NPath = file.Remove(0, GFolder.Length).Replace("\\", "//");
                        if (NPath.StartsWith("//"))
                        {
                            NPath = NPath.Remove(0, 2);
                        }
                        bc.MakeDir(NPath, ftpHost, ftpUserName, ftpPassword);
                        UpDir(file);
                    }
                    else
                    {
                        if(!bc.Upload(file, ftpHost, ftpUserName, ftpPassword, toolStripProgressBar_upload, NPath.Remove(NPath.LastIndexOf("//")) + "/"))
                            return false;
                    }
                }
                return true;
            }
            catch { return false; }
        }

        private void 上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(OnBeforPostEvent != null)
                {
                    OnBeforPostEvent(sender,Operation.UpLoad);
                }
                if (listView_local.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < listView_local.SelectedItems.Count; i++)
                    {
                        path1 = bc.Mpath() + listView_local.SelectedItems[i].Text;
                        GFolder = Directory.GetParent(path1).FullName;
                        if (Directory.Exists(path1))
                        {
                            if (listView_local.Items.Count == 0)
                            {
                                FolderN = listView_local.SelectedItems[i].Text;
                                if (UpDir(path1))
                                {
                                    if (OnFinishedPostEvent != null)
                                    {
                                        OnFinishedPostEvent(path1, Operation.UpLoad);
                                    }
                                }
                                NPath = servePath;
                            }
                            else
                            {
                                for (int j = 0; j < listView_ftp.Items.Count; j++)
                                {
                                    if (listView_ftp.Items[j].Text == listView_local.SelectedItems[i].Text)
                                    {
                                        MessageBox.Show("服务器中已经存在此目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        FolderN = listView_local.SelectedItems[i].Text;
                                        if (UpDir(path1))
                                        {
                                            if (OnFinishedPostEvent != null)
                                            {
                                                OnFinishedPostEvent(path1, Operation.UpLoad);
                                            }
                                        }
                                        NPath = servePath;
                                    }
                                }
                            }
                        }
                        else if (File.Exists(path1))
                        {
                            toolStripProgressBar_upload.Visible = true;
                            if (bc.Upload(path1, ftpHost, ftpUserName, ftpPassword, toolStripProgressBar_upload, servePath))
                            {
                                if (OnFinishedPostEvent != null)
                                {
                                    OnFinishedPostEvent(path1, Operation.UpLoad);
                                }
                            }
                        }
                    }
                    toolStripProgressBar_upload.Visible = false;
                    listView_ftp.Items.Clear();
                    bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, servePath);
                    toolStripComboBox_ftp.Text = "/" + ftpHost + servePath;
                }
            }
            catch { MessageBox.Show(""); }
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView_local.Items.Count; i++)
            {
                listView_local.Items[i].Selected = true;
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pp = listView_local.SelectedItems[0].Text;
                bc.GetPath(pp.Trim(), imageList1, listView_local, 1);
            }
            catch
            {
                MessageBox.Show("无法打开此文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_local.SelectedItems.Count != 0)
            {
                listView_local.SelectedItems[0].BeginEdit();
            }
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView_local.SelectedItems.Count != 0)
            {
                al.Clear();
                for (int i = 0; i < listView_local.SelectedItems.Count; i++)
                {
                    al.Add(bc.Mpath() + "\\" + listView_local.SelectedItems[i].Text);
                }
                T = 0;
            }
        }

        private void listView_local_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                string MyPath = bc.Mpath() + "\\" + listView_local.SelectedItems[0].Text;
                string newFilename = e.Label;
                string path2 = bc.Mpath() + "\\" + newFilename;
                if (File.Exists(MyPath))
                {
                    if (MyPath != path2)
                    {
                        File.Move(MyPath, path2);
                    }
                }
                if (Directory.Exists(MyPath))
                {
                    DirectoryInfo di = new DirectoryInfo(MyPath);
                    di.MoveTo(path2);
                }
                listView_local.Items.Clear();
                bc.GetListViewItem(bc.Mpath(), imageList1, listView_local);
            }
            catch { }
        }

        private void toolStripComboBox_local_SelectedIndexChanged(object sender, EventArgs e)
        {
            bc.GetPath(toolStripComboBox_local.Text, imageList1, listView_local, 0);
        }

        private void listView_ftp_DoubleClick(object sender, EventArgs e)
        {
            string filename = listView_ftp.SelectedItems[0].Text;
            string filetype = listView_ftp.SelectedItems[0].SubItems[1].Text;

            if (filetype == "文件夹")//文件夹
            {
                GetPath(filename.Trim(), 1);
                bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, servePath);
                toolStripComboBox_ftp.Items.Add("/" + ftpUserName + "/" + servePath);
                toolStripComboBox_ftp.Text = "/" + ftpUserName + "/" + servePath;
            }
        }

        private void toolStripButton_ftpback_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox_ftp.Text == "/" + ftpUserName)
            { }
            else
            {
                string path = servePath;
                string Path1 = path.Remove(path.LastIndexOf("/"));
                string NewPath = Path1.Remove(Path1.LastIndexOf("/") + 1);
                servePath = NewPath;
                if (NewPath.Length != 0)
                {
                    toolStripComboBox_ftp.Text = "/" + ftpUserName + "/" + NewPath;
                    listView_ftp.Items.Clear();
                    bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, NewPath);
                }
                else
                {
                    toolStripComboBox_ftp.Text = "/" + ftpUserName;
                    listView_ftp.Items.Clear();
                    bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, "");
                }
            }   
        }

        private void toolStripComboBox_ftp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox_ftp.Text == "/" + ftpUserName)
            {
                GetPath("", 0);
                bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, servePath);
            }
            else
            {
                string path = toolStripComboBox_ftp.Text.Trim().Remove(0, ftpUserName.Trim().Length + 2);
                bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, path);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView_ftp.Items.Count; i++)
                {
                    listView_ftp.Items[i].Selected = true;
                }
                for (int i = 0; i < listView_ftp.Items.Count; i++)
                {
                    string filename = servePath + listView_ftp.Items[i].Text;
                    string filetype = listView_ftp.Items[i].SubItems[1].Text;

                    if (filetype == "文件夹")
                    {
                        DeleteDir(filename);
                    }
                    else
                    {
                        bc.DeleteFileName(listView_ftp.SelectedItems[i].Text, ftpHost, ftpUserName, ftpPassword, servePath);
                    }
                }
                listView_ftp.Items.Clear();
                bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, servePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 新建文件夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewFolder dlg = new NewFolder())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(dlg.newFolder))
                    {
                        bc.MakeDir(servePath + dlg.newFolder, ftpHost, ftpUserName, ftpPassword);
                        listView_ftp.Items.Clear();
                        bc.getFTPServerICO(imageList2, ftpHost, ftpUserName, ftpPassword, listView_ftp, servePath);
                    }
                }
            }
        }
    }
}
