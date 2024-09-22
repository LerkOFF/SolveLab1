using System.Text.RegularExpressions;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve5
    {
        public static void Execute()
        {
            Console.Write("Введите текст: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Текст не должен быть пустым.");
                Console.ResetColor();
                return;
            }

            // Регулярное выражение для поиска слов, начинающихся с большой буквы и заканчивающихся двумя цифрами
            string pattern = @"\b[A-Z][a-zA-Z]*\d{2}\b";
            MatchCollection matches = Regex.Matches(input, pattern);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nНайденные слова:");
            Console.ResetColor();

            foreach (Match match in matches)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(match.Value);
                Console.ResetColor();
            }
        }
    }
}