using System.Windows.Forms;
namespace TextProcess
{
    partial class Form2
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
            this.readyPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.searchType = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Similarity = new System.Windows.Forms.Button();
            this.containMark = new System.Windows.Forms.Button();
            this.closeMatch = new System.Windows.Forms.Button();
            this.strict = new System.Windows.Forms.Button();
            this.allDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.readyPanel.SuspendLayout();
            this.searchType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // readyPanel
            // 
            this.readyPanel.AutoSize = true;
            this.readyPanel.Controls.Add(this.searchType);
            this.readyPanel.Controls.Add(this.allDataGridView);
            this.readyPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.readyPanel.Location = new System.Drawing.Point(12, 12);
            this.readyPanel.Name = "readyPanel";
            this.readyPanel.Size = new System.Drawing.Size(685, 567);
            this.readyPanel.TabIndex = 36;
            // 
            // searchType
            // 
            this.searchType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.searchType.Controls.Add(this.button4);
            this.searchType.Controls.Add(this.button3);
            this.searchType.Controls.Add(this.button2);
            this.searchType.Controls.Add(this.button1);
            this.searchType.Controls.Add(this.search);
            this.searchType.Controls.Add(this.textBox1);
            this.searchType.Controls.Add(this.comboBox1);
            this.searchType.Controls.Add(this.Similarity);
            this.searchType.Controls.Add(this.containMark);
            this.searchType.Controls.Add(this.closeMatch);
            this.searchType.Controls.Add(this.strict);
            this.searchType.Location = new System.Drawing.Point(12, 3);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(661, 60);
            this.searchType.TabIndex = 34;
            this.searchType.Paint += new System.Windows.Forms.PaintEventHandler(this.searchType_Paint);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(578, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 45;
            this.button4.Text = "包含顿号";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(495, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 44;
            this.button3.Text = "分号排比";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(414, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 43;
            this.button2.Text = "逗号排比";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "句号排比";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(281, 31);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(59, 23);
            this.search.TabIndex = 42;
            this.search.Text = "查找";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 21);
            this.textBox1.TabIndex = 41;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "主题",
            "内容"});
            this.comboBox1.Location = new System.Drawing.Point(132, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.Text = "主题";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Similarity
            // 
            this.Similarity.Location = new System.Drawing.Point(252, 3);
            this.Similarity.Name = "Similarity";
            this.Similarity.Size = new System.Drawing.Size(75, 23);
            this.Similarity.TabIndex = 39;
            this.Similarity.Text = "邻近排比";
            this.Similarity.UseVisualStyleBackColor = true;
            this.Similarity.Click += new System.EventHandler(this.Similarity_Click);
            // 
            // containMark
            // 
            this.containMark.Location = new System.Drawing.Point(171, 3);
            this.containMark.Name = "containMark";
            this.containMark.Size = new System.Drawing.Size(75, 23);
            this.containMark.TabIndex = 38;
            this.containMark.Text = "引用排比";
            this.containMark.UseVisualStyleBackColor = true;
            this.containMark.Click += new System.EventHandler(this.containMark_Click);
            // 
            // closeMatch
            // 
            this.closeMatch.Location = new System.Drawing.Point(90, 3);
            this.closeMatch.Name = "closeMatch";
            this.closeMatch.Size = new System.Drawing.Size(75, 23);
            this.closeMatch.TabIndex = 37;
            this.closeMatch.Text = "段内排比";
            this.closeMatch.UseVisualStyleBackColor = true;
            this.closeMatch.Click += new System.EventHandler(this.closeMatch_Click);
            // 
            // strict
            // 
            this.strict.Location = new System.Drawing.Point(9, 3);
            this.strict.Name = "strict";
            this.strict.Size = new System.Drawing.Size(75, 23);
            this.strict.TabIndex = 36;
            this.strict.Text = "段间排比";
            this.strict.UseVisualStyleBackColor = true;
            this.strict.Click += new System.EventHandler(this.strict_Click);
            // 
            // allDataGridView
            // 
            this.allDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.allDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.id,
            this.Text});
            this.allDataGridView.Location = new System.Drawing.Point(3, 69);
            this.allDataGridView.Name = "allDataGridView";
            this.allDataGridView.RowTemplate.Height = 23;
            this.allDataGridView.Size = new System.Drawing.Size(679, 495);
            this.allDataGridView.TabIndex = 35;
            this.allDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allDataGridView_CellContentClick);
            this.allDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allDataGridView_CellDoubleClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // id
            // 
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.Width = 60;
            // 
            // Text
            // 
            this.Text.HeaderText = "所抽文本";
            this.Text.Name = "Text";
            this.Text.Width = 1000;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 582);
            this.Controls.Add(this.readyPanel);
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.readyPanel.ResumeLayout(false);
            this.searchType.ResumeLayout(false);
            this.searchType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel readyPanel;
        private System.Windows.Forms.Panel searchType;
        private System.Windows.Forms.DataGridView allDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private Button strict;
        private Button closeMatch;
        private Button containMark;
        private Button Similarity;
        private TextBox textBox1;
        private Button search;
        private System.Diagnostics.EventLog eventLog1;
        private ComboBox comboBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button4;
        //public event EventHandler CheckedChanged;

       

    }
}