using System.Diagnostics;

namespace SolveLabs.Labs.Lab7
{
    public static class SortingAlgorithms
    {
        public struct SortResult
        {
            public long Comparisons;
            public long Swaps;
            public TimeSpan Duration;
        }

        /// <summary>
        /// Сортировка выбором
        /// </summary>
        public static SortResult SelectionSort(int[] array, bool ascending = true)
        {
            SortResult result = new SortResult();
            Stopwatch sw = Stopwatch.StartNew();

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int targetIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    result.Comparisons++;
                    if (ascending)
                    {
                        if (array[j] < array[targetIndex])
                            targetIndex = j;
                    }
                    else
                    {
                        if (array[j] > array[targetIndex])
                            targetIndex = j;
                    }
                }

                if (targetIndex != i)
                {
                    Swap(ref array[i], ref array[targetIndex]);
                    result.Swaps++;
                }
            }

            sw.Stop();
            result.Duration = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Сортировка вставками
        /// </summary>
        public static SortResult InsertionSort(int[] array, bool ascending = true)
        {
            SortResult result = new SortResult();
            Stopwatch sw = Stopwatch.StartNew();

            int n = array.Length;
            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0)
                {
                    result.Comparisons++;
                    bool condition = ascending ? array[j] > key : array[j] < key;
                    if (condition)
                    {
                        array[j + 1] = array[j];
                        result.Swaps++;
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
                array[j + 1] = key;
            }

            sw.Stop();
            result.Duration = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Пузырьковая сортировка
        /// </summary>
        public static SortResult BubbleSort(int[] array, bool ascending = true)
        {
            SortResult result = new SortResult();
            Stopwatch sw = Stopwatch.StartNew();

            int n = array.Length;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    result.Comparisons++;
                    bool condition = ascending ? array[j] > array[j + 1] : array[j] < array[j + 1];
                    if (condition)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        result.Swaps++;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }

            sw.Stop();
            result.Duration = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Шейкерная сортировка (двунаправленная пузырьковая сортировка)
        /// </summary>
        public static SortResult ShakerSort(int[] array, bool ascending = true)
        {
            SortResult result = new SortResult();
            Stopwatch sw = Stopwatch.StartNew();

            int left = 0;
            int right = array.Length - 1;
            bool swapped = true;

            while (swapped)
            {
                swapped = false;

                for (int i = left; i < right; i++)
                {
                    result.Comparisons++;
                    bool condition = ascending ? array[i] > array[i + 1] : array[i] < array[i + 1];
                    if (condition)
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        result.Swaps++;
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;
                right--;

                for (int i = right; i > left; i--)
                {
                    result.Comparisons++;
                    bool condition = ascending ? array[i] < array[i - 1] : array[i] > array[i - 1];
                    if (condition)
                    {
                        Swap(ref array[i], ref array[i - 1]);
                        result.Swaps++;
                        swapped = true;
                    }
                }

                left++;
            }

            sw.Stop();
            result.Duration = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Сортировка Шелла
        /// </summary>
        public static SortResult ShellSort(int[] array, bool ascending = true)
        {
            SortResult result = new SortResult();
            Stopwatch sw = Stopwatch.StartNew();

            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j = i;

                    while (j >= gap)
                    {
                        result.Comparisons++;
                        bool condition = ascending ? array[j - gap] > temp : array[j - gap] < temp;
                        if (condition)
                        {
                            array[j] = array[j - gap];
                            result.Swaps++;
                            j -= gap;
                        }
                        else
                        {
                            break;
                        }
                    }

                    array[j] = temp;
                }
            }

            sw.Stop();
            result.Duration = sw.Elapsed;
            return result;
        }

        /// <summary>
        /// Обмен двух элементов массива
        /// </summary>
        private static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }
    }

    public static class Solve2
    {
        private const string SortedFilePath = "sorted.dat";
        // Глобальная константа для размера массива
        private const int ArraySize = 100_000;

        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Начало выполнения задания 2 Lab7 ===\n");
            Console.ResetColor();

            // Генерация массивов
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Генерация массивов...");
            Console.ResetColor();

            int[] randomArray = GenerateRandomArray(ArraySize);
            int[] ascendingArray = (int[])randomArray.Clone();
            Array.Sort(ascendingArray);
            int[] descendingArray = ascendingArray.Reverse().ToArray();

            var datasets = new (string Description, int[] Array)[]
            {
                ($"Случайный массив из {ArraySize} элементов", randomArray),
                ($"Массив, отсортированный по возрастанию ({ArraySize} элементов)", ascendingArray),
                ($"Массив, отсортированный по убыванию ({ArraySize} элементов)", descendingArray)
            };

            // Алгоритмы сортировки
            var algorithms = new (string Name, Func<int[], bool, SortingAlgorithms.SortResult> SortFunc)[]
            {
                ("Сортировка выбором", SortingAlgorithms.SelectionSort),
                ("Сортировка вставками", SortingAlgorithms.InsertionSort),
                ("Пузырьковая сортировка", SortingAlgorithms.BubbleSort),
                ("Шейкерная сортировка", SortingAlgorithms.ShakerSort),
                ("Сортировка Шелла", SortingAlgorithms.ShellSort)
            };

            bool ascending = true;

            // Создание файла для записи результатов сортировки и отсортированных массивов
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Начало сортировки и записи результатов...");
            Console.ResetColor();

            using (BinaryWriter bw = new BinaryWriter(File.Open(SortedFilePath, FileMode.Create)))
            {
                foreach (var dataset in datasets)
                {
                    foreach (var algorithm in algorithms)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Сортировка алгоритмом '{algorithm.Name}' для набора данных: {dataset.Description}");
                        Console.ResetColor();

                        int[] arrayToSort = (int[])dataset.Array.Clone();

                        // Сортировка
                        SortingAlgorithms.SortResult result = algorithm.SortFunc(arrayToSort, ascending);

                        // Запись заголовка: алгоритм, описание массива, направление сортировки
                        bw.Write(algorithm.Name);
                        bw.Write(dataset.Description);
                        bw.Write(ascending ? "По возрастанию" : "По убыванию"); // Исправлено направление сортировки

                        // Запись метрик сортировки
                        bw.Write(result.Comparisons);
                        bw.Write(result.Swaps);
                        bw.Write(result.Duration.TotalMilliseconds);

                        // Запись отсортированного массива
                        foreach (var item in arrayToSort)
                            bw.Write(item);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Сортировка '{algorithm.Name}' завершена. Время: {result.Duration.TotalSeconds:F4} секунд ({result.Duration.TotalMilliseconds} мс)");
                        Console.ResetColor();
                        Console.WriteLine(new string('-', 60));
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nРезультаты сортировки и отсортированные массивы записаны в файл '{SortedFilePath}'.");
            Console.ResetColor();

            // Бенчмаркинг и вывод результатов
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nНачало бенчмаркинга и вывода результатов...");
            Console.ResetColor();

            BenchmarkAndReport(algorithms, datasets, SortedFilePath, ascending);

            // Проверка корректности сортировки
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nНачало проверки корректности сортировки...");
            Console.ResetColor();

            VerifySortedFile(SortedFilePath, ascending);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== Завершение выполнения задания 2 Lab7 ===");
            Console.ResetColor();
        }

        /// <summary>
        /// Генерация случайного массива
        /// </summary>
        private static int[] GenerateRandomArray(int size)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for(int i = 0; i < size; i++)
                array[i] = rand.Next(int.MinValue, int.MaxValue);
            return array;
        }

        /// <summary>
        /// Бенчмаркинг алгоритмов и вывод отчёта
        /// </summary>
        private static void BenchmarkAndReport(
            (string Name, Func<int[], bool, SortingAlgorithms.SortResult> SortFunc)[] algorithms,
            (string Description, int[] Array)[] datasets,
            string filePath,
            bool ascending)
        {
            using (BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                foreach (var dataset in datasets)
                {
                    foreach (var algorithm in algorithms)
                    {
                        // Чтение заголовков и метрик
                        string algoName = br.ReadString();
                        string datasetDesc = br.ReadString();
                        string sortDirection = br.ReadString();
                        long comparisons = br.ReadInt64();
                        long swaps = br.ReadInt64();
                        double durationMs = br.ReadDouble();

                        // Считывание отсортированного массива
                        int[] sortedArray = new int[ArraySize];
                        for(int i = 0; i < ArraySize; i++)
                            sortedArray[i] = br.ReadInt32();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Алгоритм: {algoName}, Данные: {datasetDesc}, Направление сортировки: {sortDirection}");
                        Console.ResetColor();
                        Console.WriteLine($"Время: {durationMs / 1000:F4} секунд ({durationMs} мс)");
                        Console.WriteLine($"Сравнения: {comparisons}");
                        Console.WriteLine($"Перестановки: {swaps}");
                        Console.WriteLine(new string('-', 50));
                    }
                }
            }
        }

        /// <summary>
        /// Проверка корректности сортировки в файле
        /// </summary>
        private static void VerifySortedFile(string filePath, bool ascending)
        {
            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл '{filePath}' не найден для проверки.");
                Console.ResetColor();
                return;
            }

            using (BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                bool allSorted = true;
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    string algoName = br.ReadString();
                    string datasetDesc = br.ReadString();
                    string sortDirection = br.ReadString();
                    long comparisons = br.ReadInt64();
                    long swaps = br.ReadInt64();
                    double durationMs = br.ReadDouble();

                    // Определение направления сортировки из файла
                    bool sortAsc = sortDirection == "По возрастанию";

                    // Считывание отсортированного массива
                    int[] sortedArray = new int[ArraySize];
                    for(int i = 0; i < ArraySize; i++)
                        sortedArray[i] = br.ReadInt32();

                    // Проверка сортировки
                    bool isSorted = true;
                    for(int i = 1; i < sortedArray.Length; i++)
                    {
                        if (sortAsc)
                        {
                            if (sortedArray[i-1] > sortedArray[i])
                            {
                                isSorted = false;
                                break;
                            }
                        }
                        else
                        {
                            if (sortedArray[i-1] < sortedArray[i])
                            {
                                isSorted = false;
                                break;
                            }
                        }
                    }

                    if (!isSorted)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Алгоритм: {algoName}, Данные: {datasetDesc}, Направление сортировки: {sortDirection} - ОШИБКА: Массив не отсортирован.");
                        Console.ResetColor();
                        allSorted = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Алгоритм: {algoName}, Данные: {datasetDesc}, Направление сортировки: {sortDirection} - Массив отсортирован корректно.");
                        Console.ResetColor();
                    }
                }

                if (allSorted)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nВсе массивы отсортированы корректно.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНекоторые массивы отсортированы некорректно.");
                    Console.ResetColor();
                }
            }
        }
    }
}
