namespace SolveLabs.Labs.Lab3
{
    public static class Solve3
    {
        public static void Execute()
        {
            Console.Write("Введите количество элементов массива: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            Console.Write("Введите количество позиций для сдвига (k): ");
            if (!int.TryParse(Console.ReadLine(), out int k))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            int[] array = new int[n];
            Random rand = new Random();

            // Заполнение массива случайными числами
            for (int i = 0; i < n; i++)
                array[i] = rand.Next(-100, 100);

            Console.WriteLine("\nИсходный массив:");
            PrintArray(array);

            // Нормализация k
            k = k % n;
            if (k < 0)
                k += n;

            // Циклический сдвиг влево на k позиций
            Reverse(array, 0, k - 1);
            Reverse(array, k, n - 1);
            Reverse(array, 0, n - 1);

            Console.WriteLine($"\nМассив после сдвига на {k} позиций влево:");
            PrintArray(array);
        }

        private static void Reverse(int[] array, int start, int end)
        {
            while (start < end)
            {
                (array[start], array[end]) = (array[end], array[start]);
                start++;
                end--;
            }
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i],5}");
            Console.WriteLine();
        }
    }
}