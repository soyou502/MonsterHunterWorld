using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Armor
    {
        private int idx;
        private int set_Num;
        private int part_No;
        private string setImage;
        private string level;
        private string part;
        private string name;
        private int rare;
        private string slots;
        private int defense;
        private Element resistances;
        private List<Material> items = new List<Material>();
        private List<Skill> skills = new List<Skill>();

        public Armor()
        {
        }

        public Armor(int idx, int set_Num, int part_No, string setImage, string level, string part, string name, int rare, string slots, int defense, Element resistances, List<Material> items, List<Skill> skills)
        {
            this.idx = idx;
            this.set_Num = set_Num;
            this.part_No = part_No;
            this.setImage = setImage;
            this.level = level;
            this.part = part;
            this.name = name;
            this.rare = rare;
            this.slots = slots;
            this.defense = defense;
            this.resistances = resistances;
            this.items = items;
            this.skills = skills;
        }

        public int Idx { get => idx; set => idx = value; }
        public int Set_Num { get => set_Num; set => set_Num = value; }
        public int Part_No { get => part_No; set => part_No = value; }
        public string SetImage { get => setImage; set => setImage = value; }
        public string Level { get => level; set => level = value; }
        public string Part { get => part; set => part = value; }
        public string Name { get => name; set => name = value; }
        public int Rare { get => rare; set => rare = value; }
        public string Slots { get => slots; set => slots = value; }
        public int Defense { get => defense; set => defense = value; }
        public Element Resistances { get => resistances; set => resistances = value; }
        public List<Material> Items { get => items; set => items = value; }
        public List<Skill> Skills { get => skills; set => skills = value; }
    }
}
