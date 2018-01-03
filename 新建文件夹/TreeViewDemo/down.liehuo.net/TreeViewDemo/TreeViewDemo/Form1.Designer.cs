namespace TreeViewDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
	/// download by http://down.liehuo.net
        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("书本目录", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btExpand = new System.Windows.Forms.Button();
            this.btCollapse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Indent = 14;
            this.treeView1.ItemHeight = 14;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "节点1";
            treeNode7.Text = "节点1";
            treeNode8.Name = "节点2";
            treeNode8.Text = "节点2";
            treeNode9.Name = "节点0";
            treeNode9.Text = "书本目录";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(171, 258);
            this.treeView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(177, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "类型:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(227, 17);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(159, 21);
            this.txtPath.TabIndex = 2;
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(227, 68);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(159, 21);
            this.txtBookName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(177, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "书名：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(227, 119);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(159, 21);
            this.txtAuthor.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(177, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "作者：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(227, 170);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(159, 21);
            this.txtPrice.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(177, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "价格：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btExpand
            // 
            this.btExpand.Location = new System.Drawing.Point(194, 218);
            this.btExpand.Name = "btExpand";
            this.btExpand.Size = new System.Drawing.Size(75, 23);
            this.btExpand.TabIndex = 9;
            this.btExpand.Text = "展开";
            this.btExpand.UseVisualStyleBackColor = true;
            this.btExpand.Click += new System.EventHandler(this.btExpand_Click);
            // 
            // btCollapse
            // 
            this.btCollapse.Location = new System.Drawing.Point(301, 218);
            this.btCollapse.Name = "btCollapse";
            this.btCollapse.Size = new System.Drawing.Size(75, 23);
            this.btCollapse.TabIndex = 10;
            this.btCollapse.Text = "闭合";
            this.btCollapse.UseVisualStyleBackColor = true;
            this.btCollapse.Click += new System.EventHandler(this.btCollapse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 258);
            this.Controls.Add(this.btCollapse);
            this.Controls.Add(this.btExpand);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TreeView使用示例";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btExpand;
        private System.Windows.Forms.Button btCollapse;
    }
}

