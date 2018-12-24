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
        public FormSkillInfo()
        {
            InitializeComponent();
        }
        public FormSkillInfo(Skill skill) : this()
        {
            this.skill = skill;
        }
        private void FormSkillInfo_Load(object sender, EventArgs e)
        {
            labSkillName.Text = skill.Name;
            labSkillDesc.Text = "";
            labSkillName.Parent = picMenu;
            labSkillName.BackColor = Color.Transparent;
            bool check = true;
            foreach (var item in skill.Desc)
            {
                if (check)
                {
                    this.Width += item.Desc.Length*3;
                    picMenu.Width = this.Width;
                    btnClose.Location = new Point(this.Width - 30, 0);
                    check = false;
                }
                this.Height += 14;
                labSkillDesc.Text += item.Name+": "+item.Desc+"\n";
            }
        }
        private Point mousePoint;
        private bool mouseDown;
        private Point lastLocation;

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void picMenu_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void picMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void picMenu_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
