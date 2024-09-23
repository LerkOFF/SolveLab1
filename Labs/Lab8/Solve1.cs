using System.Diagnostics;

namespace SolveLabs.Labs.Lab8
{
    public static class Solve1
    {
        private const string SortedFilePath = "sorted.dat";
        private static List<int> sortedData = new List<int>();

        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Задание 1: Алгоритмы поиска ===\n");
            Console.ResetColor();

            LoadData();

            while (true)
            {
                Console.WriteLine("\n--- Меню Задания 1 ---");
                Console.WriteLine("1. Линейный поиск");
                Console.WriteLine("2. Бинарный поиск");
                Console.WriteLine("3. Интерполяционный поиск");
                Console.WriteLine("0. Назад в Lab8");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0")
                {
                    Console.WriteLine("Возврат в Lab8.");
                    break;
                }

                Console.Write("Введите элемент для поиска: ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                    Console.ResetColor();
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        LinearSearch(target);
                        break;
                    case "2":
                        BinarySearch(target);
                        break;
                    case "3":
                        InterpolationSearch(target);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        Console.ResetColor();
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// Загружает отсортированные данные из файла sorted.dat
        /// Предполагается, что данные хранятся в бинарном формате как последовательность целых чисел
        /// </summary>
        private static void LoadData()
        {
            sortedData.Clear();

            if (!File.Exists(SortedFilePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл '{SortedFilePath}' не найден. Убедитесь, что Lab7 выполнена корректно.");
                Console.ResetColor();
                return;
            }

            using (BinaryReader br = new BinaryReader(File.Open(SortedFilePath, FileMode.Open)))
            {
                // Предполагаем, что файл содержит только отсортированные массивы целых чисел
                try
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        int number = br.ReadInt32();
                        sortedData.Add(number);
                    }
                }
                catch (EndOfStreamException)
                {
                    // Конец файла
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Загружено {sortedData.Count} элементов из '{SortedFilePath}'.");
            Console.ResetColor();
        }

        /// <summary>
        /// Линейный поиск
        /// </summary>
        private static void LinearSearch(int target)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Линейный поиск ===");
            Console.ResetColor();

            int position = -1;
            long comparisons = 0;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < sortedData.Count; i++)
            {
                comparisons++;
                if (sortedData[i] == target)
                {
                    position = i;
                    break;
                }
            }

            sw.Stop();

            if (position != -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Элемент найден на позиции: {position}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Элемент не найден.");
            }
            Console.ResetColor();

            Console.WriteLine($"Время выполнения: {sw.Elapsed.Seconds} секунд {sw.Elapsed.Milliseconds} миллисекунд");
            Console.WriteLine($"Количество сравнений: {comparisons}");
        }

        /// <summary>
        /// Бинарный поиск
        /// </summary>
        private static void BinarySearch(int target)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Бинарный поиск ===");
            Console.ResetColor();

            int left = 0;
            int right = sortedData.Count - 1;
            int position = -1;
            long comparisons = 0;
            Stopwatch sw = Stopwatch.StartNew();

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                comparisons++;
                if (sortedData[mid] == target)
                {
                    position = mid;
                    break;
                }
                else if (sortedData[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            sw.Stop();

            if (position != -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Элемент найден на позиции: {position}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Элемент не найден.");
            }
            Console.ResetColor();

            Console.WriteLine($"Время выполнения: {sw.Elapsed.Seconds} секунд {sw.Elapsed.Milliseconds} миллисекунд");
            Console.WriteLine($"Количество сравнений: {comparisons}");
        }

        /// <summary>
        /// Интерполяционный поиск
        /// </summary>
        private static void InterpolationSearch(int target)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== Интерполяционный поиск ===");
            Console.ResetColor();

            int low = 0;
            int high = sortedData.Count - 1;
            int position = -1;
            long comparisons = 0;
            Stopwatch sw = Stopwatch.StartNew();

            while (low <= high && target >= sortedData[low] && target <= sortedData[high])
            {
                comparisons++;
                if (low == high)
                {
                    if (sortedData[low] == target)
                    {
                        position = low;
                    }
                    break;
                }

                // Формула интерполяции
                int pos = low + (int)(((long)(high - low) / (sortedData[high] - sortedData[low])) * (target - sortedData[low]));

                // Проверка границ
                if (pos < 0 || pos >= sortedData.Count)
                {
                    break;
                }

                comparisons++;
                if (sortedData[pos] == target)
                {
                    position = pos;
                    break;
                }

                if (sortedData[pos] < target)
                {
                    low = pos + 1;
                }
                else
                {
                    high = pos - 1;
                }
            }

            sw.Stop();

            if (position != -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Элемент найден на позиции: {position}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Элемент не найден.");
            }
            Console.ResetColor();

            Console.WriteLine($"Время выполнения: {sw.Elapsed.Seconds} секунд {sw.Elapsed.Milliseconds} миллисекунд");
            Console.WriteLine($"Количество сравнений: {comparisons}");
        }
    }
}
