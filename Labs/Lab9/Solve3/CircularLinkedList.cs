namespace SolveLabs.Labs.Lab9
{
    public class CircularLinkedListNode<T>
    {
        public T Data { get; set; }
        public CircularLinkedListNode<T> Next { get; set; }

        public CircularLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class CircularLinkedList<T>
    {
        private CircularLinkedListNode<T> head;
        private CircularLinkedListNode<T> tail;
        public int Count { get; private set; }

        public CircularLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Добавляет узел в конец списка
        /// </summary>
        public void AddLast(T data)
        {
            CircularLinkedListNode<T> newNode = new CircularLinkedListNode<T>(data);
            if (head == null)
            {
                head = tail = newNode;
                newNode.Next = head;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
                tail.Next = head;
            }
            Count++;
        }

        /// <summary>
        /// Получает узел по индексу
        /// </summary>
        public CircularLinkedListNode<T> GetNodeAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            CircularLinkedListNode<T> current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current;
        }

        /// <summary>
        /// Перебирает все узлы списка
        /// </summary>
        public IEnumerable<CircularLinkedListNode<T>> GetAllNodes()
        {
            if (head == null)
                yield break;

            CircularLinkedListNode<T> current = head;
            do
            {
                yield return current;
                current = current.Next;
            } while (current != head);
        }
    }
}
