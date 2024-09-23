namespace SolveLabs.Labs.Lab9
{
    public static class Solve4
    {
        public static void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Задание 4: Комбинации сумм квадратов и кубов ===\n");
            Console.ResetColor();

            // Создание двусвязного списка для хранения результатов
            DoublyLinkedList<int> results = new DoublyLinkedList<int>();

            for (int N = 1; N <= 50000; N++)
            {
                if (HasSumOfSquares(N) || HasSumOfCubes(N))
                {
                    results.AddLast(N);
                }
            }

            // Вывод результатов
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Числа, для которых существует хотя бы одна комбинация суммы квадратов или суммы кубов:");
            Console.ResetColor();

            foreach (var number in results.GetAllElements())
            {
                Console.WriteLine(number);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nВсего найдено: {results.Count} чисел.");
            Console.ResetColor();
        }

        /// <summary>
        /// Проверяет, существует ли пара чисел a и b такие, что a^2 + b^2 = N
        /// </summary>
        private static bool HasSumOfSquares(int N)
        {
            for (int a = 1; a * a <= N; a++)
            {
                double bDouble = Math.Sqrt(N - a * a);
                int b = (int)bDouble;
                if (b * b == N - a * a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяет, существует ли пара чисел a и b такие, что a^3 + b^3 = N
        /// </summary>
        private static bool HasSumOfCubes(int N)
        {
            for (int a = 1; a * a * a <= N; a++)
            {
                double bDouble = Math.Cbrt(N - a * a * a);
                int b = (int)Math.Round(bDouble);
                if (b * b * b == N - a * a * a)
                    return true;
            }
            return false;
        }
    }
}
