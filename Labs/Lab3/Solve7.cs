namespace SolveLabs.Labs.Lab3
{
    public static class Solve7
    {
        public static void Execute()
        {
            Console.Write("Введите номер члена ряда Фибоначчи (n): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            long fib = FibonacciRecursive(n);
            Console.WriteLine($"Fibonacci({n}) = {fib}");
        }

        private static long FibonacciRecursive(int n)
        {
            if (n <= 1)
                return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }
    }
}