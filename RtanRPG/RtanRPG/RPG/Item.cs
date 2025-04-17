using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace RtanRPG.RPG
{
    internal static class Item
    {
        public enum ItemType
        {
            Weapon, Armor, Accessory, Potion, Scroll
        }

        public static List<string> Weapons = new List<string> // 무기
        {
            "모험가의_검", "모험가의_지팡이", "모험가의_단도", "양손_손도끼", "흑색_지팡이", "날카로운_단검",
            "기사단의_검", "마법사의_지팡이", "암기", "미스릴_양손검", "미스릴_완드", "미스릴_단도",
            "지휘관의_장검", "하이엘프의_지팡이", "살수의_단검", "사안칠성검", "태고의_지팡이", "공허의_단검"
        };
        public static List<string> Armors = new List<string> // 방어구
        {
            "모험가의_갑옷", "경량_갑옷", "가죽_로브", "손목_보호대",
            "기사단의_제복", "마법사의_로브", "닌자의_망토", "미스릴_갑옷",
            "지휘관의_방패", "하이엘프의_로브", "살수의_망토", "별빛밤", "태고의_가호", "공허의_그림자"
        };
        public static List<string> Accessories = new List<string> // 악세서리
        {
            "신앙의_증표", "수호자의_반지", "마력의_반지", "민첩의_반지", "죽은_자의_소생", "정령의_팬던트",
            "마녀의_부적", "운명의_시험", "신살의_반지"
        };
        public static List<string> Potions = new List<string> // 포션
        {
            "치유_물약", "상급_물약", "상태_회복약", "엘릭서", "만병_통치약"
        };
        public static List<string> Scrolls = new List<string> // 스크롤
        {
            "탈출_스크롤", "신앙_스크롤", "파괴_스크롤", "의문의_스크롤", "활력_스크롤", "철벽_스크롤"
        };

        public class WeaponInfo // 무기 정보
        {
            public string Name;
            public int Power;
            public int Defense;
            public int Cost;
            public bool Special;

            public WeaponInfo(string name, int power, int defense, int cost, bool special)
            {
                Name = name;
                Power = power;
                Defense = defense;
                Cost = cost;
                Special = special;
            }
        }
        public class WeaponDB
        {
            public static readonly Dictionary<int, WeaponInfo> weapon = new Dictionary<int, WeaponInfo>()
            {
                {1, new WeaponInfo(Weapons[0], 5, 5, 50, false )}, // 모험가의 검
                {4, new WeaponInfo(Weapons[3], 25, 5, 70, false )}, // 양손 손도끼
                {7, new WeaponInfo(Weapons[6], 25, 15, 120, false )}, // 기사단의 검
                {10, new WeaponInfo(Weapons[9], 45, 10, 200, false )}, // 미스릴 양손검
                {13, new WeaponInfo(Weapons[12], 50, 20, 350, false )}, // 지휘관의 장검
                {16, new WeaponInfo(Weapons[15], 75, 20, 500, true )}, // 사안칠성검

                {2, new WeaponInfo(Weapons[1], 15, 0, 50, false )}, // 모험가의 지팡이
                {5, new WeaponInfo(Weapons[4], 28, 0, 70, true )}, // 흑색 지팡이
                {8, new WeaponInfo(Weapons[7], 45, 0, 120, false )}, // 마법사의 지팡이
                {11, new WeaponInfo(Weapons[10], 55, 5, 200, false )}, // 미스릴 완드
                {14, new WeaponInfo(Weapons[13], 70, 5, 350, false )}, // 하이엘프의 지팡이
                {17, new WeaponInfo(Weapons[16], 105, 10, 500, true )}, // 태고의 지팡이

                {3, new WeaponInfo(Weapons[2], 10, 0, 50, false )}, // 모험가의 단도
                {6, new WeaponInfo(Weapons[5], 30, 0, 70, false )}, // 날카로운 단검
                {9, new WeaponInfo(Weapons[8], 40, 0, 120, true )}, // 암기
                {12, new WeaponInfo(Weapons[11], 50, 10, 200, false )}, // 미스릴 단도
                {15, new WeaponInfo(Weapons[14], 65, 15, 350, false )}, // 살수의 단검
                {18, new WeaponInfo(Weapons[17], 120, 0, 500, true )}, // 공허의 단검
            };
        }

        public class ArmorInfo // 방어구 정보
        {
            public string Name;
            public int Power;
            public int MaxHp;
            public int Defense;
            public int Cost;
            public bool Special;

            public ArmorInfo(string name, int power, int maxHp, int defense, int cost, bool special)
            {
                Name = name;
                Power = power;
                MaxHp = maxHp;
                Defense = defense;
                Cost = cost;
                Special = special;
            }
        }
        public class ArmorDB
        {
            public static readonly Dictionary<int, ArmorInfo> armor = new Dictionary<int, ArmorInfo>()
            {
                {1, new ArmorInfo(Armors[0], 0, 20, 5, 50, false )}, // 모험가의 갑옷 
                {8, new ArmorInfo(Armors[7], 5, 80, 15, 300, false )}, // 미스릴 갑옷

                {2, new ArmorInfo(Armors[1], 0, 30, 5, 100, false )}, // 경량 갑옷
                {5, new ArmorInfo(Armors[4], 3, 50, 10, 200, false )}, // 기사단의 제복
                {9, new ArmorInfo(Armors[8], 5, 120, 15, 500, false )}, // 지휘관의 방패
                {12, new ArmorInfo(Armors[11], 10, 150, 15, 800, true )}, // 별빛밤

                {3, new ArmorInfo(Armors[2], 5, 20, 5, 100, false )}, // 가죽 로브
                {6, new ArmorInfo(Armors[5], 15, 40, 5, 200, false )}, // 마법사의 로브
                {10, new ArmorInfo(Armors[9], 30, 80, 10, 500, false )}, // 하이엘프의 로브
                {13, new ArmorInfo(Armors[12], 50, 100, 10, 800, true )}, // 태고의 가호

                {4, new ArmorInfo(Armors[3], 5, 0, 15, 100, false )}, // 손목 보호대
                {7, new ArmorInfo(Armors[6], 10, 45, 7, 200, false )}, // 닌자의 망토
                {11, new ArmorInfo(Armors[10], 40, 60, 15, 500, false )}, // 살수의 망토
                {14, new ArmorInfo(Armors[13], 45, 90, 17, 800, true )}, // 공허의 그림자                           
            };
        }

        public class AccessoryInfo // 악세서리 정보
        {
            public string Name;
            public int Power;
            public int Defense;
            public int Cost;
            public bool Special;

            public AccessoryInfo(string name, int power, int defense, int cost, bool special)
            {
                Name = name;
                Power = power;
                Defense = defense;
                Cost = cost;
                Special = special;
            }
        }
        public class AccessoryDB
        {
            public static readonly Dictionary<int, AccessoryInfo> accessory = new Dictionary<int, AccessoryInfo>()
            {
                {1, new AccessoryInfo(Accessories[0], 10, 10, 0, true )}, // 신앙의 증표
                {2, new AccessoryInfo(Accessories[1], 0, 10, 100, false )}, // 수호자의 반지
                {3, new AccessoryInfo(Accessories[2], 12, 0, 100, false )}, // 마력의 반지
                {4, new AccessoryInfo(Accessories[3], 6, 5, 100, false )}, // 민첩의 반지
                {5, new AccessoryInfo(Accessories[4], 0, 5, 200, true )}, // 죽은 자의 소생
                {6, new AccessoryInfo(Accessories[5], 3, 3, 200, true )}, // 정령의 팬던트
                {7, new AccessoryInfo(Accessories[6], 15, 3, 200, false )}, // 마녀의 부적
                {8, new AccessoryInfo(Accessories[7], -10, -10, 500, true )}, // 운명의 시험
                {9, new AccessoryInfo(Accessories[8], 20, 20, 0, true )}, // 신살의 반지 
            };
        }

        public class PotionInfo // 포션 정보
        {
            public string Name;
            public int Hp;
            public int Cost;
            public bool Purification;
            public PotionInfo(string name, int hp, int cost, bool purification)
            {
                Name = name;
                Hp = hp;
                Cost = cost;
                Purification = purification;
            }
        }
        public class PotionDB
        {
            public static readonly Dictionary<int, PotionInfo> potion = new Dictionary<int, PotionInfo>()
            {
                {1, new PotionInfo(Potions[0], 30, 15, false)}, // 체력 물약
                {2, new PotionInfo(Potions[1], 60, 30, false)}, // 상급 물약
                {3, new PotionInfo(Potions[3], 100, 50, false)}, // 엘릭서
                {4, new PotionInfo(Potions[4], 9999, 150, true)}, // 만병 통치약
                {5, new PotionInfo(Potions[2], 0, 30, true)}, // 상태 회복약
            };
        }

        public class ScrollInfo // 스크롤 정보
        {
            public string Name;
            public int Cost;
            public bool Special;
            public ScrollInfo(string name, int cost, bool special)
            {
                Name = name;
                Cost = cost;
                Special = special;
            }
        }
        public class ScrollDB
        {
            public static readonly Dictionary<int, ScrollInfo> scroll = new Dictionary<int, ScrollInfo>()
            {
                {1, new ScrollInfo(Scrolls[0], 70, true)}, // 탈출 스크롤
                {2, new ScrollInfo(Scrolls[1], 100, true)}, // 신앙 스크롤
                {3, new ScrollInfo(Scrolls[2], 70, true)}, // 파괴 스크롤
                {4, new ScrollInfo(Scrolls[3], 100, true)}, // 의문의 스크롤
                {5, new ScrollInfo(Scrolls[4], 70, true)}, // 활력 스크롤
                {6, new ScrollInfo(Scrolls[5], 70, true)}, // 철벽 스크롤
            };
        }

        public class ItemInfo
        {
            public ItemType Type;
            public string Name;
            public int Cost;
            public ItemInfo()
            {
                Type = ItemType.Weapon;
                Name = "";
                Cost = -1;
            }
            public ItemInfo(ItemType type, string name, int cost)
            {
                Type = type;
                Name = name;
                Cost = cost;
            }
        }

        public class InventoryInfo
        {
            public static List<ItemInfo> Inventory = new List<ItemInfo>();
        }
    }
}