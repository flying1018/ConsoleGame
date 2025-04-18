using static RtanRPG.RPG.GameHelper.ColorHelper;
using static RtanRPG.RPG.GameHelper.TypingHelper;

namespace RtanRPG.RPG
{
    internal class Profile
    {
        public enum Job
        {
            Warrior, Mage, Thief
        }

        public class PlayerInfo
        {
            public string Name;
            public string TextJob;
            public Job PlayerJob;
            public int Level;
            public int Power;
            public int Defense;
            public int Coin;
            public int Exp;
            public int Hp;
            public int MaxHp;
            public bool isFascination;
            public bool isHurt;
            public bool isAwe;
            public bool isCeleb;
            public PlayerInfo(string name, Job playerJob, string textJob)
            {
                Name = name;
                TextJob = textJob;
                PlayerJob = playerJob;
                Level = 1;
                Exp = 0;
                isFascination = false;
                isHurt = false;
                isAwe = false;
                isCeleb = false;

                switch (playerJob) // 직업별 능력치 배분
                {
                    case Job.Warrior:
                        Power = 10;
                        Defense = 10;
                        Coin = 0;
                        MaxHp = 50;
                        break;

                    case Job.Mage:
                        Power = 20;
                        Defense = 2;
                        Coin = 150;
                        MaxHp = 35;
                        break;

                    case Job.Thief:
                        Power = 15;
                        Defense = 5;
                        Coin = 400;
                        MaxHp = 40;
                        break;
                }
                Hp = MaxHp;

            }
            public void ShowStats()
            {
                TypingText("", "상태 보기", 0);
                Console.WriteLine();
                Console.WriteLine();

                TypingText("", "레벨 : ", 0);
                TypingVar("red", Level, 0);
                Console.WriteLine();

                TypingVar("green", Name, 0);
                TypingText("", " : ", 0);
                TypingVar("blue", TextJob, 0);
                Console.WriteLine();

                TypingText("", "공격력 : ", 0);
                TypingVar("", Power, 0);
                Console.WriteLine();

                TypingText("", "방어력 : ", 0);
                TypingVar("", Defense, 0);
                Console.WriteLine();

                TypingText("", "코인 : ", 0);
                TypingVar("yellow", Coin, 0);
                TypingText("", " Gold", 0);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
