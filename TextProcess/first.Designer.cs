namespace TextProcess
{
    partial class first
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
            this.chinese = new System.Windows.Forms.Button();
            this.english = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chinese
            // 
            this.chinese.Location = new System.Drawing.Point(35, 82);
            this.chinese.Name = "chinese";
            this.chinese.Size = new System.Drawing.Size(75, 23);
            this.chinese.TabIndex = 0;
            this.chinese.Text = "chinese";
            this.chinese.UseVisualStyleBackColor = true;
            this.chinese.Click += new System.EventHandler(this.chinese_Click);
            // 
            // english
            // 
            this.english.Location = new System.Drawing.Point(35, 125);
            this.english.Name = "english";
            this.english.Size = new System.Drawing.Size(75, 23);
            this.english.TabIndex = 1;
            this.english.Text = "english";
            this.english.UseVisualStyleBackColor = true;
            this.english.Click += new System.EventHandler(this.english_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "优美句子查找";
            // 
            // first
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(174, 187);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.english);
            this.Controls.Add(this.chinese);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Name = "first";
            this.Text = "firstcs";
            this.Load += new System.EventHandler(this.firstcs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chinese;
        private System.Windows.Forms.Button english;
        private System.Windows.Forms.Label label1;
    }
}