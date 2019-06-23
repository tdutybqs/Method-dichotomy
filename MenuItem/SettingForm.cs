using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MenuItem
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void OpenWindow()
        {
            Common common = new Common();
            common.MdiParent = this;
            common.FormClosed += new FormClosedEventHandler(Common_Closed);
            common.Show();
        }

        private void Common_Closed(Object sender,EventArgs e)
        {
            this.Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            Common common = new Common();
            common.MdiParent = this;
            common.FormClosed += new FormClosedEventHandler(Common_Closed);
            common.Show();
        }
    }
}
