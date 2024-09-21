using System;

namespace SolveLab1
{
    public static class Solve11
    {
        public static void Execute()
        {
            Console.Write("Введите значение a: ");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("Некорректный ввод для a.");
                return;
            }

            Console.Write("Введите значение b: ");
            if (!double.TryParse(Console.ReadLine(), out double b))
            {
                Console.WriteLine("Некорректный ввод для b.");
                return;
            }

            Console.Write("Введите значение x: ");
            if (!double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine("Некорректный ввод для x.");
                return;
            }

            Console.Write("Введите значение c: ");
            if (!double.TryParse(Console.ReadLine(), out double c))
            {
                Console.WriteLine("Некорректный ввод для c.");
                return;
            }

            // Проверки на допустимые значения для первой формулы
            if (a + Math.Pow(x, 2) <= 0)
            {
                Console.WriteLine("Ошибка: a + x^2 должно быть больше 0 для логарифма.");
                return;
            }

            if (b == 0)
            {
                Console.WriteLine("Ошибка: b не должно быть равно 0 для деления.");
                return;
            }

            // Вычисление первой формулы f
            double f = Math.Log(a + Math.Pow(x, 2)) + Math.Pow(Math.Sin(x / b), 2);
            Console.WriteLine($"Значение f: {f}");

            // Проверки на допустимые значения для второй формулы
            if (x + a < 0)
            {
                Console.WriteLine("Ошибка: x + a должно быть больше или равно 0 для корня.");
                return;
            }

            if (x - b == 0)
            {
                Console.WriteLine("Ошибка: x не должно быть равно b для избежания деления на 0.");
                return;
            }

            // Вычисление второй формулы z
            double numerator = x + Math.Sqrt(x + a);
            double denominator = x - Math.Sqrt(Math.Abs(x - b));
            if (denominator == 0)
            {
                Console.WriteLine("Ошибка: знаменатель равен нулю.");
                return;
            }

            double z = Math.Exp(-c * x) * (numerator / denominator);
            Console.WriteLine($"Значение z: {z}");
        }
    }
}
