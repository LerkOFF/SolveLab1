namespace SolveLabs.Labs.Lab9
{
    public static class Solve5
    {
        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Задание 5: Обработка файлов и статистика слов ===\n");
            Console.ResetColor();

            Console.Write("Введите путь к файлу: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Файл не найден. Проверьте путь и попробуйте снова.");
                Console.ResetColor();
                return;
            }

            string content = File.ReadAllText(filePath);
            var words = ExtractWords(content);

            var filteredWords = words.Where(w => w.Length >= 3).ToList();

            // Вывод слов длиной 3 и более символов
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nСлова длиной 3 и более символов:");
            Console.ResetColor();
            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }

            // Сумма длин таких слов
            int totalLength = filteredWords.Sum(w => w.Length);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nСумма длин слов: {totalLength}");
            Console.ResetColor();

            // Подсчет частоты встречаемости
            var frequencyDict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var word in filteredWords)
            {
                string lowerWord = word.ToLower();
                if (frequencyDict.ContainsKey(lowerWord))
                    frequencyDict[lowerWord]++;
                else
                    frequencyDict[lowerWord] = 1;
            }

            // Сортировка: по убыванию частоты, затем по алфавиту
            var sortedWords = frequencyDict
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key)
                .ToList();

            // Вывод отсортированных слов
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nОтсортированные слова по убыванию частоты:");
            Console.ResetColor();
            foreach (var kv in sortedWords)
            {
                Console.WriteLine($"{kv.Key} - {kv.Value}");
            }
        }

        /// <summary>
        /// Извлекает слова из текста, игнорируя знаки препинания
        /// </summary>
        private static List<string> ExtractWords(string text)
        {
            List<string> words = new List<string>();
            char[] separators = new char[] { ' ', '\n', '\r', '\t', ',', '.', ';', ':', '!', '?', '-', '(', ')', '[', ']', '{', '}', '"', '\'' };
            var splitWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in splitWords)
            {
                string cleanedWord = word.Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(cleanedWord))
                    words.Add(cleanedWord);
            }
            return words;
        }
    }
}
