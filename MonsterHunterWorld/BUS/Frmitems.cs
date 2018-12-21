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
    public partial class FrmItems : Form, IGetListCollection<Items>
    {
        static List<Items> items;
        Color[] color = new Color[] { Color.Gray, Color.Black, Color.LightGreen, Color.ForestGreen, Color.SkyBlue, Color.Purple, Color.HotPink, Color.Orange };
        private Form form1;

        public FrmItems()
        {
            InitializeComponent();
        }

        public FrmItems(Form form1) : this()
        {
            this.form1 = form1;
        }

        private void FrmItems_Load(object sender, EventArgs e)
        {
            GetListCollection();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Columns.Add((i + 1).ToString(), (i + 1).ToString());
            }
            //for (int i = 0; i < items.Count; i++)
            //{
            //    string[] arr = new string[5];
            //    for (int j = 0; j < arr.Length; j++)
            //    {
            //        if (i < items.Count)
            //        {
            //            arr[j] = items[i].Name;
            //            i++;
            //        }
            //    }
            //    dataGridView1.Rows.Add(arr);
            //}
            btnSearch_Click(null, null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmItemInfo info = new FrmItemInfo(dataGridView1.SelectedCells[0].Value.ToString());
            info.Location = this.Location;
            info.Show();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int j = 0;
            string[] arr = new string[5];
            for (int i = 0; i < items.Count; i++)
            {
                if (i < items.Count && items[i].Name.Contains(textBox1.Text))
                {
                    arr[j] = items[i].Name;
                    j++;
                    if (j == 5)
                    {
                        dataGridView1.Rows.Add(arr);
                        arr = new string[5];
                        j = 0;
                    }
                }
                if (i == items.Count - 1)
                {
                    dataGridView1.Rows.Add(arr);
                }
            }
            SetColorPerRank();
        }

        private void SetColorPerRank()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                if (dataGridView1.Rows[i].Cells[j].Value.ToString() == item.Name)
                                {
                                    dataGridView1.Rows[i].Cells[j].Style.ForeColor = color[item.Rare - 1];
                                } 
                            }
                        } 
                    }

                }
            }
        }

        public IList<Items> GetListCollection()
        {
            if (items == null)
            {
                items = new List<Items>();
                Parameter parameter = new Parameter("items");
                MonsterHunterAPI api = new MonsterHunterAPI();
                string json = api.GetJson(parameter);
                JArray ja = JArray.Parse(json);
                foreach (var item in ja)
                {
                    textBox1.AutoCompleteCustomSource.Add(item["name"].ToString());
                    Items temp = new Items(int.Parse(item["idx"].ToString()), item["type"].ToString(), item["name"].ToString(), item["description"].ToString(), int.Parse(item["rare"].ToString()), int.Parse(item["price"].ToString()));
                    items.Add(temp);
                }
            }
            return items;
        }

        public IList<Items> GetListCollection(Parameter parameter)
        {
            if (items == null)
            {
                items = new List<Items>();
                MonsterHunterAPI api = new MonsterHunterAPI();
                string json = api.GetJson(parameter);
                JArray ja = JArray.Parse(json);
                foreach (var item in ja)
                {
                    Items temp = new Items(int.Parse(item["idx"].ToString()), item["type"].ToString(), item["name"].ToString(), item["description"].ToString(), int.Parse(item["rare"].ToString()), int.Parse(item["price"].ToString()));
                    items.Add(temp);
                }
            }
            return items;
        }
    }
}
