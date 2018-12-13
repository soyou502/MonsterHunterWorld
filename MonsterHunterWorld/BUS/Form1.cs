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
            //Parameter parameter = new Parameter("items");
            //parameter.Name = "가마루코인";
            //JArray ja = JArray.Parse(GetJson(parameter));          
        }    

        

        private void button1_Click(object sender, EventArgs e)
        {
            FormMonster form = new FormMonster();
            form.Owner = this;
            form.Show();
        }
    }
}
