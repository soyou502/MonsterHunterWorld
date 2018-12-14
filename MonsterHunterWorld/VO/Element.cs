namespace MonsterHunterWorld.VO
{
    internal class Element
    {
        private int fire;
        private int water;
        private int thunder;
        private int ice;
        private int dragon;

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