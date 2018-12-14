namespace MonsterHunterWorld.VO
{
    internal class Debuff
    {
        private int poison;
        private int sleep;
        private int paralysis;
        private int explosion;
        private int faint;

        public Debuff(int poison, int sleep, int paralysis, int explosion, int faint)
        {
            this.poison = poison;
            this.sleep = sleep;
            this.paralysis = paralysis;
            this.explosion = explosion;
            this.faint = faint;
        }

        public int Poison { get => poison; }
        public int Sleep { get => sleep; }
        public int Paralysis { get => paralysis; }
        public int Explosion { get => explosion; }
        public int Faint { get => faint; }
    }
}