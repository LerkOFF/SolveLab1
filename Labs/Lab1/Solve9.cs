namespace SolveLabs.Labs.Lab1
{
    public static class Solve9
    {
        public static void Execute()
        {
            Console.WriteLine("Введите коэффициенты для уравнений:");

            // Ввод коэффициентов первой строки
            Console.WriteLine("Введите a1, b1, c1, d1:");
            if (!double.TryParse(Console.ReadLine(), out double a1) ||
                !double.TryParse(Console.ReadLine(), out double b1) ||
                !double.TryParse(Console.ReadLine(), out double c1) ||
                !double.TryParse(Console.ReadLine(), out double d1))
            {
                Console.WriteLine("Некорректный ввод коэффициентов первой строки.");
                return;
            }

            // Ввод коэффициентов второй строки
            Console.WriteLine("Введите a2, b2, c2, d2:");
            if (!double.TryParse(Console.ReadLine(), out double a2) ||
                !double.TryParse(Console.ReadLine(), out double b2) ||
                !double.TryParse(Console.ReadLine(), out double c2) ||
                !double.TryParse(Console.ReadLine(), out double d2))
            {
                Console.WriteLine("Некорректный ввод коэффициентов второй строки.");
                return;
            }

            // Ввод коэффициентов третьей строки
            Console.WriteLine("Введите a3, b3, c3, d3:");
            if (!double.TryParse(Console.ReadLine(), out double a3) ||
                !double.TryParse(Console.ReadLine(), out double b3) ||
                !double.TryParse(Console.ReadLine(), out double c3) ||
                !double.TryParse(Console.ReadLine(), out double d3))
            {
                Console.WriteLine("Некорректный ввод коэффициентов третьей строки.");
                return;
            }

            // Вычисление определителей
            double det = a1 * (b2 * c3 - b3 * c2) - b1 * (a2 * c3 - a3 * c2) + c1 * (a2 * b3 - a3 * b2);
            if (det == 0)
            {
                Console.WriteLine("Система не имеет уникального решения (детерминант равен 0).");
                return;
            }

            double detX = d1 * (b2 * c3 - b3 * c2) - b1 * (d2 * c3 - d3 * c2) + c1 * (d2 * b3 - d3 * b2);
            double detY = a1 * (d2 * c3 - d3 * c2) - d1 * (a2 * c3 - a3 * c2) + c1 * (a2 * d3 - a3 * d2);
            double detZ = a1 * (b2 * d3 - b3 * d2) - b1 * (a2 * d3 - a3 * d2) + d1 * (a2 * b3 - a3 * b2);

            double x = detX / det;
            double y = detY / det;
            double z = detZ / det;

            Console.WriteLine($"Решение системы: x = {x}, y = {y}, z = {z}");
        }
    }
}
