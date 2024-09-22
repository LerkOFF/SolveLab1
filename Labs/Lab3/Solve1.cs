namespace SolveLabs.Labs.Lab3
{
    public static class Solve1
    {
        public static void Execute()
        {
            Console.Write("Введите количество элементов массива: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                return;
            }

            int[] array = new int[n];
            Random rand = new Random();

            // Заполнение массива случайными числами от -30 до 45
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(-30, 46);
            }

            Console.WriteLine("\nМассив:");
            // Вывод массива по 10 элементов в строке
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{array[i],5}");
                if ((i + 1) % 10 == 0 || i == n - 1)
                    Console.WriteLine();
            }

            Console.WriteLine("\nЭлементы массива в обратном порядке (без отрицательных):");
            // Вывод элементов в обратном порядке, игнорируя отрицательные
            int count = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (array[i] >= 0)
                {
                    Console.Write($"{array[i],5}");
                    count++;
                    if (count % 10 == 0)
                        Console.WriteLine();
                }
            }
            if (count % 10 != 0)
                Console.WriteLine();
        }
    }
}