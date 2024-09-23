namespace SolveLabs.Labs.Lab9
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Добавляет элемент в конец списка
        /// </summary>
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            Count++;
        }

        /// <summary>
        /// Удаляет элемент по индексу
        /// </summary>
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                return false;

            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            if (current.Previous != null)
                current.Previous.Next = current.Next;
            else
                head = current.Next;

            if (current.Next != null)
                current.Next.Previous = current.Previous;
            else
                tail = current.Previous;

            Count--;
            return true;
        }

        /// <summary>
        /// Получает элемент по индексу
        /// </summary>
        public T GetAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Data;
        }

        /// <summary>
        /// Обновляет элемент по индексу
        /// </summary>
        public bool UpdateAt(int index, T newData)
        {
            if (index < 0 || index >= Count)
                return false;

            Node<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            current.Data = newData;
            return true;
        }

        /// <summary>
        /// Перебор элементов списка
        /// </summary>
        public IEnumerable<T> GetAllElements()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
