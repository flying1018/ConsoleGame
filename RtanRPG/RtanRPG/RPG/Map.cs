namespace RtanRPG.RPG
{
    internal class Map
    {
        Random mapRandom = new Random();
        static int[,] mapLocation = new int[3, 17];
        static int[] mapIndex = { 1, 2, 3, 4, 5, 666 };
        static string[] mapEventType = { "몬스터", "상점", "휴식", " ? ", "시련" }; // 맵 종류

        public class MapInfo
        {
            public string EventType;
            public int Index;

            public MapInfo(string eventType, int index)
            {
                EventType = eventType;
                Index = index;
            }
        }

        public static class MapDB
        {
            public static readonly Dictionary<int, MapInfo> mapDB = new Dictionary<int, MapInfo>
            {
                {1, new MapInfo(mapEventType[0], mapIndex[0] )}, // 몬스터
                {2, new MapInfo(mapEventType[1], mapIndex[1] )}, // 상점
                {3, new MapInfo(mapEventType[2], mapIndex[2] )}, // 휴식
                {4, new MapInfo(mapEventType[3], mapIndex[3] )}, // "?" 랜덤
                {5, new MapInfo(mapEventType[4], mapIndex[4] )}, // 시련
                {6, new MapInfo("중간보스", 666 )}, // 중간보스
            };
        }

        public void MakeMap() // 맵생성 함수
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j < 17; j++)
                {
                    int k = mapRandom.Next(0, 100);
                    if (j == 4 || j == 9 || j == 14)
                        mapLocation[i, j] = mapIndex[5];
                    else if (j < 9) // 초반부
                    {
                        if (k < 35)
                            mapLocation[i, j] = mapIndex[0]; // 몬스터맵 35%
                        else if (35 <= k && k < 50)
                            mapLocation[i, j] = mapIndex[1]; // 상점 15%
                        else if (50 <= k && k < 65)
                            mapLocation[i, j] = mapIndex[2]; // 휴식 15%
                        else if (65 <= k && k < 85)
                            mapLocation[i, j] = mapIndex[3]; // 랜덤 이벤트("?") 20%
                        else if (85 <= k)
                            mapLocation[i, j] = mapIndex[4]; // 시련 15%
                    }
                    else
                    {
                        if (k < 25)
                            mapLocation[i, j] = mapIndex[0]; // 몬스터맵 25%
                        else if (25 <= k && k < 45)
                            mapLocation[i, j] = mapIndex[1]; // 상점 20%
                        else if (45 <= k && k < 65)
                            mapLocation[i, j] = mapIndex[2]; // 휴식 20%
                        else if (65 <= k && k < 75)
                            mapLocation[i, j] = mapIndex[3]; // 랜덤 이벤트("?") 10%
                        else if (75 <= k)
                            mapLocation[i, j] = mapIndex[4]; // 시련 25%
                    }
                }
            }
        }
    }
}