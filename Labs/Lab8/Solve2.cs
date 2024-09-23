using System.Diagnostics;

namespace SolveLabs.Labs.Lab8
{
    public static class Solve2
    {
        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Задание 2: Алгоритмы поиска подстроки ===\n");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("\n--- Меню Задания 2 ---");
                Console.WriteLine("1. Запустить тесты");
                Console.WriteLine("0. Назад в Lab8");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0")
                {
                    Console.WriteLine("Возврат в Lab8.");
                    break;
                }
                else if (choice == "1")
                {
                    RunTests();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Запуск тестов для различных алгоритмов поиска подстроки
        /// </summary>
        private static void RunTests()
        {
            // Определение тестовых строк
            string[] texts = new string[]
            {
                "Это простая тестовая строка для поиска подстроки.",
                "Анаконда ананас активен анкер агент.",
                "Повторяющиеся повторяющиеся повторяющиеся части строки.",
                "Строка с уникальными символами.",
                "Еще одна строка с некоторыми повторениями повторениями."
            };

            string[] patterns = new string[]
            {
                "тест",
                "ан",
                "повторяющиеся",
                "уникальными",
                "нет такого"
            };

            foreach (var text in texts)
            {
                foreach (var pattern in patterns)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Текст: \"{text}\"");
                    Console.WriteLine($"Поиск подстроки: \"{pattern}\"");
                    Console.ResetColor();

                    if (string.IsNullOrEmpty(pattern))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Пустая подстрока. Пропуск теста.");
                        Console.ResetColor();
                        continue;
                    }

                    // Алгоритмы поиска
                    var algorithms = new (string Name, Func<string, string, (int Position, long Comparisons, TimeSpan Duration)> SearchFunc)[]
                    {
                        ("Простой поиск", SimpleSearch),
                        ("КМП", KMPSearch),
                        ("Бойера-Мура", BMSearch)
                    };

                    foreach (var algo in algorithms)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n--- Алгоритм: {algo.Name} ---");
                        Console.ResetColor();

                        var result = algo.SearchFunc(text, pattern);

                        if (result.Position != -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Подстрока найдена на позиции: {result.Position}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Подстрока не найдена.");
                        }
                        Console.ResetColor();

                        Console.WriteLine($"Время выполнения: {result.Duration.Seconds} секунд {result.Duration.Milliseconds} миллисекунд");
                        Console.WriteLine($"Количество сравнений: {result.Comparisons}");
                    }

                    Console.WriteLine(new string('-', 60));
                }
            }
        }

        /// <summary>
        /// Простой алгоритм поиска подстроки (наивный)
        /// </summary>
        private static (int Position, long Comparisons, TimeSpan Duration) SimpleSearch(string text, string pattern)
        {
            long comparisons = 0;
            int position = -1;
            Stopwatch sw = Stopwatch.StartNew();

            int n = text.Length;
            int m = pattern.Length;

            for (int i = 0; i <= n - m; i++)
            {
                int j = 0;
                while (j < m)
                {
                    comparisons++;
                    if (text[i + j] != pattern[j])
                        break;
                    j++;
                }
                if (j == m)
                {
                    position = i;
                    break;
                }
            }

            sw.Stop();
            return (position, comparisons, sw.Elapsed);
        }

        /// <summary>
        /// Алгоритм Кнута-Морриса-Пратта (КМП)
        /// </summary>
        private static (int Position, long Comparisons, TimeSpan Duration) KMPSearch(string text, string pattern)
        {
            long comparisons = 0;
            int position = -1;
            Stopwatch sw = Stopwatch.StartNew();

            int[] lps = ComputeLPSArray(pattern);
            int i = 0; // Индекс для text
            int j = 0; // Индекс для pattern

            while (i < text.Length)
            {
                comparisons++;
                if (pattern[j] == text[i])
                {
                    i++;
                    j++;
                }

                if (j == pattern.Length)
                {
                    position = i - j;
                    j = lps[j - 1];
                    break;
                }
                else if (i < text.Length && pattern[j] != text[i])
                {
                    comparisons++;
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }

            sw.Stop();
            return (position, comparisons, sw.Elapsed);
        }

        /// <summary>
        /// Вычисляет массив LPS (Longest Prefix Suffix) для КМП
        /// </summary>
        private static int[] ComputeLPSArray(string pattern)
        {
            int length = 0;
            int i = 1;
            int[] lps = new int[pattern.Length];
            lps[0] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }

        /// <summary>
        /// Алгоритм Бойера-Мура (BM)
        /// </summary>
        private static (int Position, long Comparisons, TimeSpan Duration) BMSearch(string text, string pattern)
        {
            long comparisons = 0;
            int position = -1;
            Stopwatch sw = Stopwatch.StartNew();

            int n = text.Length;
            int m = pattern.Length;

            if (m == 0)
            {
                sw.Stop();
                return (-1, comparisons, sw.Elapsed);
            }

            // Создание таблицы плохих символов
            Dictionary<char, int> badChar = new Dictionary<char, int>();
            for (int i = 0; i < m; i++)
            {
                badChar[pattern[i]] = i;
            }

            int shift = 0;
            while (shift <= n - m)
            {
                int j = m - 1;

                while (j >= 0)
                {
                    comparisons++;
                    if (pattern[j] != text[shift + j])
                        break;
                    j--;
                }

                if (j < 0)
                {
                    position = shift;
                    break;
                }
                else
                {
                    if (badChar.ContainsKey(text[shift + j]))
                    {
                        shift += Math.Max(1, j - badChar[text[shift + j]]);
                    }
                    else
                    {
                        shift += j + 1;
                    }
                }
            }

            sw.Stop();
            return (position, comparisons, sw.Elapsed);
        }
    }
}
