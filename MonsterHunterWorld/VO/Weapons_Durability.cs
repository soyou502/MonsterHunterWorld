using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{//
    class Weapons_Durability
    {
        private int idx;
        private int red;
        private int orange;
        private int yellow;
        private int green;
        private int blue;
        private int white;

        // 예리도 생성자
        public Weapons_Durability(int idx, int red, int orange, int yellow, int green, int blue, int white)
        {
            Idx = idx;
            Red = red;
            Orange = orange;
            Yellow = yellow;
            Green = green;
            Blue = blue;
            White = white;
        }

        public int Red { get => red; set => red = value; }
        public int Orange { get => orange; set => orange = value; }
        public int Yellow { get => yellow; set => yellow = value; }
        public int Green { get => green; set => green = value; }
        public int Blue { get => blue; set => blue = value; }
        public int White { get => white; set => white = value; }
        public int Idx { get => idx; set => idx = value; }
    }
}
