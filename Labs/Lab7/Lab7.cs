namespace SolveLabs.Labs.Lab7
{
    public static class Lab7
    {
        public static void Execute()
        {
            while (true)
            {
                Console.WriteLine("\n--- Лабораторная работа 7 ---");
                Console.WriteLine("Выберите задание для демонстрации:");
                Console.WriteLine("1. Задача 1");
                Console.WriteLine("2. Задача 2");
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