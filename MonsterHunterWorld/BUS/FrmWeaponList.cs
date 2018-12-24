using MonsterHunterWorld.VO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using MonsterHunterWorld.DAO;
using System.Diagnostics;
using System.Threading;
using MonsterHunterWorld.BUS;
using System.Windows.Forms.DataVisualization.Charting;

namespace MonsteHunterWorld
{
    public partial class FrmWeaponList : Form
    {
        FrmWeaponInfo fwif;

        Button btn;
        MonsterHunterAPI mapi = new MonsterHunterAPI();
        List<WeaponBase> wbList = new List<WeaponBase>(); // 기본정보
        List<WeaponEelemental> weList = new List<WeaponEelemental>(); // 속성
        List<WeaponDebuff> wdList = new List<WeaponDebuff>(); // 디버프
        List<WeaponCreate> wcList = new List<WeaponCreate>(); // 제작
        List<Weapons_Durability> duaList = new List<Weapons_Durability>(); // 예리도

        private int make_price; // 제작비용
        private int upgrade_price; // 업글 비용
        private bool cheked_weapon = true; // 버튼과 라디오버튼 구분용
        private string weapon_type; // 무기종류(영문)
        private string weapon_button_name; // 무기이름
        private string first_wtype; // 첫실행시 무기타입
        private string current_name; // 선택한 셀 인덱스
        private bool cheked_Eelemental = false; // 속성 전체선택 구분용
        private string elemental_Name;  // 속석이름
        private bool cheked_Build = false; // 파생 전체선택 구분용
        private string build_name;
        private bool cheked_slots = false; // 슬롯레벨 전체선택 구분용
        private string slots_lv;
        private bool cheked_slots_Count = false; // 슬롯수 전체선택 구분용
        private string slots_Number;
        private int select_idx; // 데이터 그리드뷰 행 선택 인덱스

        private string elemental_name;
        private int elemental_value;
        private string debuff_name;
        private int debuff_value;
        private string select_name;

        /*
         1. 예리도 파싱 // FrmWeaponsInfo 에 넘겨줄 데이터 파싱
         2. 속성 조건문 넣기  // ALL 구분하기
         3. 파생트리 조건문 넣기 ( 속성처럼 체인지드 이벤트 )
         4. 이름 조건문 넣기 ( 체인지드 이벤트 )
         5. 그리드 뷰 행 클릭 이벤트 -> FrmWeaponsInfo 출력 -> 선택한 무기 상세정보 조회 ( 예리도, 재료 포함 ) // 새로 파싱
         // (파싱) 무기명 검색 uri = @"http://www.mhwdb.kr/apis/weapons/건랜스";
         */
        // 후딱 끝내고 호석 파싱하러 가야돼

        public FrmWeaponList()
        {
            InitializeComponent();

        }

        public FrmWeaponList(Form1 form1) : this()
        {
            this.form1 = form1;
        }

