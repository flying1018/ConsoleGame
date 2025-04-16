namespace RtanRPG.RPG
{
    public static class GameHelper
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
                default:
                    Console.ResetColor();
                    break;
            }
        }

        public static class TypingHelper
        {
            public static void TypingText(string textColor, string text, int speed = 45) // 밀리초
            {
                SelectColor(textColor);

                foreach (char c in text)
                {
                    Console.Write(c);  // 한 글자씩 출력
                    Thread.Sleep(speed);
                }
                Console.ResetColor();
            }

            public static void TypingVar(string textColor, object input, int speed = 45)
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
    }
}