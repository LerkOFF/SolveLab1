using SolveLabs.Labs.Lab1;
using SolveLabs.Labs.Lab2;

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
                Console.WriteLine("2. Lab2");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Lab1.Execute();
                        break;
                    case "2":
                        Lab2.Execute();
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