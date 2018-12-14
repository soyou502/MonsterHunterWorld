using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class WeaponList
    {
        // 기본 정보
        private string imgUri; // 이미지
        private string weaponName; // 무기이름
        private string derivation; // 소재파생
        private int rare; // 레어도
        private int attack; // 공격력
        private int defence; // 방어력
        private int critical; // 회심률
        private string elmental_name; // 속성 이름
        private int elmental_value; // 속성 수치
        private string debuff_type; // 상태이상 이름
        private int debuff_value; // 상태이상 수치
        private string slot; // 슬롯 수
        private bool con_make; // 제작가능여부
        private int make_price; // 제작비용
        private int upgrade_price; // 업글비용

        // 수렵피리
        private string[] timbre = new string[3]; // 음색
        private string melody; // 악보

        // 건랜스, 액스, 조충곤, 보우건
        private string specal_type;

        // 활
        private string[] bow_type = new string[6];

        public WeaponList() { }

        // 기본 정보
        public WeaponList(string imgUri, string weaponName, int rare, int attack, int defence, int critical, string slot, string derivation, string elmental_name, int elmental_value, string debuff_type, int debuff_value, bool con_make, int make_price, int upgrade_price)
        {
            ImgUri = imgUri;
            WeaponName = weaponName;
            Rare = rare;
            Attack = attack;
            Defence = defence;
            Critical = critical;
            Slot = slot;
            Derivation = derivation;
            Elmental_name = elmental_name;
            Elmental_value = elmental_value;
            Debuff_type = debuff_type;
            Debuff_value = debuff_value;
            Con_make = con_make;
            Make_price = make_price;
            Upgrade_price = upgrade_price;
        }

        // 특수타입 무기들 ( 건랜스, 액스, 조충곤, 보우건 )
        public WeaponList(string imgUri, string weaponName, int rare, int attack, int defence, int critical, string slot, string derivation, string elmental_name, int elmental_value, string debuff_type, int debuff_value, bool con_make, int make_price, int upgrade_price, string specal_type1)
        {
            ImgUri = imgUri;
            WeaponName = weaponName;
            Rare = rare;
            Attack = attack;
            Defence = defence;
            Critical = critical;
            Slot = slot;
            Derivation = derivation;
            Elmental_name = elmental_name;
            Elmental_value = elmental_value;
            Debuff_type = debuff_type;
            Debuff_value = debuff_value;
            Con_make = con_make;
            Make_price = make_price;
            Upgrade_price = upgrade_price;
            Specal_type1 = specal_type1;
        }

        // 활 전용 생성자
        public WeaponList(string imgUri, string weaponName, int rare, int attack, int defence, int critical, string slot, string derivation, string elmental_name, int elmental_value, string debuff_type, int debuff_value, bool con_make, int make_price, int upgrade_price, string[] bow_type)
        {
            ImgUri = imgUri;
            WeaponName = weaponName;
            Rare = rare;
            Attack = attack;
            Defence = defence;
            Critical = critical;
            Slot = slot;
            Derivation = derivation;
            Elmental_name = elmental_name;
            Elmental_value = elmental_value;
            Debuff_type = debuff_type;
            Debuff_value = debuff_value;
            Con_make = con_make;
            Make_price = make_price;
            Upgrade_price = upgrade_price;
            Bow_type = bow_type;
        }

        // 수렵피리 전용 생성자
        public WeaponList(string imgUri, string weaponName, int rare, int attack, int defence, int critical, string slot, string derivation, string elmental_name, int elmental_value, string debuff_type, int debuff_value, bool con_make, int make_price, int upgrade_price, string[] timbre, string melody)
        {
            ImgUri = imgUri;
            WeaponName = weaponName;
            Rare = rare;
            Attack = attack;
            Defence = defence;
            Critical = critical;
            Slot = slot;
            Derivation = derivation;
            Elmental_name = elmental_name;
            Elmental_value = elmental_value;
            Debuff_type = debuff_type;
            Debuff_value = debuff_value;
            Timbre = timbre;
            Melody = melody;
        }

        #region 기본무기 정보
        public string ImgUri { get => imgUri; set => imgUri = value; }
        public string WeaponName { get => weaponName; set => weaponName = value; }
        public int Rare { get => rare; set => rare = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defence { get => defence; set => defence = value; }
        public int Critical { get => critical; set => critical = value; }
        public string Slot { get => slot; set => slot = value; }
        public string Derivation { get => derivation; set => derivation = value; }
        public string Elmental_name { get => elmental_name; set => elmental_name = value; }
        public int Elmental_value { get => elmental_value; set => elmental_value = value; }
        public string Debuff_type { get => debuff_type; set => debuff_type = value; }
        public int Debuff_value { get => debuff_value; set => debuff_value = value; }
        public bool Con_make { get => con_make; set => con_make = value; }
        public int Make_price { get => make_price; set => make_price = value; }
        public int Upgrade_price { get => upgrade_price; set => upgrade_price = value; }
        #endregion

        // 조충곤, 건랜스, 액스 들 특수타입
        public string[] Timbre { get => timbre; set => timbre = value; }
        public string Melody { get => melody; set => melody = value; }
        public string Specal_type1 { get => specal_type; set => specal_type = value; }
        public string[] Bow_type { get => bow_type; set => bow_type = value; }
    }
}
