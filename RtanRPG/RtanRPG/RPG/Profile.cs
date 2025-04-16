namespace RtanRPG.RPG
{
    internal static class Profile
    {
        public enum Job
        {
            Warrior, Mage, Thief
        }

        public class PlayerInfo
        {
            public string Name;
            public Job PlayerJob;
            public int Level;
            public int Power;
            public int Defense;
            public int Coin;
            public PlayerInfo(string name, Job playerJob)
            {
                Name = name;
                PlayerJob = playerJob;
                Level = 1;

                switch (playerJob) // 직업별 능력치 배분
                {
                    case Job.Warrior:
                        Power = 10;
                        Defense = 10;
                        Coin = 0;
                        break;

                    case Job.Mage:
                        Power = 20;
                        Defense = 2;
                        Coin = 150;
                        break;

                    case Job.Thief:
                        Power = 15;
                        Defense = 5;
                        Coin = 400;
                        break;
                }
            }
        }
    }
}