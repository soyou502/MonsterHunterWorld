namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 스킬 레벨별 상세정보 클래스
    /// </summary>
    internal class SkillDesc
    {
        private string name;
        private int level;
        private string desc;

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public string Desc { get => desc; set => desc = value; }
    }
}