namespace SolveLabs.Labs.Lab1
{
    public static class Solve5
    {
        public static void Execute()
        {
            Console.Write("Введите длину первого катета: ");
            if (!double.TryParse(Console.ReadLine(), out double a) || a <= 0)
            {
                Console.WriteLine("Длина катета должна быть положительным числом.");
                return;
            }

            Console.Write("Введите длину второго катета: ");
            if (!double.TryParse(Console.ReadLine(), out double b) || b <= 0)
            {
                Console.WriteLine("Длина катета должна быть положительным числом.");
                return;
            }

            double area = (a * b) / 2;
            double hypotenuse = Math.Sqrt(a * a + b * b);
            double perimeter = a + b + hypotenuse;

            Console.WriteLine($"Площадь треугольника: {area}");
            Console.WriteLine($"Периметр треугольника: {perimeter}");
        }
    }
}
