using static RtanRPG.RPG.GameHelper.TypingHelper;
using static RtanRPG.RPG.GameHelper.ItemHelper;

namespace RtanRPG.RPG
{
    internal class GameManager
    {
        public Profile.PlayerInfo Player { get; set; } // 플레이어 프로필 선언
        public void NewPlayer(string name, Profile.Job job, string jobName) // 메인에서 플레이어 프로필을 초기화 하는 함수
        {
            Player = new Profile.PlayerInfo(name, job, jobName);
        }

        public Item.InventoryInfo PlayerInventory { get; set; } // 플레이어 인벤토리 선언
        public void NewInventory() // 메인에서 인벤토리를 초기화 하는 함수
        {
            PlayerInventory = new Item.InventoryInfo();
        }

        public List<Item.ItemInfo> Inventory { get; private set; } = new List<Item.ItemInfo>();




        public Map.MapInfo CurrentMap { get; set; } // 현재 맵 위치

        public int Turn { get; set; } = 0; // 턴 저장 변수

        public bool GameOver { get; set; } = false; // 게임루프 관리하는 불리언 변수

        public void NextMap() // 다음 맵갈때마다 실행 (턴+1)
        {
            Turn++;
        }

        public void EndGame() // 게임종료 함수
        {
            GameOver = true;
        }

        public int WhatNum(int a, int b)
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

        public void BasicChoice()
        {
            Console.Clear();
            TypingText("white", "┌──────────────┬───────────────┬───────────────┐", 0);
            Console.WriteLine();
            Console.WriteLine();
            TypingText("white", "│   1. 상태창  │  2. 인벤토리  │  3. 던전 입장 │", 0);
            Console.WriteLine();
            Console.WriteLine();
            TypingText("white", "└──────────────┴───────────────┴───────────────┘", 0);
            Console.WriteLine();
            Console.WriteLine();
        }

        public void MainTitle()  // 게임 메인화면
        {
            BasicChoice();
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

        public void ShowPlayerInventory() // 플레이어 인벤토리 표시 함수
        {
            PlayerInventory.ShowInventory();
            GameHelper.TypingHelper.TypingText("", "1 : 메인화면\n2 : 장비장착");
            Console.WriteLine();
            GameHelper.TypingHelper.TypingText("", "숫자 입력 : ");
            int playerChoice = WhatNum(1, 2);

            switch (playerChoice)
            {
                case 1:
                    MainTitle();
                    break;
                case 2:
                    ChageItem();
                    break;
            }
        }
        public void ShowPlayerStats() // 플레이어 스탯창 표시 함수
        {
            Player.ShowStats();
            TypingText("", "1 : 메인화면\n2 : 인벤토리");
            Console.WriteLine();
            TypingText("", "숫자 입력 : ");
            int playerChoice = WhatNum(1, 2);
            switch (playerChoice)
            {
                case 1:
                    MainTitle();
                    break;
                case 2:
                    ShowPlayerInventory();
                    break;
            }

        }

        public void ChageItem()
        {
            TypingText("", "1 : 장착\n2 : 해제");
            Console.WriteLine();
            TypingText("", "숫자 입력 : ");
            int num = WhatNum(1, 2);
            if (num == 1)
            {
                while (true)
                {
                    TypingText("", "장착을 원하는 장비 입력 : ");
                    int playerChoice = WhatNum(1, Inventory.Count);
                    Item.ItemType nowType = Inventory[playerChoice - 1].Type;
                    int nowIndex = Inventory[playerChoice - 1].Index;

                    if (Inventory[playerChoice - 1].Eq == true)
                    {
                        TypingText("", "이미 장착한 장비입니다");
                    }
                    else
                    {
                        Inventory[playerChoice - 1].Eq = true;
                        // EqItem(, Inventory[playerChoice - 1].Type, Inventory[playerChoice - 1].Index);
                        break;
                    }
                }
            }
            else if (num == 2)
            {
                while (true)
                {
                    TypingText("", "해제을 원하는 장비 입력 : ");
                    int playerChoice = WhatNum(1, Inventory.Count);
                    Item.ItemType nowType = Inventory[playerChoice - 1].Type;
                    int nowIndex = Inventory[playerChoice - 1].Index;

                    if (Inventory[playerChoice - 1].Eq == false)
                    {
                        TypingText("", "장착하지 않은 장비입니다");
                    }
                    else
                    {
                        Inventory[playerChoice - 1].Eq = true;
                        //UneqItem(, Inventory[playerChoice - 1].Type, Inventory[playerChoice - 1].Index);
                        break;
                    }
                }
            }

        }

        public void LevelUp()
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

        public void ChageStat(string stat, int value)
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

        public void ExpCalculate()
        {
            int needLvlUp = 30 + (Player.Level - 1) * 20;
            if (Player.Exp >= needLvlUp)
            {
                Player.Exp -= needLvlUp;
                LevelUp();
            }
        }

        public int RollDice()
        {
            Random random = new Random();
            int diceNum;
            if (Player.isAwe == false)
            {
                diceNum = random.Next(1, 6);
                Console.WriteLine();
                TypingText("", "주사위 결과 : ");
                TypingVar("purple", diceNum);
                Console.WriteLine();

            }
            else
            {
                diceNum = random.Next(3, 6);
                TypingText("", "신의 ");
                TypingText("red", "축복");
                TypingText("", "이 함께하리..");
                Console.WriteLine();
                Thread.Sleep(1000);

                TypingText("", "주사위 결과 : ");
                TypingVar("purple", diceNum);
                Console.WriteLine();
            }
            return diceNum;
        }

        public Events.StartEvent[] RandomEvent(string eventType)
        {
            Random random = new Random();

            switch (eventType)
            {
                case "Start":
                    int[] ranEvent = { -1, -2, -3 };
                    Events.StartEvent[] Choice = { Events.StartEvent.Belliever, Events.StartEvent.Humanism, Events.StartEvent.Warmonger };

                    for (int i = 0; i < 3; i++)
                    {
                        do
                        {
                            ranEvent[i] = random.Next(1, 6);
                            Choice[i] = (Events.StartEvent)ranEvent[i];
                        } while (ranEvent[0] == ranEvent[1] && ranEvent[1] == ranEvent[2]);

                        TypingVar("", i + 1);
                        TypingText("", ":");
                        TypingVar("", Events.startEvent[Choice[i]]);
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    return new Events.StartEvent[] { Choice[0], Choice[1], Choice[2] };

                case "RandomRoom":
                    return null;

                default:
                    return null;

            }
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

        public void DungeonStart()
        {
            TypingText("", "당신은 던전에 나아간다..");

            int luck = RollDice();

            if (luck == 6)
            {
                TypingText("yellow", "대성공!");
            }
        }
    }
}