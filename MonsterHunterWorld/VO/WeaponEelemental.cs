using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class WeaponEelemental
    {
        private int idx; // 무기번호
        private string elmental_name; // 속성 이름
        private int elmental_value; // 속성 수치
        private string debuff_type; // 상태이상 이름
        private int debuff_value; // 상태이상 수치

        public WeaponEelemental(int idx, string elmental_name, int elmental_value, string debuff_type, int debuff_value)
        {
            Idx = idx;
            Elmental_name = elmental_name;
            Elmental_value = elmental_value;
            Debuff_type = debuff_type;
            Debuff_value = debuff_value;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Elmental_name { get => elmental_name; set => elmental_name = value; }
        public int Elmental_value { get => elmental_value; set => elmental_value = value; }
        public string Debuff_type { get => debuff_type; set => debuff_type = value; }
        public int Debuff_value { get => debuff_value; set => debuff_value = value; }
    }
}
