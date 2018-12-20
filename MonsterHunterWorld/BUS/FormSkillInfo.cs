using MonsterHunterWorld.VO;
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
    public partial class FormSkillInfo : Form
    {
        Skill skill;
        public FormSkillInfo(Skill skill)
        {
            InitializeComponent();
            this.skill = skill;
        }

        private void FormSkillInfo_Load(object sender, EventArgs e)
        {
            this.Location = this.Owner.Location;
            labSkillName.Text = skill.Name;
            label1.Text = "";
            label1.Location = new Point(label1.Location.X+skill.Name.Length*8, label1.Location.Y);
            foreach (var item in skill.Desc)
            {
                label1.Text += item.Name+": "+item.Desc+"\n";
            }
        }
    }
}
