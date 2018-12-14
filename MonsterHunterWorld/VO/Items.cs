using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Items
    {
        private int idx;
        private string type;
        private string name;
        private string decription;
        private int rare;
        private int price;

        public Items(int idx, string type, string name, string decription, int rare, int price)
        {
            this.idx = idx;
            this.type = type;
            this.name = name;
            this.decription = decription;
            this.rare = rare;
            this.price = price;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string Decription { get => decription; set => decription = value; }
        public int Rare { get => rare; set => rare = value; }
        public int Price { get => price; set => price = value; }
    }
}
