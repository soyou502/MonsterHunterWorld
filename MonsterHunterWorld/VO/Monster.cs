using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Monster
    {
        private int idx;
        private string image;
        private string gubun;
        private string nick;
        private string description;
        private string hunt_info;
        private string[] location;
        private Element weakness;
        private Debuff debuff;
        private IList<Drop_Item> drop_Item;

        public int Idx { get => idx; set => idx = value; }
        public string Image { get => image; set => image = value; }
        public string Gubun { get => gubun; set => gubun = value; }
        public string Nick { get => nick; set => nick = value; }
        public string Description { get => description; set => description = value; }
        public string Hunt_info { get => hunt_info; set => hunt_info = value; }
        public string[] Location { get => location; set => location = value; }
        internal Element Weakness { get => weakness; set => weakness = value; }
        internal Debuff Debuff { get => debuff; set => debuff = value; }
        internal IList<Drop_Item> Drop_Item { get => drop_Item; set => drop_Item = value; }
    }
}
