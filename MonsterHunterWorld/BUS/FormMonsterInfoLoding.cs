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
    public partial class FormMonsterInfoLoding : Form
    {
        VO.Monster monster;
        public FormMonsterInfoLoding(VO.Monster monster)
        {
            InitializeComponent();
            this.monster = monster;
        }

        private void FormMonsterInfoLoding_Load(object sender, EventArgs e)
        {
            this.picLoding.Image = Image.FromFile(Application.StartupPath + @"\Images\Loding.gif");
        }

        private void FormMonsterInfoLoding_Shown(object sender, EventArgs e)
        {
            DAO.MonsterInfoHtmlDAO html = new DAO.MonsterInfoHtmlDAO(monster.Nick + monster.Name);
            this.Visible = false;
            FormMonsterInfo monsterInfo = new FormMonsterInfo(monster, html);
            monsterInfo.Owner = this;
            monsterInfo.ShowDialog();
            this.Close();
        }
    }
}
