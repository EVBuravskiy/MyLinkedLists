namespace MyLinkedLists.Models
{
    public class SimpleNode<T>
    {
        private T data = default(T);

        public T Data
        {
            get { return data; }
            set
            {
                data = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public SimpleNode<T> NextElement { get; set; }

        public SimpleNode(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
