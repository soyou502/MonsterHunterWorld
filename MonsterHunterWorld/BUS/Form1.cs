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
            FrmItems items = new FrmItems();
            items.Location = this.Location;
            items.Show();
        }

        private void lblArmors_Click(object sender, EventArgs e)
        {
            FrmArmors armors = new FrmArmors();
            armors.Location = this.Location;
            armors.Show();
        }

        private void lblMonsters_Click(object sender, EventArgs e)
        {
            FormMonster monsters = new FormMonster();
            monsters.Location = this.Location;
            monsters.Show();
        }

        private void lblWeapons_Click(object sender, EventArgs e)
        {
            FrmWeaponList weaponList = new FrmWeaponList();
            weaponList.Location = this.Location;
            weaponList.Show();
        }

        private void lblCharms_Click(object sender, EventArgs e)
        {
            FrmCharm charms = new FrmCharm();
            charms.Location = this.Location;
            charms.Show();
        }

        private void lblJewels_Click(object sender, EventArgs e)
        {
            FormJewel jewels = new FormJewel();
            jewels.Location = this.Location;
            jewels.Show();
        }

        private void lblSkillSimulator_Click(object sender, EventArgs e)
        {
            FrmSimulator simulator = new FrmSimulator();
            simulator.Location = this.Location;
            simulator.Show();
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
<<<<<<< HEAD
            mousePoint = new Point(e.X, e.Y);
=======
            //FormMonsterInfo form = new FormMonsterInfo();
            //form.Owner = this;
            //form.ShowDialog();
>>>>>>> 93f2cf2ed4f929573aacbcbfc0998e800a32f7d5
        }
    }
}
