using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace 测试系统_10._31
{
    public partial class MainMenu : Form
    {
        private Button CurrentBtn; //当前按钮
        private Panel LeftBorderBtn; //左侧边框按钮
        private Form CurrentChildForm; //当前子窗体
        public float x; //初始宽度
        public float y; //初始高度
        public MainMenu()
        {
            InitializeComponent();
            SetColourfulPanel();
            panelForMenu.Controls.Add(LeftBorderBtn);
            GetInitialScreenSize();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            webBrowser1.DocumentText = "<h1>欢迎</h1><p>请选择左侧的按钮以查看内容。</p>";
        }



        //设置彩色边框
        private void SetColourfulPanel()
        {
            LeftBorderBtn = new Panel();
            LeftBorderBtn.Size = new Size(7, 74);
        }
        //获取初始窗体大小
        public void GetInitialScreenSize()
        {
            x = this.Width;
            y = this.Height;
        }
        //定义颜色
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        //激活按钮
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                CurrentBtn = (Button)senderBtn;
                CurrentBtn.BackColor = Color.FromArgb(37, 36, 81);
                CurrentBtn.ForeColor = color;
                CurrentBtn.TextAlign = ContentAlignment.MiddleCenter;
                CurrentBtn.ImageAlign = ContentAlignment.MiddleRight;
                CurrentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //Left Border Button
                LeftBorderBtn.BackColor = color;
                LeftBorderBtn.Location = new Point(0, CurrentBtn.Location.Y);
                LeftBorderBtn.Visible = true;
                LeftBorderBtn.BringToFront();
            }
        }
        //禁用按钮
        private void DisableButton()
        {
            if (CurrentBtn != null)
            {
                CurrentBtn.BackColor = Color.FromArgb(255, 255, 255);
                // CurrentBtn.ForeColor = Color.Gainsboro;
                CurrentBtn.TextAlign = ContentAlignment.MiddleLeft;
                CurrentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                CurrentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
        }
        //打开子窗体
        private void OpenChildForm(Form childForm)
        {

            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }
            panelForChildForm.Dock = DockStyle.Fill;
            CurrentChildForm = childForm;

            childForm.TopLevel = false;
            panelForChildForm.Controls.Add(childForm);
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForChildForm.Controls.Add(childForm);
            panelForChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }




        private void buttonToTest_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FormTest());
          

        }

        private void buttonTo2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new FormIntroduction());
        }

        private void buttonTo3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new FormProduct());
        }

        private void buttonTo4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormLink());
        }

        private void buttonTo5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new More());
            ActivateButton(sender, RGBColors.color5);
        }

        private void buttonToHome_Click(object sender, EventArgs e)
        {
            if (CurrentChildForm != null)
                CurrentChildForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            LeftBorderBtn.Visible = false;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panelForTitle_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MainMenu_ResizeEnd(object sender, EventArgs e)
        {
            AutoControlSize.ChangeFormControlSize(this);
        }

        private void MainMenu_ResizeBegin(object sender, EventArgs e)
        {
            AutoControlSize.RegisterFormControl(this);
        }

        
    }
    
}
