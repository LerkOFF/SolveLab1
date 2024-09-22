
namespace SolveLabs.Labs.Lab2
{
    public static class Lab2
    {
        public static void Execute()
        {
            while (true)
            {
                Console.WriteLine("\n--- Лабораторная работа 2 ---");
                Console.WriteLine("Выберите задание для демонстрации:");
                Console.WriteLine("1. Задача 1");
                Console.WriteLine("2. Задача 2");
                Console.WriteLine("3. Задача 3");
                Console.WriteLine("4. Задача 4");
                Console.WriteLine("5. Задача 5");
                Console.WriteLine("6. Задача 6");
                Console.WriteLine("7. Задача 7");
                Console.WriteLine("0. Назад в главное меню");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Solve1.Execute();
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