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
        public FormMonsterInfo()
        {
            InitializeComponent();
        }

        private void FormMonsterInfo_Load(object sender, EventArgs e)
        {
            gViewComment.AllowUserToAddRows = false;
            gViewComment.AllowUserToDeleteRows = false;
            gViewComment.AllowUserToResizeColumns = false;
            gViewComment.AllowUserToResizeRows = false;
            gViewComment.EditMode = DataGridViewEditMode.EditProgrammatically;
            gViewComment.MultiSelect = false;
            gViewComment.ReadOnly = true;
            gViewComment.RowHeadersVisible = false;
            gViewComment.ColumnHeadersVisible = false;

            DAO.MonsterInfoHtmlDAO html = new DAO.MonsterInfoHtmlDAO();

            

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();
            string url = "http://mhf.inven.co.kr/dataninfo/mhw/monster?code=48";
            htmlDoc = web.LoadFromBrowser(url);
            HtmlNode root = htmlDoc.DocumentNode;
            HtmlNodeCollection table = root.SelectSingleNode("//body/div/div").FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.SelectNodes("div");

            textBox1.Text = root.SelectSingleNode("//body/div/div").FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.SelectNodes("div")[1].FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.OuterHtml;
        }
    }
}
