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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gViewComment = new System.Windows.Forms.DataGridView();
            this.picDetailMonster = new System.Windows.Forms.PictureBox();
            this.gViewDropItem = new System.Windows.Forms.DataGridView();
            this.picBar = new System.Windows.Forms.PictureBox();
            this.labMonsterName = new System.Windows.Forms.Label();
            this.picDropTab = new System.Windows.Forms.PictureBox();
            this.picCommentTab = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gViewComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailMonster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewDropItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDropTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommentTab)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewComment
            // 
            this.gViewComment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.gViewComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gViewComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gViewComment.Location = new System.Drawing.Point(0, 841);
            this.gViewComment.Name = "gViewComment";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViewComment.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gViewComment.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gViewComment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gViewComment.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViewComment.RowTemplate.Height = 23;
            this.gViewComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gViewComment.Size = new System.Drawing.Size(710, 159);
            this.gViewComment.TabIndex = 0;
            this.gViewComment.SelectionChanged += new System.EventHandler(this.gView_SelectionChanged);
            // 
            // picDetailMonster
            // 
            this.picDetailMonster.Location = new System.Drawing.Point(0, 46);
            this.picDetailMonster.Name = "picDetailMonster";
            this.picDetailMonster.Size = new System.Drawing.Size(710, 417);
            this.picDetailMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDetailMonster.TabIndex = 2;
            this.picDetailMonster.TabStop = false;
            // 
            // gViewDropItem
            // 
            this.gViewDropItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gViewDropItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gViewDropItem.DefaultCellStyle = dataGridViewCellStyle2;
            this.gViewDropItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gViewDropItem.Location = new System.Drawing.Point(0, 510);
            this.gViewDropItem.Name = "gViewDropItem";
            this.gViewDropItem.RowTemplate.Height = 23;
            this.gViewDropItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gViewDropItem.Size = new System.Drawing.Size(710, 286);
            this.gViewDropItem.TabIndex = 3;
            this.gViewDropItem.SelectionChanged += new System.EventHandler(this.gView_SelectionChanged);
            // 
            // picBar
            // 
            this.picBar.BackColor = System.Drawing.Color.Green;
            this.picBar.Location = new System.Drawing.Point(0, 0);
            this.picBar.Name = "picBar";
            this.picBar.Size = new System.Drawing.Size(710, 30);
            this.picBar.TabIndex = 4;
            this.picBar.TabStop = false;
            this.picBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.picBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.picBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // labMonsterName
            // 
            this.labMonsterName.AutoSize = true;
            this.labMonsterName.BackColor = System.Drawing.Color.Transparent;
            this.labMonsterName.Font = new System.Drawing.Font("문체부 제목 돋음체", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labMonsterName.ForeColor = System.Drawing.Color.White;
            this.labMonsterName.Location = new System.Drawing.Point(25, 5);
            this.labMonsterName.Name = "labMonsterName";
            this.labMonsterName.Size = new System.Drawing.Size(125, 20);
            this.labMonsterName.TabIndex = 5;
            this.labMonsterName.Text = "몬스터 이름";
            this.labMonsterName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.labMonsterName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.labMonsterName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // picDropTab
            // 
            this.picDropTab.Location = new System.Drawing.Point(0, 482);
            this.picDropTab.Name = "picDropTab";
            this.picDropTab.Size = new System.Drawing.Size(206, 28);
            this.picDropTab.TabIndex = 6;
            this.picDropTab.TabStop = false;
            // 
            // picCommentTab
            // 
            this.picCommentTab.Location = new System.Drawing.Point(0, 809);
            this.picCommentTab.Name = "picCommentTab";
            this.picCommentTab.Size = new System.Drawing.Size(149, 32);
            this.picCommentTab.TabIndex = 7;
            this.picCommentTab.TabStop = false;
            // 
            // FormMonsterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 1000);
            this.Controls.Add(this.picCommentTab);
            this.Controls.Add(this.picDropTab);
            this.Controls.Add(this.labMonsterName);
            this.Controls.Add(this.picBar);
            this.Controls.Add(this.gViewDropItem);
            this.Controls.Add(this.picDetailMonster);
            this.Controls.Add(this.gViewComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMonsterInfo";
            this.Text = "FormMonsterInfo";
            this.Load += new System.EventHandler(this.FormMonsterInfo_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.gViewComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailMonster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewDropItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDropTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCommentTab)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gViewComment;
        private System.Windows.Forms.PictureBox picDetailMonster;
        private System.Windows.Forms.DataGridView gViewDropItem;
        private System.Windows.Forms.PictureBox picBar;
        private System.Windows.Forms.Label labMonsterName;
        private System.Windows.Forms.PictureBox picDropTab;
        private System.Windows.Forms.PictureBox picCommentTab;
    }
}