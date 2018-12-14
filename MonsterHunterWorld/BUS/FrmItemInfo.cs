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
        public FrmItemInfo()
        {
            InitializeComponent();
        }
        public FrmItemInfo(string itemName) : this()
        {
            this.itemName = itemName;
        }
        private void FrmItemInfo_Load(object sender, EventArgs e)
        {
            /*private string level;
        private string part;
        private string name;
        private int rare;
        private string slots;
        private int defense;
        private Resistance resistances;
        private List<Needs> items = new List<Needs>();*/
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
            foreach (var item in Form1.items)
            {
                if (item.Name == itemName)
                {
                    txtType.Text = item.Type;
                    txtName.Text = item.Name;
                    txtRare.Text = item.Rare.ToString();
                    txtPrice.Text = item.Price.ToString();
                    txtDescription.Text = item.Decription;
                }
            }
            foreach (var item in Form1.armors)
            {
                foreach (var item2 in item.Items)
                {
                    if (item2.Name == itemName)
                    {
                        ArmorsTableAdd(item);
                    }
                }
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ArmorsTableAdd(Armors item)
        {
            string level = item.Level;
            string part = item.Part;
            string name = item.Name;
            string rare = item.Rare.ToString();
            string slots = item.Slots;
            string defense = item.Defense.ToString();
            string fire = item.Resistances.Fire.ToString();
            string water = item.Resistances.Water.ToString();
            string thunder = item.Resistances.Thunder.ToString();
            string ice = item.Resistances.Ice.ToString();
            string dragon = item.Resistances.Dragon.ToString();
            string items = "";
            dataGridView1.Rows.Add(new string[] { level, part, name, rare, slots, defense, fire, water, thunder, ice, dragon});
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
            FrmArmorInfo fai = new FrmArmorInfo(str);
            fai.Show();
            fai.Location = this.Location;
            this.Visible = false;
            fai.Disposed += Fai_Disposed;
        }

        private void Fai_Disposed(object sender, EventArgs e)
        {
            this.Visible = true;
        }
    }
}
