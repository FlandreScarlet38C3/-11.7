namespace 测试系统_10._31
{
    partial class FormTestChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelForDesign = new System.Windows.Forms.TableLayoutPanel();
            this.PanelForSend = new System.Windows.Forms.TableLayoutPanel();
            this.RichBoxSend = new System.Windows.Forms.RichTextBox();
            this.ButtonSend = new System.Windows.Forms.Button();
            this.CheckBoxHexSend = new System.Windows.Forms.CheckBox();
            this.PanelForReceive = new System.Windows.Forms.TableLayoutPanel();
            this.RichBoxReceive = new System.Windows.Forms.RichTextBox();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.CheckBoxTime = new System.Windows.Forms.CheckBox();
            this.PanelForSetting = new System.Windows.Forms.TableLayoutPanel();
            this.ComboBoxForCheck = new System.Windows.Forms.ComboBox();
            this.ComboBoxForDataSet = new System.Windows.Forms.ComboBox();
            this.LabelForCheck = new System.Windows.Forms.Label();
            this.LabelForDataSet = new System.Windows.Forms.Label();
            this.LabelForPotterValue = new System.Windows.Forms.Label();
            this.ComboBoxForPotterValue = new System.Windows.Forms.ComboBox();
            this.LabelForPort = new System.Windows.Forms.Label();
            this.LabelForStop = new System.Windows.Forms.Label();
            this.LabelForControl = new System.Windows.Forms.Label();
            this.ComboBoxForPort = new System.Windows.Forms.ComboBox();
            this.ComboBoxForStopBit = new System.Windows.Forms.ComboBox();
            this.ComboBoxForControl = new System.Windows.Forms.ComboBox();
            this.ButtonForOpenPort = new System.Windows.Forms.Button();
            this.ButtonForClosePort = new System.Windows.Forms.Button();
            this.PanelForDesign.SuspendLayout();
            this.PanelForSend.SuspendLayout();
            this.PanelForReceive.SuspendLayout();
            this.PanelForSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelForDesign
            // 
            this.PanelForDesign.ColumnCount = 2;
            this.PanelForDesign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForDesign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForDesign.Controls.Add(this.PanelForSend, 1, 1);
            this.PanelForDesign.Controls.Add(this.PanelForReceive, 0, 1);
            this.PanelForDesign.Controls.Add(this.PanelForSetting, 0, 0);
            this.PanelForDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForDesign.Location = new System.Drawing.Point(0, 0);
            this.PanelForDesign.Name = "PanelForDesign";
            this.PanelForDesign.RowCount = 2;
            this.PanelForDesign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.8481F));
            this.PanelForDesign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.1519F));
            this.PanelForDesign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelForDesign.Size = new System.Drawing.Size(664, 395);
            this.PanelForDesign.TabIndex = 0;
            // 
            // PanelForSend
            // 
            this.PanelForSend.ColumnCount = 2;
            this.PanelForSend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForSend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForSend.Controls.Add(this.RichBoxSend, 0, 0);
            this.PanelForSend.Controls.Add(this.ButtonSend, 1, 1);
            this.PanelForSend.Controls.Add(this.CheckBoxHexSend, 0, 1);
            this.PanelForSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForSend.Location = new System.Drawing.Point(335, 113);
            this.PanelForSend.Name = "PanelForSend";
            this.PanelForSend.RowCount = 2;
            this.PanelForSend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.60574F));
            this.PanelForSend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.39427F));
            this.PanelForSend.Size = new System.Drawing.Size(326, 279);
            this.PanelForSend.TabIndex = 0;
            // 
            // RichBoxSend
            // 
            this.PanelForSend.SetColumnSpan(this.RichBoxSend, 2);
            this.RichBoxSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichBoxSend.Location = new System.Drawing.Point(3, 3);
            this.RichBoxSend.Name = "RichBoxSend";
            this.RichBoxSend.Size = new System.Drawing.Size(320, 243);
            this.RichBoxSend.TabIndex = 0;
            this.RichBoxSend.Text = "";
            // 
            // ButtonSend
            // 
            this.ButtonSend.Location = new System.Drawing.Point(166, 252);
            this.ButtonSend.Name = "ButtonSend";
            this.ButtonSend.Size = new System.Drawing.Size(70, 24);
            this.ButtonSend.TabIndex = 2;
            this.ButtonSend.Text = "发送";
            this.ButtonSend.UseVisualStyleBackColor = true;
            this.ButtonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // CheckBoxHexSend
            // 
            this.CheckBoxHexSend.AutoSize = true;
            this.CheckBoxHexSend.Location = new System.Drawing.Point(3, 252);
            this.CheckBoxHexSend.Name = "CheckBoxHexSend";
            this.CheckBoxHexSend.Size = new System.Drawing.Size(84, 16);
            this.CheckBoxHexSend.TabIndex = 3;
            this.CheckBoxHexSend.Text = "16进制发送";
            this.CheckBoxHexSend.UseVisualStyleBackColor = true;
            // 
            // PanelForReceive
            // 
            this.PanelForReceive.ColumnCount = 2;
            this.PanelForReceive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForReceive.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForReceive.Controls.Add(this.RichBoxReceive, 0, 0);
            this.PanelForReceive.Controls.Add(this.ButtonClear, 1, 1);
            this.PanelForReceive.Controls.Add(this.CheckBoxTime, 0, 1);
            this.PanelForReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForReceive.Location = new System.Drawing.Point(3, 113);
            this.PanelForReceive.Name = "PanelForReceive";
            this.PanelForReceive.RowCount = 2;
            this.PanelForReceive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.24731F));
            this.PanelForReceive.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.75269F));
            this.PanelForReceive.Size = new System.Drawing.Size(326, 279);
            this.PanelForReceive.TabIndex = 1;
            // 
            // RichBoxReceive
            // 
            this.PanelForReceive.SetColumnSpan(this.RichBoxReceive, 2);
            this.RichBoxReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichBoxReceive.Location = new System.Drawing.Point(3, 3);
            this.RichBoxReceive.Name = "RichBoxReceive";
            this.RichBoxReceive.Size = new System.Drawing.Size(320, 242);
            this.RichBoxReceive.TabIndex = 0;
            this.RichBoxReceive.Text = "";
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(166, 251);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(75, 23);
            this.ButtonClear.TabIndex = 2;
            this.ButtonClear.Text = "清空";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.buttonClearReceive_Click);
            // 
            // CheckBoxTime
            // 
            this.CheckBoxTime.AutoSize = true;
            this.CheckBoxTime.Location = new System.Drawing.Point(3, 251);
            this.CheckBoxTime.Name = "CheckBoxTime";
            this.CheckBoxTime.Size = new System.Drawing.Size(84, 16);
            this.CheckBoxTime.TabIndex = 3;
            this.CheckBoxTime.Text = "显示时间戳";
            this.CheckBoxTime.UseVisualStyleBackColor = true;
            // 
            // PanelForSetting
            // 
            this.PanelForSetting.ColumnCount = 4;
            this.PanelForDesign.SetColumnSpan(this.PanelForSetting, 2);
            this.PanelForSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PanelForSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.PanelForSetting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.PanelForSetting.Controls.Add(this.ComboBoxForCheck, 2, 1);
            this.PanelForSetting.Controls.Add(this.ComboBoxForDataSet, 1, 1);
            this.PanelForSetting.Controls.Add(this.LabelForCheck, 2, 0);
            this.PanelForSetting.Controls.Add(this.LabelForDataSet, 1, 0);
            this.PanelForSetting.Controls.Add(this.LabelForPotterValue, 0, 0);
            this.PanelForSetting.Controls.Add(this.ComboBoxForPotterValue, 0, 1);
            this.PanelForSetting.Controls.Add(this.LabelForPort, 0, 2);
            this.PanelForSetting.Controls.Add(this.LabelForStop, 1, 2);
            this.PanelForSetting.Controls.Add(this.LabelForControl, 2, 2);
            this.PanelForSetting.Controls.Add(this.ComboBoxForPort, 0, 3);
            this.PanelForSetting.Controls.Add(this.ComboBoxForStopBit, 1, 3);
            this.PanelForSetting.Controls.Add(this.ComboBoxForControl, 2, 3);
            this.PanelForSetting.Controls.Add(this.ButtonForOpenPort, 3, 0);
            this.PanelForSetting.Controls.Add(this.ButtonForClosePort, 3, 2);
            this.PanelForSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelForSetting.Location = new System.Drawing.Point(3, 3);
            this.PanelForSetting.Name = "PanelForSetting";
            this.PanelForSetting.RowCount = 4;
            this.PanelForSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelForSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PanelForSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelForSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.PanelForSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelForSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelForSetting.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.PanelForSetting.Size = new System.Drawing.Size(658, 104);
            this.PanelForSetting.TabIndex = 2;
            // 
            // ComboBoxForCheck
            // 
            this.ComboBoxForCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxForCheck.FormattingEnabled = true;
            this.ComboBoxForCheck.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.ComboBoxForCheck.Location = new System.Drawing.Point(355, 23);
            this.ComboBoxForCheck.Name = "ComboBoxForCheck";
            this.ComboBoxForCheck.Size = new System.Drawing.Size(153, 20);
            this.ComboBoxForCheck.TabIndex = 6;
            // 
            // ComboBoxForDataSet
            // 
            this.ComboBoxForDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxForDataSet.FormattingEnabled = true;
            this.ComboBoxForDataSet.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.ComboBoxForDataSet.Location = new System.Drawing.Point(179, 23);
            this.ComboBoxForDataSet.Name = "ComboBoxForDataSet";
            this.ComboBoxForDataSet.Size = new System.Drawing.Size(170, 20);
            this.ComboBoxForDataSet.TabIndex = 5;
            // 
            // LabelForCheck
            // 
            this.LabelForCheck.AutoSize = true;
            this.LabelForCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelForCheck.Location = new System.Drawing.Point(355, 0);
            this.LabelForCheck.Name = "LabelForCheck";
            this.LabelForCheck.Size = new System.Drawing.Size(153, 20);
            this.LabelForCheck.TabIndex = 3;
            this.LabelForCheck.Text = "校验位";
            // 
            // LabelForDataSet
            // 
            this.LabelForDataSet.AutoSize = true;
            this.LabelForDataSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelForDataSet.Location = new System.Drawing.Point(179, 0);
            this.LabelForDataSet.Name = "LabelForDataSet";
            this.LabelForDataSet.Size = new System.Drawing.Size(170, 20);
            this.LabelForDataSet.TabIndex = 2;
            this.LabelForDataSet.Text = "数据位";
            // 
            // LabelForPotterValue
            // 
            this.LabelForPotterValue.AutoSize = true;
            this.LabelForPotterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelForPotterValue.Location = new System.Drawing.Point(3, 0);
            this.LabelForPotterValue.Name = "LabelForPotterValue";
            this.LabelForPotterValue.Size = new System.Drawing.Size(170, 20);
            this.LabelForPotterValue.TabIndex = 0;
            this.LabelForPotterValue.Text = "波特率";
            // 
            // ComboBoxForPotterValue
            // 
            this.ComboBoxForPotterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxForPotterValue.FormattingEnabled = true;
            this.ComboBoxForPotterValue.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.ComboBoxForPotterValue.Location = new System.Drawing.Point(3, 23);
            this.ComboBoxForPotterValue.Name = "ComboBoxForPotterValue";
            this.ComboBoxForPotterValue.Size = new System.Drawing.Size(170, 20);
            this.ComboBoxForPotterValue.TabIndex = 1;
            // 
            // LabelForPort
            // 
            this.LabelForPort.AutoSize = true;
            this.LabelForPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelForPort.Location = new System.Drawing.Point(3, 50);
            this.LabelForPort.Name = "LabelForPort";
            this.LabelForPort.Size = new System.Drawing.Size(170, 20);
            this.LabelForPort.TabIndex = 7;
            this.LabelForPort.Text = "串口选择";
            // 
            // LabelForStop
            // 
            this.LabelForStop.AutoSize = true;
            this.LabelForStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelForStop.Location = new System.Drawing.Point(179, 50);
            this.LabelForStop.Name = "LabelForStop";
            this.LabelForStop.Size = new System.Drawing.Size(170, 20);
            this.LabelForStop.TabIndex = 8;
            this.LabelForStop.Text = "停止位";
            // 
            // LabelForControl
            // 
            this.LabelForControl.AutoSize = true;
            this.LabelForControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelForControl.Location = new System.Drawing.Point(355, 50);
            this.LabelForControl.Name = "LabelForControl";
            this.LabelForControl.Size = new System.Drawing.Size(153, 20);
            this.LabelForControl.TabIndex = 9;
            this.LabelForControl.Text = "流控制";
            // 
            // ComboBoxForPort
            // 
            this.ComboBoxForPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxForPort.FormattingEnabled = true;
            this.ComboBoxForPort.Location = new System.Drawing.Point(3, 73);
            this.ComboBoxForPort.Name = "ComboBoxForPort";
            this.ComboBoxForPort.Size = new System.Drawing.Size(170, 20);
            this.ComboBoxForPort.TabIndex = 10;
            this.ComboBoxForPort.DropDown += new System.EventHandler(this.ComboBoxForPort_DropDown);
            // 
            // ComboBoxForStopBit
            // 
            this.ComboBoxForStopBit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxForStopBit.FormattingEnabled = true;
            this.ComboBoxForStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.ComboBoxForStopBit.Location = new System.Drawing.Point(179, 73);
            this.ComboBoxForStopBit.Name = "ComboBoxForStopBit";
            this.ComboBoxForStopBit.Size = new System.Drawing.Size(170, 20);
            this.ComboBoxForStopBit.TabIndex = 11;
            // 
            // ComboBoxForControl
            // 
            this.ComboBoxForControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxForControl.FormattingEnabled = true;
            this.ComboBoxForControl.Items.AddRange(new object[] {
            "None",
            "XON/XOFF",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.ComboBoxForControl.Location = new System.Drawing.Point(355, 73);
            this.ComboBoxForControl.Name = "ComboBoxForControl";
            this.ComboBoxForControl.Size = new System.Drawing.Size(153, 20);
            this.ComboBoxForControl.TabIndex = 12;
            // 
            // ButtonForOpenPort
            // 
            this.ButtonForOpenPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonForOpenPort.Location = new System.Drawing.Point(514, 3);
            this.ButtonForOpenPort.Name = "ButtonForOpenPort";
            this.PanelForSetting.SetRowSpan(this.ButtonForOpenPort, 2);
            this.ButtonForOpenPort.Size = new System.Drawing.Size(141, 44);
            this.ButtonForOpenPort.TabIndex = 14;
            this.ButtonForOpenPort.Text = "打开串口";
            this.ButtonForOpenPort.UseVisualStyleBackColor = true;
            this.ButtonForOpenPort.Click += new System.EventHandler(this.ButtonForOpenPort_Click);
            // 
            // ButtonForClosePort
            // 
            this.ButtonForClosePort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonForClosePort.Location = new System.Drawing.Point(514, 53);
            this.ButtonForClosePort.Name = "ButtonForClosePort";
            this.PanelForSetting.SetRowSpan(this.ButtonForClosePort, 2);
            this.ButtonForClosePort.Size = new System.Drawing.Size(141, 48);
            this.ButtonForClosePort.TabIndex = 15;
            this.ButtonForClosePort.Text = "关闭串口";
            this.ButtonForClosePort.UseVisualStyleBackColor = true;
            this.ButtonForClosePort.Click += new System.EventHandler(this.buttonClosePort_Click);
            // 
            // FormTestChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(664, 395);
            this.Controls.Add(this.PanelForDesign);
            this.Name = "FormTestChild";
            this.Text = "FormTestChild";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTestChild_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormTestChild_FormClosed);
            this.Load += new System.EventHandler(this.FormTestChild_Load);
            this.PanelForDesign.ResumeLayout(false);
            this.PanelForSend.ResumeLayout(false);
            this.PanelForSend.PerformLayout();
            this.PanelForReceive.ResumeLayout(false);
            this.PanelForReceive.PerformLayout();
            this.PanelForSetting.ResumeLayout(false);
            this.PanelForSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PanelForDesign;
        private System.Windows.Forms.TableLayoutPanel PanelForSend;
        private System.Windows.Forms.TableLayoutPanel PanelForReceive;
        private System.Windows.Forms.TableLayoutPanel PanelForSetting;
        private System.Windows.Forms.Label LabelForPotterValue;
        private System.Windows.Forms.ComboBox ComboBoxForPotterValue;
        private System.Windows.Forms.ComboBox ComboBoxForCheck;
        private System.Windows.Forms.ComboBox ComboBoxForDataSet;
        private System.Windows.Forms.Label LabelForCheck;
        private System.Windows.Forms.Label LabelForDataSet;
        private System.Windows.Forms.Label LabelForPort;
        private System.Windows.Forms.Label LabelForStop;
        private System.Windows.Forms.Label LabelForControl;
        private System.Windows.Forms.ComboBox ComboBoxForPort;
        private System.Windows.Forms.ComboBox ComboBoxForStopBit;
        private System.Windows.Forms.ComboBox ComboBoxForControl;
        private System.Windows.Forms.Button ButtonForOpenPort;
        private System.Windows.Forms.Button ButtonForClosePort;
        private System.Windows.Forms.RichTextBox RichBoxReceive;
        private System.Windows.Forms.RichTextBox RichBoxSend;
        private System.Windows.Forms.Button ButtonSend;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.CheckBox CheckBoxHexSend;
        private System.Windows.Forms.CheckBox CheckBoxTime;
    }
}