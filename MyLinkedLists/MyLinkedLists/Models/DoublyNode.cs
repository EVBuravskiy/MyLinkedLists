namespace MyLinkedLists.Models
{
    public class DoublyNode<T>
    {
        public DoublyNode<T> Previous { get; set; }
        public T Data { get; set; }
        public DoublyNode<T> Next { get; set; }

        public DoublyNode()
        {
            Previous = null;
            Data = default(T);
            Next = null;
        }

        public DoublyNode(T data) : this()
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
