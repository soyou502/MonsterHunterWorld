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
            //VO.Parameter parameter = new VO.Parameter("weapons/대검");
            //DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();
            //JArray ja = JArray.Parse(api.GetJson(parameter));
            //textBox1.Text = ja.ToString();

            //쥬얼폼
            //FormJewel form = new FormJewel();
            //foreach (var item in form.GetListCollection())
            //{
            //    textBox1.Text += "인덱스: " + item.Idx + "\r\n이름: " + item.Name + "\r\n레어도: " + item.Rare + "\r\n슬롯레벨: " + item.Slot_level + "\r\n";

            //    textBox1.Text += "스킬인덱스: " + item.Skill.Idx + "\r\n스킬이름: " + item.Skill.Name + "\r\n스킬타입: " + item.Skill.Type + "\r\n";
            //}

            //스킬폼
            //FormSkill form = new FormSkill();
            //foreach (var item in form.GetListCollection())
            //{
            //    textBox1.Text += "인덱스: " + item.Idx + "\r\n이름: " + item.Name + "\r\n타입: " + item.Type;
            //    foreach (var subitem in item.Desc)
            //    {
            //        textBox1.Text += "\r\n스킬이름: " + subitem.Name + "\r\n스킬레벨: " + subitem.Level + "\r\n스킬정보: " + subitem.Desc + "\r\n";
            //    }
            //    textBox1.Text += "\r\n";
            //}


            //몬스터폼
            //FormMonster form = new FormMonster();
            //foreach (var item in form.GetListCollection())
            //{
            //    textBox1.Text += "인덱스: " + item.Idx + "\r\n이미지경로: " + item.Image + "\r\n이름: " + item.Name + "\r\n별명: " + item.Nick + "\r\n구분: " + item.Gubun + "\r\n수렵정보: " + item.Hunt_info + "\r\n설명: " + item.Description;
            //    textBox1.Text += "\r\n속성정보: " + "\r\n화: " + item.Weakness.Fire + "\r\n물: " + item.Weakness.Water + "\r\n번개: " + item.Weakness.Thunder + "\r\n빙: " + item.Weakness.Ice + "\r\n용: " + item.Weakness.Dragon;
            //    textBox1.Text += "\r\n약점정보: " + "\r\n독: " + item.Debuff.Poison + "\r\n수면: " + item.Debuff.Sleep + "\r\n마비: " + item.Debuff.Paralysis + "\r\n폭파: " + item.Debuff.Explosion + "\r\n기절: " + item.Debuff.Faint;
            //    if (item.Drop_Item != null)
            //    {
            //        foreach (var subitem in item.Drop_Item)
            //        {
            //            textBox1.Text += "\r\n인덱스번호: " + subitem.Idx + "\r\n아이템이름: " + subitem.Name + "\r\n레벨: " + subitem.Level + "\r\n파트: " + subitem.Part + "\r\n타입: " + subitem.Type + "\r\n서브타입: " + subitem.Subtype + "\r\n레어도: " + subitem.Rare + "\r\n판매가: " + subitem.Price;
            //        }
            //    }
            //    textBox1.Text += "\r\n";
            //}
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FormMonster form = new FormMonster();
            form.Owner = this;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormJewel form = new FormJewel();
            form.Owner = this;
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSkill form = new FormSkill();
            form.Owner = this;
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //FormMonsterInfo form = new FormMonsterInfo();
            //form.Owner = this;
            //form.ShowDialog();
        }
    }
}
