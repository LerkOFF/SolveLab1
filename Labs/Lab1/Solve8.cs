namespace SolveLabs.Labs.Lab1
{
    public static class Solve8
    {
        public static void Execute()
        {
            Console.Write("Введите число x: ");
            if (!double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine("Введите корректное действительное число.");
                return;
            }

            // 3x^4 - 5x^3 + 2x^2 - x + 7
            double result = ((3 * x - 5) * x + 2) * x * x - x + 7;

            Console.WriteLine($"Результат: {result}");
        }
    }
}
