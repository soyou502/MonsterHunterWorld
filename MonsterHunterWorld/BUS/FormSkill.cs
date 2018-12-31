using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonsterHunterWorld.VO;
using Newtonsoft.Json.Linq;

namespace MonsterHunterWorld.BUS
{
    public partial class FormSkill : Form, IGetListCollection<VO.Skill>
    {
        static List<Skill> skills;
        public FormSkill()
        {
            InitializeComponent();
        }

        public FormSkill(Form1 form1) : this()
        {
            this.form1 = form1;
        }

        public IList<Skill> GetListCollection()
        {
            if (skills == null)
            {
                skills = new List<Skill>();
                VO.Parameter parameter = new Parameter("skills");
                DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

                JArray ja = JArray.Parse(api.GetJson(parameter));
                foreach (var item in ja)
                {
                    Skill skill = SetSkill(item);
                    skills.Add(skill);
                }
            }
            return skills;
        }

        public IList<Skill> GetListCollection(Parameter parameter)
        {
            List<Skill> searchSkills = new List<Skill>();
            DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

            JArray ja = JArray.Parse(api.GetJson(parameter));
            foreach (var item in ja)
            {
                Skill skill = SetSkill(item);
                skills.Add(skill);
            }
            return searchSkills;
        }

        private Skill SetSkill(JToken item)
        {
            Skill skill = new Skill();
            skill.Idx = Convert.ToInt32(item["idx"].ToString());
            skill.Name = item["name"].ToString();
            skill.Type = item["type"].ToString();
            skill.Desc = new List<SkillDesc>();
            foreach (var subitem in item["desc"])
            {
                SkillDesc desc = new SkillDesc();
                desc.Name = subitem["name"].ToString();
                desc.Level = Convert.ToInt32(subitem["level"].ToString());
                desc.Desc = subitem["desc"].ToString();
                skill.Desc.Add(desc);
            }
            return skill;
        }


        private void FormSkill_Load(object sender, EventArgs e)
        {
            this.Location = form1.Location;
            if (skills == null)
            {
                skills = GetListCollection() as List<Skill>;
            }
            foreach (var item in skills)
            {
                txtSearch.AutoCompleteCustomSource.Add(item.Name);
            }
            gViewSkillDataSet(skills);
        }

        private void gViewSkillDataSet(List<Skill> skill)
        {
            gViewSkills.DataSource = GetDataTable(skill);            
            gViewSkillSetting();
        }

        private void gViewSkillSetting()
        {
            gViewSkills.AllowUserToAddRows = false;
            gViewSkills.AllowUserToDeleteRows = false;
            gViewSkills.AllowUserToResizeColumns = false;
            gViewSkills.AllowUserToResizeRows = false;
            gViewSkills.EditMode = DataGridViewEditMode.EditProgrammatically;
            gViewSkills.MultiSelect = false;
            gViewSkills.ReadOnly = true;
            gViewSkills.RowHeadersVisible = false;
            gViewSkills.Columns[0].HeaderText = "스킬명";
            gViewSkills.Columns[1].HeaderText = "효과";
            gViewSkills.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            gViewSkills.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gViewSkills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gViewSkills.Columns[0].Width = gViewSkills.Width / 5;
        }
        private DataTable GetDataTable(List<Skill> skill)
        {
            DataTable dt = new DataTable("Skill");
            dt.Columns.Add("이름");
            dt.Columns.Add("세부정보");
            foreach (var item in skill)
            {
                DataRow row = dt.NewRow();
                row["이름"] = item.Name;
                foreach (var subitem in item.Desc)
                {
                    row["세부정보"] += subitem.Name + " : " + subitem.Desc + "\r\n";
                }
                string str = row["세부정보"].ToString();
                row["세부정보"] = str.Remove(str.Length - 2);
                dt.Rows.Add(row);
            }
            return dt;
        }

        private Point mousePoint;
        private Form1 form1;
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

        private void FormSkill_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<Skill> skill = new List<Skill>();
            if (!(checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked || checkBox6.Checked || checkBox7.Checked))
            {
                GetSearchTextSkills(skills);
            }
            else
            {
                skill = GetCheckedSkills(skill);
                GetSearchTextSkills(skill);
            }
        }

        private void GetSearchTextSkills(List<Skill> skillList)
        {
            List<Skill> skill = new List<Skill>();
            if (!String.IsNullOrEmpty(txtSearch.Text))
            {
                foreach (var item in skillList)
                {
                    if (item.Name.Contains(txtSearch.Text))
                    {
                        skill.Add(item);
                    }
                }
                gViewSkillDataSet(skill);
            }
            else
            {
                gViewSkillDataSet(skillList);
            }
        }

        private List<Skill> GetCheckedSkills(List<Skill> skill)
        {
            if (checkBox1.Checked)
            {
                foreach (var item in skills)
                {
                    if (item.Idx > 101 && item.Idx < 140)
                    {
                        skill.Add(item);
                    }
                }
            }
            if (checkBox2.Checked)
            {
                foreach (var item in skills)
                {
                    if (item.Idx > 90 && item.Idx < 102)
                    {
                        skill.Add(item);
                    }
                }
            }
            if (checkBox3.Checked)
            {
                foreach (var item in skills)
                {
                    if (item.Idx > 88 && item.Idx < 91)
                    {
                        skill.Add(item);
                    }
                }
            }
            if (checkBox4.Checked)
            {
                foreach (var item in skills)
                {
                    if (item.Idx > 64 && item.Idx < 89)
                    {
                        skill.Add(item);
                    }
                }
            }
            if (checkBox5.Checked)
            {
                foreach (var item in skills)
                {
                    if (item.Idx > 43 && item.Idx < 65)
                    {
                        skill.Add(item);
                    }
                }
            }
            if (checkBox6.Checked)
            {
                foreach (var item in skills)
                {
                    if (item.Idx > 21 && item.Idx < 44)
                    {
                        skill.Add(item);
                    }
                }
            }
            if (checkBox7.Checked)
            {
                foreach (var item in skills)
                {
                    if (item.Idx > 1 && item.Idx < 22)
                    {
                        skill.Add(item);
                    }
                }
            }
            return skill;
        }

        private void checkBox_CheckedChange(object sender, EventArgs e)
        {
            txtSearch_TextChanged(null, null);
        }
    }
}
