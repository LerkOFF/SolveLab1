using System;
using System.Linq;

namespace SolveLab1
{
    public static class Solve6
    {
        public static void Execute()
        {
            Console.Write("Введите четырехзначное число: ");
            string input = Console.ReadLine();

            if (input.Length != 4 || !input.All(char.IsDigit))
            {
                Console.WriteLine("Введено некорректное четырехзначное число.");
                return;
            }

            int number = int.Parse(input);
            int product = 1;
            foreach (char c in input)
            {
                product *= (c - '0');
            }

            Console.WriteLine($"Произведение цифр числа {number} равно {product}.");
        }
    }
}
