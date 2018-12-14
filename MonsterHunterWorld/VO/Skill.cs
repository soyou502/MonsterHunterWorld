using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    class Skill
    {
        private int idx; // 인덱스번호
        private string type; // 타입
        private string name; // 이름
        private IList<SkillDesc> desc; // 스킬 상세정보

        /// <summary>
        /// Skill 객체 기본생성자
        /// </summary>
        public Skill() { }

        /// <summary>
        /// Skill 객체 기본생성자
        /// </summary>
        /// <param name="idx">인덱스번호</param>
        /// <param name="type">타입</param>
        /// <param name="name">이름</param>
        /// <param name="desc">SkillDesc 리스트컬렉션</param>
        public Skill(int idx, string type, string name, IList<SkillDesc> desc) : this(idx, type, name)
        {
            this.desc = desc;
        }

        /// <summary>
        /// Skill 객체 기본생성자 / Jewel 클래스객체 생성시 사용
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        public Skill(int idx, string type, string name)
        {
            this.idx = idx;
            this.type = type;
            this.name = name;
        }

        public int Idx { get => idx; set => idx = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        internal IList<SkillDesc> Desc { get => desc; set => desc = value; }
    }
}