        private void FrmWeaponList_Load(object sender, EventArgs e)
        {
            pictur_weapon.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private string DurabilityJSON()
        {
            string durability_Uri = @"https://mhw-db.com/weapons?q={%22type%22:%22" + weapon_type + "%22}";
            string JsonStr = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(durability_Uri.Replace(" ", ""));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string status = response.StatusCode.ToString(); // 서버의 응답코드
            if (status == "OK")
            {
                try
                {
                    var stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                    JsonStr = sr.ReadToEnd();
                    if (JsonStr[0].ToString() != "[")
                    {
                        JsonStr = String.Concat("[", JsonStr) + "]";
                    }
                    sr.Close();
                }
                catch (WebException)
                {
                    Thread.Sleep(1000);
                }
            }
            else
            {
                MessageBox.Show("에러발생!\n" + status);
            }
            return JsonStr;
        }

        // 무기버튼
        private void btn_weapons_Click(object sender, EventArgs e)
        {
            weapon_button_name = ((Button)sender).Text;
            if (cheked_weapon)
            {
                cheked_weapon = false;
                this.btn = (Button)sender;
                this.first_wtype = ((Button)sender).Text;
                weapon_if((Button)sender, ((Button)sender).Text);
            }
            else
            {
                weapon_if(null, null);
            }

            weapon_tree.Nodes.Clear();
            wbList.Clear();
            weapon_data_View.DataSource = null;
            GetWeaponDate(("weapons/" + this.first_wtype));
            GetDurability(DurabilityJSON());


        }

        private void weapon_if(object sender, string type)
        {

            if (this.btn.Text == "대검" || first_wtype == "대검")
            {
                weapon_type = "great-sword";
            }
            else if (this.btn.Text == "태도" || first_wtype == "태도")
            {
                weapon_type = "long-sword";
            }
            else if (this.btn.Text == "한손검" || first_wtype == "대검")
            {
                weapon_type = "sword-and-shield";
            }
            else if (this.btn.Text == "쌍검" || first_wtype == "쌍검")
            {
                weapon_type = "dual-blades";
            }
            else if (this.btn.Text == "해머" || first_wtype == "해머")
            {
                weapon_type = "hammer";
            }
            else if (this.btn.Text == "수렵피리" || first_wtype == "수렵피리")
            {
                weapon_type = "hunting-horn";
            }
            else if (this.btn.Text == "랜스" || first_wtype == "랜스")
            {
                weapon_type = "lance";
            }
            else if (this.btn.Text == "건랜스" || first_wtype == "건랜스")
            {
                weapon_type = "gunlance";
            }
            else if (this.btn.Text == "슬러시액스" || first_wtype == "슬러시액스")
            {
                weapon_type = "switch-axe";
            }
            else if (this.btn.Text == "차지액스" || first_wtype == "차지액스")
            {
                weapon_type = "charge-blade";
            }
            else if (this.btn.Text == "조곤충" || first_wtype == "조곤충")
            {
                weapon_type = "insect-glaive";
            }
            else if (this.btn.Text == "라이트보우건" || first_wtype == "라이트보우건")
            {
                weapon_type = "light-bowgun";
            }
            else if (this.btn.Text == "헤비보우건" || first_wtype == "헤비보우건")
            {
                weapon_type = "heavy-bowgun";
            }
            else
            {
                weapon_type = "bow";
            }
        }

        #region 예리도데이터구하기
        private void GetDurability(string djson)
        {
            JArray json = JArray.Parse(djson);

            
            int count = 0;
            
            foreach (JObject item in json)
            {
                
                try
                {
                    for (int i = 0; i < item["durability"].Count(); i++)
                    {
                        JToken first_jtok = item["durability"][0];  // 처음 예리도

                        int red = Int32.Parse(first_jtok["red"].ToString());
                        int orange = Int32.Parse(first_jtok["orange"].ToString());
                        int yellow = Int32.Parse(first_jtok["yellow"].ToString());
                        int green = Int32.Parse(first_jtok["green"].ToString());
                        int blue = Int32.Parse(first_jtok["blue"].ToString());
                        int white = Int32.Parse(first_jtok["white"].ToString());

                        duaList.Add(new Weapons_Durability(wbList[count].Idx, red, orange, yellow, green, blue, white));

                        int last_Count = Int32.Parse(item["durability"].Count().ToString()); // 장비 최종 예리도
                        JToken last_jtok = item["durability"][last_Count - 1]; // 마지막 예리도
                        red = Int32.Parse(last_jtok["red"].ToString());
                        orange = Int32.Parse(last_jtok["orange"].ToString());
                        yellow = Int32.Parse(last_jtok["yellow"].ToString());
                        green = Int32.Parse(last_jtok["green"].ToString());
                        blue = Int32.Parse(last_jtok["blue"].ToString());
                        white = Int32.Parse(last_jtok["white"].ToString());

                        duaList.Add(new Weapons_Durability(wbList[count].Idx, red, orange, yellow, green, blue, white));

                        count++;
                    }
                }
                catch (Exception)
                {

                }
            }
        }



        #endregion
        private void GetWeaponDate(string weapon_type)
        {
            JArray json = JArray.Parse(mapi.GetJson(new Parameter(weapon_type)));
            //getData(weapon_type, json);
            DisplayTreeView(json, "무기도감");

            weapon_data_View.DataSource = wbList;
            weapon_data_View.Columns["idx"].Visible = false;
            weapon_data_View.Columns["WeaponName"].HeaderText = "무기이름";
            weapon_data_View.Columns["Rare"].HeaderText = "레어도";
            weapon_data_View.Columns["Attack"].HeaderText = "공격력";
            weapon_data_View.Columns["Defence"].HeaderText = "방어력";
            weapon_data_View.Columns["Critical"].HeaderText = "회심률";
            weapon_data_View.Columns["Slot"].HeaderText = "슬롯";
        }
        private void DisplayTreeView(JToken root, string rootName)
        {
            weapon_tree.BeginUpdate();
            try
            {
                weapon_tree.Nodes.Clear();
                var tNode = weapon_tree.Nodes[weapon_tree.Nodes.Add(new TreeNode(rootName))];
                tNode.Tag = root;
                AddNode(root, tNode);

                weapon_tree.ExpandAll();
            }
            finally
            {
                weapon_tree.EndUpdate();
            }
        }
        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            if (token == null)
                return;
            if (token is JValue)
            {
                var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(token.ToString()))];
                childNode.Tag = token;
            }
            else if (token is JObject)
            {
                var obj = (JObject)token;
                var obj2 = obj["children"];

                var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(obj["name"].ToString()))];
                childNode.Tag = obj2;

                // 기본정보
                int idx = Int32.Parse(obj["idx"].ToString());
                string name = obj["name"].ToString();
                int rare = Int32.Parse(obj["rare"].ToString());
                int attack = Int32.Parse(obj["attack"].ToString());
                int defense = Int32.Parse(obj["defense"].ToString());
                int critical = Int32.Parse(obj["critical"].ToString());
                string slot = obj["slots"].ToString();
                // 기본정보

                // 제작정보
                string imgUri = obj["icon"].ToString(); // 이미지
                bool con_make = bool.Parse(obj["can_make"].ToString()); // 제작가능여부
                string derivation = obj["derivation"].ToString(); // 소재파생

                if (obj.ContainsKey("make_price"))
                {
                    make_price = Int32.Parse(obj["make_price"].ToString()); // 제작비용
                }
                else if (obj.ContainsKey("upgrade_price"))
                {
                    upgrade_price = Int32.Parse(obj["upgrade_price"].ToString()); // 업글비용 
                }
                else if (obj.ContainsKey("make_price") && obj.ContainsKey("upgrade_price"))
                {
                    make_price = Int32.Parse(obj["make_price"].ToString()); // 제작비용
                    upgrade_price = Int32.Parse(obj["upgrade_price"].ToString()); // 업글비용 
                }
                // 제작정보
                // 속성정보, 디버프정보

                if (obj.ContainsKey("weakness"))
                {
                    JToken elementalObj = obj["weakness"];
                    elemental_name = elementalObj["type"].ToString();
                    elemental_value = Int32.Parse(elementalObj["value"].ToString());
                }
                else if (obj.ContainsKey("debuff"))
                {
                    JToken debuffObj = obj["debuff"];
                    debuff_name = debuffObj["type"].ToString();
                    debuff_value = Int32.Parse(debuffObj["value"].ToString());
                }
                else if (obj.ContainsKey("weakness") || obj.ContainsKey("debuff"))
                {
                    JToken elementalObj = obj["weakness"];
                    elemental_name = elementalObj["type"].ToString();
                    elemental_value = Int32.Parse(elementalObj["value"].ToString());

                    JToken debuffObj = obj["debuff"];
                    debuff_name = debuffObj["type"].ToString();
                    debuff_value = Int32.Parse(debuffObj["value"].ToString());
                }
                // 속성정보, 디버프정보

                if (obj.ContainsKey("debuff") || cheked_Eelemental || cheked_slots || cheked_slots_Count || cheked_Build || cheked_Eelemental)
                {
                    //build_name == derivation , slot.Contains(this.slots_lv) , slot.Contains(this.slots_Number)
                    if (cheked_Build && build_name == derivation)
                    {
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, imgUri, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_name, elemental_value));
                    }
                    else if (cheked_Eelemental && (elemental_Name == elemental_name || elemental_Name == debuff_name))
                    {
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, imgUri, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_name, elemental_value));
                    }
                    else if (cheked_slots && slot.Contains(this.slots_lv))
                    {
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, imgUri, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_name, elemental_value));
                    }
                    else if (cheked_slots_Count && slot.Contains(this.slots_Number))
                    {
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, imgUri, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_name, elemental_value));
                    }
                    else if (obj.ContainsKey("debuff") && (this.elemental_Name == elemental_name))
                    {
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, imgUri, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_name, elemental_value));
                    }
                }
                else
                {
                    wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                    wcList.Add(new WeaponCreate(name, imgUri, con_make, make_price, upgrade_price, derivation));
                    weList.Add(new WeaponEelemental(idx, elemental_name, elemental_value));
                }
                AddNode(obj2, childNode);
            }
            else if (token is JArray)
            {
                var array = (JArray)token;
                for (int i = 0; i < array.Count; i++)
                {
                    var arrCount = array[i];
                    var obj = (JObject)arrCount;

                    var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(obj["derivation"].ToString()))];
                    childNode.Tag = array[i];

                    AddNode(array[i], childNode);
                }
            }
            else
            {
                Debug.WriteLine(string.Format("{0} not implemented", token.Type)); // JConstructor, JRaw
            }
        }
        /// <summary>
        /// 데이터 그리드뷰 행성택시 이벤트
        /// </summary>
        /// <param name="sender">선택된 행번호출력</param>
        /// <param name="idx">선탱된 행번호를 인덱스로 idx 비교</param>
        private void weapon_data_SelectionChanged(object sender, EventArgs e)
        {
            select_idx = ((DataGridView)sender).CurrentRow.Index;

            if (weapon_data_View.Rows.Count >= 1)
            {
                int row_Index = weapon_data_View.CurrentRow.Index;

                current_name = weapon_data_View.Rows[row_Index].Cells[1].Value.ToString();

                // 수정
                foreach (var item in wcList)
                {
                    if (current_name == item.Weapon_name)
                    {
                        pictur_weapon.ImageLocation = item.ImgUri.ToString();
                    }
                }



            }
        }

        private void EeleMental_Changed(object sender, EventArgs e)
        {
            // 선택된 라디오버튼(속성)에 있으면
            if (((RadioButton)sender).Checked)
            {
                this.elemental_Name = ((RadioButton)sender).Text;
                cheked_Eelemental = true;
                //MessageBox.Show(selected_Eelemental); 
            }
            else if (((RadioButton)sender).Text == "전체")
            {
                cheked_Eelemental = false;
            }
            cheked_weapon = false;
            btn_weapons_Click(null, null);
        }

        private void rdio_AllTree_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                build_name = ((RadioButton)sender).Text;
                cheked_Build = true;
            }
            else if (((RadioButton)sender).Text == "전체")
            {
                cheked_Build = false;
            }
            cheked_weapon = false;
            btn_weapons_Click(null, null);
        }

        private void rdio_Slots_All_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                slots_lv = ((RadioButton)sender).Text;
                cheked_slots = true;
            }
            else if (((RadioButton)sender).Text == "전체")
            {
                cheked_slots = false;
            }
            cheked_weapon = false;
            btn_weapons_Click(null, null);
        }

        private void rdio_Slots_AllCount_CheckedChanged(object sender, EventArgs e)
        {

            if (((RadioButton)sender).Checked)
            {
                slots_Number = ((RadioButton)sender).Text;
                cheked_slots = true;
            }
            else if (((RadioButton)sender).Text == "전체")
            {
                cheked_slots = false;
            }
            cheked_weapon = false;
            btn_weapons_Click(null, null);
        }

        private void btn_InpoShow_Click(object sender, EventArgs e)
        {
            //
            try
            {
                this.select_name = weapon_data_View.CurrentRow.Cells["WeaponName"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("테이블에서 다시 선택후 클릭해주세요");
            }

            fwif = new FrmWeaponInfo();
            fwif.weapon_pictur.ImageLocation = this.pictur_weapon.ImageLocation;

            fwif.listView1.Columns.Add("구분");
            fwif.listView1.Columns.Add("수량");
            fwif.listView1.Columns.Add("획득처");

            fwif.listView2.Columns.Add("구분");
            fwif.listView2.Columns.Add("수량");
            fwif.listView2.Columns.Add("획득처");

            // 기본정보 전달
            foreach (var item in wbList)
            {
                if (item.Idx == select_idx)
                {
                    fwif.lbl_type.Text = weapon_button_name;
                    fwif.lbl_name.Text = item.WeaponName;
                    fwif.lbl_att.Text = item.Attack.ToString();
                    fwif.lbl_criti.Text = item.Critical.ToString();
                    fwif.lbl_debuf.Text = item.Defence.ToString();
                    fwif.lbl_rare.Text = item.Rare.ToString();
                    fwif.lbl_Slots.Text = item.Slot.ToString();
                }
            }
            // 제작 정보 전달
            foreach (var item in wcList)
            {
                if (item.Weapon_name == this.select_name)
                {
                    // 강화재료 파싱 필요
                }
            }
            // 속성 정보 전달
            foreach (var item in weList)
            {
                if (item.Idx == this.select_idx)
                {
                    if (String.IsNullOrEmpty(item.Elmental_name))
                    {
                        fwif.lbl_ele.Text = item.Elmental_name;
                        fwif.lbl_eleValue.Text = item.Elmental_value.ToString();
                    }
                    else
                    {
                        fwif.lbl_ele.Visible = false;
                        fwif.lbl_eleValue.Visible = false;
                    }
                }
            }
            // 디버프 정보 전달
            foreach (var item in wdList)
            {
                if (item.Idx == select_idx)
                {
                    if (String.IsNullOrEmpty(item.Debuff_type))
                    {
                        fwif.lbl_debuf.Text = item.Debuff_type;
                        fwif.lbl_deValue.Text = item.Debuff_value.ToString();
                    }
                    else
                    {
                        fwif.lbl_debuf.Visible = false;
                        fwif.lbl_deValue.Visible = false;
                    }
                }
            }
            // 예리도 정보 전달
            Durability_Chart(fwif);

            fwif.ShowDialog();
        }
        private Point mousePoint;
        private Form1 form1;

        private void Durability_Chart(FrmWeaponInfo fwif)
        {
            fwif.chart1.ChartAreas[0].BackColor = Color.SlateGray;
            fwif.chart1.Series.Clear();

            fwif.chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0; //AxisY.Style |= AxisStyles.HideText;
            fwif.chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0; //AxisY.Style |= AxisStyles.HideText;

            string[] color = { "Red", "Orange", "Yellow", "Green", "Blue", "White" };
            for (int i = 0; i < color.Count(); i++)
            {
                fwif.chart1.Series.Add(color[i]);
                fwif.chart1.Series[i].ChartType = SeriesChartType.StackedBar;
            }
            bool first_chk = true;
            bool last_chk = true;
            int for_index = select_idx + 1;
            foreach (var item in duaList)
            {
                if (first_chk)
                {
                    if (item.Idx == duaList[for_index - 1].Idx)
                    {
                        fwif.chart1.Series["Red"].Points.Add(item.Red);
                        fwif.chart1.Series["Orange"].Points.Add(item.Orange);
                        fwif.chart1.Series["Yellow"].Points.Add(item.Yellow);
                        fwif.chart1.Series["Green"].Points.Add(item.Green);
                        fwif.chart1.Series["Blue"].Points.Add(item.Blue);
                        fwif.chart1.Series["White"].Points.Add(item.White);
                        first_chk = false;
                        last_chk = true;
                        
                        
                    }
                }
                else if (last_chk)
                {
                    if (item.Idx == duaList[for_index].Idx)
                    {
                        fwif.chart1.Series["Red"].Points.Add(item.Red);
                        fwif.chart1.Series["Orange"].Points.Add(item.Orange);
                        fwif.chart1.Series["Yellow"].Points.Add(item.Yellow);
                        fwif.chart1.Series["Green"].Points.Add(item.Green);
                        fwif.chart1.Series["Blue"].Points.Add(item.Blue);
                        fwif.chart1.Series["White"].Points.Add(item.White);
                        first_chk = true;
                        last_chk = false;
                    }
                }
                else if(for_index >= duaList.Count)
                {
                    break;
                }

            }

            for (int i = 0; i < fwif.chart1.Legends.Count(); i++)
            {
                fwif.chart1.Legends[i].Enabled = false;
            }
        }
    }
}