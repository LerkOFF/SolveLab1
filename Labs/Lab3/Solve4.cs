namespace SolveLabs.Labs.Lab3
{
    public static class Solve4
    {
        public static void Execute()
        {
            int size = 3;
            int[,] matrix1 = new int[size, size];
            int[,] matrix2 = new int[size, size];
            Random rand = new Random();

            // Заполнение матриц случайными числами
            Console.WriteLine("Матрица 1:");
            FillMatrix(matrix1, rand);
            PrintMatrix(matrix1);

            Console.WriteLine("\nМатрица 2:");
            FillMatrix(matrix2, rand);
            PrintMatrix(matrix2);

            // Сложение матриц
            int[,] sum = AddMatrices(matrix1, matrix2);
            Console.WriteLine("\nСумма матриц:");
            PrintMatrix(sum);

            // Вычитание матриц
            int[,] difference = SubtractMatrices(matrix1, matrix2);
            Console.WriteLine("\nРазница матриц (Матрица1 - Матрица2):");
            PrintMatrix(difference);

            // Вычисление среднего значения
            double average = CalculateAverage(matrix1, matrix2);
            Console.WriteLine($"\nСреднее значение всех элементов входных матриц: {average:F2}");
        }

        private static void FillMatrix(int[,] matrix, Random rand)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = rand.Next(0, 100);
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

        private static int[,] AddMatrices(int[,] m1, int[,] m2)
        {
            int size = m1.GetLength(0);
            int[,] result = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    result[i, j] = m1[i, j] + m2[i, j];
            return result;
        }

        private static int[,] SubtractMatrices(int[,] m1, int[,] m2)
        {
            int size = m1.GetLength(0);
            int[,] result = new int[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    result[i, j] = m1[i, j] - m2[i, j];
            return result;
        }

        private static double CalculateAverage(int[,] m1, int[,] m2)
        {
            int size = m1.GetLength(0);
            double sum = 0;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    sum += m1[i, j];
                    sum += m2[i, j];
                }
            return sum / (2 * size * size);
        }
    }
}
