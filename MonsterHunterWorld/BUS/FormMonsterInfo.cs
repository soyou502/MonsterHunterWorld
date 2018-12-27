using HtmlAgilityPack;
using MonsteHunterWorld;
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
        private bool mouseDown = false;
        private Point lastLocation;

        VO.Monster monster;

        public FormMonsterInfo(VO.Monster monster)
        {
            InitializeComponent();
            this.monster = monster;
        }

        private void FormMonsterInfo_Load(object sender, EventArgs e)
        {
            // 폼 띄우는 위치 윈도우 화면 정중앙
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - (this.Size.Height / 2) - 10);

            labMonsterName.Parent = picBar;
            labMonsterName.BackColor = Color.Transparent;
            labMonsterName.Text = monster.Nick + " " + monster.Name;

            picDropTab.ImageLocation = Application.StartupPath + @"\Images\itemInfo.png";
            picCommentTab.ImageLocation = Application.StartupPath + @"\Images\com.png";
            this.BackColor = Color.White;

            dropItemSort();

            DAO.MonsterInfoHtmlDAO html = new DAO.MonsterInfoHtmlDAO();
            gViewComment.DataSource = html.GetCommentTable(monster.Nick + monster.Name);
            gViewCommentSetting();
            picDetailMonster.ImageLocation = html.GetInfoImageString();
            gViewDropItem.DataSource = GetDropItemTable();
            gViewDropItemSetting();
            MergeCellsInColumn(1, 0, gViewDropItem.Rows.Count-1);

            gViewDropItem.Invalidate();
        }

        /// <summary>
        /// 드랍아이템리스트를 정렬하는 메서드
        /// </summary>
        private void dropItemSort()
        {
            (monster.Drop_Item as List<VO.Drop_Item>).Sort(new VO.Drop_Item());
            (monster.Drop_Item as List<VO.Drop_Item>).Reverse();
        }

        /// <summary>
        /// 드랍아이템 그리드뷰의 기본설정값 세팅 메서드
        /// </summary>
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



        /// <summary>
        /// 드롭아이템 테이블을 반환하는 메서드
        /// </summary>
        /// <returns>드랍아이템 데이터테이블</returns>
        private DataTable GetDropItemTable()
        {
            //Level(상/하위) , Part(퀘스트보수/유실물등), Difficulty(획득난이도), idx, name
            DataTable dt = new DataTable();
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Part", typeof(string));
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
        /// 코멘트 그리드뷰 기본설정값 세팅 메서드
        /// </summary>
        private void gViewCommentSetting()
        {
            //gViewComment.AllowUserToAddRows = false;
            //gViewComment.AllowUserToDeleteRows = false;
            //gViewComment.AllowUserToOrderColumns = true;
            //gViewComment.ReadOnly = true;
            //gViewComment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //gViewComment.MultiSelect = false;
            //gViewComment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //gViewComment.AllowUserToResizeColumns = false;
            //gViewComment.ColumnHeadersHeightSizeMode =
            //DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //gViewComment.AllowUserToResizeRows = false;
            //gViewComment.RowHeadersWidthSizeMode =
            //DataGridViewRowHeadersWidthSizeMode.DisableResizing;

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

        /// <summary>
        /// 폼 이동을 위한 이벤트
        /// </summary>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        /// <summary>
        /// 폼 이동을 위한 이벤트
        /// </summary>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        /// <summary>
        /// 폼 이동을 위한 이벤트
        /// </summary>
        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void gView_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void gViewDropItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != -1)
            {
                FrmItemInfo form = new FrmItemInfo(gViewDropItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), this);
                form.ShowDialog();
            }
        }

        private void gViewDropItem_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && e.ColumnIndex == 2)
            {
                gViewDropItem.Cursor = Cursors.Hand;
            }
        }

        private bool IsValidCellAddress(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < gViewDropItem.RowCount &&
        columnIndex >= 0 && columnIndex <= gViewDropItem.ColumnCount;
        }

        private void gViewDropItem_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidCellAddress(e.RowIndex, e.ColumnIndex) && e.ColumnIndex == 2)
            {
                gViewDropItem.Cursor = Cursors.Default;
            }
        }

        #region 셀병합
        private void MergeCellsInRow(int row, int col1, int col2)
        {
            Graphics g = gViewDropItem.CreateGraphics();
            Pen p = new Pen(gViewDropItem.GridColor);
            Rectangle r1 = gViewDropItem.GetCellDisplayRectangle(col1, row, true);
            Rectangle r2 = gViewDropItem.GetCellDisplayRectangle(col2, row, true);

            int recWidth = 0;
            string recValue = string.Empty;
            for (int i = col1; i <= col2; i++)
            {
                recWidth += gViewDropItem.GetCellDisplayRectangle(i, row, true).Width;
                if (gViewDropItem[i, row].Value != null)
                    recValue += gViewDropItem[i, row].Value.ToString() + " ";
            }
            Rectangle newCell = new Rectangle(r1.X, r1.Y, recWidth, r1.Height);
            g.FillRectangle(new SolidBrush(gViewDropItem.DefaultCellStyle.BackColor), newCell);
            g.DrawRectangle(p, newCell);
            g.DrawString(recValue, gViewDropItem.DefaultCellStyle.Font, new SolidBrush(gViewDropItem.DefaultCellStyle.ForeColor), newCell.X + 3, newCell.Y + 3);
        }

        private void MergeCellsInColumn(int col, int row1, int row2)
        {
            Graphics g = gViewDropItem.CreateGraphics();
            Pen p = new Pen(gViewDropItem.GridColor);
            Rectangle r1 = gViewDropItem.GetCellDisplayRectangle(col, row1, true);
            Rectangle r2 = gViewDropItem.GetCellDisplayRectangle(col, row2, true);

            int recHeight = 0;
            string recValue = string.Empty;
            for (int i = row1; i <= row2; i++)
            {
                recHeight += gViewDropItem.GetCellDisplayRectangle(col, i, true).Height;
                if (gViewDropItem[col, i].Value != null)
                    recValue += gViewDropItem[col, i].Value.ToString() + " ";
            }
            Rectangle newCell = new Rectangle(r1.X, r1.Y, r1.Width, recHeight);
            g.FillRectangle(new SolidBrush(gViewDropItem.DefaultCellStyle.BackColor), newCell);
            g.DrawRectangle(p, newCell);
            g.DrawString(recValue, gViewDropItem.DefaultCellStyle.Font, new SolidBrush(gViewDropItem.DefaultCellStyle.ForeColor), newCell.X + 3, newCell.Y + 3);
        }
        #endregion

    }
}
