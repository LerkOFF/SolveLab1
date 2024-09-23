using SolveLabs.Labs.Lab1;
using SolveLabs.Labs.Lab2;
using SolveLabs.Labs.Lab3;
using SolveLabs.Labs.Lab4;
using SolveLabs.Labs.Lab5;
using SolveLabs.Labs.Lab6;
using SolveLabs.Labs.Lab7;

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
                Console.WriteLine("1. Лабораторная работа 1");
                Console.WriteLine("2. Лабораторная работа 2");
                Console.WriteLine("3. Лабораторная работа 3");
                Console.WriteLine("4. Лабораторная работа 4");
                Console.WriteLine("5. Лабораторная работа 5");
                Console.WriteLine("6. Лабораторная работа 6");
                Console.WriteLine("7. Лабораторная работа 7");
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
                    case "3":
                        Lab3.Execute();
                        break;
                    case "4":
                        Lab4.Execute();
                        break;
                    case "5":
                        Lab5.Execute();
                        break;
                    case "6":
                        Lab6.Execute();
                        break;
                    case "7":
                        Lab7.Execute();
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