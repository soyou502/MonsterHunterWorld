using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    public class Items
    {
        private int idx;
        private string type;
        private string name;
        private string description;
        private int rare;
        private int price;
        public Items()
        {

        }
        public Items(int idx, string type, string name, string description, int rare, int price)
        {
            this.idx = idx;
            this.type = type;
            this.name = name;
            this.description = description;
            this.rare = rare;
            this.price = price;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string Decription { get => description; set => description = value; }
        public int Rare { get => rare; set => rare = value; }
        public int Price { get => price; set => price = value; }
    }
}
