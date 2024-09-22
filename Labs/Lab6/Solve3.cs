using System.Text.RegularExpressions;

namespace SolveLabs.Labs.Lab6
{
    public static class Solve3
    {
        private const string InputFile = "input_text.txt";
        private const string OutputFile = "filtered_text.txt";

        public static void Execute()
        {
            if (!File.Exists(InputFile))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл '{InputFile}' не найден.");
                Console.ResetColor();
                return;
            }

            int totalLines = 0;
            int keptLines = 0;

            using (StreamReader reader = new StreamReader(InputFile))
            using (StreamWriter writer = new StreamWriter(OutputFile))
            {
                string line;
                Regex regex = new Regex(@"\d");

                while ((line = reader.ReadLine()) != null)
                {
                    totalLines++;
                    if (regex.IsMatch(line))
                    {
                        writer.WriteLine(line);
                        keptLines++;
                    }
                }
            }

            int deletedLines = totalLines - keptLines;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Фильтрация завершена. Удалено строк: {deletedLines}");
            Console.WriteLine($"Отфильтрованные строки сохранены в файл '{OutputFile}'.");
            Console.ResetColor();
        }
    }
}