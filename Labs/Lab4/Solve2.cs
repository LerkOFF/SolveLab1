using System.Text;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve2
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

            char[] separators = { ' ', '-', '.' };
            string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();

            int wordNumber = 1;
            int currentIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                // Определение начала слова
                if (currentIndex < words.Length && input.IndexOf(words[currentIndex], i) == i)
                {
                    string word = words[currentIndex];
                    result.Append($"{word}({wordNumber})");
                    wordNumber++;
                    i += word.Length - 1;
                    currentIndex++;
                }
                else
                {
                    result.Append(input[i]);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nРезультат (Обработка как массива символов):");
            Console.ResetColor();
            Console.WriteLine(result.ToString());
        }
    }
}