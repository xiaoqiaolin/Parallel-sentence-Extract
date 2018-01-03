namespace TextProcess
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

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFile = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.readyHave = new System.Windows.Forms.Button();
            this.record = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.allText = new System.Windows.Forms.TextBox();
            this.searchType = new System.Windows.Forms.Panel();
            this.alltextsearch5 = new System.Windows.Forms.RadioButton();
            this.cite = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.inStrict = new System.Windows.Forms.RadioButton();
            this.alltextsearch1 = new System.Windows.Forms.RadioButton();
            this.alltextsearch3 = new System.Windows.Forms.RadioButton();
            this.alltextsearch4 = new System.Windows.Forms.RadioButton();
            this.alltextsearch2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.keyword = new System.Windows.Forms.TextBox();
            this.keyWords = new System.Windows.Forms.Button();
            this.saveAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.result1 = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.searchType.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFile
            // 
            this.openFile.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openFile.Location = new System.Drawing.Point(387, 15);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(95, 30);
            this.openFile.TabIndex = 11;
            this.openFile.Text = "openFile";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // filePath
            // 
            this.filePath.BackColor = System.Drawing.SystemColors.MenuBar;
            this.filePath.Location = new System.Drawing.Point(28, 21);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(333, 21);
            this.filePath.TabIndex = 12;
            this.filePath.TextChanged += new System.EventHandler(this.filePath_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(28, 65);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.clear);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.readyHave);
            this.splitContainer1.Panel1.Controls.Add(this.record);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(865, 577);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 32;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "清空数据库";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // clear
            // 
            this.clear.BackgroundImage = global::TextProcess.Properties.Resources.clear1;
            this.clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clear.Location = new System.Drawing.Point(37, 30);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 69);
            this.clear.TabIndex = 32;
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "排比抽取";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "历史数据";
            // 
            // readyHave
            // 
            this.readyHave.BackgroundImage = global::TextProcess.Properties.Resources._57106;
            this.readyHave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.readyHave.Location = new System.Drawing.Point(37, 305);
            this.readyHave.Name = "readyHave";
            this.readyHave.Size = new System.Drawing.Size(75, 69);
            this.readyHave.TabIndex = 28;
            this.readyHave.UseVisualStyleBackColor = true;
            this.readyHave.Click += new System.EventHandler(this.readyHave_Click);
            // 
            // record
            // 
            this.record.BackgroundImage = global::TextProcess.Properties.Resources.t017fe5184568c351ca;
            this.record.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.record.Location = new System.Drawing.Point(37, 147);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(75, 69);
            this.record.TabIndex = 26;
            this.record.UseVisualStyleBackColor = true;
            this.record.Click += new System.EventHandler(this.record_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.allText);
            this.flowLayoutPanel1.Controls.Add(this.searchType);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.result1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(685, 562);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // allText
            // 
            this.allText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.allText.BackColor = System.Drawing.SystemColors.MenuBar;
            this.allText.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.allText.Location = new System.Drawing.Point(3, 3);
            this.allText.Multiline = true;
            this.allText.Name = "allText";
            this.allText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.allText.Size = new System.Drawing.Size(679, 213);
            this.allText.TabIndex = 35;
            // 
            // searchType
            // 
            this.searchType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.searchType.Controls.Add(this.alltextsearch5);
            this.searchType.Controls.Add(this.cite);
            this.searchType.Controls.Add(this.radioButton1);
            this.searchType.Controls.Add(this.inStrict);
            this.searchType.Controls.Add(this.alltextsearch1);
            this.searchType.Controls.Add(this.alltextsearch3);
            this.searchType.Controls.Add(this.alltextsearch4);
            this.searchType.Controls.Add(this.alltextsearch2);
            this.searchType.Location = new System.Drawing.Point(12, 222);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(661, 31);
            this.searchType.TabIndex = 34;
            // 
            // alltextsearch5
            // 
            this.alltextsearch5.AutoSize = true;
            this.alltextsearch5.Location = new System.Drawing.Point(90, 10);
            this.alltextsearch5.Name = "alltextsearch5";
            this.alltextsearch5.Size = new System.Drawing.Size(71, 16);
            this.alltextsearch5.TabIndex = 35;
            this.alltextsearch5.Text = "段内排比";
            this.alltextsearch5.UseVisualStyleBackColor = true;
            // 
            // cite
            // 
            this.cite.AutoSize = true;
            this.cite.Location = new System.Drawing.Point(319, 10);
            this.cite.Name = "cite";
            this.cite.Size = new System.Drawing.Size(71, 16);
            this.cite.TabIndex = 34;
            this.cite.Text = "引用排比";
            this.cite.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 10);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.Text = "段间排比";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // inStrict
            // 
            this.inStrict.AutoSize = true;
            this.inStrict.Location = new System.Drawing.Point(167, 10);
            this.inStrict.Name = "inStrict";
            this.inStrict.Size = new System.Drawing.Size(71, 16);
            this.inStrict.TabIndex = 32;
            this.inStrict.Text = "分号排比";
            this.inStrict.UseVisualStyleBackColor = true;
            // 
            // alltextsearch1
            // 
            this.alltextsearch1.AutoSize = true;
            this.alltextsearch1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.alltextsearch1.Location = new System.Drawing.Point(244, 10);
            this.alltextsearch1.Name = "alltextsearch1";
            this.alltextsearch1.Size = new System.Drawing.Size(71, 16);
            this.alltextsearch1.TabIndex = 28;
            this.alltextsearch1.Text = "逗号排比";
            this.alltextsearch1.UseVisualStyleBackColor = false;
            this.alltextsearch1.CheckedChanged += new System.EventHandler(this.alltextsearch1_CheckedChanged);
            // 
            // alltextsearch3
            // 
            this.alltextsearch3.AutoSize = true;
            this.alltextsearch3.Location = new System.Drawing.Point(550, 10);
            this.alltextsearch3.Name = "alltextsearch3";
            this.alltextsearch3.Size = new System.Drawing.Size(71, 16);
            this.alltextsearch3.TabIndex = 30;
            this.alltextsearch3.Text = "包含顿号";
            this.alltextsearch3.UseVisualStyleBackColor = true;
            // 
            // alltextsearch4
            // 
            this.alltextsearch4.AutoSize = true;
            this.alltextsearch4.Location = new System.Drawing.Point(396, 10);
            this.alltextsearch4.Name = "alltextsearch4";
            this.alltextsearch4.Size = new System.Drawing.Size(71, 16);
            this.alltextsearch4.TabIndex = 31;
            this.alltextsearch4.Text = "句号排比";
            this.alltextsearch4.UseVisualStyleBackColor = true;
            // 
            // alltextsearch2
            // 
            this.alltextsearch2.AutoSize = true;
            this.alltextsearch2.Location = new System.Drawing.Point(473, 10);
            this.alltextsearch2.Name = "alltextsearch2";
            this.alltextsearch2.Size = new System.Drawing.Size(71, 16);
            this.alltextsearch2.TabIndex = 29;
            this.alltextsearch2.Text = "邻近检索";
            this.alltextsearch2.UseVisualStyleBackColor = true;
            this.alltextsearch2.CheckedChanged += new System.EventHandler(this.alltextsearch2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.keyword);
            this.panel1.Controls.Add(this.keyWords);
            this.panel1.Controls.Add(this.saveAll);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.save);
            this.panel1.Location = new System.Drawing.Point(12, 259);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 39);
            this.panel1.TabIndex = 36;
            // 
            // keyword
            // 
            this.keyword.Location = new System.Drawing.Point(111, 10);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(226, 21);
            this.keyword.TabIndex = 36;
            // 
            // keyWords
            // 
            this.keyWords.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.keyWords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.keyWords.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.keyWords.Location = new System.Drawing.Point(13, 8);
            this.keyWords.Name = "keyWords";
            this.keyWords.Size = new System.Drawing.Size(92, 24);
            this.keyWords.TabIndex = 35;
            this.keyWords.Text = "关键词提取";
            this.keyWords.UseVisualStyleBackColor = true;
            this.keyWords.Click += new System.EventHandler(this.keyWords_Click);
            // 
            // saveAll
            // 
            this.saveAll.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveAll.Location = new System.Drawing.Point(543, 10);
            this.saveAll.Name = "saveAll";
            this.saveAll.Size = new System.Drawing.Size(100, 23);
            this.saveAll.TabIndex = 34;
            this.saveAll.Text = "保存全部";
            this.saveAll.UseVisualStyleBackColor = true;
            this.saveAll.Click += new System.EventHandler(this.saveAll_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(357, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 24);
            this.button1.TabIndex = 32;
            this.button1.Text = "检索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.save.Location = new System.Drawing.Point(453, 9);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(71, 24);
            this.save.TabIndex = 33;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // result1
            // 
            this.result1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.result1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.result1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.result1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.result1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.id,
            this.text});
            this.result1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.result1.Location = new System.Drawing.Point(3, 304);
            this.result1.Name = "result1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.result1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.result1.RowTemplate.Height = 23;
            this.result1.Size = new System.Drawing.Size(679, 255);
            this.result1.TabIndex = 35;
            this.result1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.result1_CellContentClick);
            this.result1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.result1_CellDoubleClick);
            // 
            // select
            // 
            this.select.HeaderText = "选择";
            this.select.Name = "select";
            this.select.Width = 40;
            // 
            // id
            // 
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.Width = 60;
            // 
            // text
            // 
            this.text.HeaderText = "所抽文本";
            this.text.Name = "text";
            this.text.Width = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(915, 657);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.openFile);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "排比句抽取";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.searchType.ResumeLayout(false);
            this.searchType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.result1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button record;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox allText;
        private System.Windows.Forms.DataGridView result1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel searchType;
        private System.Windows.Forms.RadioButton alltextsearch1;
        private System.Windows.Forms.RadioButton alltextsearch2;
        private System.Windows.Forms.RadioButton alltextsearch3;
        private System.Windows.Forms.RadioButton alltextsearch4;
        private System.Windows.Forms.Button saveAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button readyHave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton inStrict;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn text;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button keyWords;
        private System.Windows.Forms.TextBox keyword;
        private System.Windows.Forms.RadioButton cite;
        private System.Windows.Forms.RadioButton alltextsearch5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clear;
    }
}

