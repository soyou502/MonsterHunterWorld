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
    public partial class FormMonster : Form, IGetListCollection<VO.Monster>
    {
        List<Monster> monsters;
        public FormMonster()
        {
            InitializeComponent();
        }


        private void FormMonster_Load(object sender, EventArgs e)
        {

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


            try
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
            catch (NullReferenceException) { }
            creturn monster;
        }
    }
}
