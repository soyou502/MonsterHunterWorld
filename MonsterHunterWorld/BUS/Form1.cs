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
            //예제
            VO.Parameter parameter = new VO.Parameter("weapons/대검");
            DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();
            JArray ja = JArray.Parse(api.GetJson(parameter));
            textBox1.Text = ja.ToString();
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
    }
}
