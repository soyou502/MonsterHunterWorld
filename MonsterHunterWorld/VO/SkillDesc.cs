namespace MonsterHunterWorld.VO
{
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