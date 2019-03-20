using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test321
{
    //链表的普通版本
    /*public class LinkedListNode
    {
        public LinkedListNode(object value)
        {
            this.Value = value;
        }
        public object Value { get; private set; }
        public LinkedListNode Next { get; internal set; }
        public LinkedListNode Prev { get; internal set; }
    }
    public class LinkedList: IEnumerable
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }
        public LinkedListNode AddLast(object node)
        {
            var newNode = new LinkedListNode(node);
            if(First==null)
            {
                First = newNode;
                newNode.Prev = Last;
                Last = First;
            }
            else
            {
                LinkedListNode previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }
        public IEnumerator GetEnumerator()
        {
            LinkedListNode current = First;
            while(current!=null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }*/
    //链表的泛型版本
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }
        public LinkedListNode<T> Next { get; internal set; }
        public LinkedListNode<T> Prev { get; internal set; }
    }
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedListNode<T> First { get; private set; }
        public LinkedListNode<T> Last { get; private set; }

        public LinkedListNode<T> AddLast(T node)
        {
            var newNode = new LinkedListNode<T>(node);
            if (First == null)
            {
                First = newNode;
                newNode.Prev = Last;
                Last = First;
            }
            else
            {
                LinkedListNode<T> previous = Last;
                Last.Next = newNode;
                Last = newNode;
                Last.Prev = previous;
            }
            return newNode;
        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*var list1 = new LinkedList();
            list1.AddLast(2);
            list1.AddLast(4);
            list1.AddLast("6");//编译时出错
            foreach(int i in list1)
            {
                Console.WriteLine(i);
            }*/
            var list2 = new LinkedList<int>();
            list2.AddLast(2);
            list2.AddLast(4);
            list2.AddLast(6);
            foreach (int i in list2)
            {
                Console.WriteLine(i);
            }

            var list3 = new LinkedList<string>();
            list3.AddLast("2");
            list3.AddLast("four");
            list3.AddLast("foo");
            foreach (int i in list2)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
