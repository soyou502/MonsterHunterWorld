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
    public partial class FrmSimulator : Form
    {
        FormSkill skill;
        FrmCharm charm;
        FormJewel Jewel;
        FrmArmors armors;
        public List<Armors> getArmors;
        List<string> jewelName;
        ComboBox[] combos;
        public FrmSimulator()
        {
            InitializeComponent();
        }

        private void FrmSimulator_Load(object sender, EventArgs e)
        {
            skill = new FormSkill();
            charm = new FrmCharm();
            Jewel = new FormJewel();
            armors = new FrmArmors();
            getArmors = new List<Armors>();
            jewelName = new List<string>();
            combos = new ComboBox[] { cboHead, cboChest, cboArm, cboWaist, cboLeg };
            gViewResistance.Columns.Add("Part", "부위");
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
            gVIewSkill.Columns.Add("totla", "총합");
            gVIewSkill.Columns["Skill"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            gViewResistance.Rows.Add(new string[] { "총합", "0", "0", "0", "0", "0", "0" });
            foreach (var item in skill.GetListCollection())
            {
                cboSkill1.Items.Add(item.Name);
                cboSkill2.Items.Add(item.Name);
            }
            foreach (var item in charm.GetListCollection())
            {
                cboCharm.Items.Add(item.Name);
            }
            foreach (var item in Jewel.GetListCollection())
            {
                jewelName.Add(item.Name + " lv" + item.Slot_level);
            }

            for (int i = 0; i < 3; i++)
            {
                ComboBox cbo = (ComboBox)panel1.Controls[i];
                cbo.Items.Add("");
                cbo.Items.AddRange(jewelName.ToArray());
                cbo = (ComboBox)panel2.Controls[i];
                cbo.Items.Add("");
                cbo.Items.AddRange(jewelName.ToArray());
                cbo = (ComboBox)panel3.Controls[i];
                cbo.Items.Add("");
                cbo.Items.AddRange(jewelName.ToArray());
                cbo = (ComboBox)panel4.Controls[i];
                cbo.Items.Add("");
                cbo.Items.AddRange(jewelName.ToArray());
                cbo = (ComboBox)panel5.Controls[i];
                cbo.Items.Add("");
                cbo.Items.AddRange(jewelName.ToArray());
                cbo = (ComboBox)panel6.Controls[i];
                cbo.Items.Add("");
                cbo.Items.AddRange(jewelName.ToArray());
            }
        }

        private void cboCharm_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCharmRank.Items.Clear();
            foreach (var item in charm.GetListCollection())
            {
                if (item.Name == cboCharm.SelectedItem.ToString())
                {
                    for (int i = 1; i < item.Max_level + 1; i++)
                    {
                        cboCharmRank.Items.Add(i);
                    }
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string skill1;
            string skill2;
            string slotLevel;
            string slots;
            string part;
            string name;
            if (cboSkill1.SelectedItem != null)
            {
                skill1 = cboSkill1.SelectedItem.ToString();
            }
            else
            {
                skill1 = "";
            }
            if (cboSkill2.SelectedItem != null)
            {
                skill2 = cboSkill2.SelectedItem.ToString();
            }
            else
            {
                skill2 = "";
            }
            if (cboSlotLevel.SelectedItem != null)
            {
                slotLevel = cboSlotLevel.SelectedItem.ToString();
            }
            else
            {
                slotLevel = "";
            }
            if (cboSlotCount.SelectedItem != null)
            {
                slots = cboSlotCount.SelectedItem.ToString();
            }
            else
            {
                slots = "";
            }
            if (cboPart.SelectedItem != null)
            {
                part = cboPart.SelectedItem.ToString();
            }
            else
            {
                part = "";
            }
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                name = textBox1.Text;
            }
            else
            {
                name = "";
            }
            FrmSimulatorSearch search = new FrmSimulatorSearch(skill1, skill2, slotLevel, slots, part, name);
            search.Owner = this;
            search.Show();
        }

        private void cboHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetResistance(sender);
            GetSkillList();
        }

        private void GetResistance(object sender)
        {
            ComboBox cbo = (ComboBox)sender;
            foreach (var item in armors.GetListCollection())
            {
                if (item.Name == cbo.SelectedItem.ToString())
                {
                    string[] resistance = new string[7];
                    resistance[0] = item.Part;
                    resistance[1] = item.Defense.ToString();
                    resistance[2] = item.Resistances.Fire.ToString();
                    resistance[3] = item.Resistances.Water.ToString();
                    resistance[4] = item.Resistances.Thunder.ToString();
                    resistance[5] = item.Resistances.Ice.ToString();
                    resistance[6] = item.Resistances.Dragon.ToString();
                    int defence = 0;
                    int fire = 0;
                    int water = 0;
                    int thunder = 0;
                    int ice = 0;
                    int dragon = 0;
                    if (gViewResistance.Rows.Count != 0)
                    {
                        bool temp = true;

                        for (int i = 0; i < gViewResistance.Rows.Count; i++)
                        {
                            if (gViewResistance.Rows[i].Cells["Part"].Value.ToString() == item.Part)
                            {
                                temp = false;
                                gViewResistance.Rows[i].Cells[0].Value = item.Part;
                                gViewResistance.Rows[i].Cells[1].Value = item.Defense.ToString();
                                gViewResistance.Rows[i].Cells[2].Value = item.Resistances.Fire.ToString();
                                gViewResistance.Rows[i].Cells[3].Value = item.Resistances.Water.ToString();
                                gViewResistance.Rows[i].Cells[4].Value = item.Resistances.Thunder.ToString();
                                gViewResistance.Rows[i].Cells[5].Value = item.Resistances.Ice.ToString();
                                gViewResistance.Rows[i].Cells[6].Value = item.Resistances.Dragon.ToString();
                            }
                        }
                        if (temp)
                        {
                            gViewResistance.Rows.Insert(gViewResistance.Rows.Count - 1, resistance);
                        }
                        int count = gViewResistance.Rows.Count;
                        for (int i = 0; i < gViewResistance.Rows.Count - 1; i++)
                        {
                            defence += int.Parse(gViewResistance.Rows[i].Cells[1].Value.ToString());
                            fire += int.Parse(gViewResistance.Rows[i].Cells[2].Value.ToString());
                            water += int.Parse(gViewResistance.Rows[i].Cells[3].Value.ToString());
                            thunder += int.Parse(gViewResistance.Rows[i].Cells[4].Value.ToString());
                            ice += int.Parse(gViewResistance.Rows[i].Cells[5].Value.ToString());
                            dragon += int.Parse(gViewResistance.Rows[i].Cells[6].Value.ToString());
                        }
                        gViewResistance.Rows[count - 1].Cells[0].Value = "총합";
                        gViewResistance.Rows[count - 1].Cells[1].Value = defence.ToString();
                        gViewResistance.Rows[count - 1].Cells[2].Value = fire.ToString();
                        gViewResistance.Rows[count - 1].Cells[3].Value = water.ToString();
                        gViewResistance.Rows[count - 1].Cells[4].Value = thunder.ToString();
                        gViewResistance.Rows[count - 1].Cells[5].Value = ice.ToString();
                        gViewResistance.Rows[count - 1].Cells[6].Value = dragon.ToString();
                    }
                }
            }
        }
        private void GetSkillList()
        {
            gVIewSkill.Rows.Clear();
            foreach (ComboBox item in combos)
            {
                if (item.SelectedItem != null)
                {
                    foreach (var armor in armors.GetListCollection())
                    {
                        if (item.SelectedItem.ToString() == armor.Name)
                        {
                            foreach (var skill in skill.GetListCollection())
                            {
                                foreach (var armorSkill in armor.Skills)
                                {
                                    if (armorSkill.Name.Contains(skill.Name))
                                    {
                                        string[] temp = new string[] { "0", "0", "0", "0", "0", "0", "0", "0" };
                                        temp[0] = skill.Name;
                                        if (armor.Part == "머리")
                                        {
                                            temp[2] = armorSkill.Level.ToString();
                                        }
                                        if (armor.Part == "몸통")
                                        {
                                            temp[3] = armorSkill.Level.ToString();
                                        }
                                        if (armor.Part == "팔")
                                        {
                                            temp[4] = armorSkill.Level.ToString();
                                        }
                                        if (armor.Part == "허리")
                                        {
                                            temp[5] = armorSkill.Level.ToString();
                                        }
                                        if (armor.Part == "다리")
                                        {
                                            temp[6] = armorSkill.Level.ToString();
                                        }
                                        gVIewSkill.Rows.Add(temp);
                                    }
                                }
                            }
                        }
                    } 
                }
            }
            if (gVIewSkill.Rows.Count > 0)
            {
                for (int i = 0; i < gVIewSkill.Rows.Count; i++)
                {
                    int result = 0;
                    for (int j = 2; j < 8; j++)
                    {
                        if (!string.IsNullOrEmpty(gVIewSkill.Rows[i].Cells[j].Value.ToString()))
                        {
                            result += int.Parse(gVIewSkill.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                    gVIewSkill.Rows[i].Cells[7].Value = result.ToString();
                }
            }
            for (int i = 0; i < gVIewSkill.Rows.Count - 1; i++)
            {
                for (int j = 1; j < gVIewSkill.Rows.Count; j++)
                {
                    if (gVIewSkill.Rows[i].Cells[0].Value == gVIewSkill.Rows[j].Cells[0].Value)
                    {
                        for (int k = 2; k < gVIewSkill.Rows[i].Cells.Count; k++)
                        {
                            gVIewSkill.Rows[i].Cells[k].Value = (int.Parse(gVIewSkill.Rows[i].Cells[k].Value.ToString()) + int.Parse(gVIewSkill.Rows[j].Cells[k].Value.ToString())).ToString();
                        }
                        gVIewSkill.Rows.RemoveAt(j);
                        gVIewSkill.Refresh();
                    }
                }
            }
        }
        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
