using MonsterHunterWorld;
using MonsterHunterWorld.BUS;
using MonsterHunterWorld.DAO;
using MonsterHunterWorld.VO;
using Newtonsoft.Json.Linq;
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
    public partial class FrmItemInfo : Form
    {
        string itemName;
        Form form;
        public FrmItemInfo()
        {
            InitializeComponent();
        }
        public FrmItemInfo(string itemName, Form form) : this()
        {
            this.itemName = itemName;
            this.form = form;
        }
        private void FrmItemInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Level", "단계");
            dataGridView1.Columns.Add("Part", "부위");
            dataGridView1.Columns.Add("Name", "이름");
            dataGridView1.Columns.Add("Rare", "레어도");
            dataGridView1.Columns.Add("Slots", "장신주슬롯");
            dataGridView1.Columns.Add("Defense", "방어력");
            dataGridView1.Columns.Add("FireResistances", "화내성");
            dataGridView1.Columns.Add("WaterResistances", "수내성");
            dataGridView1.Columns.Add("ThunderResistances", "뇌내성");
            dataGridView1.Columns.Add("IceResistances", "빙내성");
            dataGridView1.Columns.Add("DragonResistances", "용내성");
            dataGridView1.BackgroundColor = Color.White;
            foreach (var item in new FrmItems().GetListCollection())
            {
                if (item.Name.Contains(itemName) || itemName.Contains(item.Name))
                {
                    txtType.Text = item.Type;
                    txtName.Text = item.Name;
                    txtRare.Text = item.Rare.ToString();
                    txtPrice.Text = item.Price.ToString();
                    txtDescription.Text = item.Description;
                }
            }
            foreach (var item in new FrmArmors().GetListCollection())
            {
                foreach (var item2 in item.Items)
                {
                    if (item2.Name.Contains(itemName) || itemName.Contains(item2.Name))
                    {
                        ArmorsTableAdd(item);
                    }
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ArmorsTableAdd(Armors armors)
        {
            string level = armors.Level;
            string part = armors.Part;
            string name = armors.Name;
            string rare = armors.Rare.ToString();
            string slots = armors.Slots;
            string defense = armors.Defense.ToString();
            string fire = armors.Resistances.Fire.ToString();
            string water = armors.Resistances.Water.ToString();
            string thunder = armors.Resistances.Thunder.ToString();
            string ice = armors.Resistances.Ice.ToString();
            string dragon = armors.Resistances.Dragon.ToString();
            dataGridView1.Rows.Add(new string[] { level, part, name, rare, slots, defense, fire, water, thunder, ice, dragon });
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            this.Visible = false;
            FrmArmorInfo fai = new FrmArmorInfo(str, this);
            fai.ShowDialog();
        }

        private void FrmItemInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Show();
        }
        private Point mousePoint;

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
    }
}
