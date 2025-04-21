namespace RtanRPG.RPG
{
    internal class Map
    {
        public enum MapEventType
        {
            Monster = 1,
            Shop = 2,
            Rest = 3,
            Event = 4,
            Hardship = 5,
            Boss = 666,
        } // 맵 종류

        public class MapInfo
        {
            MapEventType MapType;
            public string Name;
            public int Index;

            public MapInfo(MapEventType mapType, string name, int index)
            {
                MapType = mapType;
                Name = name;
                Index = index;
            }
        }

        public class MapDB
        {
            public static readonly Dictionary<int, MapInfo> mapDB = new Dictionary<int, MapInfo>
            {
                {1, new MapInfo(MapEventType.Monster, "몬스터", 1)}, // 몬스터
                {2, new MapInfo(MapEventType.Shop, "상점", 2)}, // 상점
                {3, new MapInfo(MapEventType.Rest,"휴식", 3)}, // 휴식
                {4, new MapInfo(MapEventType.Event, "이벤트", 4)}, // 이벤트
                {5, new MapInfo(MapEventType.Hardship, "시련", 5)}, // 시련
                {6, new MapInfo(MapEventType.Boss, "중간보스", 666)}, // 중간보스
            };
        }
    }
}