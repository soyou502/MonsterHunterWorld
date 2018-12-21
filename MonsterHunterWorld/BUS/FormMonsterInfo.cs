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
            DAO.MonsterInfoHtmlDAO html = new DAO.MonsterInfoHtmlDAO();
            gViewComment.DataSource = html.GetCommentTable(monster.Nick+monster.Name);
            gViewCommentSetting();
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
