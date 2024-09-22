namespace SolveLabs.Labs.Lab3
{
    public static class Solve5
    {
        public static void Execute()
        {
            int size = 5;
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

            // Умножение матриц
            int[,] product = MultiplyMatrices(matrix1, matrix2);
            Console.WriteLine("\nПроизведение матриц:");
            PrintMatrix(product);
        }

        private static void FillMatrix(int[,] matrix, Random rand)
        {
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                matrix[i, j] = rand.Next(1, 10); // Для удобства умножения использую числа от 1 до 9
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

        private static int[,] MultiplyMatrices(int[,] m1, int[,] m2)
        {
            int size = m1.GetLength(0);
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < size; k++)
                    result[i, j] += m1[i, k] * m2[k, j];
            }

            return result;
        }
    }
}