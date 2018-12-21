namespace MonsterHunterWorld.BUS
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
<<<<<<< HEAD
            this.lblItems = new System.Windows.Forms.Label();
            this.lblArmors = new System.Windows.Forms.Label();
            this.lblMonsters = new System.Windows.Forms.Label();
            this.lblWeapons = new System.Windows.Forms.Label();
            this.lblCharms = new System.Windows.Forms.Label();
            this.lblJewels = new System.Windows.Forms.Label();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblSkillSimulator = new System.Windows.Forms.Label();
=======
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
>>>>>>> 93f2cf2ed4f929573aacbcbfc0998e800a32f7d5
            this.SuspendLayout();
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.BackColor = System.Drawing.Color.Transparent;
            this.lblItems.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItems.ForeColor = System.Drawing.Color.Red;
            this.lblItems.Location = new System.Drawing.Point(23, 30);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(71, 28);
            this.lblItems.TabIndex = 0;
            this.lblItems.Text = "Items";
            this.lblItems.Click += new System.EventHandler(this.lblItems_Click);
            this.lblItems.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // lblArmors
            // 
            this.lblArmors.AutoSize = true;
            this.lblArmors.BackColor = System.Drawing.Color.Transparent;
            this.lblArmors.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblArmors.ForeColor = System.Drawing.Color.Red;
            this.lblArmors.Location = new System.Drawing.Point(23, 83);
            this.lblArmors.Name = "lblArmors";
            this.lblArmors.Size = new System.Drawing.Size(93, 28);
            this.lblArmors.TabIndex = 1;
            this.lblArmors.Text = "Armors";
            this.lblArmors.Click += new System.EventHandler(this.lblArmors_Click);
            this.lblArmors.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblArmors.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // lblMonsters
            // 
            this.lblMonsters.AutoSize = true;
            this.lblMonsters.BackColor = System.Drawing.Color.Transparent;
            this.lblMonsters.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMonsters.ForeColor = System.Drawing.Color.Red;
            this.lblMonsters.Location = new System.Drawing.Point(23, 136);
            this.lblMonsters.Name = "lblMonsters";
            this.lblMonsters.Size = new System.Drawing.Size(114, 28);
            this.lblMonsters.TabIndex = 2;
            this.lblMonsters.Text = "Monsters";
            this.lblMonsters.Click += new System.EventHandler(this.lblMonsters_Click);
            this.lblMonsters.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblMonsters.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // lblWeapons
            // 
            this.lblWeapons.AutoSize = true;
            this.lblWeapons.BackColor = System.Drawing.Color.Transparent;
            this.lblWeapons.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWeapons.ForeColor = System.Drawing.Color.Red;
            this.lblWeapons.Location = new System.Drawing.Point(23, 189);
            this.lblWeapons.Name = "lblWeapons";
            this.lblWeapons.Size = new System.Drawing.Size(112, 28);
            this.lblWeapons.TabIndex = 3;
            this.lblWeapons.Text = "Weapons";
            this.lblWeapons.Click += new System.EventHandler(this.lblWeapons_Click);
            this.lblWeapons.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblWeapons.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // lblCharms
            // 
            this.lblCharms.AutoSize = true;
            this.lblCharms.BackColor = System.Drawing.Color.Transparent;
            this.lblCharms.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCharms.ForeColor = System.Drawing.Color.Red;
            this.lblCharms.Location = new System.Drawing.Point(23, 242);
            this.lblCharms.Name = "lblCharms";
            this.lblCharms.Size = new System.Drawing.Size(93, 28);
            this.lblCharms.TabIndex = 4;
            this.lblCharms.Text = "Charms";
            this.lblCharms.Click += new System.EventHandler(this.lblCharms_Click);
            this.lblCharms.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblCharms.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // lblJewels
            // 
            this.lblJewels.AutoSize = true;
            this.lblJewels.BackColor = System.Drawing.Color.Transparent;
            this.lblJewels.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJewels.ForeColor = System.Drawing.Color.Red;
            this.lblJewels.Location = new System.Drawing.Point(23, 295);
            this.lblJewels.Name = "lblJewels";
            this.lblJewels.Size = new System.Drawing.Size(83, 28);
            this.lblJewels.TabIndex = 5;
            this.lblJewels.Text = "Jewels";
            this.lblJewels.Click += new System.EventHandler(this.lblJewels_Click);
            this.lblJewels.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblJewels.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExit.ForeColor = System.Drawing.Color.Red;
            this.lblExit.Location = new System.Drawing.Point(23, 401);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(55, 28);
            this.lblExit.TabIndex = 6;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // lblSkillSimulator
            // 
            this.lblSkillSimulator.AutoSize = true;
            this.lblSkillSimulator.BackColor = System.Drawing.Color.Transparent;
            this.lblSkillSimulator.Font = new System.Drawing.Font("이순신 Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSkillSimulator.ForeColor = System.Drawing.Color.Red;
            this.lblSkillSimulator.Location = new System.Drawing.Point(23, 348);
            this.lblSkillSimulator.Name = "lblSkillSimulator";
            this.lblSkillSimulator.Size = new System.Drawing.Size(160, 28);
            this.lblSkillSimulator.TabIndex = 7;
            this.lblSkillSimulator.Text = "SkillSimulator";
            this.lblSkillSimulator.Click += new System.EventHandler(this.lblSkillSimulator_Click);
            this.lblSkillSimulator.MouseLeave += new System.EventHandler(this.label7_MouseLeave);
            this.lblSkillSimulator.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label7_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(255, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(319, 204);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MonsterHunterWorld.Properties.Resources._001;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
<<<<<<< HEAD
            this.Controls.Add(this.lblSkillSimulator);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblJewels);
            this.Controls.Add(this.lblCharms);
            this.Controls.Add(this.lblWeapons);
            this.Controls.Add(this.lblMonsters);
            this.Controls.Add(this.lblArmors);
            this.Controls.Add(this.lblItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
=======
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
>>>>>>> 93f2cf2ed4f929573aacbcbfc0998e800a32f7d5
            this.ResumeLayout(false);

        }

        #endregion

<<<<<<< HEAD
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblArmors;
        private System.Windows.Forms.Label lblMonsters;
        private System.Windows.Forms.Label lblWeapons;
        private System.Windows.Forms.Label lblCharms;
        private System.Windows.Forms.Label lblJewels;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblSkillSimulator;
=======
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
>>>>>>> 93f2cf2ed4f929573aacbcbfc0998e800a32f7d5
    }
}

