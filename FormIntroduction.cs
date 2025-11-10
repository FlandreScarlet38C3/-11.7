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
    public partial class FormIntroduction : Form
    {
        private struct NodeTag
        {
            public string Title;
            public string Content;
        }
        public FormIntroduction()
        {
            InitializeComponent();

        }



        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.Text)
            {
                case "公司总览":
                    webBrowser1.DocumentText = "<h1>公司总览</h1><p>这里是公司总览的内容。</p>";
                    break;
                case "介绍1":
                    webBrowser1.DocumentText = "<h1>介绍1</h1><p>这里是介绍1的内容。</p>";
                    break;
                case "介绍1的下属内容1":
                    webBrowser1.DocumentText = "<h1>介绍1的下属内容1</h1><p>这里是介绍1的下属内容1的内容。</p>";
                    break;
                case "公司介绍":
                    MessageBox.Show("即将打开公司介绍网页。请点击右上角最大化按钮查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    webBrowser1.DocumentText = "<a href='http://www.lctech-inc.com/index.html'>点击这里查看公司介绍</a>";
                    break;
                default:
                    webBrowser1.DocumentText = "<h1>欢迎</h1><p>请选择左侧的节点以查看内容。</p>";
                    break;
                    {

                    }
            }
        }
    }
}
