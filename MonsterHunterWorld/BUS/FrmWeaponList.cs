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
        List<WeaponList> wlist = new List<WeaponList>();

        public FrmWeaponList()
        {
            InitializeComponent();
        }

        private void FrmWeaponList_Load(object sender, EventArgs e)
        {
           

        }

       

        

        private void GetWeaponDate(string weapon_type)
        {
            JArray json = JArray.Parse(mapi.GetJson(new Parameter(weapon_type)));
            if (weapon_type.Contains("대검") || weapon_type.Contains("태도") || weapon_type.Contains("한손검") || weapon_type.Contains("쌍검") || weapon_type.Contains("해머") || weapon_type.Contains("랜스"))
            {
                foreach (var item in json)
                {
                   //wlist.Add(new WeaponList() {
                   //ImgUri = item["icon"].ToString(),  // 이미지
                   //WeaponName = item["name"].ToString(), // 무기이름
                   //Rare = Int32.Parse(item["rare"].ToString()), // 레어도
                   //Attack = Int32.Parse(item["attack"].ToString()),// 공격력
                   //Defence = Int32.Parse(item["defense"].ToString()),// 방어력
                   //Critical = Int32.Parse(item["critical"].ToString()),// 회심률
                   //Slot = item["slots"].ToString(), // 슬롯수
                   //Derivation = item["derivation"].ToString(),// 소재파생
                   //                                           //  
                   //Elmental_name = item["weakness"].ToString(), // 속성이름
                   // Elmental_value = Int32.Parse(item["value"].ToString()), // 속성수치 

                   // // 상태이상
                   // Debuff_type = item["name"].ToString(), // 상태이상 이름
                   // Debuff_value = Int32.Parse(item["name"].ToString()), // 상태이상 수치
                   // Con_make = bool.Parse(item["name"].ToString()), // 생산 여부
                   // Make_price = Int32.Parse(item["name"].ToString()), // 생산 비용
                   // Upgrade_price = Int32.Parse(item["name"].ToString()), // 업그레이드 비용
                   //});
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

            waepon_data.DataSource = wlist;
        }

        /// <summary>
        /// 무기전용 제이슨따기
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>제이슨 문자열 반환</returns>
        private void btn_weapons_Click(object sender, EventArgs e)
        {
            GetWeaponDate(("weapons/"+((Button)sender).Text));
        }
    }
}