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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gViewComment = new System.Windows.Forms.DataGridView();
            this.picDetailMonster = new System.Windows.Forms.PictureBox();
            this.gViewDropItem = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gViewComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailMonster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewDropItem)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewComment
            // 
            this.gViewComment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.gViewComment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gViewComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gViewComment.Location = new System.Drawing.Point(0, 721);
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViewComment.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gViewComment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gViewComment.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViewComment.RowTemplate.Height = 23;
            this.gViewComment.Size = new System.Drawing.Size(773, 149);
            this.gViewComment.TabIndex = 0;
            // 
            // picDetailMonster
            // 
            this.picDetailMonster.Location = new System.Drawing.Point(32, 12);
            this.picDetailMonster.Name = "picDetailMonster";
            this.picDetailMonster.Size = new System.Drawing.Size(710, 417);
            this.picDetailMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDetailMonster.TabIndex = 2;
            this.picDetailMonster.TabStop = false;
            // 
            // gViewDropItem
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViewDropItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gViewDropItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gViewDropItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.gViewDropItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gViewDropItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gViewDropItem.Location = new System.Drawing.Point(0, 435);
            this.gViewDropItem.Name = "gViewDropItem";
            this.gViewDropItem.RowTemplate.Height = 23;
            this.gViewDropItem.Size = new System.Drawing.Size(773, 286);
            this.gViewDropItem.TabIndex = 3;
            // 
            // FormMonsterInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 870);
            this.Controls.Add(this.gViewDropItem);
            this.Controls.Add(this.picDetailMonster);
            this.Controls.Add(this.gViewComment);
            this.Name = "FormMonsterInfo";
            this.Text = "FormMonsterInfo";
            this.Load += new System.EventHandler(this.FormMonsterInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gViewComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetailMonster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewDropItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gViewComment;
        private System.Windows.Forms.PictureBox picDetailMonster;
        private System.Windows.Forms.DataGridView gViewDropItem;
    }
}