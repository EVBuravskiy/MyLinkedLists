using MyLinkedLists.Models;

namespace MyLinkedLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleLinkedList<int> simpleLinkedList = new SimpleLinkedList<int>();
            simpleLinkedList.Add(1);
            simpleLinkedList.Add(2);
            simpleLinkedList.Add(3);
            foreach (int i in simpleLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            simpleLinkedList.Remove(2);
            foreach (int i in simpleLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            simpleLinkedList.Remove(3);
            foreach (int i in simpleLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            simpleLinkedList.Remove(1);
            foreach (int i in simpleLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();


            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            doublyLinkedList.Add(10);
            doublyLinkedList.Add(20);
            doublyLinkedList.Add(30);
            foreach(var i in doublyLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            doublyLinkedList.Remove(20);
            foreach (var i in doublyLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            doublyLinkedList.Remove(30);
            foreach (var i in doublyLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            doublyLinkedList.Remove(10);
            foreach (var i in doublyLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            CirculedLinkedList<int> circuledLinkedList = new CirculedLinkedList<int>();
            circuledLinkedList.Add(100);
            circuledLinkedList.Add(200);
            circuledLinkedList.Add(300);
            foreach(var i in circuledLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            circuledLinkedList.Remove(200);
            foreach (var i in circuledLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            circuledLinkedList.Remove(300);
            foreach (var i in circuledLinkedList)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            circuledLinkedList.Remove(100);
            foreach (var i in circuledLinkedList)
            {
                Console.Write(i + " ");
            }

        }
    }
}