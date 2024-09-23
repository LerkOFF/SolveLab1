using SolveLabs.Labs.Lab5;

namespace SolveLabs.Labs.Lab9
{
    public static class Solve7
    {
        public static void Execute()
        {
            while (true)
            {
                Console.WriteLine("\n--- Задание 7: Сравнение двух списков ---");
                Console.WriteLine("Выберите метод сравнения:");
                Console.WriteLine("1. Самодельный двусвязный список");
                Console.WriteLine("2. .NET List<T>");
                Console.WriteLine("0. Назад в главное меню");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ExecuteCustomListComparison();
                        break;
                    case "2":
                        ExecuteListComparison();
                        break;
                    case "0":
                        Console.WriteLine("Возврат в главное меню.");
                        return;
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

        // Часть для самодельного списка
        private static void ExecuteCustomListComparison()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Сравнение двух двусвязных списков ===\n");
            Console.ResetColor();

            // Создание двух двусвязных списков
            DoublyLinkedList<Country> list1 = new DoublyLinkedList<Country>();
            DoublyLinkedList<Country> list2 = new DoublyLinkedList<Country>();

            // Заполнение списков
            PopulateCustomList(list1, isList1: true);
            PopulateCustomList(list2, isList1: false);

            // Вывод содержимого списков
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список 1:");
            Console.ResetColor();
            PrintCustomList(list1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСписок 2:");
            Console.ResetColor();
            PrintCustomList(list2);

            // Проверка равенства
            bool areEqual = CompareCustomLists(list1, list2);
            Console.WriteLine($"\nСписки {(areEqual ? "равны" : "не равны")}.\n");
        }

        private static void PopulateCustomList(DoublyLinkedList<Country> list, bool isList1)
        {
            list.AddLast(new Country { Name = "FRA", Capital = "Paris", Population = 67000000, GovernmentType = "Ф" });
            list.AddLast(new Country { Name = "ARG", Capital = "Buenos Aires", Population = 45000000, GovernmentType = "УГ" });
            list.AddLast(new Country { Name = "BRA", Capital = "Brasília", Population = 210000000, GovernmentType = "Ф" });
            list.AddLast(new Country { Name = "COL", Capital = "Bogotá", Population = 50000000, GovernmentType = "УГ" });
        }

        private static void PrintCustomList(DoublyLinkedList<Country> list)
        {
            if (list.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Список пуст.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,-5} |", "Государство", "Столица", "Население", "Строй");
            Console.WriteLine(new string('-', 60));
            foreach (var country in list.GetAllElements())
                Console.WriteLine(country.ToString());
            Console.WriteLine(new string('-', 60));
            Console.ResetColor();
        }

        private static bool CompareCustomLists(DoublyLinkedList<Country> list1, DoublyLinkedList<Country> list2)
        {
            // Преобразуем двусвязные списки в обычные списки для удобства обработки
            List<Country> listA = list1.GetAllElements().ToList();
            List<Country> listB = list2.GetAllElements().ToList();

            // Если размеры списков различны, они не равны
            if (listA.Count != listB.Count)
                return false;

            // Создаём словари для подсчёта количества каждого элемента
            Dictionary<Country, int> dictA = new Dictionary<Country, int>();
            Dictionary<Country, int> dictB = new Dictionary<Country, int>();

            foreach (var country in listA)
            {
                if (dictA.ContainsKey(country))
                    dictA[country]++;
                else
                    dictA[country] = 1;
            }

            foreach (var country in listB)
            {
                if (dictB.ContainsKey(country))
                    dictB[country]++;
                else
                    dictB[country] = 1;
            }

            // Сравниваем словари
            if (dictA.Count != dictB.Count)
                return false;

            foreach (var kvp in dictA)
            {
                if (!dictB.TryGetValue(kvp.Key, out int countB))
                    return false;

                if (kvp.Value != countB)
                    return false;
            }

            return true;
        }

        // Часть для .NET List<T>
        private static void ExecuteListComparison()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Сравнение двух списков (.NET List<T>) ===\n");
            Console.ResetColor();

            // Создание двух списков
            List<Country> list1 = new List<Country>();
            List<Country> list2 = new List<Country>();

            // Заполнение списков
            PopulateDotNetList(list1, isList1: true);
            PopulateDotNetList(list2, isList1: false);

            // Вывод содержимого списков
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список 1:");
            Console.ResetColor();
            PrintDotNetList(list1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСписок 2:");
            Console.ResetColor();
            PrintDotNetList(list2);

            // Проверка равенства
            bool areEqual = CompareDotNetLists(list1, list2);
            Console.WriteLine($"\nСписки {(areEqual ? "равны" : "не равны")}.\n");
        }

        private static void PopulateDotNetList(List<Country> list, bool isList1)
        {
            list.Add(new Country { Name = "FRA", Capital = "Paris", Population = 67000000, GovernmentType = "Ф" });
            list.Add(new Country { Name = "ARG", Capital = "Buenos Aires", Population = 45000000, GovernmentType = "УГ" });
            list.Add(new Country { Name = "BRA", Capital = "Brasília", Population = 210000000, GovernmentType = "Ф" });
            list.Add(new Country { Name = "COL", Capital = "Bogotá", Population = 50000000, GovernmentType = "УГ" });

            // Для демонстрации несоответствия списков можно изменить один элемент во втором списке
            if (!isList1)
            {
                // изменю население одной страны
                list[3] = new Country { Name = "COL", Capital = "Bogotá", Population = 60000000, GovernmentType = "УГ" };
                // Или добавить новый элемент
                // list.Add(new Country { Name = "USA", Capital = "Washington D.C.", Population = 328200000, GovernmentType = "Ф" });
            }
        }

        private static void PrintDotNetList(List<Country> list)
        {
            if (list.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Список пуст.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-10} | {3,-5} |", "Государство", "Столица", "Население", "Строй");
            Console.WriteLine(new string('-', 60));
            foreach (var country in list)
                Console.WriteLine(country.ToString());
            Console.WriteLine(new string('-', 60));
            Console.ResetColor();
        }

        private static bool CompareDotNetLists(List<Country> listA, List<Country> listB)
        {
            // Если размеры списков различны, они не равны
            if (listA.Count != listB.Count)
                return false;

            // Создаём словари для подсчёта количества каждого элемента
            Dictionary<Country, int> dictA = new Dictionary<Country, int>();
            Dictionary<Country, int> dictB = new Dictionary<Country, int>();

            foreach (var country in listA)
            {
                if (dictA.ContainsKey(country))
                    dictA[country]++;
                else
                    dictA[country] = 1;
            }

            foreach (var country in listB)
            {
                if (dictB.ContainsKey(country))
                    dictB[country]++;
                else
                    dictB[country] = 1;
            }

            // Сравниваем словари
            if (dictA.Count != dictB.Count)
                return false;

            foreach (var kvp in dictA)
            {
                if (!dictB.TryGetValue(kvp.Key, out int countB))
                    return false;

                if (kvp.Value != countB)
                    return false;
            }

            return true;
        }
    }
}
