using MonsterHunterWorld.VO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterWorld.BUS
{
    public partial class FormMonster : Form, IGetListCollection<Monster>
    {
        List<Monster> monsters;
        public FormMonster()
        {
            InitializeComponent();
        }


        private void FormMonster_Load(object sender, EventArgs e)
        {
            foreach (var item in GetListCollection())
            {
                //textBox1.Text += "인덱스: " + item.Idx + "\r\n이미지경로: " + item.Image + "\r\n이름: " + item.Name + "\r\n별명: " + item.Nick + "\r\n구분: " + item.Gubun + "\r\n수렵정보: " + item.Hunt_info + "\r\n설명: " + item.Description;
                //textBox1.Text += "\r\n속성정보: " + "\r\n화: " + item.Weakness.Fire + "\r\n물: " + item.Weakness.Water + "\r\n번개: " + item.Weakness.Thunder + "\r\n빙: " + item.Weakness.Ice + "\r\n용: " + item.Weakness.Dragon;
                //textBox1.Text += "\r\n약점정보: " + "\r\n독: " + item.Debuff.Poison + "\r\n수면: " + item.Debuff.Sleep + "\r\n마비: " + item.Debuff.Paralysis + "\r\n폭파: " + item.Debuff.Explosion + "\r\n기절: " + item.Debuff.Faint;
                //if (item.Drop_Item != null)
                //{
                //    foreach (var subitem in item.Drop_Item)
                //    {
                //        textBox1.Text += "\r\n인덱스번호: " + subitem.Idx + "\r\n아이템이름: " + subitem.Name + "\r\n레벨: " + subitem.Level + "\r\n파트: " + subitem.Part + "\r\n타입: " + subitem.Type + "\r\n서브타입: " + subitem.Subtype + "\r\n레어도: " + subitem.Rare + "\r\n판매가: " + subitem.Price;
                //    }
                //}
                //textBox1.Text += "\r\n";
            }
        }

        public IList<Monster> GetListCollection(Parameter parameter)
        {
            List<Monster> searchMonsters = new List<Monster>();
            DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

            JArray ja = JArray.Parse(api.GetJson(parameter));
            foreach (var item in ja)
            {
                Monster monster = SetMonster(item);
                searchMonsters.Add(monster);
            }
            return searchMonsters;
        }

        public IList<Monster> GetListCollection()
        {
            if (monsters == null)
            {
                monsters = new List<Monster>();
                Parameter parameter = new Parameter("monsters");
                DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

                JArray ja = JArray.Parse(api.GetJson(parameter));
                foreach (var item in ja)
                {
                    Monster monster = SetMonster(item);
                    monsters.Add(monster);
                }
            }
            return monsters;
        }

        private Monster SetMonster(JToken item)
        {
            Monster monster = new Monster();
            monster.Idx = Convert.ToInt32(item["idx"].ToString());
            monster.Image = item["image"].ToString();
            monster.Gubun = item["gubun"].ToString();
            monster.Name = item["name"].ToString();
            monster.Nick = item["nick"].ToString();
            monster.Description = item["description"].ToString();
            monster.Hunt_info = item["hunt_info"].ToString();
            monster.Location = new List<string>();
            foreach (var location in item["location"])
            {
                monster.Location.Add(location.ToString());
            }

            monster.Weakness = new Element
            {
                Fire = Convert.ToInt32(item["weakness"]["fire"].ToString()),
                Water = Convert.ToInt32(item["weakness"]["water"].ToString()),
                Thunder = Convert.ToInt32(item["weakness"]["thunder"].ToString()),
                Ice = Convert.ToInt32(item["weakness"]["ice"].ToString()),
                Dragon = Convert.ToInt32(item["weakness"]["dragon"].ToString())
            };

            monster.Debuff = new Debuff
            {
                Poison = Convert.ToInt32(item["debuff"]["poison"].ToString()),
                Sleep = Convert.ToInt32(item["debuff"]["sleep"].ToString()),
                Paralysis = Convert.ToInt32(item["debuff"]["paralysis"].ToString()),
                Explosion = Convert.ToInt32(item["debuff"]["explosion"].ToString()),
                Faint = Convert.ToInt32(item["debuff"]["faint"].ToString())
            };

            if (item["gubun"].ToString() != "환경")
            {
                monster.Drop_Item = new List<Drop_Item>();
                foreach (var drop in item["drop_items"])
                {
                    monster.Drop_Item.Add(new Drop_Item
                    {
                        Idx = Convert.ToInt32(drop["idx"].ToString()),
                        Level = drop["level"].ToString(),
                        Part = drop["part"].ToString(),
                        Difficulty = Convert.ToInt32(drop["difficulty"].ToString()),
                        Type = drop["type"].ToString(),
                        Subtype = drop["subtype"].ToString(),
                        Name = drop["name"].ToString(),
                        Description = drop["description"].ToString(),
                        Rare = Convert.ToInt32(drop["rare"].ToString()),
                        Price = Convert.ToInt32(drop["price"].ToString())
                    });
                }
            }
            return monster;
        }
    }
}
