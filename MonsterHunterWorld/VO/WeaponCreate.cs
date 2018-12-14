using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class WeaponCreate
    {
        private int idx; // 무기번호
        private string imgUri; // 이미지
        private bool con_make; // 제작가능여부
        private string derivation; // 소재파생
        private int make_price; // 제작비용
        private int upgrade_price; // 업글비용

        public WeaponCreate(int idx, string imgUri, bool con_make, int make_price, int upgrade_price, string derivation)
        {
            Idx = idx;
            ImgUri = imgUri;
            Con_make = con_make;
            Make_price = make_price;
            Upgrade_price = upgrade_price;
            Derivation = derivation;
        }

        public int Idx { get => idx; set => idx = value; }
        public string ImgUri { get => imgUri; set => imgUri = value; }
        public bool Con_make { get => con_make; set => con_make = value; }
        public int Make_price { get => make_price; set => make_price = value; }
        public int Upgrade_price { get => upgrade_price; set => upgrade_price = value; }
        public string Derivation { get => derivation; set => derivation = value; }
    }
}
