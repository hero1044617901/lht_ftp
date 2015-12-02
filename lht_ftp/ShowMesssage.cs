using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lht_ftp
{
    public partial class ShowMesssage : Form
    {
        public ShowMesssage()
        {
            InitializeComponent();
        }
        public string _setText
        {
            set { label1.Text = value; }
            get { return label1.Text; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
