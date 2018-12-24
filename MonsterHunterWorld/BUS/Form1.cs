using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Newtonsoft.Json.Linq;
using MonsteHunterWorld;
using MonsterHunterWorld.VO;

namespace MonsterHunterWorld.BUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + @"\Images\FormMain.jpg");
            try
            {
                Directory.CreateDirectory(Application.LocalUserAppDataPath + "/Save");
            }
            catch (Exception)
            {

            }
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.White;
        }
        private void label7_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.ForeColor = Color.Red;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblItems_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmItems items = new FrmItems(this);
            items.ShowDialog();
        }

        private void lblArmors_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmArmors armors = new FrmArmors(this);
            armors.ShowDialog();
        }



        private void lblMonsters_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormMonster monsters = new FormMonster(this);
            monsters.ShowDialog();
        }

        private void lblWeapons_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmWeaponList weaponList = new FrmWeaponList(this);
            weaponList.ShowDialog();
        }

        private void lblCharms_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmCharm charms = new FrmCharm(this);
            charms.ShowDialog();
        }

        private void lblJewels_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormJewel jewels = new FormJewel(this);
            jewels.ShowDialog();
        }

        private void lblSkillSimulator_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            FrmSimulator simulator = new FrmSimulator(this);
            simulator.ShowDialog();
        }
        private Point mousePoint;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormSkill skill = new FormSkill(this);
            skill.ShowDialog();
        }
    }
}
