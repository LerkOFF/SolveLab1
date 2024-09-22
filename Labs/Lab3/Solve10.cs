namespace SolveLabs.Labs.Lab3
{
    public static class Solve10
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

            // Заполнение массива случайными числами от 1 до 100
            for (int i = 0; i < n; i++)
                array[i] = rand.Next(1, 101);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nСгенерированный массив:");
            Console.ResetColor();
            PrintArray(array);

            // Определение середины массива
            int mid = n / 2;

            // Вычисление суммы левой и правой половин
            int leftSum = 0;
            int rightSum = 0;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Левая половина: ");
            Console.ResetColor();
            for (int i = 0; i < mid; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{array[i],4} ");
                Console.ResetColor();
                leftSum += array[i];
            }
            Console.WriteLine($"\nСумма левой половины: {leftSum}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Правая половина: ");
            Console.ResetColor();
            for (int i = mid; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{array[i],4} ");
                Console.ResetColor();
                rightSum += array[i];
            }
            Console.WriteLine($"\nСумма правой половины: {rightSum}");

            int result = rightSum - leftSum;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nРезультат вычитания суммы левой половины из суммы правой половины: {rightSum} - {leftSum} = {result}");
            Console.ResetColor();
        }

        private static void PrintArray(int[] array)
        {
            foreach (var item in array)
                Console.Write($"{item,4} ");
            Console.WriteLine();
        }
    }
}
