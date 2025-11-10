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
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             var result = MessageBox.Show("是否打开产品链接？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
                Process.Start("IExplore", "http://www.taobao.com");
            }
        }
    }
}
