using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    public class ArmorSkill
    {
        private int idx;
        private string name;
        private int level;
        private string type;

        public ArmorSkill(int idx, string name, int level, string type)
        {
            this.idx = idx;
            this.name = name;
            this.level = level;
            this.type = type;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public string Type { get => type; set => type = value; }
    }
}
