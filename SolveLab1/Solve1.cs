using System;

namespace SolveLab1
{
    public static class Solve1
    {
        public static void Execute()
        {
            Console.Write("Введите положительное вещественное число x: ");
            if (!double.TryParse(Console.ReadLine(), out double x) || x < 0)
            {
                Console.WriteLine("Число должно быть положительным.");
                return;
            }

            double fractionalPart = x - Math.Truncate(x);
            fractionalPart *= 10;
            int d = (int)Math.Truncate(fractionalPart);

            Console.WriteLine($"Первая цифра дробной части числа {x} равна {d}.");
        }
    }
}