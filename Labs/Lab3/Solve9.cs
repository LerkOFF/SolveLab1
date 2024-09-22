namespace SolveLabs.Labs.Lab3
{
    public static class Solve9
    {
        public static void Execute()
        {
            int size = 9;
            int[,] matrix = new int[size, size];
            Random rand = new Random();

            // Заполнение массива случайными числами от 1 до 99
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = rand.Next(1, 100);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Исходный массив (9x9):");
            Console.ResetColor();
            PrintMatrix(matrix);

            // Транспонирование матрицы (отражение относительно главной диагонали)
            int[,] transposed = TransposeMatrix(matrix, size);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nТранспонированный массив (отражён относительно главной диагонали):");
            Console.ResetColor();
            PrintMatrix(transposed);
        }

        private static int[,] TransposeMatrix(int[,] matrix, int size)
        {
            int[,] transposed = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    transposed[j, i] = matrix[i, j];
            return transposed;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Используем разные цвета для главной диагонали
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{matrix[i, j],4} ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write($"{matrix[i, j],4} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
