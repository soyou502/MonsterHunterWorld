using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// Api를 통해 Json 문자열을 받기위해 필요한 매개변수 클래스
    /// </summary>
    public class Parameter
    {
        
        private string getName;
        private string name;
        private string type;

        /// <summary>
        /// Parameter 클래스 기본생성자
        /// <param name="getName">
        /// 가능한 문자열 종류
        /// 몬스터 도감: monsters
        /// 스킬 도감: skills
        /// 아이템 도감: items
        /// 장비 도감: armors
        /// 호석 도감: charms
        /// 장식품 도감: jewels</param>
        /// </summary>
        public Parameter(string getName)
        {
            this.getName = getName;
        }

        public string GetName { get => getName; set => getName = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
    }
}
