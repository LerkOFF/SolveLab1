namespace SolveLabs.Labs.Lab9
{
    public static class Lab9
    {
        public static void Execute()
        {
            while (true)
            {
                Console.WriteLine("\n--- Лабораторная работа 9 ---");
                Console.WriteLine("Выберите подзадачу:");
                Console.WriteLine("1.1 Модификация Lab5 с использованием двусвязного списка");
                Console.WriteLine("1.2 Модификация Lab5 с использованием .NET List");
                Console.WriteLine("2. Задание 2");
                Console.WriteLine("3. Задание 3");
                Console.WriteLine("4. Задание 4");
                Console.WriteLine("5. Задание 5");
                Console.WriteLine("6. Задание 6");
                Console.WriteLine("7. Задание 7");
                Console.WriteLine("8. Задание 8");
                Console.WriteLine("0. Назад в главное меню");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1.1":
                        Solve1_CustomList.Execute();
                        break;
                    case "1.2":
                        Solve1_DotNetList.Execute();
                        break;
                    case "2":
                        Solve2.Execute();
                        break;
                    case "3":
                        Solve3.Execute();
                        break;
                    case "4":
                        Solve4.Execute();
                        break;
                    case "5":
                        Solve5.Execute();
                        break;
                    case "6":
                        Solve6.Execute();
                        break;
                    case "7":
                        Solve7.Execute();
                        break;
                    case "8":
                        Solve8.Execute();
                        break;
                    case "0":
                        Console.WriteLine("Возврат в главное меню.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }
    }
}