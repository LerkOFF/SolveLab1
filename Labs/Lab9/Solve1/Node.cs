namespace SolveLabs.Labs.Lab9
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Previous = null;
            Next = null;
        }
    }
}