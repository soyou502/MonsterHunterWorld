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
            form.Owner = this;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmWeaponList fwl = new FrmWeaponList();
            fwl.Show();
        }
    }
}
