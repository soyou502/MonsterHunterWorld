namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 몬스터 드롭 아이템 정보 클래스
    /// </summary>
    public class Drop_Item : Items
    {
        private string level;
        private string part;
        private int difficulty;
        private string subtype;

        public string Level { get => level; set => level = value; }
        public string Part { get => part; set => part = value; }
        public int Difficulty { get => difficulty; set => difficulty = value; }
        public string Subtype { get => subtype; set => subtype = value; }
    }
}