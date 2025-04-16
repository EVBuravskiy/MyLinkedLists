using System.Collections;

namespace MyLinkedLists.Models
{
    public class SimpleLinkedList<T> : IEnumerable
    {
        public SimpleNode<T> Head { get; set; }
        public SimpleNode<T> Tail { get; set; }
        public int Count { get; private set; }
        public SimpleLinkedList()
        {
            Clear();
        }
        public SimpleLinkedList(T data)
        {
            SimpleNode<T> element = new SimpleNode<T>(data);
            SetHeadAndTail(element);
        }
        public void Add(T item)
        {
            SimpleNode<T> element = new SimpleNode<T>(item);
            if (Tail != null)
            {
                Tail.NextElement = element;
                Tail = element;
                Count++;
            }
            else
            {
                SetHeadAndTail(element);
            }
        }

        public void AppendHead(T data)
        {
            SimpleNode<T> firstElement = new SimpleNode<T>(data);
            firstElement.NextElement = Head;
            Head = firstElement;
            Count++;
        }

        public void InsertAfter(T target, T data)
        {
            SimpleNode<T> newElement = new SimpleNode<T>(data);
            Count++;
            if (Head.Data.Equals(target))
            {
                newElement.NextElement = Head.NextElement;
                Head.NextElement = newElement;
                return;
            }
            if (Tail.Data.Equals(target))
            {
                Tail.NextElement = newElement;
                Tail = newElement;
                return;
            }
            SimpleNode<T> current = Head.NextElement;
            while (current != Tail)
            {
                if (current.Data.Equals(target))
                {
                    newElement.NextElement = current.NextElement;
                    current.NextElement = newElement;

                    return;
                }
                current = current.NextElement;
            }
            Tail.NextElement = newElement;
            Tail = newElement;
            return;
        }

        public bool Find(T item)
        {
            SimpleNode<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return true;
                }
                current = current.NextElement;

            }
            return false;
        }

        public void Remove(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.NextElement;
                    Tail = null;
                    Count--;
                    return;
                }

                SimpleNode<T> current = Head.NextElement;
                SimpleNode<T> previous = Head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.NextElement = current.NextElement;
                        Count--;
                        if (current == Tail)
                        {
                            Tail = previous;
                        }
                        return;
                    }
                    previous = current;
                    current = current.NextElement;
                }
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        private void SetHeadAndTail(SimpleNode<T> element)
        {
            Head = element;
            Tail = element;
            Count = 1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            SimpleNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.NextElement;
            }
        }
    }
}
