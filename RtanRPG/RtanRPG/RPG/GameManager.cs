using static RtanRPG.RPG.GameHelper.TypingHelper;
using static RtanRPG.RPG.GameHelper.ItemHelper;

namespace RtanRPG.RPG
{
    internal class GameManager 
    {
        public Profile.PlayerInfo? Player;// 플레이어 프로필 선언
        public void NewPlayer(string name, Profile.Job job, string jobName) // 메인에서 플레이어 프로필을 초기화 하는 함수
        {
            Player = new Profile.PlayerInfo(name, job, jobName);
        }
        public Data.MonsterInfo? Enemy;
        public void NewEnemy(int Difficulty, int mapLocation, bool hidden)
        {
           // Enemy = new Data.MonsterInfo();
        }

        public Item.InventoryInfo? PlayerInventory; // 플레이어 인벤토리 선언
        public void NewInventory() // 메인에서 인벤토리를 초기화 하는 함수
        {
            PlayerInventory = new Item.InventoryInfo();
        }

        public List<Item.ItemInfo> Inventory { get; private set; } = new List<Item.ItemInfo>();

        public int Turn = 0; // 턴 저장 변수
        public int Difficulty = 1;


        public int[]? mapLocation; // 맵 정보 보관하는 배열

        public bool GameOver = false; // 게임루프 관리하는 불리언 변수
        public int[] MakeMap() // 맵생성 함수
        {
            int[] arry = new int[4];

            Random random = new Random();

            for (int j = 0; j < 4; j++)
            {
                int k = random.Next(0, 100);
                if (Turn == 4 || Turn == 9 || Turn == 14)
                {
                    arry[j - 1] = Map.MapDB.mapDB[6].Index;
                }
                else if (Turn < 9) // 초반부
                {
                    if (k < 40)
                        arry[j] = Map.MapDB.mapDB[1].Index; // 몬스터맵 40%
                    else if (40 <= k && k < 55)
                        arry[j] = Map.MapDB.mapDB[2].Index; // 상점 15%
                    else if (55 <= k && k < 70)
                        arry[j] = Map.MapDB.mapDB[3].Index; // 휴식 15%
                    else if (70 <= k && k < 90)
                        arry[j] = Map.MapDB.mapDB[4].Index; // 이벤트 20%
                    else if (90 <= k)
                        arry[j] = Map.MapDB.mapDB[5].Index; // 시련 10%
                }
                else // 후반부
                {
                    if (k < 30)
                        arry[j] = Map.MapDB.mapDB[1].Index; // 몬스터맵 30%
                    else if (30 <= k && k < 45)
                        arry[j] = Map.MapDB.mapDB[2].Index;  // 상점 15%
                    else if (45 <= k && k < 60)
                        arry[j] = Map.MapDB.mapDB[3].Index; // 휴식 15%
                    else if (60 <= k && k < 80)
                        arry[j] = Map.MapDB.mapDB[4].Index; // 이벤트 20%
                    else if (80 <= k)
                        arry[j] = Map.MapDB.mapDB[5].Index; // 시련 20%
                }
            }

            return arry;
        }

        public void NextMap() // 다음 맵갈때마다 실행 (턴+1)
        {
            Turn++;
            TypingText("", "=============", 0);
            Console.WriteLine();

            TypingText("", "당신은 ", 100);
            Thread.Sleep(1000);
            TypingText("", "마을에 나와 던전으로 향했다.", 100);
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);

            TypingText("", "  현재 : ", 0);
            Thread.Sleep(1000);
            TypingVar("yellow", Turn);
            TypingText("", "층", 0);
            Console.WriteLine();

