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



        private void button1_Click(object sender, EventArgs e)
        {
            FormMonster form = new FormMonster();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmWeaponList fwl = new FrmWeaponList();
            fwl.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmArmors fa = new FrmArmors();
            fa.Location = this.Location;
            fa.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmItems fi = new FrmItems();
            fi.Location = this.Location;
            fi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            FrmLogin fl = new FrmLogin();
            fl.Location = this.Location;
            fl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmCharm fc = new FrmCharm();
            fc.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmSimulator fs = new FrmSimulator();
            fs.ShowDialog();
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
            items.Show();
        }

        private void lblArmors_Click(object sender, EventArgs e)
        {
            FrmArmors armors = new FrmArmors();
            armors.Show();
        }

        private void lblMonsters_Click(object sender, EventArgs e)
        {
            FormMonster monsters = new FormMonster();
            monsters.Show();
        }

        private void lblWeapons_Click(object sender, EventArgs e)
        {
            FrmWeaponList weaponList = new FrmWeaponList();
            weaponList.Show();
        }

        private void lblCharms_Click(object sender, EventArgs e)
        {
            FrmCharm charms = new FrmCharm();
            charms.Show();
        }

        private void lblJewels_Click(object sender, EventArgs e)
        {
            FormJewel jewels = new FormJewel();
            jewels.Show();
        }

        private void lblSkillSimulator_Click(object sender, EventArgs e)
        {
            FrmSimulator simulator = new FrmSimulator();
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
            mousePoint = new Point(e.X, e.Y);
        }
    }
}
