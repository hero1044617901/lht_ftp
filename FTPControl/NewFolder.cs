using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPControl
{
    public partial class NewFolder : Form
    {
        public string newFolder
        {
            get;
            set;
        }
        public NewFolder()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (txtNewFolderName.Text == "")
            { }
            else
            {
                if (txtNewFolderName.Text.Trim().LastIndexOf(".") != -1)
                {
                    MessageBox.Show("文件夹名不规范", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    newFolder = txtNewFolderName.Text.Trim();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
