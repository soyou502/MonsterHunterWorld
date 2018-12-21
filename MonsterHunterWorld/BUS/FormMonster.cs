using MonsterHunterWorld.VO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterHunterWorld.BUS
{
    public partial class FormMonster : Form, IGetListCollection<Monster>
    {
        List<Monster> monsters;
        Form Form;
        public FormMonster()
        {
            InitializeComponent();
        }
        public FormMonster(Form Form) : this()
        {
            this.Form = Form;
        }

        private void FormMonster_Load(object sender, EventArgs e)
        {
            Monster dd = new Monster();
            DataTable dt = new DataTable();
            dt.Columns.Add("Image", typeof(Image));
            dt.Columns.Add("Nick");
            dt.Columns.Add("Name");
            dt.Columns.Add("Weaknees");
            dt.Columns.Add("Debuff");
            dt.Columns.Add("Idx", typeof(Int32));
            foreach (var item in GetListCollection())
            {
                DataRow row = dt.NewRow();
                row["Image"] = item.Image;
                row["Nick"] = item.Nick;
                row["Name"] = item.Name;
                row["Weaknees"] = item.Weakness.ToString();
                row["Debuff"] = item.Debuff.ToString();
                row["Idx"] = item.Idx;
                dt.Rows.Add(row);
            }
            gViewMonster.DataSource = dt;
            gViewMonsterSetting();
        }

        private void gViewMonsterSetting()
        {
            gViewMonster.AllowUserToAddRows = false;
            gViewMonster.AllowUserToDeleteRows = false;
            gViewMonster.AllowUserToResizeColumns = false;
            gViewMonster.AllowUserToResizeRows = false;
            gViewMonster.EditMode = DataGridViewEditMode.EditProgrammatically;
            gViewMonster.MultiSelect = false;
            gViewMonster.ReadOnly = true;
            gViewMonster.RowHeadersVisible = false;
            //gViewComment.ColumnHeadersVisible = false;

            gViewMonster.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gViewMonster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //gViewMonster.Columns[0].Width = this.Size.Width / 5;
            //gViewMonster.Columns[1].Width = this.Size.Width / 2;
            //gViewMonster.Columns[2].Width = this.Size.Width / 10;
            foreach (DataGridViewColumn column in gViewMonster.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            gViewMonster.Columns["Idx"].Visible = false;
            gViewMonster.Columns["Image"].Width = 110;
            gViewMonster.Columns["Weaknees"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gViewMonster.Columns["Debuff"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            gViewMonster.Columns["Image"].HeaderText = "아이콘";
            gViewMonster.Columns["Nick"].HeaderText = "별명";
            gViewMonster.Columns["Name"].HeaderText = "이름";
            gViewMonster.Columns["Weaknees"].HeaderText = "유효속성";
            gViewMonster.Columns["Debuff"].HeaderText = "상태이상";

            int rowHeight = gViewMonster.Rows.GetRowsHeight(DataGridViewElementStates.Displayed);
            int colWidth = gViewMonster.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
            gViewMonster.Size = new Size(colWidth, rowHeight);
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
                    if (item["gubun"].ToString() != "환경" && item["gubun"].ToString() != "소형")
                    {
                        Monster monster = SetMonster(item);
                        monsters.Add(monster);
                    }
                }
            }
            return monsters;
        }

        /// <summary>
        /// 제이슨토큰을 파싱하여 하나의 Monster 객체를 반환하는 메서드
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Monster SetMonster(JToken item)
        {
            Monster monster = new Monster();
            monster.Idx = Convert.ToInt32(item["idx"].ToString());
            monster.Gubun = item["gubun"].ToString();

            WebRequest request = WebRequest.Create(item["image"].ToString());
            WebResponse response = request.GetResponse();
            Image originImage = Image.FromStream(response.GetResponseStream());
            monster.Image = ReSizeImage(originImage, new Size(110, 110));

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

            return monster;
        }

        /// <summary>
        /// 이미지 리사이즈 메서드
        /// </summary>
        /// <param name="originImage"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private Image ReSizeImage(Image originImage, Size size)
        {
            Image resizeImage = new Bitmap(originImage, size);
            return resizeImage;
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < gViewMonster.RowCount &&
        columnIndex >= 0 && columnIndex <= gViewMonster.ColumnCount;
        }

        private void gViewMonster_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && e.ColumnIndex == 0)
            {
                gViewMonster.Cursor = Cursors.Hand;
                //monsterInfoToolTip.Show(gViewMonster.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),);
            }
        }

        private void gViewMonster_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && e.ColumnIndex == 0)
            {
                gViewMonster.Cursor = Cursors.Default;
            }
        }

        private void gViewMonster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                int index = Convert.ToInt32(gViewMonster.Rows[e.RowIndex].Cells["Idx"].Value);
                foreach (var item in GetListCollection())
                {
                    if (item.Idx == index)
                    {
                        FormMonsterInfo monsterInfo = new FormMonsterInfo(item);
                        monsterInfo.ShowDialog();
                        return;
                    }
                }

            }
        }

        private void gViewMonster_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }
    }
}
