using System;
using System.Collections.Generic;

namespace MonsterHunterWorld.VO
{
    /// <summary>
    /// 몬스터 드롭 아이템 정보 클래스
    /// </summary>
    public class Drop_Item : Items, IComparer<Drop_Item>
    {

        private string level;
        private string part;
        private int difficulty;
        private string subtype;

        public string Level { get => level; set => level = value; }
        public string Part { get => part; set => part = value; }
        public int Difficulty { get => difficulty; set => difficulty = value; }
        public string Subtype { get => subtype; set => subtype = value; }

        public string DifficultyToStar()
        {
            string star = string.Empty;
            if (difficulty != 0)
            {
                for (int i = 0; i < Difficulty; i++)
                {
                    star += "☆";
                }
            }
            else
            {
                star = "☆☆☆☆☆";
            }
            return star;
        }

        public int Compare(Drop_Item x, Drop_Item y)
        {
            int xLevel = (x.Level != "상위") ? 0 : 1;
            int yLevel = (y.Level != "상위") ? 0 : 1;
            int xPart = GetPartNum(x.Part);
            int yPart = GetPartNum(y.Part);
            int xDifficulty = (x.Difficulty != 0) ? x.Difficulty : 5;
            int yDifficulty = (x.Difficulty != 0) ? y.Difficulty : 5;            

            if (xLevel == yLevel)
            {
                if (xPart == yPart)
                {
                    if (xDifficulty > yDifficulty) return 1;
                    else if (xDifficulty == yDifficulty) return 0;
                    else return -1;
                }
                else if (xPart > yPart) return 1;
                else return -1;
            }
            else if (xLevel > yLevel) return 1;
            else return -1;            
        }

        private int GetPartNum(string part)
        {
            //유실물 14
            //머리 파괴 13
            //앞다리 파괴 12
            //몸통 파괴 11
            //등 파괴 10
            //날개 파괴 9
            //꼬리 파괴 8
            //목 주머니 파괴 7
            //뿔 파괴 6
            //배열기관 파괴 5

            //갈무리 소재 4
            //꼬리 갈무리 3
            //머리 갈무리 2
            //황금 갈무리 1

            //퀘스트 보수 0
            if (part.Contains("유실물")) return 14;
            else if (part.Contains("파괴"))
            {
                if (part.Contains("머리")) return 13;
                if (part.Contains("앞다리")) return 12;
                if (part.Contains("몸통")) return 11;
                if (part.Contains("등")) return 10;
                if (part.Contains("날개")) return 9;
                if (part.Contains("꼬리")) return 8;
                if (part.Contains("목")) return 7;
                if (part.Contains("뿔")) return 6;
                if (part.Contains("배열")) return 5;
            }
            else if (part.Contains("갈무리"))
            {
                if (part.Contains("소재")) return 4;
                if (part.Contains("꼬리")) return 3;
                if (part.Contains("머리")) return 2;
                if (part.Contains("황금")) return 1;
            }

            return 0; // 퀘스트보수
        }
    }
}