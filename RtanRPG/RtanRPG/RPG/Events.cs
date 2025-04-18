using static RtanRPG.RPG.GameHelper.TypingHelper;

namespace RtanRPG.RPG
{
    internal static class Events
    {
        public enum StartEvent
        {
            Belliever, // 신앙자
            Humanism, // 인간찬가
            Warmonger, // 전쟁광
            Wealthy, // 갑부
            Godslayer // 신살자
        }
        public static readonly Dictionary<StartEvent, string> startEvent = new Dictionary<StartEvent, string>() 
        {
            {StartEvent.Belliever, "신앙자 : 마음에 신앙이 차오르는것 같다."},
            {StartEvent.Humanism, "인간찬가 : 인간들은 위기들을 스스로 해쳐왔다.\n이번에도 마찬가지일거다."},
            {StartEvent.Warmonger, "전쟁광 : 강한 힘의 유혹이 느껴진다."},
            {StartEvent.Wealthy, "갑부 : Flex~"},
            {StartEvent.Godslayer, "신살자 : ????"},
        };
        public static void ApplyStartEvent(GameManager game, StartEvent name)
        {
            switch (name)
            {
                case StartEvent.Belliever:
                    game.Player.isAwe = true;
                    game.Player.Power += 5;
                    game.Player.Defense += 5;
                    game.Player.MaxHp += 15;
                    game.Player.Hp = game.Player.MaxHp;
                    TypingText("", "몸에 활력이 돋아난다.");
                    Console.WriteLine();
                    TypingText("", "체력:15 / 공격력:5 / 방어력:5 증가");
                    Thread.Sleep(1000);
                    Console.WriteLine();

                    TypingText("", "신에게 ");
                    TypingText("yellow", "경외심");
                    TypingText("", "을 느낀다");
                    Console.WriteLine();
                    break;

                case StartEvent.Humanism:
                    game.Player.Defense += 5;
                    game.Player.MaxHp += 5;
                    game.Player.Hp = game.Player.MaxHp;
                    TypingText("", "인류의 ");
                    TypingText("green", "강한 의지");
                    TypingText("", "가 느껴진다.");
                    Console.WriteLine();
                    TypingText("", "체력:5 / 방어력:5 증가");
                    Console.WriteLine();
                    Thread.Sleep(1000);

                    game.LevelUp();
                    break;

                case StartEvent.Warmonger:
                    game.Player.Power += 11;
                    game.Player.Defense += 5;
                    game.Player.Hp -= 10;
                    TypingText("", "그 순간 참을 수 없는 ");
                    TypingText("red", "전투의");
                    TypingText("", " 충동이 느껴진다.");
                    Console.WriteLine();
                    TypingText("", "공격력:11 / 방어력:5 증가");
                    Thread.Sleep(1000);
                    Console.WriteLine();

                    TypingText("", "현재 체력이");
                    TypingText("red", "10");
                    TypingText("", "감소했다.");
                    break;

                case StartEvent.Wealthy:
                    game.Player.Coin += 200;
                    TypingText("", "하늘에서 ");
                    TypingText("yellow", "금화가");
                    TypingText("", " 쏟아진다.");
                    Thread.Sleep(1000);
                    Console.WriteLine();
                    
                    TypingText("", "코인 ");
                    TypingText("yellow", "200");
                    TypingText("", " 증가.");
                    Console.WriteLine();
                    break;

                case StartEvent.Godslayer:
                    GameHelper.ItemHelper.ItemToInven(game, Item.ItemType.Accessory, 8);
                    break;
            }
        }
    }
}