using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;

namespace lht_ftp
{
    public partial class MainForm : Form
    {
        private object mainInfo;
        private string uri = "http://192.168.2.34/mycloud/home/direct_login?";
        ShowMesssage fUpload, fDown;
        public MainForm(object user)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            mainInfo = user;
            MyFTPControl.OnBeforPostEvent += new FTPControl.FTPControl.BeforPostEventHandler(MyFTPControl_OnPostEvent);
            MyFTPControl.OnFinishedPostEvent += new FTPControl.FTPControl.FinishedPostEventHandler(MyFTPControl_OnFinishedPostEvent);
        }

        void MyFTPControl_OnFinishedPostEvent(object sender, FTPControl.Operation operation)
        {
            switch (operation)
            {
                case FTPControl.Operation.DownLoad:
                    if (fDown != null)
                        fDown.Close();
                    break;
                case FTPControl.Operation.UpLoad:
                    if (fUpload != null)
                        fUpload.Close();
                    break;
                case FTPControl.Operation.Delete:
                    MessageBox.Show(sender.ToString());
                    break;
            }
        }

        void MyFTPControl_OnPostEvent(object sender, FTPControl.Operation operation)
        {
            switch (operation)
            {
                case FTPControl.Operation.DownLoad:
                    var th = new Thread(delegate()
                    {
                        fDown = new ShowMesssage();
                        fDown._setText = "正在下载请稍后 ...";
                        fDown.ShowDialog();
                    });
                    th.IsBackground = true;
                    th.Start();
                    break;
                case FTPControl.Operation.UpLoad:
                    var th1 = new Thread(delegate()
                    {
                        fUpload = new ShowMesssage();
                        fUpload._setText = "正在上传请稍后 ...";
                        fUpload.ShowDialog();
                    });
                    th1.IsBackground = true;
                    th1.Start();
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MyFTPControl.LoadUser(mainInfo);
            string[] infoList = (string[])mainInfo;
            webBrowser1.Navigate(uri+"username="+infoList[1]+"&password="+infoList[2]);
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
        }

        private void toolStripButton_home_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(0);
            tBtn_back.Enabled = true;
            tBtn_forward.Enabled = true;
        }

        private void toolStripButton_ftp_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(1);
            tBtn_back.Enabled = false;
            tBtn_forward.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            //将所有的链接的目标，指向本窗体 
            foreach (HtmlElement archor in this.webBrowser1.Document.Links)
            {
                archor.SetAttribute("target", "_self");
            }
            //将所有的FORM的提交目标，指向本窗体 
            foreach (HtmlElement form in this.webBrowser1.Document.Forms)
            {
                form.SetAttribute("target", "_self");
            }
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void tBtn_back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void tBtn_forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(2);
            tBtn_back.Enabled = false;
            tBtn_forward.Enabled = false;
        }
    }
}
