namespace SolveLabs.Labs.Lab3
{
    public static class Solve8
    {
        public static void Execute()
        {
            Console.Write("Введите размер матрицы (N): ");
            if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            int[,] matrix = new int[N, N];
            Console.WriteLine("Введите элементы матрицы:");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Строка {i + 1}:");
                string[] inputs = Console.ReadLine().Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (inputs.Length != N)
                {
                    Console.WriteLine("Неверное количество элементов. Попробуйте снова.");
                    i--;
                    continue;
                }
                for (int j = 0; j < N; j++)
                {
                    if (!int.TryParse(inputs[j], out matrix[i, j]))
                    {
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        j--;
                    }
                }
            }

            Console.WriteLine("\nВведённая матрица:");
            PrintMatrix(matrix);

            long determinant = Determinant(matrix, N);
            Console.WriteLine($"\nОпределитель матрицы: {determinant}");
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int N = matrix.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write($"{matrix[i, j],5}");
                Console.WriteLine();
            }
        }

        private static long Determinant(int[,] matrix, int N)
        {
            if (N == 1)
                return matrix[0, 0];
            if (N == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            long det = 0;
            for (int k = 0; k < N; k++)
            {
                int[,] minor = GetMinor(matrix, 0, k, N);
                long minorDet = Determinant(minor, N - 1);
                det += (long)(Math.Pow(-1, k) * matrix[0, k]) * minorDet;
            }
            return det;
        }

        private static int[,] GetMinor(int[,] matrix, int rowToRemove, int colToRemove, int N)
        {
            int[,] minor = new int[N - 1, N - 1];
            int m = 0, n = 0;
            for (int i = 0; i < N; i++)
            {
                if (i == rowToRemove)
                    continue;
                n = 0;
                for (int j = 0; j < N; j++)
                {
                    if (j == colToRemove)
                        continue;
                    minor[m, n] = matrix[i, j];
                    n++;
                }
                m++;
            }
            return minor;
        }
    }
}
