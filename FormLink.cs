using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测试系统_10._31
{
    public partial class FormLink : Form
    {
        public FormLink()
        {
            InitializeComponent();
        }

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            Process.Start("IExplore", "http://www.baidu.com");

        }
    }
}
