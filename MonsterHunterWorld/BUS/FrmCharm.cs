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
        private Form form1;
        FormSkill skill;
        public FrmCharm()
        {
            InitializeComponent();
        }

        public FrmCharm(Form form1) : this()
        {
            this.form1 = form1;
            skill = new FormSkill();
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
                        str[2] += skill.Name + ", ";
                    }
                    if (str[2].Length > 2)
                    {
                        str[2] = str[2].Remove(str[2].Length - 2, 2); 
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
            this.Location = form1.Location;
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
                this.Visible = false;
                FrmItemInfo fii = new FrmItemInfo(dataGridView1.SelectedCells[0].Value.ToString(), this);
                fii.ShowDialog();
            }
            if (e.ColumnIndex == 2)
            {
                string skilldesc = "";
                if (e.RowIndex != -1)
                {
                    foreach (var item in skill.GetListCollection())
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells["skill"].Value.ToString().Contains(item.Name))
                        {
                            foreach (var desc in item.Desc)
                            {
                                skilldesc +=item.Name +  " Lv" + desc.Level + " " + desc.Desc + Environment.NewLine;
                            }
                        }
                    }
                    MessageBox.Show(skilldesc);
                }
            }
        }

        private void FrmCharm_FormClosed(object sender, FormClosedEventArgs e)
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
