namespace SolveLabs.Labs.Lab5
{
    public static class Lab5
    {
        public static void Execute()
        {
            while (true)
            {
                Console.WriteLine("\n--- Лабораторная работа 5 ---");
                Console.WriteLine("Выберите задание для демонстрации:");
                Console.WriteLine("1. Задача 1");
                Console.WriteLine("0. Назад в главное меню");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Solve1.Execute();
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