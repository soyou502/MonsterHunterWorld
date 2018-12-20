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
    public partial class FrmSimulatorSearch : Form
    {
        string skill1;
        string skill2;
        string slotLevel;
        string slots;
        string part;
        string name;
        FrmArmors frmarmors;
        List<Armors> armors;
        public FrmSimulatorSearch()
        {
            frmarmors = new FrmArmors();
            armors = new List<Armors>();
            InitializeComponent();
        }

        public FrmSimulatorSearch(string skill1, string skill2, string slotLevel, string slots, string part, string name) : this()
        {
            this.skill1 = skill1;
            this.skill2 = skill2;
            this.slotLevel = slotLevel;
            this.slots = slots;
            this.part = part;
            this.name = name;
            dataGridView1.Columns.Add("Name", "이름");
            dataGridView1.Columns.Add("Rare", "레어도");
            dataGridView1.Columns.Add("Slots", "슬롯");
            dataGridView1.Columns.Add("Skill", "스킬");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Columns["Skill"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FrmSimulatorSearch_Load(object sender, EventArgs e)
        {
            foreach (var item in frmarmors.GetListCollection())
            {
                if (item.Name.Contains(name) && item.Part.Contains(part) && item.Slots.Contains(slots) && item.Slots.Contains(slotLevel))
                {

                    if (skill1 == "" && skill2 == "")
                    {
                        if (item.Skills.Count == 0)
                        {
                            string[] temp = new string[4];
                            temp[0] = item.Name;
                            temp[1] = item.Rare.ToString();
                            temp[2] = item.Slots;
                            temp[3] += "스킬없음";
                            dataGridView1.Rows.Add(temp);
                        }
                        else
                        {
                            string[] temp = new string[4];
                            temp[0] = item.Name;
                            temp[1] = item.Rare.ToString();
                            temp[2] = item.Slots;
                            temp[3] = "";
                            foreach (var armorskill in item.Skills)
                            {
                                temp[3] += armorskill.Name + armorskill.Level + "  ";
                            }
                            dataGridView1.Rows.Add(temp);
                        }
                    }
                    else
                    {
                        foreach (var skill in item.Skills)
                        {
                            if (skill.Name == skill1 || skill.Name == skill2)
                            {
                                string[] temp = new string[4];
                                temp[0] = item.Name;
                                temp[1] = item.Rare.ToString();
                                temp[2] = item.Slots;
                                temp[3] = "";
                                foreach (var armorskill in item.Skills)
                                {
                                    temp[3] += armorskill.Name + armorskill.Level + "  ";
                                }
                                dataGridView1.Rows.Add(temp);
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (var item in frmarmors.GetListCollection())
            {
                if (dataGridView1.SelectedRows[0].Cells["name"].Value.ToString() == item.Name)
                {
                    FrmSimulator frmSimulator = this.Owner as FrmSimulator;
                    if (item.Part == "머리")
                    {
                        frmSimulator.cboHead.Items.Add(item.Name);
                    }
                    else if (item.Part == "몸통")
                    {
                        frmSimulator.cboChest.Items.Add(item.Name);
                    }
                    else if (item.Part == "팔")
                    {
                        frmSimulator.cboArm.Items.Add(item.Name);
                    }
                    else if (item.Part == "허리")
                    {
                        frmSimulator.cboWaist.Items.Add(item.Name);
                    }
                    else if (item.Part == "다리")
                    {
                        frmSimulator.cboLeg.Items.Add(item.Name);
                    }
                }
            }
        }
    }
}
