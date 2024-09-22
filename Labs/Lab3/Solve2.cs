namespace SolveLabs.Labs.Lab3
{
    public static class Solve2
    {
        public static void Execute()
        {
            int size = 7;
            int[,] matrix = new int[size, size];
            Random rand = new Random();

            // Заполнение массива случайными числами
            for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                matrix[i, j] = rand.Next(1, 100);

            Console.WriteLine("Исходный массив:");
            PrintMatrix(matrix);

            // Поворот массива на 90 градусов вправо
            Rotate90Degrees(matrix, size);

            Console.WriteLine("\nМассив после поворота на 90 градусов вправо:");
            PrintMatrix(matrix);
        }

        private static void Rotate90Degrees(int[,] matrix, int size)
        {
            // Транспонирование матрицы
            for (int i = 0; i < size; i++)
            for (int j = i + 1; j < size; j++)
            {
                (matrix[i, j], matrix[j, i]) = (matrix[j, i], matrix[i, j]);
            }

            // Отражение по горизонтали
            for (int i = 0; i < size; i++)
            for (int j = 0; j < size / 2; j++)
            {
                (matrix[i, j], matrix[i, size - 1 - j]) = (matrix[i, size - 1 - j], matrix[i, j]);
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{matrix[i, j],5}");
                Console.WriteLine();
            }
        }
    }
}