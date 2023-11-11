namespace AW_Inheritance_Business
{
    public static class Print
    {
        public static void TextToConsole(string text, bool newLine = true, ConsoleColor foregroundColour = ConsoleColor.Black, ConsoleColor backgroundColour = ConsoleColor.Gray)
        {
            Console.BackgroundColor = backgroundColour;
            Console.ForegroundColor = foregroundColour;

            if (newLine == true)
            {
                Console.WriteLine("\t" + text);
            }
            else
            {
                Console.Write("\t" + text);
            }

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}