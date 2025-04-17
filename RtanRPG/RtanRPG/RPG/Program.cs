using System.Threading.Tasks.Dataflow;
using static RtanRPG.RPG.GameHelper.ColorHelper;
using static RtanRPG.RPG.GameHelper.TypingHelper;
using static RtanRPG.RPG.GameHelper.LordingHelper;

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

                    while (true)
                    {
                        Console.WriteLine();
                        TypingText("", "(Y/N) 입력 : ");
                        string input = Console.ReadLine();
                        Console.WriteLine();

                        if (input == "y" || input == "Y")
                        {
                            TypingText("", "환영합니다 ");
                            TypingVar("green", playerName);
                            TypingText("", " 모험가여...");
                            break;
                        }
                        else if (input == "n" || input == "N")
                        {
                            nameSelect = false;
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            TypingText("red", "Y/N");
                            TypingText("", "를 입력 해주십시오");
                        }
                    }
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

                    int jobIndex = 0;
                    while (true)
                    {
                        Console.Write("직업(1~3) 입력 : ");
                        string input = Console.ReadLine();
                        Console.Clear();

                        int inputNum = -1;
                        bool isIndex = int.TryParse(input, out inputNum);
                        if (1 <= inputNum && inputNum <= 3)
                        {
                            jobIndex = inputNum;
                            break;
                        }
                        else
                        {
                            TypingText("red", "유효한 ");
                            TypingText("", "숫자를 입력 해주십시오");
                            Console.WriteLine();
                        }
                    }

                    switch (jobIndex)
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
                            goto finishGame;
                    }

                    TypingText($"", "당신이 선택한 직업은 \'");
                    TypingVar("green", textJob);
                    TypingText("", "\' 맞습니까?");

                    while (true)
                    {
                        Console.WriteLine();
                        TypingText("", "(Y/N) 입력 : ");
                        string check = Console.ReadLine();

                        Console.WriteLine();

                        if (check == "y" || check == "Y")
                        {
                            TypingText("", "당신은 \'");
                            TypingVar("blue", textJob);
                            TypingText("", "\' 직업을 선택 하셨습니다 모험가여...");
                            break;
                        }
                        else if (check == "n" || check == "N")
                        {
                            jobSelect = false;
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            TypingText("red", "Y/N");
                            TypingText("", "를 입력 해주십시오");
                        }
                    }
                } while (!jobSelect);

                Console.WriteLine();
                Thread.Sleep(1500);

                TypingText("", "다음과 같이 진행 하시겠습니까?");
                Console.WriteLine();
                Thread.Sleep(1000);

                game = new GameManager();
                game.InputPlayer(playerName, playerJob, textJob);

                game.ShowPlayerStats();
                Console.WriteLine();
                while (true)
                {
                    TypingText("", "(Y/N) 입력 : ");
                    string input = Console.ReadLine();
                    Console.Clear();

                    if (input == "y" || input == "Y")
                    {
                        selectLoop = false;
                        TypingText("", "잠시후 게임이 시작합니다");
                        TypingText("", "....", 400);
                        break;
                    }
                    else if (input == "n" || input == "N")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        TypingText("red", "Y/N");
                        TypingText("", "를 입력 해주십시오");
                    }
                }
            }




            finishGame:;
        }
    }
}