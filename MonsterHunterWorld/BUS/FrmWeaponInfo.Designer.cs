namespace MonsterHunterWorld.BUS
{
    partial class FrmWeaponInfo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.weapon_pictur = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_deValue = new System.Windows.Forms.Label();
            this.lbl_eleValue = new System.Windows.Forms.Label();
            this.lbl_Slots = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_debuf = new System.Windows.Forms.Label();
            this.lbl_defen = new System.Windows.Forms.Label();
            this.lbl_rare = new System.Windows.Forms.Label();
            this.lbl_der = new System.Windows.Forms.Label();
            this.lbl_criti = new System.Windows.Forms.Label();
            this.lbl_ele = new System.Windows.Forms.Label();
            this.lbl_att = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_type = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_sangsan = new System.Windows.Forms.Label();
            this.lbl_jejak = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.weapon_pictur)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // weapon_pictur
            // 
            this.weapon_pictur.Location = new System.Drawing.Point(12, 12);
            this.weapon_pictur.Name = "weapon_pictur";
            this.weapon_pictur.Size = new System.Drawing.Size(240, 256);
            this.weapon_pictur.TabIndex = 0;
            this.weapon_pictur.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "파생";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "레어도";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "추가 방어";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(280, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "상태이상";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart1);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lbl_deValue);
            this.panel2.Controls.Add(this.lbl_eleValue);
            this.panel2.Controls.Add(this.lbl_Slots);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lbl_debuf);
            this.panel2.Controls.Add(this.lbl_defen);
            this.panel2.Controls.Add(this.lbl_rare);
            this.panel2.Controls.Add(this.lbl_der);
            this.panel2.Controls.Add(this.lbl_criti);
            this.panel2.Controls.Add(this.lbl_ele);
            this.panel2.Controls.Add(this.lbl_att);
            this.panel2.Controls.Add(this.lbl_name);
            this.panel2.Controls.Add(this.lbl_type);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(261, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(527, 258);
            this.panel2.TabIndex = 17;
            // 
            // chart1
            // 
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(77, 185);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(428, 70);
            this.chart1.TabIndex = 26;
            this.chart1.Text = "chart1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "예리도";
            // 
            // lbl_deValue
            // 
            this.lbl_deValue.AutoSize = true;
            this.lbl_deValue.Location = new System.Drawing.Point(446, 120);
            this.lbl_deValue.Name = "lbl_deValue";
            this.lbl_deValue.Size = new System.Drawing.Size(44, 12);
            this.lbl_deValue.TabIndex = 24;
            this.lbl_deValue.Text = "label19";
            // 
            // lbl_eleValue
            // 
            this.lbl_eleValue.AutoSize = true;
            this.lbl_eleValue.Location = new System.Drawing.Point(188, 121);
            this.lbl_eleValue.Name = "lbl_eleValue";
            this.lbl_eleValue.Size = new System.Drawing.Size(53, 12);
            this.lbl_eleValue.TabIndex = 23;
            this.lbl_eleValue.Text = "속성수치";
            // 
            // lbl_Slots
            // 
            this.lbl_Slots.AutoSize = true;
            this.lbl_Slots.Location = new System.Drawing.Point(351, 156);
            this.lbl_Slots.Name = "lbl_Slots";
            this.lbl_Slots.Size = new System.Drawing.Size(41, 12);
            this.lbl_Slots.TabIndex = 22;
            this.lbl_Slots.Text = "슬롯수";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(289, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "슬롯수";
            // 
            // lbl_debuf
            // 
            this.lbl_debuf.AutoSize = true;
            this.lbl_debuf.Location = new System.Drawing.Point(351, 120);
            this.lbl_debuf.Name = "lbl_debuf";
            this.lbl_debuf.Size = new System.Drawing.Size(44, 12);
            this.lbl_debuf.TabIndex = 20;
            this.lbl_debuf.Text = "label19";
            // 
            // lbl_defen
            // 
            this.lbl_defen.AutoSize = true;
            this.lbl_defen.Location = new System.Drawing.Point(351, 88);
            this.lbl_defen.Name = "lbl_defen";
            this.lbl_defen.Size = new System.Drawing.Size(44, 12);
            this.lbl_defen.TabIndex = 19;
            this.lbl_defen.Text = "label20";
            // 
            // lbl_rare
            // 
            this.lbl_rare.AutoSize = true;
            this.lbl_rare.Location = new System.Drawing.Point(351, 50);
            this.lbl_rare.Name = "lbl_rare";
            this.lbl_rare.Size = new System.Drawing.Size(44, 12);
            this.lbl_rare.TabIndex = 18;
            this.lbl_rare.Text = "label18";
            // 
            // lbl_der
            // 
            this.lbl_der.AutoSize = true;
            this.lbl_der.Location = new System.Drawing.Point(351, 18);
            this.lbl_der.Name = "lbl_der";
            this.lbl_der.Size = new System.Drawing.Size(44, 12);
            this.lbl_der.TabIndex = 17;
            this.lbl_der.Text = "label17";
            // 
            // lbl_criti
            // 
            this.lbl_criti.AutoSize = true;
            this.lbl_criti.Location = new System.Drawing.Point(105, 156);
            this.lbl_criti.Name = "lbl_criti";
            this.lbl_criti.Size = new System.Drawing.Size(44, 12);
            this.lbl_criti.TabIndex = 16;
            this.lbl_criti.Text = "label16";
            // 
            // lbl_ele
            // 
            this.lbl_ele.AutoSize = true;
            this.lbl_ele.Location = new System.Drawing.Point(105, 121);
            this.lbl_ele.Name = "lbl_ele";
            this.lbl_ele.Size = new System.Drawing.Size(53, 12);
            this.lbl_ele.TabIndex = 15;
            this.lbl_ele.Text = "속성타입";
            // 
            // lbl_att
            // 
            this.lbl_att.AutoSize = true;
            this.lbl_att.Location = new System.Drawing.Point(105, 88);
            this.lbl_att.Name = "lbl_att";
            this.lbl_att.Size = new System.Drawing.Size(44, 12);
            this.lbl_att.TabIndex = 14;
            this.lbl_att.Text = "label14";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(105, 50);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(44, 12);
            this.lbl_name.TabIndex = 13;
            this.lbl_name.Text = "label12";
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(105, 18);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(44, 12);
            this.lbl_type.TabIndex = 12;
            this.lbl_type.Text = "label11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "구분";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "공격력";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "무기 속성";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "회심률";
            // 
            // lbl_sangsan
            // 
            this.lbl_sangsan.AutoSize = true;
            this.lbl_sangsan.Location = new System.Drawing.Point(10, 283);
            this.lbl_sangsan.Name = "lbl_sangsan";
            this.lbl_sangsan.Size = new System.Drawing.Size(29, 12);
            this.lbl_sangsan.TabIndex = 10;
            this.lbl_sangsan.Text = "생산";
            // 
            // lbl_jejak
            // 
            this.lbl_jejak.AutoSize = true;
            this.lbl_jejak.Location = new System.Drawing.Point(390, 283);
            this.lbl_jejak.Name = "lbl_jejak";
            this.lbl_jejak.Size = new System.Drawing.Size(29, 12);
            this.lbl_jejak.TabIndex = 23;
            this.lbl_jejak.Text = "제작";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(372, 150);
            this.dataGridView1.TabIndex = 24;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(390, 298);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(376, 150);
            this.dataGridView2.TabIndex = 25;
            // 
            // FrmWeaponInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbl_jejak);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.weapon_pictur);
            this.Controls.Add(this.lbl_sangsan);
            this.Name = "FrmWeaponInfo";
            this.Text = "무기상세정보";
            this.Load += new System.EventHandler(this.FrmWeaponInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.weapon_pictur)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox weapon_pictur;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lbl_sangsan;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lbl_debuf;
        public System.Windows.Forms.Label lbl_defen;
        public System.Windows.Forms.Label lbl_rare;
        public System.Windows.Forms.Label lbl_der;
        public System.Windows.Forms.Label lbl_criti;
        public System.Windows.Forms.Label lbl_ele;
        public System.Windows.Forms.Label lbl_att;
        public System.Windows.Forms.Label lbl_name;
        public System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lbl_Slots;
        public System.Windows.Forms.Label lbl_jejak;
        public System.Windows.Forms.Label lbl_deValue;
        public System.Windows.Forms.Label lbl_eleValue;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridView dataGridView2;
    }
}