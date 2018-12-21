using HtmlAgilityPack;
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
    public partial class FormMonsterInfo : Form
    {
        VO.Monster monster;
        public FormMonsterInfo(VO.Monster monster)
        {
            InitializeComponent();
            this.monster = monster;
        }

        private void FormMonsterInfo_Load(object sender, EventArgs e)
        {
            picDetailMonster.Location = new Point((this.Width / 2) - picDetailMonster.Width/2,picDetailMonster.Location.Y);
            dropItemSort();
            DAO.MonsterInfoHtmlDAO html = new DAO.MonsterInfoHtmlDAO();
            gViewComment.DataSource = html.GetCommentTable(monster.Nick + monster.Name);
            gViewCommentSetting();
            picDetailMonster.ImageLocation = html.GetInfoImageString();
            gViewDropItem.DataSource = GetDropItemTable();
            gViewDropItemSetting();
        }

        private void dropItemSort()
        {
            (monster.Drop_Item as List<VO.Drop_Item>).Sort(new VO.Drop_Item());
            (monster.Drop_Item as List<VO.Drop_Item>).Reverse();
        }

        private void gViewDropItemSetting()
        {
            gViewDropItem.AllowUserToAddRows = false;
            gViewDropItem.AllowUserToDeleteRows = false;
            gViewDropItem.AllowUserToResizeColumns = false;
            gViewDropItem.AllowUserToResizeRows = false;
            gViewDropItem.EditMode = DataGridViewEditMode.EditProgrammatically;
            gViewDropItem.MultiSelect = false;
            gViewDropItem.ReadOnly = true;
            gViewDropItem.RowHeadersVisible = false;
            gViewDropItem.Columns[0].HeaderText = "난이도";
            gViewDropItem.Columns[1].HeaderText = "획득방법";
            gViewDropItem.Columns[2].HeaderText = "소재이름";
            gViewDropItem.Columns[3].HeaderText = "획득률";
            gViewDropItem.Columns[4].Visible = false;

            int rowHeight = gViewDropItem.Rows.GetRowsHeight(DataGridViewElementStates.Displayed);
            int colWidth = gViewDropItem.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
            gViewDropItem.Size = new Size(colWidth, rowHeight);

            gViewDropItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gViewDropItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gViewDropItem.Columns[0].Width = this.Size.Width / 4;
            gViewDropItem.Columns[1].Width = this.Size.Width / 4;
            gViewDropItem.Columns[2].Width = this.Size.Width / 4;
            foreach (DataGridViewColumn column in gViewDropItem.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable GetDropItemTable()
        {
            //레벨(상/하위) , 파트(퀘스트보수/유실물등), difi(획득난이도), idx, name
            DataTable dt = new DataTable();
            dt.Columns.Add("Level");
            dt.Columns.Add("Part");
            dt.Columns.Add("Name");
            dt.Columns.Add("Difficulty");
            dt.Columns.Add("Idx");

            foreach (var item in monster.Drop_Item)
            {
                DataRow row = dt.NewRow();
                row["Level"] = item.Level;
                row["Part"] = item.Part;
                row["Name"] = item.Name;
                row["Difficulty"] = item.DifficultyToStar();
                row["Idx"] = item.Idx;

                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        /// 코멘트 그리드뷰 기본설정값 세팅
        /// </summary>
        private void gViewCommentSetting()
        {
            gViewComment.AllowUserToAddRows = false;
            gViewComment.AllowUserToDeleteRows = false;
            gViewComment.AllowUserToResizeColumns = false;
            gViewComment.AllowUserToResizeRows = false;
            gViewComment.EditMode = DataGridViewEditMode.EditProgrammatically;
            gViewComment.MultiSelect = false;
            gViewComment.ReadOnly = true;
            gViewComment.RowHeadersVisible = false;
            //gViewComment.ColumnHeadersVisible = false;
            gViewComment.Columns[0].HeaderText = "아이디";

            gViewComment.Columns[1].HeaderText = "코멘트";
            gViewComment.Columns[2].HeaderText = "작성일";

            int rowHeight = gViewComment.Rows.GetRowsHeight(DataGridViewElementStates.Displayed);
            int colWidth = gViewComment.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
            gViewComment.Size = new Size(colWidth, rowHeight);

            gViewComment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gViewComment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gViewComment.Columns[0].Width = this.Size.Width / 5;
            gViewComment.Columns[1].Width = this.Size.Width / 2;
            gViewComment.Columns[2].Width = this.Size.Width / 10;
            foreach (DataGridViewColumn column in gViewComment.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }        
    }
}
