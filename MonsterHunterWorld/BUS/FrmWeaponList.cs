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

namespace MonsteHunterWorld
{
    public partial class FrmWeaponList : Form
    {
        MonsterHunterAPI mapi = new MonsterHunterAPI();
        List<WeaponBase> wbList = new List<WeaponBase>();
        List<WeaponEelemental> weList = new List<WeaponEelemental>();
        List<WeaponCreate> wcList = new List<WeaponCreate>();

        public FrmWeaponList()
        {
            InitializeComponent();
        }

        private void FrmWeaponList_Load(object sender, EventArgs e)
        {


        }

        private void btn_weapons_Click(object sender, EventArgs e)
        {
            weapon_tree.Nodes.Clear();
            GetWeaponDate(("weapons/" + ((Button)sender).Text));
        }

        private void GetWeaponDate(string weapon_type)
        {
            JArray json = JArray.Parse(mapi.GetJson(new Parameter(weapon_type)));
            getData(weapon_type, json);

            waepon_data.DataSource = wbList;
        }

        private void getData(string weapon_type, JArray json)
        {
            if (weapon_type.Contains("대검") || weapon_type.Contains("태도") || weapon_type.Contains("한손검") || weapon_type.Contains("쌍검") || weapon_type.Contains("해머") || weapon_type.Contains("랜스"))
            {
                foreach (var item in json)
                {
                    int idx = Int32.Parse(item["idx"].ToString());
                    string name = item["name"].ToString();
                    int rare = Int32.Parse(item["rare"].ToString());
                    int attack = Int32.Parse(item["attack"].ToString());
                    int defense = Int32.Parse(item["defense"].ToString());
                    int critical = Int32.Parse(item["critical"].ToString());
                    string slots = item["slots"].ToString();

                    // 무기 기본 정보 데이터 저장
                    wbList.Add(new WeaponBase(idx, name, rare, attack, defense, critical, slots));

                    // JObject job = JObject.Parse(item.ToString());

                    // 조건문을 통해 속석과 상태이상 정보를 획득

                    #region json 자식노드 받기와 트리뷰 생성 작성중(수정중)
                    if (item["children"].HasValues)
                    {
                        var test = item["children"];
                        foreach (var jtem in test)
                        {
                            MessageBox.Show(jtem["name"].ToString());
                            test = item["children"].Next;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Test");
                    }
                    #endregion



                    weapon_tree.Nodes.Add(item["name"].ToString());
                }
            }
            else if (weapon_type.Contains("수렵피리"))
            {

            }
            else if (weapon_type.Contains("건랜스"))
            {

            }
            else if (weapon_type.Contains("조충곤"))
            {

            }
            else if (weapon_type.Contains("수렵피리"))
            {

            }
            else if (weapon_type.Contains("보우건"))
            {

            }
            else
            {
                // 활
            }
        }

        /* //  메모용 
        //기본정보
        무기번호
        이름
        레어도
        공격력
        방어력
        회심률
        슬롯

        //속성정보
        무기번호
        속성이름
        속성수치
        상태이상이름
        상태이상수치

        // 제작정보
                무기번호
        이미지
        소재파생
        제작가능여부
        제작비용
        업글비용
        */ 
    }
}