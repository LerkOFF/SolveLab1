namespace SolveLabs.Labs.Lab9
{
    public static class Solve8
    {
        public static void Execute()
        {
            while (true)
            {
                Console.WriteLine("\n--- Задание 8: Обработка разреженных матриц ---");
                Console.WriteLine("Выберите способ представления матрицы:");
                Console.WriteLine("1. Двумерный массив");
                Console.WriteLine("2. Связные списки");
                Console.WriteLine("0. Назад в главное меню");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ExecuteArrayMatrixOperations();
                        break;
                    case "2":
                        ExecuteLinkedListMatrixOperations();
                        break;
                    case "0":
                        Console.WriteLine("Возврат в главное меню.");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                        Console.ResetColor();
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
        }

        #region Двумерный массив

        private static void ExecuteArrayMatrixOperations()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Работа с разреженными матрицами (двумерный массив) ===\n");
            Console.ResetColor();

            // Задаём размеры матриц
            Console.Write("Введите количество строк матрицы A: ");
            int rowsA = ReadPositiveInt();
            Console.Write("Введите количество столбцов матрицы A: ");
            int colsA = ReadPositiveInt();

            Console.Write("Введите количество строк матрицы B: ");
            int rowsB = ReadPositiveInt();
            Console.Write("Введите количество столбцов матрицы B: ");
            int colsB = ReadPositiveInt();

            // Создание матриц
            SparseMatrixArray matrixA = new SparseMatrixArray(rowsA, colsA);
            SparseMatrixArray matrixB = new SparseMatrixArray(rowsB, colsB);

            // Заполнение матриц
            Console.WriteLine("\nЗаполнение матрицы A:");
            FillMatrixArray(matrixA);

            Console.WriteLine("\nЗаполнение матрицы B:");
            FillMatrixArray(matrixB);

            // Вывод матриц
            Console.WriteLine("\nМатрица A:");
            matrixA.PrintMatrix();

            Console.WriteLine("\nМатрица B:");
            matrixB.PrintMatrix();

            // Транспонирование
            Console.WriteLine("\nТранспонированная матрица A:");
            var transposedA = matrixA.Transpose();
            transposedA.PrintMatrix();

            Console.WriteLine("\nТранспонированная матрица B:");
            var transposedB = matrixB.Transpose();
            transposedB.PrintMatrix();

            // Суммирование
            if (rowsA == rowsB && colsA == colsB)
            {
                Console.WriteLine("\nСумма матриц A + B:");
                var sum = SparseMatrixArray.Add(matrixA, matrixB);
                sum.PrintMatrix();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nСуммирование невозможно: размерности матриц A и B различны.");
                Console.ResetColor();
            }

            // Перемножение
            if (colsA == rowsB)
            {
                Console.WriteLine("\nПроизведение матриц A * B:");
                var product = SparseMatrixArray.Multiply(matrixA, matrixB);
                product.PrintMatrix();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nУмножение невозможно: количество столбцов матрицы A не равно количеству строк матрицы B.");
                Console.ResetColor();
            }
        }

        private static void FillMatrixArray(SparseMatrixArray matrix)
        {
            Console.WriteLine("Введите количество ненулевых элементов:");
            int nonZero = ReadNonNegativeInt();

            for (int i = 0; i < nonZero; i++)
            {
                Console.WriteLine($"\nЭлемент {i + 1}:");
                int row = ReadIntInRange($"  Строка (0 - {matrix.Rows - 1}): ", 0, matrix.Rows - 1);
                int col = ReadIntInRange($"  Столбец (0 - {matrix.Columns - 1}): ", 0, matrix.Columns - 1);
                int value = ReadInt($"  Значение (не равно 0): ", excludeZero: true);

                matrix.SetElement(row, col, value);
            }
        }

        #endregion

        #region Связные списки

        private static void ExecuteLinkedListMatrixOperations()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Работа с разреженными матрицами (связные списки) ===\n");
            Console.ResetColor();

            // Задаём размеры матриц
            Console.Write("Введите количество строк матрицы A: ");
            int rowsA = ReadPositiveInt();
            Console.Write("Введите количество столбцов матрицы A: ");
            int colsA = ReadPositiveInt();

            Console.Write("Введите количество строк матрицы B: ");
            int rowsB = ReadPositiveInt();
            Console.Write("Введите количество столбцов матрицы B: ");
            int colsB = ReadPositiveInt();

            // Создание матриц
            SparseMatrixLinkedList matrixA = new SparseMatrixLinkedList(rowsA, colsA);
            SparseMatrixLinkedList matrixB = new SparseMatrixLinkedList(rowsB, colsB);

            // Заполнение матриц
            Console.WriteLine("\nЗаполнение матрицы A:");
            FillMatrixLinkedList(matrixA);

            Console.WriteLine("\nЗаполнение матрицы B:");
            FillMatrixLinkedList(matrixB);

            // Вывод матриц
            Console.WriteLine("\nМатрица A:");
            matrixA.PrintMatrix();

            Console.WriteLine("\nМатрица B:");
            matrixB.PrintMatrix();

            // Транспонирование
            Console.WriteLine("\nТранспонированная матрица A:");
            var transposedA = matrixA.Transpose();
            transposedA.PrintMatrix();

            Console.WriteLine("\nТранспонированная матрица B:");
            var transposedB = matrixB.Transpose();
            transposedB.PrintMatrix();

            // Суммирование
            if (rowsA == rowsB && colsA == colsB)
            {
                Console.WriteLine("\nСумма матриц A + B:");
                var sum = SparseMatrixLinkedList.Add(matrixA, matrixB);
                sum.PrintMatrix();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nСуммирование невозможно: размерности матриц A и B различны.");
                Console.ResetColor();
            }

            // Перемножение
            if (colsA == rowsB)
            {
                Console.WriteLine("\nПроизведение матриц A * B:");
                var product = SparseMatrixLinkedList.Multiply(matrixA, matrixB);
                product.PrintMatrix();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nУмножение невозможно: количество столбцов матрицы A не равно количеству строк матрицы B.");
                Console.ResetColor();
            }
        }

        private static void FillMatrixLinkedList(SparseMatrixLinkedList matrix)
        {
            Console.WriteLine("Введите количество ненулевых элементов:");
            int nonZero = ReadNonNegativeInt();

            for (int i = 0; i < nonZero; i++)
            {
                Console.WriteLine($"\nЭлемент {i + 1}:");
                int row = ReadIntInRange($"  Строка (0 - {matrix.Rows - 1}): ", 0, matrix.Rows - 1);
                int col = ReadIntInRange($"  Столбец (0 - {matrix.Columns - 1}): ", 0, matrix.Columns - 1);
                int value = ReadInt($"  Значение (не равно 0): ", excludeZero: true);

                matrix.SetElement(row, col, value);
            }
        }

        #endregion

        #region Вспомогательные Методы

        private static int ReadPositiveInt()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value > 0)
                    return value;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введите положительное целое число: ");
                Console.ResetColor();
            }
        }

        private static int ReadNonNegativeInt()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= 0)
                    return value;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введите неотрицательное целое число: ");
                Console.ResetColor();
            }
        }

        private static int ReadInt(string prompt, bool excludeZero = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    if (excludeZero && value == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Значение не может быть равно нулю.");
                        Console.ResetColor();
                        continue;
                    }
                    return value;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                Console.ResetColor();
            }
        }

        private static int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= min && value <= max)
                    return value;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Введите целое число в диапазоне от {min} до {max}.");
                Console.ResetColor();
            }
        }

        #endregion
    }
}
