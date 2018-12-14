using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Jewel
    {
        private int idx;
        private string name;
        private int slot_level;
        private int rare;
        private Skill skill;

        public int Idx { get => idx; set => idx = value; }
        public string Name { get => name; set => name = value; }
        public int Slot_level { get => slot_level; set => slot_level = value; }
        public int Rare { get => rare; set => rare = value; }
        internal Skill Skill { get => skill; set => skill = value; }
    }
}
