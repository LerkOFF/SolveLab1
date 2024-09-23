using SolveLabs.Labs.Lab5;

namespace SolveLabs.Labs.Lab9
{
    public static class Solve1_CustomList
    {
        private static DoublyLinkedList<Country> countries = new DoublyLinkedList<Country>();
        private static Queue<string> log = new Queue<string>();
        private const int MaxLogSize = 50;
        private static TimeSpan maxInactivity = TimeSpan.Zero;
        private static DateTime lastActionTime = DateTime.Now;

        private static readonly string[] validGovernmentTypes = { "Ф", "УГ" };

        // Пути к файлам
        private const string LogFilePath = "LogFile_For_Lab9_Solve1_CustomList.txt";
        private const string TableFilePath = "Table_for_Lab9_Solve1_CustomList.txt";

        public static void Execute()
        {
            LoadTableFromFile(); // Загрузка таблицы из файла
            LoadLogFromFile();    // Загрузка существующего лога из файла

            while (true)
            {
                UpdateInactivity();
                DisplayMenu();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Выберите действие (1-7): ");
                Console.ResetColor();
                string choice = Console.ReadLine();
                lastActionTime = DateTime.Now;

                switch (choice)
                {
                    case "1":
                        ViewTable();
                        break;
                    case "2":
                        AddEntry();
                        break;
                    case "3":
                        DeleteEntry();
                        break;
                    case "4":
                        UpdateEntry();
                        break;
                    case "5":
                        SearchEntries();
                        break;
                    case "6":
                        ViewLog();
                        break;
                    case "7":
                        DisplayMaxInactivity();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите пункт от 1 до 7.");
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
        /// Загружает таблицу стран из файла при запуске программы
        /// </summary>
        private static void LoadTableFromFile()
        {
            if (File.Exists(TableFilePath))
            {
                var lines = File.ReadAllLines(TableFilePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        countries.AddLast(Country.FromFileString(line));
                }
            }
        }

        /// <summary>
        /// Сохраняет текущую таблицу в файл
        /// </summary>
        private static void SaveTableToFile()
        {
            List<string> lines = new List<string>();
            foreach (var country in countries.GetAllElements())
            {
                lines.Add(country.ToFileString());
            }
            File.WriteAllLines(TableFilePath, lines);
        }

        /// <summary>
        /// Загружает последние 50 записей лога из файла при запуске программы
        /// </summary>
        private static void LoadLogFromFile()
        {
            if (File.Exists(LogFilePath))
            {
                var lines = File.ReadAllLines(LogFilePath);
                var lastLines = lines.Skip(Math.Max(0, lines.Length - MaxLogSize));
                foreach (var line in lastLines)
                    log.Enqueue(line);
            }
        }

        /// <summary>
        /// Сохраняет текущий лог в файл, перезаписывая его
        /// </summary>
        private static void SaveLogToFile()
        {
            File.WriteAllLines(LogFilePath, log);
        }

        private static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Меню ===");
            Console.ResetColor();
            Console.WriteLine("1 – Просмотр таблицы");
            Console.WriteLine("2 – Добавить запись");
            Console.WriteLine("3 – Удалить запись");
            Console.WriteLine("4 – Обновить запись");
            Console.WriteLine("5 – Поиск записей");
            Console.WriteLine("6 – Просмотреть лог");
            Console.WriteLine("7 – Выход");
            Console.WriteLine();
        }

        private static void ViewTable()
        {
            if (countries.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Таблица пуста.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nГеография");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,-5} |", "Государство", "Столица", "Население", "Строй");
            Console.WriteLine(new string('-', 60));
            int index = 1;
            foreach (var country in countries.GetAllElements())
            {
                Console.WriteLine($"| {country.Name,-15} | {country.Capital,-15} | {country.Population,-10} | {country.GovernmentType,-5} |");
                index++;
            }
            Console.WriteLine(new string('-', 60));
        }

        private static void AddEntry()
        {
            Country newCountry = new Country();

            Console.Write("Название страны: ");
            newCountry.Name = ReadNonEmptyInput();

            Console.Write("Столица: ");
            newCountry.Capital = ReadNonEmptyInput();

            newCountry.Population = ReadPositiveLong("Население (целое положительное число): ");

            Console.Write("Тип строя (Ф - федерация, УГ - унитарное государство): ");
            newCountry.GovernmentType = ReadValidGovernmentType();

            countries.AddLast(newCountry);
            AddLog("ADD", newCountry);

            SaveTableToFile();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Запись успешно добавлена.");
            Console.ResetColor();
        }

        private static void DeleteEntry()
        {
            if (countries.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Таблица пуста. Нет записей для удаления.");
                Console.ResetColor();
                return;
            }

            ViewTable();
            Console.Write("Введите номер записи для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= countries.Count)
            {
                Country removed = countries.GetAt(index - 1);
                bool success = countries.RemoveAt(index - 1);
                if (success)
                {
                    AddLog("DELETE", removed);
                    SaveTableToFile();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Запись '{removed.Name}' успешно удалена.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Не удалось удалить запись.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный номер записи.");
                Console.ResetColor();
            }
        }

        private static void UpdateEntry()
        {
            if (countries.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Таблица пуста. Нет записей для обновления.");
                Console.ResetColor();
                return;
            }

            ViewTable();
            Console.Write("Введите номер записи для обновления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= countries.Count)
            {
                Country updated = countries.GetAt(index - 1);

                Console.Write($"Название страны ({updated.Name}): ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    updated.Name = input;

                Console.Write($"Столица ({updated.Capital}): ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    updated.Capital = input;

                Console.Write($"Население ({updated.Population}): ");
                input = Console.ReadLine();
                if (long.TryParse(input, out long population) && population > 0)
                    updated.Population = population;

                Console.Write($"Тип строя ({updated.GovernmentType}): ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && validGovernmentTypes.Contains(input.ToUpper()))
                    updated.GovernmentType = input.ToUpper();

                bool success = countries.UpdateAt(index - 1, updated);
                if (success)
                {
                    AddLog("UPDATE", updated);
                    SaveTableToFile();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Запись успешно обновлена.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Не удалось обновить запись.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный номер записи.");
                Console.ResetColor();
            }
        }

        private static void SearchEntries()
        {
            Console.Write("Введите тип строя для поиска (Ф/УГ) или оставьте пустым для пропуска: ");
            string governmentType = Console.ReadLine().ToUpper();

            var results = new List<Country>();
            foreach (var country in countries.GetAllElements())
            {
                if (governmentType == "Ф" || governmentType == "УГ")
                {
                    if (country.GovernmentType == governmentType)
                        results.Add(country);
                }
                else
                {
                    results.Add(country);
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nРезультаты поиска:");
            Console.ResetColor();

            if (results.Any())
            {
                Console.WriteLine(new string('-', 60));
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,-5} |", "Государство", "Столица", "Население", "Строй");
                Console.WriteLine(new string('-', 60));
                foreach (var country in results)
                    Console.WriteLine(country.ToString());
                Console.WriteLine(new string('-', 60));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Нет записей, соответствующих критериям поиска.");
                Console.ResetColor();
            }
        }

        private static void ViewLog()
        {
            if (!log.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Лог пуст.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n=== Лог Действий ===");
            Console.ResetColor();

            foreach (var entry in log)
                Console.WriteLine(entry);

            Console.WriteLine(new string('-', 40));
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Самый долгий период бездействия пользователя: {maxInactivity}");
            Console.ResetColor();
        }

        /// <summary>
        /// Добавляет запись в лог и сохраняет его в файл
        /// </summary>
        /// <param name="actionType">Тип действия (ADD, DELETE, UPDATE)</param>
        /// <param name="country">Данные страны, с которой произошло действие</param>
        private static void AddLog(string actionType, Country country)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string logEntry = $"{timestamp} – {actionType} – \"{country.Name}\"";

            if (log.Count >= MaxLogSize)
                log.Dequeue();

            log.Enqueue(logEntry);
            SaveLogToFile(); // Сохранение лога в файл после каждого изменения
        }

        private static string ReadNonEmptyInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ввод не может быть пустым. Попробуйте снова: ");
                Console.ResetColor();
            }
        }

        private static long ReadPositiveLong(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (long.TryParse(Console.ReadLine(), out long value) && value > 0)
                    return value;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите корректное положительное целое число.");
                Console.ResetColor();
            }
        }

        private static string ReadValidGovernmentType()
        {
            while (true)
            {
                string input = Console.ReadLine().ToUpper();
                if (validGovernmentTypes.Contains(input))
                    return input;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Неверный тип строя. Введите 'Ф' или 'УГ': ");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Обновляет максимальное время бездействия пользователя
        /// </summary>
        private static void UpdateInactivity()
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan inactivity = currentTime - lastActionTime;
            if (inactivity > maxInactivity)
                maxInactivity = inactivity;
        }

        /// <summary>
        /// Отображает самый длительный период бездействия пользователя
        /// </summary>
        private static void DisplayMaxInactivity()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nСамый долгий период бездействия пользователя: {maxInactivity}");
            Console.ResetColor();
        }
    }
}
