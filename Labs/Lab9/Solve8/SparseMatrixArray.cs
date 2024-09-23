namespace SolveLabs.Labs.Lab9
{
    public class SparseMatrixArray
    {
        private int[,] matrix;
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public SparseMatrixArray(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            matrix = new int[rows, columns];
        }

        /// <summary>
        /// Заполнение матрицы. Позволяет установить значение в определённой ячейке.
        /// </summary>
        public void SetElement(int row, int column, int value)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException("Индексы выходят за пределы матрицы.");

            matrix[row, column] = value;
        }

        /// <summary>
        /// Получение значения элемента матрицы.
        /// </summary>
        public int GetElement(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException("Индексы выходят за пределы матрицы.");

            return matrix[row, column];
        }

        /// <summary>
        /// Вывод матрицы на экран.
        /// </summary>
        public void PrintMatrix()
        {
            Console.WriteLine("Матрица:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        public SparseMatrixArray Transpose()
        {
            SparseMatrixArray transposed = new SparseMatrixArray(Columns, Rows);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    transposed.matrix[j, i] = matrix[i, j];
            return transposed;
        }

        /// <summary>
        /// Суммирование двух матриц.
        /// </summary>
        public static SparseMatrixArray Add(SparseMatrixArray a, SparseMatrixArray b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Размерности матриц должны совпадать для суммирования.");

            SparseMatrixArray result = new SparseMatrixArray(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
            return result;
        }

        /// <summary>
        /// Перемножение двух матриц.
        /// </summary>
        public static SparseMatrixArray Multiply(SparseMatrixArray a, SparseMatrixArray b)
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("Количество столбцов первой матрицы должно равняться количеству строк второй матрицы для умножения.");

            SparseMatrixArray result = new SparseMatrixArray(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < a.Columns; k++)
                        sum += a.matrix[i, k] * b.matrix[k, j];
                    result.matrix[i, j] = sum;
                }
            }
            return result;
        }
    }
}
