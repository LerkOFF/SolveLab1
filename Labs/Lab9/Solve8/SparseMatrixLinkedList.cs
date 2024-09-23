namespace SolveLabs.Labs.Lab9
{
    public class SparseMatrixLinkedList
    {
        private DoublyLinkedList<MatrixElement> elements;
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public SparseMatrixLinkedList(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            elements = new DoublyLinkedList<MatrixElement>();
        }

        /// <summary>
        /// Заполнение матрицы. Устанавливает значение в определённой ячейке.
        /// Если значение равно нулю, элемент удаляется из списка.
        /// </summary>
        public void SetElement(int row, int column, int value)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException("Индексы выходят за пределы матрицы.");

            // Поиск существующего элемента
            MatrixElement? existing = elements.GetAllElements()
                .FirstOrDefault(e => e.Row == row && e.Column == column);

            if (existing.HasValue)
            {
                if (value == 0)
                {
                    // Удаление элемента
                    RemoveElement(row, column);
                }
                else
                {
                    // Обновление значения
                    int index = GetElementIndex(row, column);
                    if (index != -1)
                        elements.UpdateAt(index, new MatrixElement(row, column, value));
                }
            }
            else
            {
                if (value != 0)
                    elements.AddLast(new MatrixElement(row, column, value));
            }
        }

        /// <summary>
        /// Получение значения элемента матрицы.
        /// </summary>
        public int GetElement(int row, int column)
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
                throw new ArgumentOutOfRangeException("Индексы выходят за пределы матрицы.");

            MatrixElement? element = elements.GetAllElements()
                .FirstOrDefault(e => e.Row == row && e.Column == column);

            return element.HasValue ? element.Value.Value : 0;
        }

        /// <summary>
        /// Удаляет элемент из матрицы.
        /// </summary>
        private void RemoveElement(int row, int column)
        {
            int index = GetElementIndex(row, column);
            if (index != -1)
                elements.RemoveAt(index);
        }

        /// <summary>
        /// Получает индекс элемента в списке по его позиции.
        /// </summary>
        private int GetElementIndex(int row, int column)
        {
            int index = 0;
            foreach (var element in elements.GetAllElements())
            {
                if (element.Row == row && element.Column == column)
                    return index;
                index++;
            }
            return -1;
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
                    Console.Write($"{GetElement(i, j),4}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Транспонирование матрицы.
        /// </summary>
        public SparseMatrixLinkedList Transpose()
        {
            SparseMatrixLinkedList transposed = new SparseMatrixLinkedList(Columns, Rows);
            foreach (var element in elements.GetAllElements())
            {
                transposed.SetElement(element.Column, element.Row, element.Value);
            }
            return transposed;
        }

        /// <summary>
        /// Суммирование двух матриц.
        /// </summary>
        public static SparseMatrixLinkedList Add(SparseMatrixLinkedList a, SparseMatrixLinkedList b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new ArgumentException("Размерности матриц должны совпадать для суммирования.");

            SparseMatrixLinkedList result = new SparseMatrixLinkedList(a.Rows, a.Columns);

            // Добавляем все элементы из матрицы a
            foreach (var element in a.elements.GetAllElements())
            {
                result.SetElement(element.Row, element.Column, element.Value);
            }

            // Добавляем все элементы из матрицы b
            foreach (var element in b.elements.GetAllElements())
            {
                int existingValue = result.GetElement(element.Row, element.Column);
                result.SetElement(element.Row, element.Column, existingValue + element.Value);
            }

            return result;
        }

        /// <summary>
        /// Перемножение двух матриц.
        /// </summary>
        public static SparseMatrixLinkedList Multiply(SparseMatrixLinkedList a, SparseMatrixLinkedList b)
        {
            if (a.Columns != b.Rows)
                throw new ArgumentException("Количество столбцов первой матрицы должно равняться количеству строк второй матрицы для умножения.");

            SparseMatrixLinkedList result = new SparseMatrixLinkedList(a.Rows, b.Columns);

            // Для ускорения поиска элементов второй матрицы создадим список по строкам
            var bElementsByRow = b.elements.GetAllElements()
                                        .GroupBy(e => e.Row)
                                        .ToDictionary(g => g.Key, g => g.ToList());

            foreach (var aElem in a.elements.GetAllElements())
            {
                if (bElementsByRow.TryGetValue(aElem.Column, out List<MatrixElement> bRowElements))
                {
                    foreach (var bElem in bRowElements)
                    {
                        int current = result.GetElement(aElem.Row, bElem.Column);
                        result.SetElement(aElem.Row, bElem.Column, current + aElem.Value * bElem.Value);
                    }
                }
            }

            return result;
        }
    }
}
