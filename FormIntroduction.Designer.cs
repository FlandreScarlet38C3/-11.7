namespace 测试系统_10._31
{
    partial class FormIntroduction
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
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("公司介绍");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("公司产品");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("公司123");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("公司总览", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("介绍1的下属内容1");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("介绍1的下属内容2");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("介绍1", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 438);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.webBrowser1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(114, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 438);
            this.panel2.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(566, 438);
            this.webBrowser1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode8.Name = "节点1";
            treeNode8.Text = "公司介绍";
            treeNode9.Name = "节点2";
            treeNode9.Text = "公司产品";
            treeNode10.Name = "节点3";
            treeNode10.Text = "公司123";
            treeNode11.Name = "节点0";
            treeNode11.Text = "公司总览";
            treeNode12.Name = "节点5";
            treeNode12.Text = "介绍1的下属内容1";
            treeNode13.Name = "节点6";
            treeNode13.Text = "介绍1的下属内容2";
            treeNode14.Name = "节点4";
            treeNode14.Text = "介绍1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode14});
            this.treeView1.Size = new System.Drawing.Size(114, 438);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // FormIntroduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 438);
            this.Controls.Add(this.panel1);
            this.Name = "FormIntroduction";
            this.Text = "FormFor2";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}