namespace MonsterHunterWorld.BUS
{
    partial class FormJewel
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
            this.gViewJewels = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gViewJewels)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewJewels
            // 
            this.gViewJewels.AllowUserToAddRows = false;
            this.gViewJewels.AllowUserToDeleteRows = false;
            this.gViewJewels.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.gViewJewels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gViewJewels.DefaultCellStyle = dataGridViewCellStyle1;
            this.gViewJewels.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gViewJewels.Location = new System.Drawing.Point(12, 31);
            this.gViewJewels.MultiSelect = false;
            this.gViewJewels.Name = "gViewJewels";
            this.gViewJewels.ReadOnly = true;
            this.gViewJewels.RowHeadersVisible = false;
            this.gViewJewels.RowTemplate.Height = 23;
            this.gViewJewels.Size = new System.Drawing.Size(450, 250);
            this.gViewJewels.TabIndex = 0;
            this.gViewJewels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.gViewJewels.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViewJewels_CellMouseEnter);
            this.gViewJewels.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViewJewels_CellMouseLeave);
            this.gViewJewels.SelectionChanged += new System.EventHandler(this.gViewJewels_SelectionChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("문체부 제목 돋음체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(447, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(500, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "종료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormJewel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gViewJewels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormJewel";
            this.Text = "FormJewel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormJewel_FormClosed);
            this.Load += new System.EventHandler(this.FormJewel_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.gViewJewels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gViewJewels;
        private System.Windows.Forms.Button button1;
    }
}