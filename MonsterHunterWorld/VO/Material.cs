using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Material
    {
        private string name;
        private int count;

        public Material(string name, int count)
        {
            this.name = name;
            this.count = count;
        }

        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }
    }
}
