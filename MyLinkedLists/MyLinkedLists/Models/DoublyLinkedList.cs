using System.Collections;

namespace MyLinkedLists.Models
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyNode<T> Head { get; set; }
        public DoublyNode<T> Tail { get; set; }
        public int Count { get; set; }

        public DoublyLinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public DoublyLinkedList(T data)
        {
            DoublyNode<T> element = new DoublyNode<T>(data);
            Head = element;
            Tail = element;
            Count = 1;
        }

        public void Add(T data)
        {
            DoublyNode<T> newElement = new DoublyNode<T>(data);
            if (Tail == null)
            {
                Head = newElement;
                Tail = newElement;
                Count = 1;
                return;
            }
            else
            {
                Tail.Next = newElement;
                newElement.Previous = Tail;
                Tail = newElement;
                Count++;
                return;
            }
        }

        public void Remove(T data)
        {
            if (Tail == null)
            {
                throw new NullReferenceException("List is Empty");
            }
            if (Head.Data.Equals(data))
            {
                if (Head.Next != null)
                {
                    Head = Head.Next;
                    Head.Previous = null;
                    Count--;
                    return;
                }
                Head = null;
                Tail = null;
                Count--;
                return;
            }
            if (Tail.Data.Equals(data))
            {
                Tail = Tail.Previous;
                Tail.Next = null;
                Count--;
                return;
            }
            DoublyNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    //DoublyNode<T> previous = current.Previous;
                    //DoublyNode<T> next = current.Next;
                    //previous.Next = next;
                    //next.Previous = previous; =>

                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;

                    current = null;
                    Count--;
                    return;
                }
                current = current.Next;
            }
            if (current == null)
            {
                throw new IndexOutOfRangeException($"Element {data} is not in the list");
            }
        }
        public void InsertAfter(T target, T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            DoublyNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(target))
                {
                    newNode.Next = current.Next;
                    newNode.Previous = current;
                    current.Next = newNode;
                }
                current = current.Next;
            }
        }

        public DoublyLinkedList<T> Reverse()
        {
            DoublyLinkedList<T> reversed = new DoublyLinkedList<T>();
            DoublyNode<T> current = Tail;
            while (current != null)
            {
                reversed.Add(current.Data);
                current = current.Previous;
            }
            return reversed;
        }

        public IEnumerator GetEnumerator()
        {
            DoublyNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}
