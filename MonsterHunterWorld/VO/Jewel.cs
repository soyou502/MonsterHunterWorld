using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    public class Jewel
    {
        private int idx; // 인덱스번호
        private string name; // 이름
        private int slot_level; // 슬롯개수
        private int rare; // 레어도
        private Skill skill; // 스킬정보

        public int Idx { get => idx; set => idx = value; }
        public string Name { get => name; set => name = value; }
        public int Slot_level { get => slot_level; set => slot_level = value; }
        public int Rare { get => rare; set => rare = value; }
        internal Skill Skill { get => skill; set => skill = value; }
    }
}
