using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{//
    class WeaponDebuff
    {
        private int idx; // 무기번호
        private string debuff_type; // 상태이상 이름
        private int debuff_value; // 상태이상 수치

        public WeaponDebuff(int idx, string debuff_type, int debuff_value)
        {
            Debuff_type = debuff_type;
            Debuff_value = debuff_value;
            Idx = idx;
        }

        public string Debuff_type { get => debuff_type; set => debuff_type = value; }
        public int Debuff_value { get => debuff_value; set => debuff_value = value; }
        public int Idx { get => idx; set => idx = value; }
    }
}
