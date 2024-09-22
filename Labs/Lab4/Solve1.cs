namespace SolveLabs.Labs.Lab4
{
    public static class Solve1
    {
        public static void Execute()
        {
            Console.Write("Введите предложение, завершающееся точкой: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input[input.Length - 1] != '.')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Предложение должно завершаться точкой.");
                Console.ResetColor();
                return;
            }

            char[] characters = input.ToCharArray();
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            // Подсчёт количества вхождений каждого символа
            foreach (char c in characters)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount[c] = 1;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nСимволы, встречающиеся ровно один раз (Обработка как массива символов):");
            Console.ResetColor();

            foreach (var pair in charCount)
            {
                if (pair.Value == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{pair.Key} ");
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
    }
}