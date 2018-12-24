namespace MonsterHunterWorld.BUS
{
    partial class FormSkillInfo
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
            this.labSkillName = new System.Windows.Forms.Label();
            this.labSkillDesc = new System.Windows.Forms.Label();
            this.picMenu = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // labSkillName
            // 
            this.labSkillName.AutoSize = true;
            this.labSkillName.Font = new System.Drawing.Font("함초롬돋움 확장", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labSkillName.Location = new System.Drawing.Point(12, 9);
            this.labSkillName.Name = "labSkillName";
            this.labSkillName.Size = new System.Drawing.Size(51, 17);
            this.labSkillName.TabIndex = 0;
            this.labSkillName.Text = "label1";
            // 
            // labSkillDesc
            // 
            this.labSkillDesc.AutoSize = true;
            this.labSkillDesc.Font = new System.Drawing.Font("함초롬돋움", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labSkillDesc.Location = new System.Drawing.Point(20, 38);
            this.labSkillDesc.Name = "labSkillDesc";
            this.labSkillDesc.Size = new System.Drawing.Size(43, 17);
            this.labSkillDesc.TabIndex = 2;
            this.labSkillDesc.Text = "label1";
            // 
            // picMenu
            // 
            this.picMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picMenu.Location = new System.Drawing.Point(0, 0);
            this.picMenu.Name = "picMenu";
            this.picMenu.Size = new System.Drawing.Size(434, 30);
            this.picMenu.TabIndex = 3;
            this.picMenu.TabStop = false;
            this.picMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMenu_MouseDown);
            this.picMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picMenu_MouseMove);
            this.picMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMenu_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("문체부 제목 돋음체", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(404, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormSkillInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 64);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.picMenu);
            this.Controls.Add(this.labSkillDesc);
            this.Controls.Add(this.labSkillName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSkillInfo";
            this.Text = "FormSkillInfo";
            this.Load += new System.EventHandler(this.FormSkillInfo_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labSkillName;
        private System.Windows.Forms.Label labSkillDesc;
        private System.Windows.Forms.PictureBox picMenu;
        private System.Windows.Forms.Button btnClose;
    }
}