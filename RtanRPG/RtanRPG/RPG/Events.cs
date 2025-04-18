using static RtanRPG.RPG.GameHelper.TypingHelper;

namespace RtanRPG.RPG
{
    internal static class Events
    {
        public enum StartEvent
        {
            Belliever = 1, // 신앙자
            Humanism = 2, // 인간찬가
            Warmonger = 3, // 전쟁광
            Wealthy = 4, // 갑부
            Celeb = 5, // 연예인
            Godslayer = 6, // 신살자
        }
        public static readonly Dictionary<StartEvent, string> startEvent = new Dictionary<StartEvent, string>()
        {
            {StartEvent.Belliever, "신앙자 : 마음에 신앙이 차오르는것 같다."},
            {StartEvent.Humanism, "인간찬가 : 인간들은 늘 위기를 스스로 해쳐왔다.\n지금도 마찬가지다."},
            {StartEvent.Warmonger, "전쟁광 : 강한 힘의 유혹이 느껴진다."},
            {StartEvent.Wealthy, "갑부 : Flex~"},
            {StartEvent.Celeb, "연예인 : 포근함이 느껴진다."},
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
                    GameHelper.ItemHelper.ItemToInven(game, Item.ItemType.Accessory, 1);
                    TypingText("", "몸에 활력이 돋아난다.");
                    Console.WriteLine();
                    TypingText("", "체력:15 / 공격력:5 / 방어력:5 증가");
                    Thread.Sleep(500);

                    Console.WriteLine();
                    Console.WriteLine();
                    TypingText("", ".....", 400);
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "신에게 ");
                    TypingText("yellow", "경외심");
                    TypingText("", "이 느껴진다.");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    TypingVar("yellow", Item.AccessoryDB.accessory[1].Name);
                    TypingText("", " 획득.");
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
                    Console.WriteLine();

                    TypingText("", ".....", 400);
                    Console.WriteLine();
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
                    TypingText("", "순간 참을 수 없는 ");
                    TypingText("red", "전투의");
                    TypingText("", " 충동이 느껴진다.");
                    Console.WriteLine();
                    Thread.Sleep(500);
                    TypingText("", "공격력:11 / 방어력:5 증가");
                    Thread.Sleep(500);
                    Console.WriteLine();
                    Console.WriteLine();
                    TypingText("", ".....", 400);
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "현재 체력이");
                    TypingText("red", " 10 ");
                    TypingText("", "감소했다.");
                    Console.WriteLine();
                    break;

                case StartEvent.Wealthy:
                    game.Player.Coin += 200;
                    TypingText("", "하늘에서 ");
                    TypingText("yellow", "금화가");
                    TypingText("", " 쏟아진다.");
                    Thread.Sleep(500);
                    Console.WriteLine();
                    Console.WriteLine();
                    TypingText("", ".....", 400);
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "코인 ");
                    TypingText("yellow", "200");
                    TypingText("", " 증가.");
                    Console.WriteLine();
                    break;

                case StartEvent.Celeb:
                    game.Player.isCeleb = true;
                    TypingText("", "주위 사람들이 점점 ");
                    TypingText("green", "동경의 시선");
                    TypingText("", "을 보낸다.");
                    Thread.Sleep(500);
                    Console.WriteLine();
                    Console.WriteLine();
                    TypingText("", ".....", 400);
                    Console.WriteLine();
                    Console.WriteLine();

                    TypingText("", "옆의 꼬마가 ");
                    TypingText("green", "선물");
                    TypingText("", "을 줬다.");
                    Console.WriteLine();
                    Thread.Sleep(1000);

                    TypingVar("yellow", Item.PotionDB.potion[3].Name);
                    TypingText("", ", ");
                    TypingVar("yellow", Item.AccessoryDB.accessory[4].Name);
                    TypingText("", " 획득.");
                    break;

                case StartEvent.Godslayer:
                    GameHelper.ItemHelper.ItemToInven(game, Item.ItemType.Accessory, 8);
                    break;
            }
        }
    }
}