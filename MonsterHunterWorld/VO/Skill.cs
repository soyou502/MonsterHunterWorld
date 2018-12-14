using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Skill
    {
        private int idx;
        private string type;
        private string name;
        private IList<SkillDesc> desc;

        public Skill()
        {
        }

        public Skill(int idx, string type, string name, IList<SkillDesc> desc) : this(idx, type, name)
        {
            this.desc = desc;
        }

        public Skill(int idx, string type, string name)
        {
            this.idx = idx;
            this.type = type;
            this.name = name;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        internal IList<SkillDesc> Desc { get => desc; set => desc = value; }
    }
}
