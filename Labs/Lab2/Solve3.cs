namespace SolveLabs.Labs.Lab2
{
    public static class Solve3
    {
        public static void Execute()
        {
            int a = 1, b = 1;
            int count = 0;

            while (b < 10000)
            {
                int next = a + b;
                a = b;
                b = next;

                if (b >= 1000 && b < 10000)
                    count++;
            }

            Console.WriteLine($"Количество четырёхзначных чисел в ряде Фибоначчи: {count}");
        }
    }
}