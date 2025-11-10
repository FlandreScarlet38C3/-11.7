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
    public partial class FormTest : Form
    {
        private Button CurrentBtn;
        private Panel LeftBorderBtn;
        private Form CurrentChildForm;
        public FormTest()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {

            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }

            CurrentChildForm = childForm;

            childForm.TopLevel = false;
            panel2.Controls.Add(childForm);
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTestChild());
        }
    }
}
