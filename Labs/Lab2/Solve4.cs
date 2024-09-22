namespace SolveLabs.Labs.Lab2
{
    public static class Solve4
    {
        public static void Execute()
        {
            Console.Write("Введите значение x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите значение q (точность): ");
            double q = double.Parse(Console.ReadLine());

            double cosX = 1;
            double term = 1;
            int n = 1;
            int count = 1;

            while (Math.Abs(term) > q)
            {
                term *= -x * x / ((2 * n - 1) * (2 * n));
                cosX += term;
                n++;
                count++;
            }

            Console.WriteLine($"Приближённое значение cos({x}) = {cosX}");
            Console.WriteLine($"Количество учтённых слагаемых: {count}");
        }
    }
}