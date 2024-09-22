using System.Text;

namespace SolveLabs.Labs.Lab4
{
    public static class Solve3
    {
        public static void Execute()
        {
            Console.Write("Введите текст из нескольких слов, завершающийся точкой: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input[input.Length - 1] != '.')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Текст должен завершаться точкой.");
                Console.ResetColor();
                return;
            }

            // Удаление точки и разделение на слова
            string trimmedInput = input.TrimEnd('.');
            string[] words = trimmedInput.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            // Перестановка слов в обратном порядке
            Array.Reverse(words);

            // Сборка новой строки с использованием StringBuilder
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                result.Append(words[i]);
                if (i < words.Length - 1)
                {
                    // Восстановление разделителей (пробелы и тире)
                    int originalIndex = trimmedInput.IndexOf(words[i]) + words[i].Length;
                    if (originalIndex < trimmedInput.Length && (trimmedInput[originalIndex] == ' ' || trimmedInput[originalIndex] == '-'))
                    {
                        result.Append(trimmedInput[originalIndex]);
                    }
                    else
                    {
                        result.Append(' ');
                    }
                }
            }
            result.Append('.');

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nРезультат (Использование методов класса string и StringBuilder):");
            Console.ResetColor();
            Console.WriteLine(result.ToString());
        }
    }
}
