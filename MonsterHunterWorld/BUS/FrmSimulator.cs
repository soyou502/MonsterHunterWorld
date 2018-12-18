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
        public FrmSimulator()
        {
            skill = new FormSkill();
            charm = new FrmCharm();
            Jewel = new FormJewel();
            armors = new FrmArmors();
            getArmors = new List<Armors>();
            jewelName = new List<string>();
            InitializeComponent();
        }

        private void FrmSimulator_Load(object sender, EventArgs e)
        {
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
                jewelName.Add(item.Name +" lv" + item.Slot_level);
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
            if (cboSkill1.SelectedItem!=null)
            {
                skill1 = cboSkill1.SelectedItem.ToString();
            }else
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
                    gViewResistance.Rows.Add(resistance);
                    string[] skill = new string[7];
                    foreach (var armorSkill in item.Skills)
                    {
                        skill[0] = armorSkill.Name;
                        for (int i = 0; i < 7; i++)
                        {
                            if (item.Part == "무기")
                            {
                                skill[i] = "1";
                            }else if(item.Part == "머리")
                            {
                                skill[i] = "1";
                            }
                            else if (item.Part == "몸통")
                            {
                                skill[i] = "1";
                            }
                            else if (item.Part == "팔")
                            {
                                skill[i] = "1";
                            }
                            else if (item.Part == "허리")
                            {
                                skill[i] = "1";
                            }
                            else if (item.Part == "다리")
                            {
                                skill[i] = "1";
                            }else
                            {
                                skill[i] = "";
                            }
                        }
                    }
                    gVIewSkill.Rows.Add(skill);
                }
            }
        }
    }
}
