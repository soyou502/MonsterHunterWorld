using MonsteHunterWorld;
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
    public partial class FrmCharm : Form, IGetListCollection<Charm>
    {
        static List<Charm> charms;
        public FrmCharm()
        {
            InitializeComponent();
        }

        public IList<Charm> GetListCollection()
        {
            if (charms == null)
            {
                charms = new List<Charm>();
                Parameter parameter = new Parameter("charms");
                MonsterHunterAPI api = new MonsterHunterAPI();
                string json = api.GetJson(parameter);
                JArray ja = JArray.Parse(json);
                foreach (var item in ja)
                {
                    List<Material> materials = new List<Material>();
                    List<ArmorSkill> skills = new List<ArmorSkill>();
                    foreach (var material in item["items"])
                    {
                        materials.Add(new Material(material["name"].ToString(), int.Parse(material["count"].ToString())));
                    }
                    foreach (var skill in item["skills"])
                    {
                        skills.Add(new ArmorSkill(int.Parse(skill["idx"].ToString()), skill["name"].ToString(), 0, skill["type"].ToString()));
                    }
                    Charm temp = new Charm(int.Parse(item["idx"].ToString()), item["name"].ToString(), int.Parse(item["max_level"].ToString()), materials, skills);
                    charms.Add(temp);
                }
            }
            return charms;
        }

        public IList<Charm> GetListCollection(Parameter parameter)
        {
            if (charms == null)
            {
                charms = new List<Charm>();
                MonsterHunterAPI api = new MonsterHunterAPI();
                string json = api.GetJson(parameter);
                JArray ja = JArray.Parse(json);
                foreach (var item in ja)
                {
                    List<Material> materials = new List<Material>();
                    List<ArmorSkill> skills = new List<ArmorSkill>();
                    foreach (var material in item["items"])
                    {
                        materials.Add(new Material(material["name"].ToString(), int.Parse(material["count"].ToString())));
                    }
                    foreach (var skill in item["skills"])
                    {
                        skills.Add(new ArmorSkill(int.Parse(skill["idx"].ToString()), skill["name"].ToString(), 0, skill["type"].ToString()));
                    }
                    textBox1.AutoCompleteCustomSource.Add(item["name"].ToString());
                    Charm temp = new Charm(int.Parse(item["idx"].ToString()), item["name"].ToString(), int.Parse(item["max_level"].ToString()), materials, skills);
                    charms.Add(temp);
                }
            }
            return charms;
        }
        public void CharmList()
        {
            for (int i = 0; i < charms.Count; i++)
            {

                int materialIndex = 0;
                for (int j = 0; j < charms[i].Max_level; j++)
                {
                    string[] str = new string[8];
                    str[0] = charms[i].Name;
                    str[1] = (j + 1).ToString();
                    foreach (var skill in charms[i].Skills)
                    {
                        str[2] += skill.Name;
                    }
                    if (charms[i].Items.Count != 0 && materialIndex < charms[i].Items.Count - 1)
                    {
                        for (int k = 3; k < 7; k++)
                        {
                            str[k] = charms[i].Items[materialIndex].Name + " x" + charms[i].Items[materialIndex].Count;
                            if (materialIndex >= charms[i].Items.Count - 1)
                            {
                                continue;
                            }
                            else
                            {
                                materialIndex++;
                            }
                        }
                        materialIndex++;
                    }
                    dataGridView1.Rows.Add(str);
                }

            }
        }
        private void FrmCharm_Load(object sender, EventArgs e)
        {
            GetListCollection();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dataGridView1.Columns.Add("name", "이름");
            dataGridView1.Columns.Add("level", "레벨");
            dataGridView1.Columns.Add("skill", "스킬");
            dataGridView1.Columns.Add("material1", "재료1");
            dataGridView1.Columns.Add("material2", "재료2");
            dataGridView1.Columns.Add("material3", "재료3");
            dataGridView1.Columns.Add("material4", "재료4");
            dataGridView1.Columns["level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            CharmList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 3 && e.ColumnIndex <= 6)
            {
                FrmItemInfo fii = new FrmItemInfo(dataGridView1.SelectedCells[0].Value.ToString());
                fii.ShowDialog();
            }
        }
    }
}
