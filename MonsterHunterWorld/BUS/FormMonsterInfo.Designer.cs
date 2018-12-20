namespace MonsterHunterWorld.BUS
{
    partial class FormMonsterInfo
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
            this.gViewComment = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gViewComment)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewComment
            // 
            this.gViewComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gViewComment.Location = new System.Drawing.Point(109, 288);
            this.gViewComment.Name = "gViewComment";
            this.gViewComment.RowTemplate.Height = 23;
            this.gViewComment.Size = new System.Drawing.Size(519, 150);
            this.gViewComment.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(519, 258);
            this.textBox1.TabIndex = 1;
            // 
            // FormMonsterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gViewComment);
            this.Name = "FormMonsterInfo";
            this.Text = "FormMonsterInfo";
            this.Load += new System.EventHandler(this.FormMonsterInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gViewComment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gViewComment;
        private System.Windows.Forms.TextBox textBox1;
    }
}