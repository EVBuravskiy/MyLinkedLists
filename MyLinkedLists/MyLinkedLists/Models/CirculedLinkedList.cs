using System.Collections;

namespace MyLinkedLists.Models
{
    public class CirculedLinkedList<T> : IEnumerable<T>
    {
        public DoublyNode<T> Head { get; set; }
        public DoublyNode<T> Tail { get; set; }
        public int Count { get; set; }

        public CirculedLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public CirculedLinkedList(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            Head = node;
            Tail.Next = node;
            Tail.Previous = node;
            Count = 1;
        }

        public void Add(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (Tail == null)
            {
                Tail = Head = newNode;
                Tail.Next = newNode;
                Tail.Previous = newNode;
                Count = 1;
                return;
            }
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
            Tail.Next = Head;
            Head.Previous = Tail;
            Count++;
            return;
        }

        public void Remove(T data)
        {
            if (Tail == null)
            {
                throw new NullReferenceException("List is empty");
            }
            if (Head.Data.Equals(data))
            {
                if (Head.Next != Head)
                {
                    Head = Head.Next;
                    Head.Previous = Tail;
                    Tail.Next = Head;
                    Count--;
                    return;
                }
                Head = null;
                Tail = null;
                Count = 0;
                return;
            }
            if (Tail.Data.Equals(data))
            {
                Tail = Tail.Previous;
                Tail.Next = Head;
                Head.Previous = Tail;
                Count--;
                return;
            }
            DoublyNode<T> current = Head.Next;
            do
            {
                if (current.Data.Equals(data))
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    current = null;
                    Count--;
                    return;
                }
                current = current.Next;
            } while (current != Head);
            throw new NullReferenceException("Element not in List");
        }

        public IEnumerator GetEnumerator()
        {
            DoublyNode<T> current = Head;
            if (current != null)
            {
                do
                {
                    yield return current.Data;
                    current = current.Next;
                }
                while (current != Head);
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
