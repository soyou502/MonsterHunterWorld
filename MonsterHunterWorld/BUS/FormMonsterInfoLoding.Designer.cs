namespace MonsterHunterWorld.BUS
{
    partial class FormMonsterInfoLoding
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
            this.picLoding = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoding)).BeginInit();
            this.SuspendLayout();
            // 
            // picLoding
            // 
            this.picLoding.Location = new System.Drawing.Point(0, 0);
            this.picLoding.Name = "picLoding";
            this.picLoding.Size = new System.Drawing.Size(430, 323);
            this.picLoding.TabIndex = 0;
            this.picLoding.TabStop = false;
            // 
            // FormMonsterInfoLoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 323);
            this.Controls.Add(this.picLoding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMonsterInfoLoding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMonsterInfoLoding";
            this.Load += new System.EventHandler(this.FormMonsterInfoLoding_Load);
            this.Shown += new System.EventHandler(this.FormMonsterInfoLoding_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picLoding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLoding;
    }
}