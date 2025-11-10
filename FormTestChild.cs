using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测试系统_10._31
{
    public partial class FormTestChild : Form
    {
        public FormTestChild()
        {
            InitializeComponent();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            label1.Visible = true;
            label1.Text = "功能1已启用";
            label2.Visible = false;
            chart1.Series["功能1"].Enabled = true;
            chart1.Series["功能2"].Enabled = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            checkBox1.Checked = false;
            label2.Visible = true;
            label2.Text = "功能2已启用";
            label1.Visible = false;
            chart1.Series["功能2"].Enabled = true;
            chart1.Series["功能1"].Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          this.Refresh();
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            label1.Visible = true;
            label2.Visible = false;
            check.Text = null;
            comboBox1.Text = "默认设备";
            chart1.Series["功能1"].Enabled = true;
            chart1.Series["功能2"].Enabled = false;
            numericUpDown1.Value = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            check.Text = "开始检测";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            check.Text = "停止检测";
        }
    }
}
