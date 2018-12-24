using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{//
    class WeaponBase
    {
        // 기본 정보
        private int idx; // 무기번호
        private string weaponName; // 무기이름
        private int rare; // 레어도
        private int attack; // 공격력
        private int defence; // 방어력
        private int critical; // 회심률
        private string slot; // 슬롯 수

        // 수렵피리
        private string[] timbre = new string[3]; // 음색
        private string melody; // 악보

        // 건랜스, 액스, 조충곤, 보우건
        private string specal_type;

        // 활
        private string[] bow_type = new string[6];

        #region 기본무기정보
        public WeaponBase(int idx, string weaponName, int rare, int attack, int defence, int critical, string slot)
        {
            Idx = idx;
            WeaponName = weaponName;
            Rare = rare;
            Attack = attack;
            Defence = defence;
            Critical = critical;
            Slot = slot;
        }

        public WeaponBase(int idx, string weaponName, int rare, int attack, int defence, int critical, string slot, string specal_type)
        {
            Idx = idx;
            WeaponName = weaponName;
            Rare = rare;
            Attack = attack;
            Defence = defence;
            Critical = critical;
            Slot = slot;
            Specal_type = specal_type;
        }
        #endregion



        public int Idx { get => idx; set => idx = value; }
        public string WeaponName { get => weaponName; set => weaponName = value; }
        public int Rare { get => rare; set => rare = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Defence { get => defence; set => defence = value; }
        public int Critical { get => critical; set => critical = value; }
        public string Slot { get => slot; set => slot = value; }
        public string Specal_type { get => specal_type; set => specal_type = value; }
        public string Melody { get => melody; set => melody = value; }
    }
}
