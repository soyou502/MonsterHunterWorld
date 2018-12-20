using MonsterHunterWorld.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsteHunterWorld
{
    public partial class FrmArmorInfo : Form
    {
        private string str;

        public FrmArmorInfo()
        {
            InitializeComponent();
        }

        public FrmArmorInfo(string str) : this()
        {
            this.str = str;
        }
        private void FrmArmorInfo_Load(object sender, EventArgs e)
        {
            gViewItem.Columns.Add("item", "소재");
            gViewItem.Columns.Add("count", "필요량");
            gViewItem.Columns["item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gViewItem.BackgroundColor = Color.White;
            gViewSkill.Columns.Add("type", "타입");
            gViewSkill.Columns.Add("name", "이름");
            gViewSkill.Columns.Add("level", "등급");
            gViewSkill.BackgroundColor = Color.White;
            gViewSkill.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            foreach (var item in new FrmArmors().GetListCollection())
            {
                if (item.Name == str)
                {
                    string set_image = item.SetImage;
                    string level = item.Level;
                    string part = item.Part;
                    string name = item.Name;
                    int rare = item.Rare;
                    string slots = item.Slots;
                    int defense = item.Defense;
                    int fire = item.Resistances.Fire;
                    int water = item.Resistances.Water;
                    int thunder = item.Resistances.Thunder;
                    int ice = item.Resistances.Ice;
                    int dragon = item.Resistances.Dragon;
                    pictureBox1.ImageLocation = set_image;
                    lblLevel.Text = level;
                    lblName.Text = name;
                    lblPart.Text = part;
                    lblRare.Text = rare.ToString();
                    lblSlots.Text = slots;
                    lblDefense.Text = defense.ToString();
                    lblResistances.Text = "Fire : " + fire + " Warter : " + water + " Thunder : " + thunder + " Ice : " + ice + " Dragon : " + dragon;
                    foreach (var item2 in item.Items)
                    {
                        string[] arr = new string[2];
                        arr[0] = item2.Name;
                        arr[1] = item2.Count + "개";
                        gViewItem.Rows.Add(arr);
                    }
                    foreach (var skill in item.Skills)
                    {
                        string[] arr = new string[3];
                        arr[0] = skill.Type;
                        arr[1] = skill.Name; 
                        arr[2] = skill.Level.ToString();
                        gViewSkill.Rows.Add(arr);
                    }
                }
            }    
        }

        private void gViewItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmItemInfo fii = new FrmItemInfo(gViewItem.Rows[e.RowIndex].Cells["item"].Value.ToString());
            fii.Location = this.Location;
            fii.Show();
        }
    }
}
