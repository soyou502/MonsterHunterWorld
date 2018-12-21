using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{//
    class WeaponEelemental
    {
        private string elmental_name; // 속성 이름
        private int elmental_value; // 속성 수치
        private int idx; // 무기번호

        public WeaponEelemental(int idx, string elmental_name, int elmental_value)
        {
            Idx = idx;
            Elmental_name = elmental_name;
            Elmental_value = elmental_value;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Elmental_name { get => elmental_name; set => elmental_name = value; }
        public int Elmental_value { get => elmental_value; set => elmental_value = value; }

    }
}
