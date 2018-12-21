using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Weapons_Image
    {
        private int idx;
        private string image_Uri;

        public Weapons_Image(int idx, string image_Uri)
        {
            Idx = idx;
            Image_Uri = image_Uri;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Image_Uri { get => image_Uri; set => image_Uri = value; }
    }
}
