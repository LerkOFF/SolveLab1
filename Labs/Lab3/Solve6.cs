namespace SolveLabs.Labs.Lab3
{
    public static class Solve6
    {
        public static void Execute()
        {
            Console.Write("Введите количество элементов массива: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            int[] array = new int[n];
            Random rand = new Random();

            // Заполнение массива случайными числами
            for (int i = 0; i < n; i++)
                array[i] = rand.Next(-100, 100);

            Console.WriteLine("\nМассив:");
            PrintArray(array);

            // Вычисление суммы итеративно
            int sumIt = SumIterative(array);
            Console.WriteLine($"\nСумма элементов (итеративно): {sumIt}");

            // Вычисление суммы рекурсивно
            int sumRec = SumRecursive(array, n - 1);
            Console.WriteLine($"Сумма элементов (рекурсивно): {sumRec}");

            // Нахождение минимума итеративно
            int minIt = MinIterative(array);
            Console.WriteLine($"\nМинимальный элемент (итеративно): {minIt}");

            // Нахождение минимума рекурсивно
            int minRec = MinRecursive(array, n - 1);
            Console.WriteLine($"Минимальный элемент (рекурсивно): {minRec}");
        }

        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
                Console.Write($"{item,5}");
            Console.WriteLine();
        }

        public static int SumIterative(int[] array)
        {
            int sum = 0;
            foreach (var num in array)
                sum += num;
            return sum;
        }

        public static int SumRecursive(int[] array, int index)
        {
            if (index < 0)
                return 0;
            return array[index] + SumRecursive(array, index - 1);
        }

        public static int MinIterative(int[] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Массив пуст.");

            int min = array[0];
            foreach (var num in array)
                if (num < min)
                    min = num;
            return min;
        }

        public static int MinRecursive(int[] array, int index)
        {
            if (index == 0)
                return array[0];
            int min = MinRecursive(array, index - 1);
            return array[index] < min ? array[index] : min;
        }
    }
}
