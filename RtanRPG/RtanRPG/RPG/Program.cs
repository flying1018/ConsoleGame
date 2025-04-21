using System.Threading.Tasks.Dataflow;
using static RtanRPG.RPG.GameHelper.TypingHelper;
using static RtanRPG.RPG.GameHelper.LordingHelper;
using static RtanRPG.RPG.GameHelper.ItemHelper;

namespace RtanRPG.RPG
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Rtan RPG";

            bool selectLoop = true; // 캐릭터 생성 관리 불리언 변수

            string playerName = "";
            Profile.Job playerJob = Profile.Job.Warrior; // 초기 세팅
            string textJob = "";
            string input = "";
            int inputNum = -1;


            GameManager game = new GameManager();

            while (selectLoop)
            {
                bool nameSelect = true;
                bool jobSelect = true;

                do // 플레이어 이름 선택 루프
                {
                    nameSelect = true;
                    TypingText("green", "당신");
                    TypingText("", "의 이름을 입력하시오.");
                    Console.WriteLine();

                    Console.Write("이름 : ");
                    playerName = Console.ReadLine();
                    Console.Clear();

                    TypingText($"", "당신의 이름은 \'");
                    TypingVar("green", playerName);
                    TypingText("", "\' 맞습니까?");
                    Console.WriteLine();

                    input = game.YesOrNo();

                    if (input == "y" || input == "Y")
                    {
                        TypingText("", "환영합니다 ");
                        TypingVar("green", playerName);
                        TypingText("", " 모험가여...");
                    }
                    else if (input == "n" || input == "N")
                    {
                        nameSelect = false;
                        Console.Clear();
                    }
                    input = "";
                } while (!nameSelect);
                Console.WriteLine();

                Thread.Sleep(1500);
                do // 직업 선택루프
                {
                    jobSelect = true;
                    TypingText("", "당신이 선택할 ");
                    TypingText("blue", "직업");
                    TypingText("", "을 선택하시오.");
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "1.");
                    TypingText("blue", "전사");
                    TypingText("", " : 어떤 시련이 와도 굴하지 않을 자 - ");
                    TypingText("yellow", "높은 방어력");
                    TypingText("", "이 특징이다.");
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "2.");
                    TypingText("blue", "마법사");
                    TypingText("", " : 세상의 이치를 탐구하는자 - ");
                    TypingText("yellow", "높은 공격력");
                    TypingText("", "이 특징이다.");
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "3.");
                    TypingText("blue", "도적");
                    TypingText("", " : 기민하며 은밀한자 - ");
                    TypingText("yellow", "변칙적인 플레이");
                    TypingText("", "가 특징이다.");
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "원하는 직업 선택 (1~3) : ");

                    inputNum = game.WhatNum(1, 3);
                    Console.Clear();

                    switch (inputNum)
                    {
                        case 1:
                            playerJob = Profile.Job.Warrior;
                            textJob = "전사";
                            break;

                        case 2:
                            playerJob = Profile.Job.Mage;
                            textJob = "마법사";
                            break;

                        case 3:
                            playerJob = Profile.Job.Thief;
                            textJob = "도적";
                            break;

                        default:
                            TypingText("red", "오류 발생!");
                            TypingText("", ", 게임을 종료합니다.");
                            return;
                    }
                    inputNum = -1;

                    TypingText($"", "당신이 선택한 직업은 \'");
                    TypingVar("green", textJob);
                    TypingText("", "\' 맞습니까?");
                    Console.WriteLine();

                    input = game.YesOrNo();

                    if (input == "y")
                    {
                        TypingText("", "당신은 \'");
                        TypingVar("blue", textJob);
                        TypingText("", "\' 직업을 선택 하셨습니다 모험가여...");
                        Console.WriteLine();
                    }
                    else if (input == "n")
                    {
                        jobSelect = false;
                        Console.Clear();
                    }
                    input = "";
                } while (!jobSelect);

                Console.WriteLine();
                Thread.Sleep(1500);

                TypingText("", "다음과 같이 진행 하시겠습니까?");
                Console.WriteLine();
                Thread.Sleep(1000);

                game = new GameManager();
                game.NewPlayer(playerName, playerJob, textJob); // 플레이어 객체 선언
                game.NewInventory(); // 플레이어 인벤토리 선언

                game.Player.ShowStats();
                Console.WriteLine();

                input = game.YesOrNo(); // YorN 선택
                if (input == "y")
                {
                    selectLoop = false;
                    TypingText("", "잠시후 게임이 시작합니다");
                    TypingText("", "....", 400);
                }
                else if (input == "n")
                {
                    Console.Clear();
                }
                input = "";
            }

            Console.WriteLine();
            ItemToInven(game, Item.ItemType.Potion, 1);
            ItemToInven(game, Item.ItemType.Potion, 1); // 기본 템으로 체력_물약 2개 지급
            ItemToInven(game, Item.ItemType.Armor, 1);
            switch (game.Player.PlayerJob)
            {
                case Profile.Job.Warrior:
                    ItemToInven(game, Item.ItemType.Weapon, 1);
                    break;

                case Profile.Job.Mage:
                    ItemToInven(game, Item.ItemType.Weapon, 2);
                    break;

                case Profile.Job.Thief:
                    ItemToInven(game, Item.ItemType.Weapon, 3);
                    break;
            }
            int TestSpeed = 50;
            bool gameSkip = true;
            if (!gameSkip)
            {
                Console.Clear();
                TypingText("", "이 세상은 ", TestSpeed);
                Thread.Sleep(700);
                TypingText("red", "운명의 신", TestSpeed);
                TypingText("", "의");
                Thread.Sleep(700);
                TypingText("", " 은총을 받는다는 전승이 있다.", TestSpeed);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1200);

                TypingText("", "하지만,", TestSpeed);
                Thread.Sleep(700);
                TypingText("", " 여러 나라들이 자국의 이익을 위해 전쟁을 하며\n", TestSpeed);
                Thread.Sleep(700);
                TypingText("", "마계의 존재들이 세상을 뒤엎을 계획을 꾀하는 지금.", TestSpeed);
                Thread.Sleep(700);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1200);

                TypingText("", "사람들은 현 시대를 ", TestSpeed);
                Thread.Sleep(700);
                TypingText("yellow", "\'군웅할거\'", TestSpeed);
                TypingText("", "의 시대라 말하고 있다..", TestSpeed);
                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(1000);
                TypingText("", ".....", 400);
                Console.WriteLine();
                Console.WriteLine();

                TypingText("", "?? : \"반갑네 ", TestSpeed);
                TypingVar("green", game.Player.Name);
                TypingText("", ".\"");
                Console.WriteLine();
                Thread.Sleep(700);

                TypingText("", "?? : \"자네가 이번에 새로 등록한 모험가구먼.\"", TestSpeed);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1500);

                TypingText("", "르탄 : \"그리 경계하지 말게나. 난 르탄, 모험가 길드의 길드장이지.\"", TestSpeed);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1000);

                TypingText("", "-신전 스토리 생략-");
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1000);

                TypingText("", "사제 : \'여행에 떠나기전, ", TestSpeed);
                Thread.Sleep(700);
                TypingText("", "네가 원하는 ", TestSpeed);
                TypingText("yellow", "\'신의 축복\'", TestSpeed);
                TypingText("", "을 선택해라 모험가여.", TestSpeed);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(1500);
            }

            Events.StartEvent[] StartEventSelect = game.RandomStartEvent();

            inputNum = game.WhatNum(1, 3);
            Events.StartEvent playerStartEvent = StartEventSelect[inputNum - 1];
            Events.ApplyStartEvent(game, playerStartEvent);
            Console.WriteLine();
            Console.WriteLine();
            TypingText("", ".....", 400);
            Console.WriteLine();
            Console.WriteLine();



            while (!game.GameOver)
            {
                game.MainTitle();
                game.DungeonTitle();
            }
        }
    }
}