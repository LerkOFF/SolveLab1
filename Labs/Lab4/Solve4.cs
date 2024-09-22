namespace SolveLabs.Labs.Lab4
{
    public static class Solve4
    {
        public static void Execute()
        {
            string[] lines = new string[7];
            Console.WriteLine("Введите 7 строк:");

            for (int i = 0; i < 7; i++)
            {
                Console.Write($"Строка {i + 1}: ");
                lines[i] = Console.ReadLine();
            }

            // Фильтрация строк, содержащих слова, оканчивающиеся на ".com" (без учета регистра)
            var comLines = lines.Select((line, index) => new { Line = line, Number = index + 1 })
                .Where(x => x.Line.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                    .Any(word => word.EndsWith(".com", StringComparison.OrdinalIgnoreCase)))
                .ToList();

            // Нахождение строки с наименьшим количеством пробелов
            var minSpaceLine = lines.Select((line, index) => new { Line = line, Number = index + 1, SpaceCount = line.Count(c => c == ' ') })
                .OrderBy(x => x.SpaceCount)
                .First();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nСтроки, содержащие слова, оканчивающиеся на '.com':");
            Console.ResetColor();

            foreach (var item in comLines)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Строка {item.Number}: {item.Line}");
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nСтрока с наименьшим количеством пробелов: Строка {minSpaceLine.Number} (Пробелов: {minSpaceLine.SpaceCount})");
            Console.ResetColor();
        }
    }
}