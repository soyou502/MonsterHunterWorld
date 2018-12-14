namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 스킬 레벨별 상세정보 클래스
    /// </summary>
    internal class SkillDesc
    {
        private string name; // 레벨이름
        private int level; // 레벨
        private string desc; // 상세정보

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public string Desc { get => desc; set => desc = value; }
    }
}