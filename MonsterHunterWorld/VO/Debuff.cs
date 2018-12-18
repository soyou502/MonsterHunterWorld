namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 디버프 정보 클래스
    /// </summary>
    public class Debuff
    {
        private int poison; // 독
        private int sleep; // 수면
        private int paralysis; // 마비
        private int explosion; // 폭파
        private int faint; // 기절

        /// <summary>
        /// Debuff 클래스 기본생성자
        /// </summary>
        public Debuff() { }

        /// <summary>
        /// Debuff 클래스 기본생성자
        /// </summary>
        /// <param name="poison">독</param>
        /// <param name="sleep">수면</param>
        /// <param name="paralysis">마비</param>
        /// <param name="explosion">폭파</param>
        /// <param name="faint">기절</param>
        public Debuff(int poison, int sleep, int paralysis, int explosion, int faint)
        {
            this.poison = poison;
            this.sleep = sleep;
            this.paralysis = paralysis;
            this.explosion = explosion;
            this.faint = faint;
        }

        public int Poison { get => poison; set => poison = value; }
        public int Sleep { get => sleep; set => sleep = value; }
        public int Paralysis { get => paralysis; set => paralysis = value; }
        public int Explosion { get => explosion; set => explosion = value; }
        public int Faint { get => faint; set => faint = value; }
    }
}