            TypingText("", "=============", 0);
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1000);
        }

        public void EndGame() // 게임종료 함수
        {
            GameOver = true;
        }

        public int WhatNum(int a, int b) // 숫자 입력 검증 메서드
        {
            int index = -1;
            while (true)
            {
                string input = Console.ReadLine();
                bool isNum = int.TryParse(input, out index);

                if (a <= index && index <= b)
                    break;
                else
                {
                    TypingText("red", "유효한 ");
                    TypingText("", "숫자를 입력 해주십시오");
                    Console.WriteLine();
                }
            }
            return index;
        }

        public string YesOrNo() // Yes or No 반환하는 함수
        {
            while (true)
            {
                TypingText("", "(Y/N) 입력 : ");
                string input = Console.ReadLine();
                Console.WriteLine();

                if (input == "y" || input == "Y")
                {
                    return "y";
                }
                else if (input == "n" || input == "N")
                {
                    return "n";
                }
                else
                {
                    TypingText("red", "Y/N");
                    TypingText("", "를 입력 해주십시오");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
        public void MainChoice() // 콘솔 꾸미기 (메인화면)
        {
            Console.Clear();
            TypingText("cyan", "┌──────────────┬───────────────┬───────────────┬───────────────┐", 0);
            Console.WriteLine();
            Console.WriteLine();
            TypingText("cyan", "│   1. 상태창  │  2. 인벤토리  │  3. 마을 상점 │  4. 던전 입장 ", 0);
            Console.WriteLine();
            Console.WriteLine();
            TypingText("cyan", "└──────────────┴───────────────┴───────────────┴───────────────┘", 0);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void DungeonChoice(int[] mapLocation) // 콘솔 꾸미기 (던전)
        {
            Console.Clear();
            TypingText("cyan", "=========================================", 0);
            Console.WriteLine();
            Console.WriteLine();
            TypingText("cyan", "   1. ", 0);
            TypingVar("cyan", Map.MapDB.mapDB[mapLocation[0]].Name);
            TypingText("cyan", "   2. ");
            TypingVar("cyan", Map.MapDB.mapDB[mapLocation[1]].Name);
            TypingText("cyan", "   3. ");
            TypingVar("cyan", Map.MapDB.mapDB[mapLocation[2]].Name);
            TypingText("cyan", "   4. ");
            TypingVar("cyan", Map.MapDB.mapDB[mapLocation[3]].Name);
            TypingText("cyan", "   ");
            Console.WriteLine();
            Console.WriteLine();
            TypingText("cyan", "=========================================", 0);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void MainTitle()  // 게임 메인화면
        {
            MainChoice();
            TypingText("", "원하는 선택지를 입력 해주세요(1~4)");
            Console.WriteLine();
            TypingText("", "숫자 입력 : ");

            int playerChoice = WhatNum(1, 4);

            switch (playerChoice)
            {
                case 1:
                    ShowPlayerStats();
                    break;
                case 2:
                    ShowPlayerInventory();
                    break;
                case 3:
                    TownShop();
                    break;
                case 4:
                    DungeonStart();
                    break;
            }
        }

        public void DungeonTitle() // 던전 메인화면
        {
            Console.Clear();
            DungeonChoice(mapLocation);
            TypingText("", "1.스탯 / 2.인벤토리 / 3.던전 진입");
            Console.WriteLine();
            TypingText("", "원하는 선택지를 입력 해주세요(1~3)");
            Console.WriteLine();
            TypingText("", "숫자 입력 : ");

            int playerChoice = WhatNum(1, 3);

            switch (playerChoice)
            {
                case 1:
                    ShowPlayerStats();
                    break;
                case 2:
                    ShowPlayerInventory();
                    break;
                case 3:
                    DungeonStart();
                    break;
            }
        }

        public void ShowPlayerInventory() // 플레이어 인벤토리 표시 
        {
            PlayerInventory.ShowInventory();
            GameHelper.TypingHelper.TypingText("", "1 : 돌아가기\n2 : 장비변경\n3 : 장비 정보확인");
            Console.WriteLine();
            GameHelper.TypingHelper.TypingText("", "숫자 입력 : ");
            int playerChoice = WhatNum(1, 3);

            switch (playerChoice)
            {
                case 1:
                    if (Player.isDungeon == false)
                        MainTitle();
                    else if (Player.isDungeon == true)
                        DungeonTitle();
                    break;
                case 2:
                    ChageItem();
                    break;
                case 3:
                    SeeItem();
                    break;
            }
        }
        public void ShowPlayerStats() // 플레이어 스탯창 표시
        {
            Player.ShowStats();
            TypingText("", "1 : 돌아가기\n2 : 인벤토리");
            Console.WriteLine();
            TypingText("", "숫자 입력 : ");
            int playerChoice = WhatNum(1, 2);
            switch (playerChoice)
            {
                case 1:
                    if (Player.isDungeon == false)
                        MainTitle();
                    else if (Player.isDungeon == true)
                        DungeonTitle();
                    break;
                case 2:
                    ShowPlayerInventory();
                    break;
            }

        }

        public void ChageItem() // 장비 변경
        {
            Console.Clear();
            PlayerInventory.ShowInventory();
            TypingText("", "1 : 장착\n2 : 해제\n3 : 돌아가기");
            Console.WriteLine();
            TypingText("", "숫자 입력 : ");
            int num = WhatNum(1, 2);
            if (num == 1)
            {
                while (true)
                {
                    TypingText("", "장착을 원하는 장비 입력 : ");
                    Console.WriteLine();
                    int playerChoice = WhatNum(1, PlayerInventory.Inventory.Count);

                    if (PlayerInventory.Inventory[playerChoice - 1].Eq == true)
                    {
                        TypingText("", "이미 장착한 장비입니다");
                        Console.WriteLine();
                    }
                    else
                    {
                        PlayerInventory.Inventory[playerChoice - 1].Eq = true;
                        EqItem(PlayerInventory.Inventory[playerChoice - 1].Type, PlayerInventory.Inventory[playerChoice - 1].Index);
                        break;
                    }
                }
            }
            else if (num == 2)
            {
                while (true)
                {
                    TypingText("", "해제을 원하는 장비 입력 : ");
                    Console.WriteLine();
                    int playerChoice = WhatNum(1, PlayerInventory.Inventory.Count);

                    if (PlayerInventory.Inventory[playerChoice - 1].Eq == false)
                    {
                        TypingText("", "장착하지 않은 장비입니다");
                        Console.WriteLine();
                    }
                    else
                    {
                        PlayerInventory.Inventory[playerChoice - 1].Eq = false;
                        UneqItem(PlayerInventory.Inventory[playerChoice - 1].Type, PlayerInventory.Inventory[playerChoice - 1].Index);
                        break;
                    }
                }
            }
            else
                PlayerInventory.ShowInventory();

        }
        public void SeeItem() // 장비 확인 메서드
        {
            while (true)
            {
                Console.Clear();
                PlayerInventory.ShowInventory();
                TypingText("", "정보를 보기 원하는 아이템 숫자 : ");
                Console.WriteLine();
                int playerChoice = WhatNum(1, PlayerInventory.Inventory.Count);

                TypingVar("green", PlayerInventory.Inventory[playerChoice - 1].Name);
                Console.WriteLine();
                switch (PlayerInventory.Inventory[playerChoice - 1].Type)
                {
                    case Item.ItemType.Weapon:
                        TypingText("", "공격력 : ", 0);
                        TypingVar("", Item.WeaponDB.weapon[PlayerInventory.Inventory[playerChoice - 1].Index].Power, 0);
                        Console.WriteLine();
                        TypingText("", "방어력 : ", 0);
                        TypingVar("", Item.WeaponDB.weapon[PlayerInventory.Inventory[playerChoice - 1].Index].Defense, 0);
                        Console.WriteLine();
                        TypingText("", "가격 : ", 0);
                        TypingVar("yellow", Item.WeaponDB.weapon[PlayerInventory.Inventory[playerChoice - 1].Index].Cost, 0);
                        Console.WriteLine();
                        break;

                    case Item.ItemType.Armor:
                        TypingText("", "공격력 : ", 0);
                        TypingVar("", Item.ArmorDB.armor[PlayerInventory.Inventory[playerChoice - 1].Index].Power, 0);
                        Console.WriteLine();
                        TypingText("", "방어력 : ", 0);
                        TypingVar("", Item.ArmorDB.armor[PlayerInventory.Inventory[playerChoice - 1].Index].Defense, 0);
                        Console.WriteLine();
                        TypingText("", "체력 : ", 0);
                        TypingVar("green", Item.ArmorDB.armor[PlayerInventory.Inventory[playerChoice - 1].Index].MaxHp, 0);
                        Console.WriteLine();
                        TypingText("", "가격 : ", 0);
                        TypingVar("yellow", Item.ArmorDB.armor[PlayerInventory.Inventory[playerChoice - 1].Index].Cost, 0);
                        Console.WriteLine();
                        break;

                    case Item.ItemType.Accessory:
                        TypingText("", "공격력 : ", 0);
                        TypingVar("", Item.AccessoryDB.accessory[PlayerInventory.Inventory[playerChoice - 1].Index].Power, 0);
                        Console.WriteLine();
                        TypingText("", "방어력 : ", 0);
                        TypingVar("", Item.AccessoryDB.accessory[PlayerInventory.Inventory[playerChoice - 1].Index].Defense, 0);
                        Console.WriteLine();
                        TypingText("", "가격 : ", 0);
                        TypingVar("yellow", Item.AccessoryDB.accessory[PlayerInventory.Inventory[playerChoice - 1].Index].Cost, 0);
                        Console.WriteLine();
                        break;


                    case Item.ItemType.Potion:
                        TypingText("", "회복량 : ", 0);
                        TypingVar("", Item.PotionDB.potion[PlayerInventory.Inventory[playerChoice - 1].Index].Hp, 0);
                        Console.WriteLine();
                        TypingText("", "가격 : ", 0);
                        TypingVar("yellow", Item.PotionDB.potion[PlayerInventory.Inventory[playerChoice - 1].Index].Cost, 0);
                        Console.WriteLine();

                        if (Item.PotionDB.potion[PlayerInventory.Inventory[playerChoice - 1].Index].Purification == true)
                        {
                            TypingText("green", "상태이상 회복 가능", 0);
                            Console.WriteLine();
                        }
                        break;

                    case Item.ItemType.Scroll:
                        TypingText("", "가격 : ", 0);
                        TypingVar("yellow", Item.ScrollDB.scroll[PlayerInventory.Inventory[playerChoice - 1].Index].Cost, 0);
                        Console.WriteLine();
                        TypingText("", "사용시 신비한 효과가 나타난다.");
                        Console.WriteLine();
                        break;
                }

                TypingText("", "1 : 다른 장비정보 확인\n2 : 돌아가기");
                Console.WriteLine();
                TypingText("", "숫자 입력 : ");
                int playerChoice2 = WhatNum(1, 2);
                switch (playerChoice2)
                {
                    case 1:
                        break;
                    case 2:
                        ShowPlayerInventory();
                        break;
                }
            }
        }
        public void EqItem(Item.ItemType type, int index) // 장비 장착
        {
            switch (type)
            {
                case Item.ItemType.Weapon:
                    Player.Power += Item.WeaponDB.weapon[index].Power;
                    Player.Defense += Item.WeaponDB.weapon[index].Defense;
                    TypingVar("green", Item.WeaponDB.weapon[index].Name);
                    TypingText("", "을 장착 했습니다.");
                    break;

                case Item.ItemType.Armor:
                    Player.MaxHp += Item.ArmorDB.armor[index].MaxHp;
                    Player.Defense += Item.ArmorDB.armor[index].Defense;
                    Player.Power += Item.ArmorDB.armor[index].Power;
                    TypingVar("green", Item.ArmorDB.armor[index].Name);
                    TypingText("", "을 장착 했습니다.");
                    break;

                case Item.ItemType.Accessory:
                    Player.Power += Item.AccessoryDB.accessory[index].Power;
                    Player.Defense += Item.AccessoryDB.accessory[index].Defense;
                    TypingVar("green", Item.AccessoryDB.accessory[index].Name);
                    TypingText("", "을 장착 했습니다.");
                    break;
                default:
                    TypingText("", "장착 할 수 없는 아이템입니다");
                    break;
            }
            Console.WriteLine();
            ShowPlayerInventory();
        }

        public void UneqItem(Item.ItemType type, int index) // 장비 탈착
        {
            switch (type)
            {
                case Item.ItemType.Weapon:
                    Player.Power -= Item.WeaponDB.weapon[index].Power;
                    Player.Defense -= Item.WeaponDB.weapon[index].Defense;
                    TypingVar("green", Item.WeaponDB.weapon[index].Name);
                    TypingText("", "을 해제 했습니다.");
                    break;

                case Item.ItemType.Armor:
                    Player.MaxHp -= Item.ArmorDB.armor[index].MaxHp;
                    Player.Defense -= Item.ArmorDB.armor[index].Defense;
                    Player.Power -= Item.ArmorDB.armor[index].Power;
                    TypingVar("green", Item.ArmorDB.armor[index].Name);
                    TypingText("", "을 해제 했습니다.");
                    break;

                case Item.ItemType.Accessory:
                    Player.Power -= Item.AccessoryDB.accessory[index].Power;
                    Player.Defense -= Item.AccessoryDB.accessory[index].Defense;
                    TypingVar("green", Item.AccessoryDB.accessory[index].Name);
                    TypingText("", "을 해제 했습니다.");
                    break;
                default:
                    TypingText("", "장착 할 수 없는 아이템입니다");
                    break;
            }
            Console.WriteLine();
            ShowPlayerInventory();
        }
        public void LevelUp() // 레벨업 함수
        {
            TypingText("green", "레벨업! ");
            TypingText("", "능력치가 상승했다.");
            Console.WriteLine();

            Player.Level++;
            switch (Player.PlayerJob)
            {
                case Profile.Job.Warrior:
                    Player.Power += 3;
                    Player.Defense += 2;
                    Player.MaxHp += 6;
                    Player.Hp += 6;
                    break;

                case Profile.Job.Mage:
                    Player.Power += 5;
                    Player.Defense++;
                    Player.MaxHp += 3;
                    Player.Hp += 3;
                    break;

                case Profile.Job.Thief:
                    Player.Power += 4;
                    Player.Defense += 2;
                    Player.MaxHp += 4;
                    Player.Hp += 4;
                    break;
            }
        }

        public void ChageStat(string stat, int value) // 스탯변경시 사용
        {
            switch (stat)
            {
                case "MaxHp": // 최대체력
                    if (value >= 0)
                    {
                        Player.MaxHp += value;
                        TypingText("", "최대 체력이 ");
                        TypingVar("blue", value);
                        TypingText("", "만큼 올라갔다!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Player.MaxHp += value;
                        TypingText("", "최대 체력이 ");
                        TypingVar("red", value);
                        TypingText("", "만큼 하락됐다..");
                        Console.WriteLine();
                    }
                    break;

                case "Hp": // 체력
                    if (value >= 0)
                    {
                        Player.Hp += value;
                        if (Player.Hp >= Player.MaxHp)
                        {
                            Player.Hp = Player.MaxHp;
                            TypingText("", "체력이 ");
                            TypingText("blue", "최대치로");
                            TypingText("", " 회복됐다!");
                            Console.WriteLine();
                        }
                        else
                        {
                            TypingText("", "체력이 ");
                            TypingVar("blue", value);
                            TypingText("", "만큼 회복됐다!");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Player.MaxHp += value;
                        if (Player.Hp >= 0)
                        {
                            TypingText("", "체력이 ");
                            TypingVar("red", value);
                            TypingText("", "만큼 감소했다..");
                            Console.WriteLine();
                        }
                        else
                        {
                            EndGame();
                        }
                    }
                    break;

                case "Power": // 공격력
                    if (value >= 0)
                    {
                        Player.Power += value;
                        TypingText("", "공격력이 ");
                        TypingVar("blue", value);
                        TypingText("", "만큼 증가됐다!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Player.Power += value;
                        TypingText("", "공격력이 ");
                        TypingVar("red", value);
                        TypingText("", "만큼 감소됐다..");
                        Console.WriteLine();
                    }

                    break;

                case "Defense": // 방어력
                    if (value >= 0)
                    {
                        Player.Defense += value;
                        TypingText("", "방어력이 ");
                        TypingVar("blue", value);
                        TypingText("", "만큼 증가됐다!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Player.Defense += value;
                        TypingText("", "방어력이 ");
                        TypingVar("red", value);
                        TypingText("", "만큼 감소됐다..");
                        Console.WriteLine();
                    }

                    break;

                case "Coin":
                    if (value >= 0)
                    {
                        Player.Coin += value;
                        TypingText("yellow", "코인을 ");
                        TypingVar("blue", value);
                        TypingText("", " Gold 얻었다!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Player.Coin += value;
                        TypingText("yellow", "코인을 ");
                        TypingVar("red", value);
                        TypingText("", " Gold 잃었다..");
                        Console.WriteLine();
                    }

                    break;

                case "Exp":
                    Player.Exp += value;
                    TypingText("", "경험치를 ");
                    TypingVar("green", value);
                    TypingText("", "획득했다!");
                    Console.WriteLine();
                    ExpCalculate();
                    break;

                default:
                    Console.WriteLine("유효하지 않은 입력.");
                    break;
            }
        }

        public void ExpCalculate() // 경험치 계산
        {
            int needLvlUp = 30 + (Player.Level - 1) * 20;
            if (Player.Exp >= needLvlUp)
            {
                Player.Exp -= needLvlUp;
                LevelUp();
            }
        }

        public int RollDice() // 주사위 굴러가기
        {
            Console.WriteLine();
            TypingText("", "던전에 진입하자 나를 저울질 하는듯한 ");
            TypingText("yellow", "주사위");
            TypingText("", "가 굴러간다");
            Console.WriteLine();
            Thread.Sleep(1000);

            Random random = new Random();
            int diceNum;
            if (Player.isAwe == false)
            {
                diceNum = random.Next(1, 7);
                Console.WriteLine();

                switch (diceNum)
                {
                    case 1:
                        TypingText("", "...", 500);
                        Console.WriteLine();
                        TypingText("red", "대실패...");
                        Console.WriteLine();
                        Console.WriteLine();
                        TypingText("", "주사위 결과 : ");
                        TypingVar("purple", diceNum);
                        Console.WriteLine();
                        Console.WriteLine();
                        Thread.Sleep(1500);
                        TypingText("", "알 수 없는 불안감이 엄습한다..");
                        break;

                    case 2:
                        TypingText("", "...", 500);
                        Console.WriteLine();
                        TypingText("yellow", "실패..");
                        Console.WriteLine();
                        Console.WriteLine();
                        TypingText("", "주사위 결과 : ");
                        TypingVar("purple", diceNum);
                        Console.WriteLine();
                        Console.WriteLine();
                        Thread.Sleep(1500);
                        TypingText("", "등골이 서늘하다..");
                        break;

                    case 3:
                    case 4:
                        TypingText("", "...", 500);
                        Console.WriteLine();
                        TypingText("", "음.. 아무일도 일어나지 않은듯 하다.");
                        Console.WriteLine();
                        Console.WriteLine();
                        TypingText("", "주사위 결과 : ");
                        TypingVar("purple", diceNum);
                        Console.WriteLine();
                        break;

                    case 5:
                        TypingText("", "...", 500);
                        Console.WriteLine();
                        TypingText("yellow", "성공!");
                        Console.WriteLine();
                        Console.WriteLine();
                        TypingText("", "주사위 결과 : ");
                        TypingVar("purple", diceNum);
                        Console.WriteLine();
                        Console.WriteLine();
                        Thread.Sleep(1500);
                        TypingText("", "하는 일들이 술술 풀리는듯 하다.");
                        break;

                    case 6:
                        TypingText("", "...", 500);
                        Console.WriteLine();
                        TypingText("red", "대성공!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        TypingText("", "주사위 결과 : ");
                        TypingVar("purple", diceNum);
                        Console.WriteLine();
                        Console.WriteLine();
                        Thread.Sleep(1500);
                        TypingText("", "운명의 신이 나에게 웃어준건가..?");
                        break;

                }
            }
            else
            {
                diceNum = random.Next(4, 7);
                TypingText("", "신의 ");
                TypingText("red", "축복");
                TypingText("", "이 함께하리..");
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1000);

                TypingText("", "주사위 결과 : ");
                TypingVar("purple", diceNum);
                Console.WriteLine();

                if (diceNum == 6)
                {
                    Console.WriteLine();
                    TypingText("", "운명의 신이 나를 ");
                    TypingText("red", "주시 ");
                    TypingText("", "하는 기분이 든다.");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            return diceNum;
        }

        public Events.StartEvent[] RandomStartEvent() // 이벤트 랜덤추출
        {
            Random random = new Random();

            int[] ranEvent = { -1, -2, -3 };
            Events.StartEvent[] Choice = { Events.StartEvent.Belliever, Events.StartEvent.Humanism, Events.StartEvent.Warmonger };

            for (int i = 0; i < 3; i++)
            {
                do
                {
                    ranEvent[i] = random.Next(1, 6);
                    Choice[i] = (Events.StartEvent)ranEvent[i];
                } while (ranEvent[0] == ranEvent[1] || ranEvent[1] == ranEvent[2] || ranEvent[0] == ranEvent[2]);

                TypingVar("", i + 1);
                TypingText("", ":");
                TypingVar("", Events.startEvent[Choice[i]]);
                Console.WriteLine();
                Console.WriteLine();
            }
            return new Events.StartEvent[] { Choice[0], Choice[1], Choice[2] };
        }

        public void AddItem(GameManager game, Item.ItemType type, int index)
        {
            ItemToInven(game, type, index);
        }

        public void DeleteItem(int index)
        {
            if (index >= 0 && index < Inventory.Count)
                Inventory.RemoveAt(index);
        }

        public void TownShop()
        {

        }

        public void DungeonStart()  // 던전 진입시 사용
        {
            Player.isDungeon = true;
            Console.Clear();
            NextMap();

            int luck = RollDice();
            TypingText("", ".....", 400);
            Console.WriteLine();

            mapLocation = MakeMap();

        }
    }
}