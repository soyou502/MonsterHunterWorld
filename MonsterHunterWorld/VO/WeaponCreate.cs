﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{//
    class WeaponCreate
    {
        private string weapon_name; // 무기이름
        private bool con_make; // 제작가능여부
        private string derivation; // 소재파생
        private int make_price; // 제작비용
        private int upgrade_price; // 업글비용

        public WeaponCreate(string weapon_name, bool con_make, int make_price, int upgrade_price, string derivation)
        {
            Weapon_name = weapon_name;
            Con_make = con_make;
            Make_price = make_price;
            Upgrade_price = upgrade_price;
            Derivation = derivation;
        }

        public string Weapon_name { get => weapon_name; set => weapon_name = value; }
        public bool Con_make { get => con_make; set => con_make = value; }
        public int Make_price { get => make_price; set => make_price = value; }
        public int Upgrade_price { get => upgrade_price; set => upgrade_price = value; }
        public string Derivation { get => derivation; set => derivation = value; }
    }
}