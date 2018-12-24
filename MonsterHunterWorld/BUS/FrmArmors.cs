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
        static List<Armors> armors;
        Color[] color = new Color[] { Color.Gray, Color.Black, Color.LightGreen, Color.ForestGreen, Color.SkyBlue, Color.Purple, Color.HotPink, Color.Orange };
        private Form form1;

        public FrmArmors()
        {
            InitializeComponent();
        }

        public FrmArmors(Form form1) : this()
        {
            this.form1 = form1;
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
                textBox1.AutoCompleteCustomSource.Add(item["name"].ToString());
                armors.Add(ar);
            }
        }

        public IList<Armors> GetListCollection()
        {
            if (armors == null)
            {
                armors = new List<Armors>();
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
                armors = new List<Armors>();
                MonsterHunterAPI api = new MonsterHunterAPI();
                string json = api.GetJson(parameter);
                JArray ja = JArray.Parse(json);
                AddArmorList(ja);
            }
            return armors;
        }

        private void FrmArmors_Load(object sender, EventArgs e)
        {
            GetListCollection();
            dataGridView1.Columns.Add("Name", "이름");
            dataGridView1.Columns.Add("Rare", "레어도");
            dataGridView1.Columns.Add("Slots", "슬롯");
            dataGridView1.Columns.Add("Skill", "스킬");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns["Skill"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            button1_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string slots = "";
            string part = "";
            foreach (RadioButton item in groupBox1.Controls)
            {
                if (item.Checked && item.Text != "상관없음")
                {
                    slots = item.Text.Replace("_", "");
                }
                else if(item.Checked && item.Text == "상관없음")
                {
                    slots = "";
                }
            }
            foreach (RadioButton item in groupBox2.Controls)
            {
                if (item.Checked && item.Text != "상관없음")
                {
                    part = item.Text;
                }
                else if(item.Checked && item.Text == "상관없음")
                {
                    part = "";
                }
            }
            foreach (var item in armors)
            {
                if (item.Name.Contains(textBox1.Text) && item.Slots.Replace(" " , "") == slots && item.Part.Contains(part))
                {
                    string[] temp = new string[4];
                    temp[0] = item.Name;
                    temp[1] = item.Rare.ToString();
                    temp[2] = item.Slots;
                    temp[3] = "";
                    foreach (var skill in item.Skills)
                    {
                        temp[3] += skill.Name + skill.Level + "  ";
                    }
                    if (item.Skills.Count == 0)
                    {
                        temp[3] += "";
                    }
                    dataGridView1.Rows.Add(temp);
                }
            }
            SetColorPerRare();
        }

        private void SetColorPerRare()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                foreach (var item in armors)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == item.Name)
                        {
                            dataGridView1.Rows[i].Cells[0].Style.ForeColor = color[item.Rare - 1];
                        }
                    }
                }
            }
        }

        private void FrmArmors_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
