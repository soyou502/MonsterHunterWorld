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
        List<Weapons_Image> imageList = new List<Weapons_Image>(); // 이미지

        private int make_price; // 제작비용
        private int upgrade_price; // 업글 비용
        private string weapon_type; // 무기종류(영문)
        private string weapon_button_name; // 무기이름
        private string first_wtype; // 첫실행시 무기타입
        private string current_name; // 선택한 셀 인덱스
        private string build_name; // 파생트리 이름 저장용
        private string[] slots_lv = new string[3]; // 슬롯 레벨
        private int slots_count; // 슬롯 수

        private bool cheked_weapon = true; // 무기버튼 체크
        private bool cheked_Build; // 파생 체크
        private bool cheked_Eelemental; // 속성 체크
        private bool cheked_SlotsLv; // 슬롯 체크 
        private bool cheked_SlotsCount; // 슬롯 체크 

        private int select_idx; // 데이터 그리드뷰 행 선택 인덱스

        private string elemental_Name;  // 이벤트용 속성이름
        private string ele_name;      // 파싱용 속성이름
        private int elemental_value; // 속성수치
        private string debuff_name; // 디버프이름
        private int debuff_value; // 디버프 수치
        private string select_name; // 그리드뷰 선택한 행의 무기 이름
    
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

        private void FrmWeaponList_Load(object sender, EventArgs e)
        {
            pictur_weapon.SizeMode = PictureBoxSizeMode.Zoom;

            chk_slotsLevel_All.Checked = true;
            chk_slotsCount_All.Checked = true;
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
            cheked_weapon = true; // 버튼 클릭시만 true

            weapon_button_name = ((Button)sender).Text;

            if (cheked_weapon)
            {
                cheked_weapon = false; // 그리드뷰 이벤트 중복 방지용
                this.btn = (Button)sender;
                this.first_wtype = ((Button)sender).Text;
                weapon_type = weapon_if((Button)sender, ((Button)sender).Text);
            }
            else
            {
                weapon_type = weapon_if(null, null);
            }

            ScreenButton();
        }
        // 해외사이트 검색용으로 조건문들이 늘어남
        private string weapon_if(object sender, string type)
        {

            if (this.btn.Text == "대검" || first_wtype == "대검")
            {
                return "great-sword";
            }
            else if (this.btn.Text == "태도" || first_wtype == "태도")
            {
                return "long-sword";
            }
            else if (this.btn.Text == "한손검" || first_wtype == "대검")
            {
                return "sword-and-shield";
            }
            else if (this.btn.Text == "쌍검" || first_wtype == "쌍검")
            {
                return "dual-blades";
            }
            else if (this.btn.Text == "해머" || first_wtype == "해머")
            {
                return "hammer";
            }
            else if (this.btn.Text == "수렵피리" || first_wtype == "수렵피리")
            {
                return "hunting-horn";
            }
            else if (this.btn.Text == "랜스" || first_wtype == "랜스")
            {
                return "lance";
            }
            else if (this.btn.Text == "건랜스" || first_wtype == "건랜스")
            {
                return "gunlance";
            }
            else if (this.btn.Text == "슬러시액스" || first_wtype == "슬러시액스")
            {
                return "switch-axe";
            }
            else if (this.btn.Text == "차지액스" || first_wtype == "차지액스")
            {
                return "charge-blade";
            }
            else if (this.btn.Text == "조곤충" || first_wtype == "조곤충")
            {
                return "insect-glaive";
            }
            else if (this.btn.Text == "라이트보우건" || first_wtype == "라이트보우건")
            {
                return "light-bowgun";
            }
            else if (this.btn.Text == "헤비보우건" || first_wtype == "헤비보우건")
            {
                return "heavy-bowgun";
            }
            else
            {
                return "bow";
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
            weapon_data_View.Columns["idx"].Visible = false; // idx 열 안보임
            weapon_data_View.Columns["WeaponName"].HeaderText = "무기이름";
            weapon_data_View.Columns["Rare"].HeaderText = "레어도";
            weapon_data_View.Columns["Attack"].HeaderText = "공격력";
            weapon_data_View.Columns["Defence"].HeaderText = "방어력";
            weapon_data_View.Columns["Critical"].HeaderText = "회심률";
            weapon_data_View.Columns["Slot"].HeaderText = "슬롯";
        }

        // 트리뷰 출력
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

        // 데이터 파싱, 트리뷰 노드 생성
        private void AddNode(JToken token, TreeNode inTreeNode)
        {
            if (token == null) // 토큰이 없다면 되돌림
                return;
            if (token is JValue) // 토큰이 Jvalu 타입이면 실행
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
                string slot = obj["slots"].ToString().Replace(" ", "").Trim();
                string imageUri = obj["icon"].ToString();
                // 기본정보

                // 제작정보
                //string imgUri = obj["icon"].ToString(); // 이미지
                bool con_make = bool.Parse(obj["can_make"].ToString()); // 제작가능여부
                string derivation = obj["derivation"].ToString(); // 소재파생

                if (obj.ContainsKey("make_price")) // make_price 가 있다면
                {
                    make_price = Int32.Parse(obj["make_price"].ToString()); // 제작비용
                }
                else if (obj.ContainsKey("upgrade_price")) // 업글 가격이 있따면
                {
                    upgrade_price = Int32.Parse(obj["upgrade_price"].ToString()); // 업글비용 
                }
                else if (obj.ContainsKey("make_price") && obj.ContainsKey("upgrade_price")) // 업글 비용이 있다면
                {
                    make_price = Int32.Parse(obj["make_price"].ToString()); // 제작비용
                    upgrade_price = Int32.Parse(obj["upgrade_price"].ToString()); // 업글비용 
                }
                // 제작정보

                // 속성정보, 디버프정보

                if (obj.ContainsKey("weakness"))
                {
                    JToken elementalObj = obj["weakness"];
                    ele_name = elementalObj["type"].ToString();
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
                    ele_name = elementalObj["type"].ToString();
                    elemental_value = Int32.Parse(elementalObj["value"].ToString());

                    JToken debuffObj = obj["debuff"];
                    debuff_name = debuffObj["type"].ToString();
                    debuff_value = Int32.Parse(debuffObj["value"].ToString());
                }
                // 속성정보, 디버프정보

                imageList.Add(new Weapons_Image(idx, imageUri));
                wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));

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
        }

        // 무기파생트리 조건
        private void rdio_AllTree_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                build_name = ((RadioButton)sender).Text.Replace("파생", "").Replace(" ", "").Trim();
                cheked_Build = true;
            }
            else if (((RadioButton)sender).Text == "전체")
            {
                cheked_Build = false;
            }
            cheked_weapon = false;
            ScreenButton();
        }

        // 상세정보 윈폼 출력 버튼
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



            fwif.dataGridView1.Columns.Add("division", "구분");
            fwif.dataGridView1.Columns.Add("Quantity", "수량");
            fwif.dataGridView1.Columns.Add("Acquisition", "획득처");

            fwif.dataGridView2.Columns.Add("division", "구분");
            fwif.dataGridView2.Columns.Add("Quantity", "수량");
            fwif.dataGridView2.Columns.Add("Acquisition", "획득처");

            // 기본정보 전달
            foreach (var item in wbList)
            {
                if (item.Idx == wbList[select_idx].Idx)
                {
                    fwif.lbl_type.Text = weapon_button_name;
                    fwif.lbl_name.Text = item.WeaponName;
                    fwif.lbl_att.Text = item.Attack.ToString();
                    fwif.lbl_defen.Text = item.Defence.ToString();
                    fwif.lbl_criti.Text = item.Critical.ToString();
                    fwif.lbl_debuf.Text = item.Defence.ToString();
                    fwif.lbl_rare.Text = item.Rare.ToString();
                    if (item.Slot.ToString().Length == 1)
                    {
                        fwif.lbl_Slots.Text = item.Slot.ToString() + "__";
                    }
                    else if (item.Slot.ToString().Length == 2)
                    {
                        fwif.lbl_Slots.Text = item.Slot.ToString() + "_";
                    }
                    else
                    {
                        fwif.lbl_Slots.Text = item.Slot.ToString();
                    }

                    fwif.lbl_der.Text = wcList[select_idx].Derivation.ToString();
                }
            }
            // 제작 및 업그레이드 정보 전달
            foreach (var item in wcList)
            {
                if (item.Weapon_name == wcList[select_idx].Weapon_name)
                {
                    if (item.Con_make)
                    {
                        fwif.dataGridView1.Rows.Add("금액", item.Make_price, "");
                    }
                }
            }
            // 속성 정보 전달
            foreach (var item in weList)
            {
                if (item.Idx == weList[select_idx].Idx)
                {
                    fwif.lbl_ele.Text = item.Elmental_name;
                    fwif.lbl_eleValue.Text = item.Elmental_value.ToString();
                }
                else
                {
                    fwif.lbl_ele.Text = "없습니다";
                    fwif.lbl_eleValue.Visible = false;
                }
            }
            // 디버프 정보 전달
            foreach (var item in wdList)
            {
                if (String.IsNullOrEmpty(item.Debuff_type))
                {
                    fwif.lbl_debuf.Text = "님 머임";
                    fwif.lbl_deValue.Text = item.Debuff_value.ToString();
                }
                else
                {
                    fwif.lbl_debuf.Text = "없습니다";
                    fwif.lbl_deValue.Visible = false;
                }
            }
            // 예리도 정보 전달
            Durability_Chart(fwif);

            fwif.ShowDialog(); // 실행
        }

        /// <summary>
        /// 예리도 차트 ( 기본, 최종 예리도 )
        /// </summary>
        /// <param name="Durability_Chart"></param>
        private void Durability_Chart(FrmWeaponInfo fwif)
        {
            fwif.chart1.ChartAreas[0].BackColor = Color.SlateGray;
            //fwif.chart1.ChartAreas[0].
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
                if (first_chk) // 기본 예리도
                {
                    if (item.Idx == duaList[for_index - 1].Idx)
                    {
                        fwif.chart1.Series["Red"].Points.Add(item.Red);
                        fwif.chart1.Series["Red"].Color = Color.Red;
                        fwif.chart1.Series["Orange"].Points.Add(item.Orange);
                        fwif.chart1.Series["Orange"].Color = Color.Orange;
                        fwif.chart1.Series["Yellow"].Points.Add(item.Yellow);
                        fwif.chart1.Series["Yellow"].Color = Color.Yellow;
                        fwif.chart1.Series["Green"].Points.Add(item.Green);
                        fwif.chart1.Series["Green"].Color = Color.Green;
                        fwif.chart1.Series["Blue"].Points.Add(item.Blue);
                        fwif.chart1.Series["Blue"].Color = Color.Blue;
                        fwif.chart1.Series["White"].Points.Add(item.White);
                        fwif.chart1.Series["White"].Color = Color.White;

                        first_chk = false;
                        last_chk = true;

                    }
                }
                else if (last_chk) // 최종 예리도
                {
                    if (item.Idx == duaList[for_index].Idx)
                    {
                        fwif.chart1.Series["Red"].Points.Add(item.Red);
                        fwif.chart1.Series["Red"].Color = Color.Red;
                        fwif.chart1.Series["Orange"].Points.Add(item.Orange);
                        fwif.chart1.Series["Orange"].Color = Color.Orange;
                        fwif.chart1.Series["Yellow"].Points.Add(item.Yellow);
                        fwif.chart1.Series["Yellow"].Color = Color.Yellow;
                        fwif.chart1.Series["Green"].Points.Add(item.Green);
                        fwif.chart1.Series["Green"].Color = Color.Green;
                        fwif.chart1.Series["Blue"].Points.Add(item.Blue);
                        fwif.chart1.Series["Blue"].Color = Color.Blue;
                        fwif.chart1.Series["White"].Points.Add(item.White);
                        fwif.chart1.Series["White"].Color = Color.White;
                        first_chk = true;
                        last_chk = false;
                    }
                }
                else if (for_index >= duaList.Count)
                {
                    break;
                }

            }

            for (int i = 0; i < fwif.chart1.Legends.Count(); i++)
            {
                fwif.chart1.Legends[i].Enabled = false;
            }
        }

        private void weapon_data_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   // 셀 내부의 내용을 클릭하면 발생
            if (!cheked_weapon)
            {
                select_idx = weapon_data_View.CurrentRow.Index;
                // 선태한 행의 인덱스를 idx 로 전달
                if (weapon_data_View.Rows.Count >= 1)
                {   // 행의 수가 1이상이면 실행
                    // 현재 행의 idx 를 current_idx 로 전달
                    int current_idx = Int32.Parse(weapon_data_View.Rows[select_idx].Cells[0].Value.ToString());
                    // 이미지 넣기
                    foreach (var item in imageList)
                    {
                        if (item.Idx == current_idx) // 리스트의 idx 와 선택한 행의 idx가 같으면
                        {
                            pictur_weapon.ImageLocation = item.Image_Uri.ToString();
                            if(item.Image_Uri.ToString() == "")
                            {
                                pictur_weapon.ImageLocation = @"https://media.istockphoto.com/vectors/no-knife-or-no-weapon-prohibition-sign-vector-illustration-vector-id844522804";
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void rdio_Elemental_All_Click(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Name.Contains("All")) // <- 이거 이상함 내가 원하는거랑 반대로 작동함
            {   // 선택한 라이도버튼의 이름이 ALL 이 아니면 실행

                cheked_Eelemental = false;
            }
            else
            {
                this.elemental_Name = ((RadioButton)sender).Text;
                cheked_Eelemental = true;
            }

            try
            {
                ScreenButton();
            }
            catch (Exception)
            {

                MessageBox.Show("무기 종류를 먼저 선택해주세요");
            }
        }

        private void ScreenButton()
        {
            weapon_tree.Nodes.Clear(); // 노드 비우기
            wbList.Clear(); // 리스트 비우기
            wcList.Clear(); // 리스트 비우기
            wdList.Clear(); // 리스트 비우기
            duaList.Clear(); // 리스트 비우기
            imageList.Clear(); // 리스트 비우기
            weapon_data_View.DataSource = null;
            GetWeaponDate(("weapons/" + this.first_wtype));

            // 파싱조건
            if (cheked_Build && cheked_Eelemental && cheked_SlotsLv && cheked_SlotsCount)
            {
                if (build_name == derivation && (elemental_Name == ele_name || elemental_Name == debuff_name))
                {
                    foreach (var Lv in slots_lv)
                    {
                        if (slot.Contains(Lv) && slot.Length == slots_count)
                        {   // slot 에 해당 레벨이 있고 슬롯개수(길이) 가 Count 와 같으면
                            imageList.Add(new Weapons_Image(idx, imageUri));
                            wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                            wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                            weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));
                        }
                    }
                }
            }
            else if (cheked_Build && cheked_Eelemental && cheked_SlotsLv)
            {
                if (build_name == derivation && (elemental_Name == ele_name || elemental_Name == debuff_name))
                {
                    foreach (var Lv in slots_lv)
                    {
                        imageList.Add(new Weapons_Image(idx, imageUri));
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));
                    }
                }
            }
            else if (cheked_Build && cheked_Eelemental)
            {
                if ((elemental_Name == ele_name || elemental_Name == debuff_name))
                {
                    // slot 에 해당 레벨이 있고 슬롯개수(길이) 가 Count 와 같으면
                    imageList.Add(new Weapons_Image(idx, imageUri));
                    wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                    wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                    weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));

                }
            }
            else if (cheked_Eelemental && cheked_SlotsLv && cheked_SlotsCount)
            {
                if (elemental_Name == ele_name || elemental_Name == debuff_name)
                {
                    foreach (var Lv in slots_lv)
                    {
                        if (slot.Contains(Lv) && slot.Length == slots_count)
                        {
                            //imageList
                            //wbList
                            //wcList
                            //weList
                        }
                    }
                }
            }
            else if (cheked_Eelemental && cheked_SlotsLv)
            {
                if (elemental_Name == ele_name || elemental_Name == debuff_name)

                {
                    foreach (var Lv in slots_lv)
                    {


                    }
                }
            }
            else if (cheked_SlotsLv && cheked_SlotsCount)
            {
                foreach (var Lv in slots_lv)
                {
                    if (slot.Contains(Lv) && slot.Length == slots_count)
                    {   // slot 에 해당 레벨이 있고 슬롯개수(길이) 가 Count 와 같으면
                        imageList.Add(new Weapons_Image(idx, imageUri));
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));
                    }
                }
            }
            else if (cheked_Build || cheked_Eelemental || cheked_SlotsLv || cheked_SlotsCount)
            {
                if (build_name == derivation)
                {
                    imageList.Add(new Weapons_Image(idx, imageUri));
                    wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                    wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                    weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));
                }
                else if (elemental_Name == ele_name || elemental_Name == debuff_name)
                {
                    imageList.Add(new Weapons_Image(idx, imageUri));
                    wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                    wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                    weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));
                }
                else if (cheked_SlotsLv)
                {
                    foreach (var Lv in slots_lv)
                    {
                        imageList.Add(new Weapons_Image(idx, imageUri));
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));
                    }
                }
                else if (cheked_SlotsCount)
                {
                    if (slot.Length == slots_count)
                    {
                        imageList.Add(new Weapons_Image(idx, imageUri));
                        wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                        wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
                        weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));
                    }
                }
            }
            else
            {
            }

            GetDurability(DurabilityJSON());
        }

        private void chk_slotsLevel_3_Click(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Name.Contains("All"))
            {   // 현재 체크한게 ALL 체크박스면 실행
                
                cheked_SlotsLv = false; // Slot 박스 ALL
                
                // 다른 레벨 체크박스 전부 해제
                chk_slotsLevel_1.Checked = false;
                chk_slotsLevel_2.Checked = false;
                chk_slotsLevel_3.Checked = false;
            }
            else if (!((CheckBox)sender).Name.Contains("All")) // 체크 이벤트가 발생한다면
            {
                chk_slotsLevel_All.Checked = false;
                cheked_SlotsLv = true;
                if (((CheckBox)sender).Name.Contains("1"))
                {   // 체크박스 이름에 1이 있다면
                    slots_lv[0] = "1"; // 슬롯레벨[0] 에 1 넣기
                }
                else if (((CheckBox)sender).Name.Contains("2"))
                {   // 체크박스 이름에 1이 있다면
                    slots_lv[1] = "2";
                }
                else if (((CheckBox)sender).Name.Contains("3"))
                {   // 체크박스 이름에 1이 있다면
                    slots_lv[2] = "3";
                }
            }
            else if (!((CheckBox)sender).Checked && !((CheckBox)sender).Name.Contains("All"))
            {   // 선택한 체크박스가 해제 되고 All 체크박스가 아니면 실행
                if (((CheckBox)sender).Name.Contains("1"))
                {   // 체크박스 이름에 1이 있다면
                    slots_lv [0] = null; // 비우기
                }
                else if (((CheckBox)sender).Name.Contains("2"))
                {   // 체크박스 이름에 1이 있다면
                    slots_lv[1] = null; // 비우기
                }
                else if (((CheckBox)sender).Name.Contains("3"))
                {   // 체크박스 이름에 1이 있다면
                    slots_lv[2] = null; // 비우기
                }
            }
            else if (!chk_slotsLevel_1.Checked && !chk_slotsLevel_1.Checked && !chk_slotsLevel_1.Checked)
            {   // All 을 제외한 모든 체크가 false 면
                cheked_SlotsLv = false; // Slot 박스 ALL
                slots_lv = null; // 슬롯을 비운다.
            }
            try
            {
                ScreenButton();
            }
            catch (Exception)
            {

                MessageBox.Show("무기종류를 먼저 선택해주세요.");
            }
        }

        private void chk_slotsCount_3_Click(object sender, EventArgs e)
        {
            if (chk_slotsCount_All.Checked == ((CheckBox)sender).Checked)
            {   // 현재 체크한게 ALL 체크박스면 실행

                slots_count = 0; // 슬롯 0으로 초기화.

                // 다른 레벨 체크박스 전부 해제
                chk_slotsCount_1.Checked = false;
                chk_slotsCount_2.Checked = false;
                chk_slotsCount_3.Checked = false;

                cheked_SlotsCount = false;
            }
            else if (((CheckBox)sender).Checked) // 체크 이벤트가 발생한다면
            {
                cheked_SlotsCount = true;
                chk_slotsCount_All.Checked = false;
                if (((CheckBox)sender).Name.Contains("1"))
                {   // 체크박스 이름에 1이 있다면
                    slots_count = 1; // 슬롯레벨[0] 에 1 넣기
                }
                else if (((CheckBox)sender).Name.Contains("2"))
                {   // 체크박스 이름에 1이 있다면
                    slots_count = 2;
                }
                else if (((CheckBox)sender).Name.Contains("3"))
                {   // 체크박스 이름에 1이 있다면
                    slots_count = 3;
                }
            }
            try
            {
                ScreenButton();
            }
            catch (Exception)
            {

                MessageBox.Show("무기종류를 먼저 선택해주세요.");
            }
        }
    }
}