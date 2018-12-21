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
        DataTable dt;
        private void FormSkill_Load(object sender, EventArgs e)
        {
            if (skills == null)
            {
                skills = GetListCollection() as List<Skill>;
            }

            dt = new DataTable("Jewel");
            for (int i = 1; i < 7; i++)
            {
                dt.Columns.Add("인덱스" + i);
                dt.Columns.Add("이름" + i);
                dt.Columns.Add("세부정보" + i);
            }

            DataRow row = dt.NewRow();
            int index = 0;
            foreach (var item in skills)
            {
                index++;
                row["인덱스" + index] = item.Idx;
                row["이름" + index] = item.Name;
                row["세부정보" + index] = item;
                if (index == 6)
                {
                    index = 0;
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                }
            }
            dataGridView1.DataSource = dt;

            for (int i = 1; i < 7; i++)
            {
                dataGridView1.Columns["이름" + i].HeaderText = "";                
                dataGridView1.Columns["인덱스" + i].Visible = false;
                dataGridView1.Columns["세부정보" + i].Visible = false;
                dataGridView1.Columns["이름" + i].Width = 150;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // SkillInfo 창 띄워주기
            // 값은 dataGridView1.Rows[e.RowIndex].Cells["스킬정보"]에서 뽑아오기
            if (e.RowIndex != -1)
            {
                int a = (e.ColumnIndex / 3 + e.RowIndex * 6);
                FormSkillInfo form = new FormSkillInfo(skills[a]);
                form.Owner = this;
                form.ShowDialog();
            }
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
    }
}
