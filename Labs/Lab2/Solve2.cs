namespace SolveLabs.Labs.Lab2
{
    public static class Solve2
    {
        public static void Execute()
        {
            Console.Write("Введите количество слагаемых: ");
            int n = int.Parse(Console.ReadLine());

            double pi = 0;
            for (int i = 0; i < n; i++)
            {
                double term = Math.Pow(-1, i) / (2 * i + 1);
                pi += term;
            }

            pi *= 4;
            Console.WriteLine($"Приближённое значение числа π: {pi}");
        }
    }
}