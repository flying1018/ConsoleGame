namespace RtanRPG.RPG
{
    public static class GameHelper
    {
        public static class ColorHelper
        {
            public static void ColorRed(string text) // 빨간색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(text);
                Console.ResetColor();
            }

            public static void ColorYellow(string text) // 노란색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(text);
                Console.ResetColor();
            }

            public static void ColorGreen(string text) // 초록색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(text);
                Console.ResetColor();
            }

            public static void ColorBlue(string text) // 파란색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(text);
                Console.ResetColor();
            }

            public static void ColorWhite(string text) // 밝은 흰색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(text);
                Console.ResetColor();
            }  

            public static void ColorPurple(string text) // 보라색 타이핑
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(text);
                Console.ResetColor();
            }                      
        }

        public static class TypingHelper
        {
            public static void TypeText(string text, int speed = 30) // 밀리초
            {
                foreach (char c in text)
                {
                    Console.Write(c);  // 한 글자씩 출력
                    Thread.Sleep(speed);
                }
                Console.WriteLine();
            }
        }
    }
}