using System.Text.RegularExpressions;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve10
    {
        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Задание 10: Поиск Временных Значений ===");
            Console.ResetColor();
            Console.Write("Введите текст: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Текст не должен быть пустым.");
                Console.ResetColor();
                return;
            }

            // Регулярное выражение для поиска временных значений
            string pattern = @"\b([01]?\d|2[0-3]):([0-5]\d):([0-5]\d)\b";
            MatchCollection matches = Regex.Matches(input, pattern);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nНайденные временные значения:");
            Console.ResetColor();

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(match.Value);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Временные значения в заданном формате не найдены.");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }
    }
}