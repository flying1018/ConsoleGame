using static RtanRPG.RPG.GameHelper.ColorHelper;
using static RtanRPG.RPG.GameHelper.TypingHelper;

namespace RtanRPG.RPG
{
    internal static class Utils
    {
        public static void ApplySpecialEffect(string name, GameManager game)
        {
            switch (name)
            {
                case "치유_물약":
                    Heal(game, Item.PotionDB.potion[1].Hp);
                    TypingText("", "체력 ");
                    TypingVar("red", Item.PotionDB.potion[1].Hp);
                    TypingText("", " 회복!");
                    Console.WriteLine();
                    break;

                case "상급_물약":
                    Heal(game, Item.PotionDB.potion[2].Hp);
                    TypingText("", "체력 ");
                    TypingVar("red", Item.PotionDB.potion[2].Hp);
                    TypingText("", " 회복!");
                    Console.WriteLine();
                    break;

                case "엘릭서":
                    Heal(game, Item.PotionDB.potion[3].Hp);
                    TypingText("", "체력 ");
                    TypingVar("red", Item.PotionDB.potion[3].Hp);
                    TypingText("", " 회복!");
                    Console.WriteLine();

                    break;

                case "만병_통치약":
                    Heal(game, Item.PotionDB.potion[4].Hp);
                    NoDebuff(game);
                    TypingText("", "모든 ");
                    TypingText("purple", "체력과 상태이상이");
                    TypingText("", " 회복 되었습니다!");
                    Console.WriteLine();
                    break;

                case "상태_회복약":
                    NoDebuff(game);
                    TypingText("", "모든 ");
                    TypingText("purple", "상태이상이");
                    TypingText("", " 회복 되었습니다!");
                    Console.WriteLine();
                    break;

            }
        }

        public static void NoDebuff(GameManager game)
        {
            game.Player.isFascination = false;
            game.Player.isAwe = false;
        }

        public static void Heal(GameManager game, int amount)
        {
            game.Player.Hp += amount;
            if (game.Player.Hp >= game.Player.MaxHp)
                game.Player.Hp = game.Player.MaxHp;
        }
    }
}