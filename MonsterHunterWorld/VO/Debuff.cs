﻿namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 디버프 정보 클래스
    /// </summary>
    internal class Debuff
    {
        private int poison;
        private int sleep;
        private int paralysis;
        private int explosion;
        private int faint;

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

        public int Poison { get => poison; }
        public int Sleep { get => sleep; }
        public int Paralysis { get => paralysis; }
        public int Explosion { get => explosion; }
        public int Faint { get => faint; }
    }
}