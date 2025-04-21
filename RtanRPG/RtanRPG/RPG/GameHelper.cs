namespace RtanRPG.RPG
{
    internal static class GameHelper
    {
        public static class ColorHelper
        {
            public static void ColorRed() // 빨간색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            public static void ColorYellow() // 노란색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            public static void ColorGreen() // 초록색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            public static void ColorBlue() // 파란색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            public static void ColorWhite() // 밝은 흰색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            public static void ColorPurple() // 보라색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }

            public static void ColorCyan() // 하늘색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            public static void ColorMagenta() // 하늘색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }

        public static void SelectColor(string str)
        {
            switch (str.ToLower())
            {
                case "red":
                    ColorHelper.ColorRed();
                    break;
                case "yellow":
                    ColorHelper.ColorYellow();
                    break;
                case "green":
                    ColorHelper.ColorGreen();
                    break;
                case "blue":
                    ColorHelper.ColorBlue();
                    break;
                case "white":
                    ColorHelper.ColorWhite();
                    break;
                case "purple":
                    ColorHelper.ColorPurple();
                    break;
                case "cyan":
                    ColorHelper.ColorCyan();
                    break;
                case "magenta":
                    ColorHelper.ColorMagenta();
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }
        public static class TypingHelper
        {
            public static void TypingText(string textColor, string text, int speed = 60) // 밀리초
            {
                SelectColor(textColor);

                foreach (char c in text)
                {
                    Console.Write(c);  // 한 글자씩 출력
                    Thread.Sleep(speed);
                }
                Console.ResetColor();
            }

            public static void TypingVar(string textColor, object input, int speed = 60)
            {
                SelectColor(textColor);
                string text = input.ToString();

                foreach (char c in text)
                {
                    Console.Write(c);  // 한 글자씩 출력
                    Thread.Sleep(speed);
                }
                Console.ResetColor();
            }
        }
        public static class LordingHelper
        {
            public static void Lording(int time)
            {
                if (time <= 0)
                {
                    Console.WriteLine(time + "!");
                }
                else
                {
                    TypingHelper.TypingVar("", time + "...", 50);
                    Thread.Sleep(800);
                    Lording(time - 1);
                }
            }
        }
        public static class ItemHelper
        {
            public static void ItemToInven(GameManager game, Item.ItemType type, int index)
            {
                Item.ItemInfo dummy = new Item.ItemInfo();

                switch (type)
                {
                    case Item.ItemType.Weapon:
                        dummy.Type = type;
                        dummy.Name = Item.WeaponDB.weapon[index].Name;
                        dummy.Cost = Item.WeaponDB.weapon[index].Cost;
                        dummy.Index = index;
                        game.PlayerInventory.Inventory.Add(dummy);
                        break;

                    case Item.ItemType.Armor:
                        dummy.Type = type;
                        dummy.Name = Item.ArmorDB.armor[index].Name;
                        dummy.Cost = Item.ArmorDB.armor[index].Cost;
                        dummy.Index = index;
                        game.PlayerInventory.Inventory.Add(dummy);
                        break;

                    case Item.ItemType.Accessory:
                        dummy.Type = type;
                        dummy.Name = Item.AccessoryDB.accessory[index].Name;
                        dummy.Cost = Item.AccessoryDB.accessory[index].Cost;
                        dummy.Index = index;
                        game.PlayerInventory.Inventory.Add(dummy);
                        break;

                    case Item.ItemType.Potion:
                        dummy.Type = type;
                        dummy.Name = Item.PotionDB.potion[index].Name;
                        dummy.Cost = Item.PotionDB.potion[index].Cost;
                        dummy.Index = index;
                        game.PlayerInventory.Inventory.Add(dummy);
                        break;

                    case Item.ItemType.Scroll:
                        dummy.Type = type;
                        dummy.Name = Item.ScrollDB.scroll[index].Name;
                        dummy.Cost = Item.ScrollDB.scroll[index].Cost;
                        dummy.Index = index;
                        game.PlayerInventory.Inventory.Add(dummy);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}