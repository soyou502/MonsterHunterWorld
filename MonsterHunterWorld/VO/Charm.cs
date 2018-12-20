using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    public class Charm
    {
        private int idx;
        private string name;
        private int max_level;
        private List<Material> items;
        private List<ArmorSkill> skills;

        public Charm(int idx, string name, int max_level, List<Material> items, List<ArmorSkill> skills)
        {
            this.idx = idx;
            this.name = name;
            this.max_level = max_level;
            this.items = items;
            this.skills = skills;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Name { get => name; set => name = value; }
        public int Max_level { get => max_level; set => max_level = value; }
        public List<Material> Items { get => items; set => items = value; }
        public List<ArmorSkill> Skills { get => skills; set => skills = value; }
    }
}
