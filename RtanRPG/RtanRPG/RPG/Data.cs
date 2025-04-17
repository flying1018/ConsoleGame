namespace RtanRPG.RPG
{
    internal class Data
    {
        public static List<string> easyM = new List<string> // 초반몹
        {
            "고블린", "고블린_무리", "오크", "오크_무리", "늑대", "늑대_무리",
            "언데드", "산적", "슬라임", "스톤골렘", "파이어골렘"
        };
        public static List<string> firstHardM = new List<string> // 1루트 후반몹
        {
            "임프", "임프_무리", "혈귀", "지옥파수견", "지옥파수견_무리",
            "서큐버스", "영혼포식자", "악마"
        };

        public static List<string> secondHardM = new List<string> // 2루트 후반몹
        {
            "기사", "기사_무리", "공허기사", "광신도", "광신도_무리",
            "암살자", "사제", "천사"
        };

        public static List<string> extraM = new List<string> // 시련, 기타 몬스터
        {
            "미믹", "불사조", "도플갱어", "고대골렘",
            "타락한_정령", "듀라한", "사신", "대장군", "성기사장"
        };

        public static List<string> bossM = new List<string> // 보스몹들
        {
            "와이번", "드래곤", "고위악마", "루시퍼", "세뇌된_용사", "천사장", "신"
        };

        public class MonsterInfo
        {
            public string Name;
            public Types.Type Type;
            public int Hp;
            public int Power;
            public int Defense;
            public int GiveCoin;
            public int GiveExp;
            public bool Special;

            public MonsterInfo(string name, Types.Type type, int hp, int power, int defense,
            int giveCoin, int giveExp, bool special)
            {
                Name = name;
                Type = type;
                Hp = hp;
                Power = power;
                Defense = defense;
                GiveCoin = giveCoin;
                GiveExp = giveExp;
                Special = special;
            }
        }
        public class MonsterDB
        {
            public static readonly Dictionary<int, MonsterInfo> EasyMon = new Dictionary<int, MonsterInfo>()
            { // 이름 타입 체력 파워 방어력 돈 경험치 특수
                {1, new MonsterInfo(easyM[0], Types.Type.normal, 25, 3, 0, 10, 10, false )}, // 고블린
                {2, new MonsterInfo(easyM[1], Types.Type.normal, 50, 5, 0, 25, 20, false )}, // 고블린 무리
                {3, new MonsterInfo(easyM[2], Types.Type.land, 35, 5, 3, 15, 15, false )}, // 오크
                {4, new MonsterInfo(easyM[3], Types.Type.land, 60, 8, 3, 35, 25, false )}, // 오크 무리
                {5, new MonsterInfo(easyM[4], Types.Type.wind, 20, 7, 0, 15, 15, false )}, // 늑대
                {6, new MonsterInfo(easyM[5], Types.Type.wind, 40, 10, 0, 30, 25, false )}, // 늑대 무리
                {7, new MonsterInfo(easyM[7], Types.Type.dark, 70, 5, 10, 35, 35, true )}, // 언데드
                {8, new MonsterInfo(easyM[8], Types.Type.normal, 50, 15, 5, 60, 20, false )}, // 산적
                {9, new MonsterInfo(easyM[9], Types.Type.water, 4, 10, 0, 20, 55, true )}, // 슬라임
                {10, new MonsterInfo(easyM[10], Types.Type.land, 100, 20, 15, 45, 45, false )}, // 스톤골렘
                {11, new MonsterInfo(easyM[11], Types.Type.fire, 80, 20, 10, 45, 45, true )}, // 파이어골렘
            };
            public static readonly Dictionary<int, MonsterInfo> FirstHardMon = new Dictionary<int, MonsterInfo>()
            {
                {1, new MonsterInfo(firstHardM[0], Types.Type.normal, 65, 20, 10, 40, 50, false )}, // 임프
                {2, new MonsterInfo(firstHardM[1], Types.Type.normal, 110, 30, 10, 70, 80, false )}, // 임프 무리
                {3, new MonsterInfo(firstHardM[2], Types.Type.fire, 120, 30, 15, 50, 100, true )}, // 혈귀
                {4, new MonsterInfo(firstHardM[3], Types.Type.wind, 60, 30, 5, 50, 50, false )}, // 지옥파수견
                {5, new MonsterInfo(firstHardM[4], Types.Type.wind, 100, 50, 5, 80, 80, false )}, // 지옥파수견 무리
                {6, new MonsterInfo(firstHardM[5], Types.Type.water, 150, 30, 20, 150, 80, true )}, // 서큐버스
                {7, new MonsterInfo(firstHardM[6], Types.Type.land, 50, 50, 30, 90, 90, false )}, // 영혼포식자
                {8, new MonsterInfo(firstHardM[7], Types.Type.dark, 198, 66, 25, 132, 132, true )}, // 악마
            };
            public static readonly Dictionary<int, MonsterInfo> SecondHardMon = new Dictionary<int, MonsterInfo>()
            {
                {1, new MonsterInfo(secondHardM[0], Types.Type.normal, 90, 15, 15, 50, 50, false )}, // 기사
                {2, new MonsterInfo(secondHardM[1], Types.Type.normal, 150, 25, 15, 75, 80, false )}, // 기사 무리
                {3, new MonsterInfo(secondHardM[2], Types.Type.dark, 160, 25, 20, 60, 110, true )}, // 공허기사
                {4, new MonsterInfo(secondHardM[3], Types.Type.fire, 70, 30, 0, 130, 1, false )}, // 광신도
                {5, new MonsterInfo(secondHardM[4], Types.Type.fire, 70, 30, 0, 260, 1, false )}, // 광신도 무리
                {6, new MonsterInfo(secondHardM[5], Types.Type.wind, 80, 80, 5, 100, 100, false )}, // 암살자
                {7, new MonsterInfo(secondHardM[6], Types.Type.water, 150, 30, 25, 80, 150, true )}, // 사제
                {8, new MonsterInfo(secondHardM[7], Types.Type.light, 200, 50, 30, 140, 140, true )}, // 천사
            };
            public static readonly Dictionary<int, MonsterInfo> extraMon = new Dictionary<int, MonsterInfo>()
            {
                {1, new MonsterInfo(extraM[0], Types.Type.normal, 5, 10, 200, 150, 0, false )}, // 미믹
                {2, new MonsterInfo(extraM[1], Types.Type.fire, 100, 20, 0, 80, 80, true )}, // 불사조
                {3, new MonsterInfo(extraM[2], Types.Type.normal, 1, 1, 1, 1, 1, true )}, // 도플갱어
                {4, new MonsterInfo(extraM[3], Types.Type.light, 150, 25, 15, 85, 85, false )}, // 고대골렘
                {5, new MonsterInfo(extraM[4], Types.Type.light, 50, 40, 0, 70, 70, false )}, // 타락한 정령
                {6, new MonsterInfo(extraM[5], Types.Type.land, 190, 45, 35, 140, 140, false )}, // 듀라한
                {7, new MonsterInfo(extraM[6], Types.Type.dark, 110, 100, 0, 150, 150, true )}, // 사신
                {8, new MonsterInfo(extraM[7], Types.Type.land, 200, 50, 35, 150, 150, false )}, // 대장군
                {9, new MonsterInfo(extraM[8], Types.Type.light, 200, 40, 20, 160, 160, true )}, // 성기사장
            };
            public static readonly Dictionary<int, MonsterInfo> bossMon = new Dictionary<int, MonsterInfo>()
            {
                {1, new MonsterInfo(bossM[0], Types.Type.wind, 200, 15, 15, 50, 50, false )}, // 와이번
                {2, new MonsterInfo(bossM[1], Types.Type.fire, 400, 15, 15, 50, 50, true )}, // 드래곤
                {3, new MonsterInfo(bossM[2], Types.Type.dark, 500, 15, 15, 50, 50, true )}, // 고위악마
                {4, new MonsterInfo(bossM[3], Types.Type.light, 666, 66, 66, 0, 0, true )}, // 루시퍼
                {5, new MonsterInfo(bossM[4], Types.Type.land, 350, 15, 15, 50, 50, true )}, // 세뇌된 용사
                {6, new MonsterInfo(bossM[5], Types.Type.dark, 550, 15, 15, 50, 50, true )}, // 천사장
                {7, new MonsterInfo(bossM[6], Types.Type.normal, 1000, 15, 15, 0, 0, true )}, // 신
            };
        }
    }
}