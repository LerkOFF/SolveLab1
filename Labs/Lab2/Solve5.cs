namespace SolveLabs.Labs.Lab2
{
    public static class Solve5
    {
        public static void Execute()
        {
            Console.Write("Введите натуральное число N: ");
            int N = int.Parse(Console.ReadLine());

            bool found = false;
            for (int x = 1; x * x * x <= N; x++)
            {
                for (int y = 1; y * y * y <= N; y++)
                {
                    for (int z = 1; z * z * z <= N; z++)
                    {
                        if (x * x * x + y * y * y + z * z * z == N)
                        {
                            Console.WriteLine($"Число {N} можно представить как сумму кубов: {x}^3 + {y}^3 + {z}^3");
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
                if (found) break;
            }

            if (!found)
            {
                Console.WriteLine($"Число {N} нельзя представить как сумму кубов.");
            }
        }
    }
}