namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 속성(화,물,번개,빙,용속성)정보 클래스
    /// </summary>

    public class Element
    {
        private int fire; // 불
        private int water; // 물
        private int thunder; // 번개
        private int ice; // 빙
        private int dragon; // 용

        /// <summary>
        /// Element 클래스 기본생성자
        /// </summary>
        /// <param name="fire">불속성</param>
        /// <param name="water">물속성</param>
        /// <param name="thunder">번개속성</param>
        /// <param name="ice">빙속성</param>
        /// <param name="dragon">용속성</param>
        public Element(int fire, int water, int thunder, int ice, int dragon)
        {
            this.fire = fire;
            this.water = water;
            this.thunder = thunder;
            this.ice = ice;
            this.dragon = dragon;
        }
        public Element()
        {

        }
        public int Fire { get => fire; set => fire = value; }
        public int Water { get => water; set => water = value; }
        public int Thunder { get => thunder; set => thunder = value; }
        public int Ice { get => ice; set => ice = value; }
        public int Dragon { get => dragon; set => dragon = value; }

        public override string ToString()
        {
            string str = "불: " + PrintStar(Fire) + "\n물: " + PrintStar(Water) + "\n번개: " + PrintStar(Thunder) + "\n얼음: " + PrintStar(Ice) + "\n용: " + PrintStar(Dragon);
            return str;
        }
        private string PrintStar(int number)
        {
            string star = string.Empty;
            if (number < 0)
            {
                for (int i = 0; i > number; number++)
                {
                    star += "X";
                }
            }
            else
            {
                for (int i = 0; i < number; i++)
                {
                    star += "☆";
                }
            }
            return star;
        }
    }
}