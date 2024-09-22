using SolveLabs.Labs.Lab1;

namespace SolveLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- SolveLabs ---");
                Console.WriteLine("Выберите лабораторную работу для демонстрации:");
                Console.WriteLine("1. Lab1");
                // Добавьте новые лабораторные работы здесь, например:
                // Console.WriteLine("2. Lab2");
                // Console.WriteLine("3. Lab3");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Lab1.Execute();
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