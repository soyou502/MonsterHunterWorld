using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    public class Monster
    {
        private int idx; // 인덱스번호
        private Image image; // 이미지 주소
        private string gubun; // 구분
        private string name; // 이름
        private string nick; // 몬스터 별명
        private string description; // 몬스터 설명
        private string hunt_info; // 수렵 팁
        private List<string> location; // 출현장소
        private Element weakness; // 약점 정보
        private Debuff debuff; // 디버프 정보
        private IList<Drop_Item> drop_Item; // 드롭 아이템 정보

        public int Idx { get => idx; set => idx = value; }
        public Image Image { get => image; set => image = value; }
        public string Gubun { get => gubun; set => gubun = value; }
        public string Nick { get => nick; set => nick = value; }
        public string Description { get => description; set => description = value; }
        public string Hunt_info { get => hunt_info; set => hunt_info = value; }
        public string Name { get => name; set => name = value; }
        public List<string> Location { get => location; set => location = value; }
        internal Element Weakness { get => weakness; set => weakness = value; }
        internal Debuff Debuff { get => debuff; set => debuff = value; }
        internal IList<Drop_Item> Drop_Item { get => drop_Item; set => drop_Item = value; }
    }
}
