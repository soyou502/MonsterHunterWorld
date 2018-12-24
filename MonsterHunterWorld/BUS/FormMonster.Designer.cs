namespace MonsterHunterWorld.BUS
{
    partial class FormMonster
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gViewMonster = new System.Windows.Forms.DataGridView();
            this.monsterInfoToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gViewMonster)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewMonster
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gViewMonster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gViewMonster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gViewMonster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViewMonster.Location = new System.Drawing.Point(0, 0);
            this.gViewMonster.Name = "gViewMonster";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gViewMonster.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gViewMonster.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gViewMonster.RowTemplate.Height = 23;
            this.gViewMonster.Size = new System.Drawing.Size(800, 538);
            this.gViewMonster.TabIndex = 0;
            this.gViewMonster.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViewMonster_CellContentClick);
            this.gViewMonster.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViewMonster_CellMouseEnter);
            this.gViewMonster.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViewMonster_CellMouseLeave);
            this.gViewMonster.SelectionChanged += new System.EventHandler(this.gViewMonster_SelectionChanged);
            // 
            // FormMonster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 538);
            this.Controls.Add(this.gViewMonster);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMonster";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "몬스터 정보";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMonster_FormClosed);
            this.Load += new System.EventHandler(this.FormMonster_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.gViewMonster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gViewMonster;
        private System.Windows.Forms.ToolTip monsterInfoToolTip;
    }
}