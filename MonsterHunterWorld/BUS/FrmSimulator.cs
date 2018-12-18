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
    public partial class FrmSimulator : Form
    {
        public FrmSimulator()
        {
            InitializeComponent();
        }

        private void FrmSimulator_Load(object sender, EventArgs e)
        {
            gViewResistance.Columns.Add("Defence", "방어력");
            gViewResistance.Columns.Add("Fire", "화속성");
            gViewResistance.Columns.Add("Water", "수속성");
            gViewResistance.Columns.Add("Thunder", "뇌속성");
            gViewResistance.Columns.Add("Ice", "빙속성");
            gViewResistance.Columns.Add("Dragon", "용속성");
            gVIewSkill.Columns.Add("Skill", "스킬");
            gVIewSkill.Columns.Add("Weapon", "무기");
            gVIewSkill.Columns.Add("Head", "머리");
            gVIewSkill.Columns.Add("Chest", "가슴");
            gVIewSkill.Columns.Add("Arm", "팔");
            gVIewSkill.Columns.Add("Waist", "허리");
            gVIewSkill.Columns.Add("Leg", "다리");

        }
    }
}
