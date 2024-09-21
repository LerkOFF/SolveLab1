namespace SolveLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Лабораторная работа 1 ---");
                Console.WriteLine("Выберите задание для демонстрации:");
                Console.WriteLine("1. Solve1");
                Console.WriteLine("2. Solve2");
                Console.WriteLine("3. Solve3");
                Console.WriteLine("4. Solve4");
                Console.WriteLine("5. Solve5");
                Console.WriteLine("6. Solve6");
                Console.WriteLine("7. Solve7");
                Console.WriteLine("8. Solve8");
                Console.WriteLine("9. Solve9");
                Console.WriteLine("10. Solve10");
                Console.WriteLine("11. Solve11");
                Console.WriteLine("0. Выход");
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
                    case "8":
                        Solve8.Execute();
                        break;
                    case "9":
                        Solve9.Execute();
                        break;
                    case "10":
                        Solve10.Execute();
                        break;
                    case "11":
                        Solve11.Execute();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }
    }
}
