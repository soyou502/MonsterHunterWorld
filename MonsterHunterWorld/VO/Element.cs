namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 속성(화,물,번개,빙,용속성)정보 클래스
    /// </summary>
    internal class Element
    {
        private int fire;
        private int water;
        private int thunder;
        private int ice;
        private int dragon;

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

        public int Fire { get => fire; set => fire = value; }
        public int Water { get => water; set => water = value; }
        public int Thunder { get => thunder; set => thunder = value; }
        public int Ice { get => ice; set => ice = value; }
        public int Dragon { get => dragon; set => dragon = value; }
    }
}