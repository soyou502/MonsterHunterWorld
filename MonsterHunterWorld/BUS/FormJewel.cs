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
    public partial class FormJewel : Form, IGetListCollection<VO.Jewel>
    {
        static List<VO.Jewel> jewels;
        private Form form1;

        public FormJewel()
        {
            InitializeComponent();
        }

        public FormJewel(Form form1) : this()
        {
            this.form1 = form1;
        }

        public IList<Jewel> GetListCollection(Parameter parameter)
        {
            List<Jewel> searchJewels = new List<Jewel>();
            DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

            JArray ja = JArray.Parse(api.GetJson(parameter));
            foreach (var item in ja)
            {
                Jewel jewel = SetJewel(item);
                searchJewels.Add(jewel);
            }

            return searchJewels;
        }

        public IList<Jewel> GetListCollection()
        {
            if (jewels == null)
            {
                jewels = new List<Jewel>();
                Parameter parameter = new Parameter("jewels");
                DAO.MonsterHunterAPI api = new DAO.MonsterHunterAPI();

                JArray ja = JArray.Parse(api.GetJson(parameter));
                foreach (var item in ja)
                {
                    Jewel jewel = SetJewel(item);
                    jewels.Add(jewel);
                }
            }
            return jewels;
        }

        private Jewel SetJewel(JToken item)
        {
            Jewel jewel = new Jewel();
            jewel.Idx = Convert.ToInt32(item["idx"].ToString());
            jewel.Name = item["name"].ToString();
            jewel.Slot_level = Convert.ToInt32(item["slot_level"].ToString());
            jewel.Rare = Convert.ToInt32(item["rare"].ToString());
            jewel.Skill = new Skill(Convert.ToInt32(item["skill"]["idx"].ToString()), item["skill"]["name"].ToString(), item["skill"]["type"].ToString());
            return jewel;
        }

        private void FormJewel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Jewel");
            dt.Columns.Add("인덱스");
            dt.Columns.Add("이름");
            dt.Columns.Add("슬롯레벨");
            dt.Columns.Add("레어도");
            dt.Columns.Add("스킬");
            dt.Columns.Add("스킬정보");
            foreach (var item in GetListCollection())
            {
                DataRow row = dt.NewRow();
                row["인덱스"] = item.Idx;
                row["이름"] = item.Name;
                row["슬롯레벨"] = item.Slot_level;
                row["레어도"] = item.Rare;
                row["스킬"] = item.Skill.Name;
                row["스킬정보"] = item.Skill.Idx;
                dt.Rows.Add(row);
            }
            gViewJewels.DataSource = dt;
            gViewJewels.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gViewJewels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gViewJewels.Columns["인덱스"].Visible = false;
            gViewJewels.Columns["스킬정보"].Visible = false;

            gViewJewels.Columns["슬롯레벨"].Width = 80;
            gViewJewels.Columns["레어도"].Width = 70;
            gViewJewels.Columns["스킬"].Width = 140;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                FormSkill form = new FormSkill();
                foreach (var item in form.GetListCollection())
                {
                    if (item.Idx == Convert.ToInt32(gViewJewels.Rows[e.RowIndex].Cells["스킬정보"].Value))
                    {
                        FormSkillInfo ff = new FormSkillInfo(item);
                        ff.Show();
                        return;
                    }
                }
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

        private void FormJewel_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gViewJewels_SelectionChanged(object sender, EventArgs e)
        {
            gViewJewels.ClearSelection();
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < gViewJewels.RowCount &&
        columnIndex >= 0 && columnIndex <= gViewJewels.ColumnCount;
        }

        private void gViewJewels_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && e.ColumnIndex == 2)
            {
                gViewJewels.Cursor = Cursors.Hand;
            }
        }

        private void gViewJewels_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && e.ColumnIndex == 2)
            {
                gViewJewels.Cursor = Cursors.Default;
            }
        }
    }
}
