namespace MonsteHunterWorld
{
    partial class FrmArmorInfo
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
            this.gViewSkill = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gViewItem = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRare = new System.Windows.Forms.Label();
            this.lblSlots = new System.Windows.Forms.Label();
            this.lblPart = new System.Windows.Forms.Label();
            this.lblDefense = new System.Windows.Forms.Label();
            this.lblResistances = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gViewSkill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gViewSkill
            // 
            this.gViewSkill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gViewSkill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gViewSkill.Location = new System.Drawing.Point(257, 170);
            this.gViewSkill.Name = "gViewSkill";
            this.gViewSkill.ReadOnly = true;
            this.gViewSkill.RowHeadersVisible = false;
            this.gViewSkill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gViewSkill.RowTemplate.Height = 23;
            this.gViewSkill.Size = new System.Drawing.Size(220, 136);
            this.gViewSkill.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "착용부위";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "레어도";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "방어력";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "슬롯";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "내성";
            // 
            // gViewItem
            // 
            this.gViewItem.AllowUserToAddRows = false;
            this.gViewItem.AllowUserToDeleteRows = false;
            this.gViewItem.AllowUserToResizeColumns = false;
            this.gViewItem.AllowUserToResizeRows = false;
            this.gViewItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gViewItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gViewItem.Location = new System.Drawing.Point(6, 170);
            this.gViewItem.Name = "gViewItem";
            this.gViewItem.ReadOnly = true;
            this.gViewItem.RowHeadersVisible = false;
            this.gViewItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gViewItem.RowTemplate.Height = 23;
            this.gViewItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gViewItem.Size = new System.Drawing.Size(238, 136);
            this.gViewItem.TabIndex = 12;
            this.gViewItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gViewItem_CellDoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "생산 소재";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(255, 155);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "스킬";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(82, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 12);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "label7";
            // 
            // lblRare
            // 
            this.lblRare.AutoSize = true;
            this.lblRare.Location = new System.Drawing.Point(82, 62);
            this.lblRare.Name = "lblRare";
            this.lblRare.Size = new System.Drawing.Size(38, 12);
            this.lblRare.TabIndex = 8;
            this.lblRare.Text = "label8";
            // 
            // lblSlots
            // 
            this.lblSlots.AutoSize = true;
            this.lblSlots.Location = new System.Drawing.Point(82, 89);
            this.lblSlots.Name = "lblSlots";
            this.lblSlots.Size = new System.Drawing.Size(38, 12);
            this.lblSlots.TabIndex = 9;
            this.lblSlots.Text = "label9";
            // 
            // lblPart
            // 
            this.lblPart.AutoSize = true;
            this.lblPart.Location = new System.Drawing.Point(284, 36);
            this.lblPart.Name = "lblPart";
            this.lblPart.Size = new System.Drawing.Size(44, 12);
            this.lblPart.TabIndex = 10;
            this.lblPart.Text = "label10";
            // 
            // lblDefense
            // 
            this.lblDefense.AutoSize = true;
            this.lblDefense.Location = new System.Drawing.Point(284, 68);
            this.lblDefense.Name = "lblDefense";
            this.lblDefense.Size = new System.Drawing.Size(44, 12);
            this.lblDefense.TabIndex = 11;
            this.lblDefense.Text = "label11";
            // 
            // lblResistances
            // 
            this.lblResistances.AutoSize = true;
            this.lblResistances.Location = new System.Drawing.Point(82, 116);
            this.lblResistances.Name = "lblResistances";
            this.lblResistances.Size = new System.Drawing.Size(44, 12);
            this.lblResistances.TabIndex = 15;
            this.lblResistances.Text = "label14";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(215, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "등급";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(284, 100);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(44, 12);
            this.lblLevel.TabIndex = 17;
            this.lblLevel.Text = "label14";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(483, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(218, 293);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // FrmArmorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 315);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblResistances);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.gViewItem);
            this.Controls.Add(this.lblDefense);
            this.Controls.Add(this.lblPart);
            this.Controls.Add(this.lblSlots);
            this.Controls.Add(this.lblRare);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gViewSkill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmArmorInfo";
            this.Text = "FrmArmorInfo";
            this.Load += new System.EventHandler(this.FrmArmorInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gViewSkill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gViewSkill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView gViewItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRare;
        private System.Windows.Forms.Label lblSlots;
        private System.Windows.Forms.Label lblPart;
        private System.Windows.Forms.Label lblDefense;
        private System.Windows.Forms.Label lblResistances;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}