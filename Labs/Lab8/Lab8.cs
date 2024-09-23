namespace SolveLabs.Labs.Lab8
{
    public static class Lab8
    {
        public static void Execute()
        {
            while (true)
            {
                Console.WriteLine("\n--- Лабораторная работа 8 ---");
                Console.WriteLine("Выберите задание для демонстрации:");
                Console.WriteLine("1. Алгоритмы поиска (линейный, бинарный, интерполяционный)");
                Console.WriteLine("2. Алгоритмы поиска подстроки (КМП, Бойера-Мура, простой поиск)");
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