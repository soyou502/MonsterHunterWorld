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
    // 통합본
    public partial class FrmWeaponList : Form
    {
        FrmWeaponInfo fwif;
        private Form form1;
        Button btn;
        MonsterHunterAPI mapi = new MonsterHunterAPI();
        List<WeaponBase> wbList = new List<WeaponBase>(); // 기본정보
        List<WeaponEelemental> weList = new List<WeaponEelemental>(); // 속성
        List<WeaponDebuff> wdList = new List<WeaponDebuff>(); // 디버프
        List<WeaponCreate> wcList = new List<WeaponCreate>(); // 제작
        List<Weapons_Durability> duaList = new List<Weapons_Durability>(); // 예리도
        List<Weapons_Image> imageList = new List<Weapons_Image>(); // 이미지

        // 조건 저장용 리스트
        List<WeaponBase> if_wbList = new List<WeaponBase>(); // 기본정보


        private int make_price; // 제작비용
        private int upgrade_price; // 업글 비용
        private string weapon_type; // 무기종류(영문)
        private string weapon_button_name; // 무기이름
        private string first_wtype; // 첫실행시 무기타입
        private string build_name; // 파생트리 이름 저장용
        private int slots_lv; // 슬롯 레벨
        private int slots_count; // 슬롯 수

        private bool cheked_weapon = true; // 무기버튼 체크
        private bool cheked_Build; // 파생 체크
        private bool cheked_Eelemental; // 속성 체크
        private bool cheked_SlotsLv; // 슬롯 체크 
        private bool cheked_SlotsCount; // 슬롯 체크 

        private int select_idx; // 데이터 그리드뷰 행 선택 인덱스

        private string elemental_Name;  // 이벤트용 속성이름
        private string select_name; // 그리드뷰 선택한 행의 무기 이름

        private string sp_type; // 스페셜 타입

        public FrmWeaponList()
        {
            InitializeComponent();

        }

        public FrmWeaponList(Form form1) : this()
        {
            this.form1 = form1;
        }

        private void FrmWeaponList_Load(object sender, EventArgs e)
        {
            this.Location = form1.Location;
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

        private void ScreenButton2()
        {   // wbList 조건문
            // 체크포인트1
            if_wbList.Clear();
            if (cheked_Build && (cheked_SlotsCount || cheked_SlotsLv))
            {
                for (int i = 0; i < wbList.Count; i++)
                {
                    for (int j = 0; j < wcList.Count; j++)
                    {
                        if (wcList[i].Derivation.Contains(build_name))
                        {
                            string wp_name = wcList[i].Weapon_name;
                            if (slots_count == 1)
                            {
                                if (wbList[i].Slot.Length == 1)
                                {
                                    if (wbList[i].Slot.Contains(slots_lv.ToString()) && wbList[j].WeaponName == wp_name)
                                    {
                                        if_wbList.Add(wbList[i]);
                                    }
                                }
                            }
                        }
                        else if (wcList[i].Derivation.Contains(build_name))
                        {
                            string wp_name = wcList[i].Weapon_name;
                            if (slots_count == 2)
                            {
                                if (wbList[i].Slot.Length == 2)
                                {
                                    if (wbList[i].Slot.Contains(slots_lv.ToString()) && wbList[j].WeaponName == wp_name)
                                    {
                                        if_wbList.Add(wbList[i]);
                                    }
                                }
                            }
                        }
                        else if (wcList[i].Derivation.Contains(build_name))
                        {
                            string wp_name = wcList[i].Weapon_name;
                            if (slots_count == 3)
                            {
                                if (wbList[i].Slot.Length == 3)
                                {
                                    if (wbList[i].Slot.Contains(slots_lv.ToString()) && wbList[j].WeaponName == wp_name)
                                    {
                                        if_wbList.Add(wbList[i]);
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
            else if (cheked_SlotsCount && cheked_SlotsLv)
            {   // 슬롯 수 + 레벨
                for (int i = 0; i < wbList.Count; i++)
                {
                    if (slots_count == 1)
                    {
                        if (wbList[i].Slot.Length == 1)
                        {
                            if (wbList[i].Slot.Contains(slots_lv.ToString()))
                            {
                                if_wbList.Add(wbList[i]);
                            }
                        }
                    }
                    else if (slots_count == 2)
                    {
                        if (wbList[i].Slot.Length == 2)
                        {
                            if (wbList[i].Slot.Contains(slots_lv.ToString()))
                            {
                                if_wbList.Add(wbList[i]);
                            }

                        }
                    }
                    else if (slots_count == 3)
                    {
                        if (wbList[i].Slot.Length == 3)
                        {
                            if (wbList[i].Slot.Contains(slots_lv.ToString()))
                            {
                                if_wbList.Add(wbList[i]);
                            }
                        }
                    }
                }
            }
            else if (cheked_Eelemental && cheked_Build)
            { //속성+파생
                for (int i = 0; i < weList.Count; i++)
                {
                    if (weList[i].Elmental_name == elemental_Name)
                    {   // 속성
                        int ele_idx = weList[i].Idx; // 속성 dix

                            foreach (var wb in wbList)
                            {
                                if (wb.Idx == ele_idx)
                                {
                                    foreach (var wc in wcList)
                                    {
                                        if (wc.Weapon_name == build_name)
                                        {
                                            if (wb.WeaponName == wc.Weapon_name)
                                            {
                                                if_wbList.Add(wb);
                                            }
                                        }
                                    }
                                }
                            }
                    }
                }

                for (int i = 0; i < wdList.Count; i++)
                {
                    if (wdList[i].Debuff_type == elemental_Name)
                    {   // 속성
                        int ele_idx = weList[i].Idx; // 속성 dix

                        foreach (var item in wcList)
                        {
                            if (item.Weapon_name == build_name) // 파생 무기이름
                            {
                                string wp_name = item.Weapon_name;
                                for (int j = 0; j < wbList.Count(); j++)
                                {
                                    if (wbList[j].Idx == ele_idx && wbList[j].WeaponName == wp_name)
                                    {
                                        if_wbList.Add(wbList[j]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (cheked_Eelemental || cheked_Build || cheked_SlotsCount || cheked_SlotsLv)
            {
                if (cheked_Eelemental) // 속성 조건 검색
                {
                    for (int i = 0; i < weList.Count; i++)
                    {
                        if (weList[i].Elmental_name == elemental_Name)
                        {   // 속성
                            int ele_idx = weList[i].Idx;
                            foreach (var item in wbList)
                            {
                                if (item.Idx == ele_idx)
                                {
                                    string wp_name = item.WeaponName;
                                    if_wbList.Add(item);
                                    break;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < wdList.Count; i++)
                    {
                        if (wdList[i].Debuff_type == elemental_Name)
                        {   // 상태이상
                            int dbf_idx = wdList[i].Idx;
                            foreach (var item in wbList)
                            {
                                if (item.Idx == dbf_idx)
                                {
                                    string wp_name = item.WeaponName;
                                    if_wbList.Add(item);
                                    break;
                                }
                            }
                        }
                    }

                }
                else if (cheked_Build)
                {   // 파생조건
                    for (int i = 0; i < wcList.Count; i++)
                    {
                        if (wcList[i].Derivation.Contains(build_name))
                        {
                            string wp_name = wcList[i].Weapon_name;
                            foreach (var item in wbList)
                            {
                                if (item.WeaponName == wp_name)
                                {
                                    if_wbList.Add(item);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (cheked_SlotsCount)
                {// 슬롯 수 조건
                    for (int i = 0; i < wbList.Count; i++)
                    {
                        if (slots_count == 1)
                        {
                            if (wbList[i].Slot.Length == 1)
                            {
                                if_wbList.Add(wbList[i]);
                            }
                        }
                        else if (slots_count == 2)
                        {
                            if (wbList[i].Slot.Length == 2)
                            {
                                if_wbList.Add(wbList[i]);

                            }
                        }
                        else if (slots_count == 3)
                        {
                            if (wbList[i].Slot.Length == 3)
                            {
                                if_wbList.Add(wbList[i]);
                            }
                        }
                    }
                }
                else if (cheked_SlotsLv)
                {   // 슬롯 레벨 조건
                    for (int i = 0; i < wbList.Count; i++)
                    {
                        if (wbList[i].Slot.Contains(slots_lv.ToString()))
                        {
                            if_wbList.Add(wbList[i]);
                        }
                    }
                }
                else
                {
                    foreach (var item in wbList)
                    {
                        if_wbList.Add(item);
                    }
                }
            }
            weapon_data_View.DataSource = null;
            if (if_wbList.Count > 0)
            {
                weapon_data_View.DataSource = if_wbList;
            }
            else
            {
                weapon_data_View.DataSource = wbList;
            }
            weapon_data_View.Columns["idx"].Visible = false; // idx 열 안보임
            weapon_data_View.Columns["Specal_type"].Visible = false; // idx 열 안보임
            weapon_data_View.Columns["Melody"].Visible = false; // idx 열 안보임
            weapon_data_View.Columns["idx"].Visible = false; // idx 열 안보임
            weapon_data_View.Columns["WeaponName"].HeaderText = "무기이름";
            weapon_data_View.Columns["Rare"].HeaderText = "레어도";
            weapon_data_View.Columns["Attack"].HeaderText = "공격력";
            weapon_data_View.Columns["Defence"].HeaderText = "방어력";
            weapon_data_View.Columns["Critical"].HeaderText = "회심률";
            weapon_data_View.Columns["Slot"].HeaderText = "슬롯";
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
            {// 해외사이트 이미지 링크 파싱
                JObject job = JObject.Parse(item["assets"].ToString());
                int idx = Int32.Parse(item["id"].ToString());
                string image = job["image"].ToString();
                imageList.Add(new Weapons_Image(idx, image));

                // 예리도 파싱
                for (int j = 0; j < item["durability"].Count(); j++)
                {
                    JToken first_jtok = item["durability"][0];  // 처음 예리도


                    int red = Int32.Parse(first_jtok["red"].ToString());
                    int orange = Int32.Parse(first_jtok["orange"].ToString());
                    int yellow = Int32.Parse(first_jtok["yellow"].ToString());
                    int green = Int32.Parse(first_jtok["green"].ToString());
                    int blue = Int32.Parse(first_jtok["blue"].ToString());
                    int white = Int32.Parse(first_jtok["white"].ToString());

                    duaList.Add(new Weapons_Durability(wbList[j].Idx, red, orange, yellow, green, blue, white));

                    int last_Count = Int32.Parse(item["durability"].Count().ToString()); // 장비 최종 예리도
                    JToken last_jtok = item["durability"][last_Count - 1]; // 마지막 예리도
                    red = Int32.Parse(last_jtok["red"].ToString());
                    orange = Int32.Parse(last_jtok["orange"].ToString());
                    yellow = Int32.Parse(last_jtok["yellow"].ToString());
                    green = Int32.Parse(last_jtok["green"].ToString());
                    blue = Int32.Parse(last_jtok["blue"].ToString());
                    white = Int32.Parse(last_jtok["white"].ToString());

                    duaList.Add(new Weapons_Durability(wbList[j].Idx, red, orange, yellow, green, blue, white));

                    count++;
                }
            }
        }



        #endregion
        private void GetWeaponDate(string weapon_type)
        {
            JArray json = JArray.Parse(mapi.GetJson(new Parameter(weapon_type)));
            //getData(weapon_type, json);
            DisplayTreeView(json, "무기도감");

            weapon_data_View.DataSource = null;
            weapon_data_View.DataSource = wbList;
            weapon_data_View.Columns["idx"].Visible = false; // idx 열 안보임
            weapon_data_View.Columns["Specal_type"].Visible = false; // idx 열 안보임
            weapon_data_View.Columns["Melody"].Visible = false; // idx 열 안보임
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
                // 기본정보

                if (obj.ContainsKey("포격타입"))
                {
                    sp_type = obj["포격타입"].ToString();
                }
                else if (obj.ContainsKey("병"))
                {
                    sp_type = obj["병"].ToString();
                }
                else if (obj.ContainsKey("벌레"))
                {
                    sp_type = obj["벌레"].ToString();
                }
                else if (obj.ContainsKey("특수탄"))
                {
                    sp_type = obj["특수탄"].ToString();
                }

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
                // 제작정보 끝

                if (obj.ContainsKey("weakness"))
                {
                    JToken elementalObj = obj["weakness"];
                    string elemental_Name = elementalObj["type"].ToString();
                    int elemental_value = Int32.Parse(elementalObj["value"].ToString());
                    weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));

                }
                else if (obj.ContainsKey("debuff"))
                {
                    JToken debuffObj = obj["debuff"];
                    string debuff_name = debuffObj["type"].ToString();
                    int debuff_value = Int32.Parse(debuffObj["value"].ToString());
                    weList.Add(new WeaponEelemental(idx, debuff_name, debuff_value));
                }
                else if (obj.ContainsKey("weakness") && obj.ContainsKey("debuff"))
                {
                    JToken elementalObj = obj["weakness"];
                    string elemental_Name = elementalObj["type"].ToString();
                    int elemental_value = Int32.Parse(elementalObj["value"].ToString());
                    weList.Add(new WeaponEelemental(idx, elemental_Name, elemental_value));

                    JToken debuffObj = obj["debuff"];
                    string debuff_name = debuffObj["type"].ToString();
                    int debuff_value = Int32.Parse(debuffObj["value"].ToString());
                    wdList.Add(new WeaponDebuff(idx, debuff_name, debuff_value));
                }
                // 속성정보, 디버프정보
                if (weapon_button_name == "라이트보우건" || weapon_button_name == "헤비보우건" || weapon_button_name == "건랜스" || weapon_button_name == "차지액스" || weapon_button_name == "슬래시액스" || weapon_button_name == "조충곤")
                {
                    wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot, sp_type));
                }
                else
                {
                    wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slot));
                }
                wcList.Add(new WeaponCreate(name, con_make, make_price, upgrade_price, derivation));
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
            if (rdio_Tree_All.Checked)
            { // 파생이 전체로 체크되면
                cheked_Build = false;
            }
            else
            {
                build_name = ((RadioButton)sender).Text.Replace(" ", "").Replace("파생", "").Replace("속성", "");
                cheked_Build = true;
            }
            try
            {
                ScreenButton2();
            }
            catch (Exception)
            {
                MessageBox.Show("먼저 무기 타입을 선택하세요");
            }
        }

        // 상세정보 윈폼 출력 버튼
        private void btn_InpoShow_Click(object sender, EventArgs e)
        {
            //
            try
            {
                this.select_name = weapon_data_View.CurrentRow.Cells["WeaponName"].ToString();
                fwif = new FrmWeaponInfo();
                fwif.weapon_pictur.ImageLocation = this.pictur_weapon.ImageLocation;
            }
            catch (Exception)
            {
                MessageBox.Show("테이블에서 다시 선택후 클릭해주세요");
                return;
            }


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
                    fwif.lbl_Slots.Text = item.Slot.ToString();
                }
                if (item.Specal_type == null)
                {
                    fwif.lbl_spc_type.Visible = false;
                }
                else if (item.Specal_type != null)
                {
                    fwif.lbl_spc_type.Visible = true;
                    fwif.lbl_spc_type.Text = item.Specal_type;
                }
            }

            // 제작 및 업그레이드 정보 전달
            foreach (var item in wcList)
            {
                if (item.Weapon_name == wbList[select_idx].WeaponName)
                {
                    fwif.lbl_der.Text = wcList[select_idx].Derivation.ToString();
                    fwif.lbl_make_price.Text = wcList[select_idx].Make_price.ToString();
                    fwif.upgrade_price.Text = wcList[select_idx].Upgrade_price.ToString();

                    if (item.Con_make == true)
                    {
                        fwif.lbl_creaft.Text = "가능";
                        fwif.lbl_creaft.ForeColor = Color.AliceBlue;
                        
                    }
                    else
                    {
                        fwif.lbl_creaft.Text = "불가능";
                        fwif.lbl_creaft.ForeColor = Color.Red;
                    }
                }
            }
            // 속성 정보 전달
            foreach (var item in weList)
            {
                if (item.Idx == wbList[select_idx].Idx)
                {
                    fwif.lbl_ele.Text = item.Elmental_name;
                    fwif.lbl_eleValue.Visible = true;
                    fwif.lbl_eleValue.Text = item.Elmental_value.ToString();
                    break;
                }
                else
                {
                    fwif.lbl_ele.Text = "없습니다";
                    fwif.lbl_eleValue.Visible = false;
                }
            }
            fwif.lbl_deValue.Visible = false;
            // 디버프 정보 전달
            foreach (var item in wdList)
            {
                if (String.IsNullOrEmpty(item.Debuff_type))
                {
                    fwif.lbl_debuf.Text = item.Debuff_type;
                    fwif.lbl_eleValue.Visible = true;
                    fwif.lbl_deValue.Text = item.Debuff_value.ToString().Replace("-", "");
                    break;
                }
                else
                {
                    fwif.lbl_debuf.Text = "없습니다.";
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
            // 예리도 차트
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
                        break;
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
                            pictur_weapon.ImageLocation = item.Image_Uri;
                            break;
                        }
                    }
                }
            }
        }

        private void rdio_Elemental_All_Click(object sender, EventArgs e)
        {
            if (rdio_Elemental_All.Checked) // <- 이거 이상함 내가 원하는거랑 반대로 작동함
            {   // 속성 전체가 체크되면 실행

                cheked_Eelemental = false;
            }
            else
            {
                this.elemental_Name = ((RadioButton)sender).Text;
                cheked_Eelemental = true;
            }
            try
            {
                ScreenButton2();
            }
            catch (Exception)
            {

                MessageBox.Show("무기 종류를 먼저 선택해주세요", "속성 오류");
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
            GetWeaponDate(("weapons/" + this.first_wtype));

            GetDurability(DurabilityJSON());
        }

        private void chk_slotsLevel_3_Click(object sender, EventArgs e)
        {

            if (chk_slotsLevel_All.Checked)
            {   // 현재 체크한게 ALL 체크박스면 실행

                cheked_SlotsLv = false; // Slot 박스 ALL

                // 다른 레벨 체크박스 전부 해제
            }
            else
            {
                cheked_SlotsLv = true;
                if (chk_slotsLevel_1.Checked)
                {
                    slots_lv = 1; // 슬롯레벨[0] 에 1 넣기
                }
                else if (chk_slotsLevel_2.Checked)
                {
                    slots_lv = 2;
                }
                else if (chk_slotsLevel_3.Checked)
                {
                    slots_lv = 3;
                }
            }
            try
            {
                if_wbList.Clear();
                ScreenButton2();
            }
            catch (Exception)
            {
                chk_slotsLevel_All.Checked = true;
                MessageBox.Show("무기종류를 먼저 선택해주세요.", "슬롯레벨 오류");
            }
        }

        private void chk_slotsCount_Click(object sender, EventArgs e)
        {
            if (chk_slotsCount_All.Checked)
            {   // 현재 체크한게 ALL 체크박스면 실행

                slots_count = 0;// 실행완료 후 0으로 초기화

                // 다른 레벨 체크박스 전부 해제

                cheked_SlotsCount = false;
            }
            else
            {
                cheked_SlotsCount = true;

                if (chk_slotsCount_1.Checked)
                {
                    slots_count = 1;
                }
                else if (chk_slotsCount_2.Checked)
                {
                    slots_count = 2;
                }
                else if (chk_slotsCount_3.Checked)
                {
                    slots_count = 3;
                }
            }
            try
            {
                ScreenButton2();
            }
            catch (Exception)
            {
                chk_slotsCount_All.Checked = true;
                MessageBox.Show("무기종류를 먼저 선택해주세요.", "슬롯 수 오류");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void FrmWeaponList_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }
    }
}