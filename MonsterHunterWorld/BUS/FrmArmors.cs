using MonsterHunterWorld.DAO;
using MonsterHunterWorld.VO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterWorld.BUS
{
    public partial class FrmArmors : Form, IGetListCollection<Armors>
    {
        List<Armors> armors;
        public FrmArmors()
        {
            InitializeComponent();
        }
       
        private void AddArmorList(JArray ja)
        {
            foreach (var item in ja)
            {
                List<Material> items = new List<Material>();
                foreach (var item2 in item["items"])
                {
                    Material val = new Material(item2["name"].ToString(), int.Parse(item2["count"].ToString()));
                    items.Add(val);
                }
                List<ArmorSkill> skills = new List<ArmorSkill>();
                foreach (var skill in item["skills"])
                {
                    ArmorSkill val = new ArmorSkill(int.Parse(skill["idx"].ToString()), skill["name"].ToString(), int.Parse(skill["level"].ToString()), skill["type"].ToString());
                    skills.Add(val);
                }
                Armors ar = new Armors
                {
                    Idx = int.Parse(item["idx"].ToString()),
                    Set_Num = int.Parse(item["set_num"].ToString()),
                    Part_No = int.Parse(item["part_no"].ToString()),
                    SetImage = item["set_image"].ToString(),
                    Level = item["set_level"].ToString(),
                    Part = item["part"].ToString(),
                    Name = item["name"].ToString(),
                    Rare = int.Parse(item["rare"].ToString()),
                    Slots = item["slots"].ToString(),
                    Defense = int.Parse(item["defense"].ToString()),
                    Resistances = new Element
                    {
                        Fire = int.Parse(item["resistance"]["fire"].ToString()),
                        Water = int.Parse(item["resistance"]["water"].ToString()),
                        Thunder = int.Parse(item["resistance"]["thunder"].ToString()),
                        Ice = int.Parse(item["resistance"]["ice"].ToString()),
                        Dragon = int.Parse(item["resistance"]["dragon"].ToString())
                    },
                    Items = items,
                    Skills = skills
                };
                armors.Add(ar);
            }
        }

        public IList<Armors> GetListCollection()
        {
            if (armors == null)
            {
                Parameter parameter = new Parameter("armors");
                MonsterHunterAPI api = new MonsterHunterAPI();
                string json = api.GetJson(parameter);
                JArray ja = JArray.Parse(json);
                AddArmorList(ja);
            }
            return armors;
        }

        public IList<Armors> GetListCollection(Parameter parameter)
        {
            if (armors == null)
            {
                MonsterHunterAPI api = new MonsterHunterAPI();
                string json = api.GetJson(parameter);
                JArray ja = JArray.Parse(json);
                AddArmorList(ja);
            }
            return armors;
        }

        private void FrmArmors_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = armors;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
