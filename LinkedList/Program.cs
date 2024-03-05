using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace LinkedList
{
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null;
        public MyLinkedListNode<T> Tail = null;
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newMyLinkedListNode = new MyLinkedListNode<T>();
            newMyLinkedListNode.Data = data;

            // 만약 아무 노드도 없었다면 새로 추가한 노드가 head이다.
            if (Head == null)
            {
                Head = newMyLinkedListNode;
            }

            // 기존의 마지막 노드와 새로 추가되는 노드를 연결해준다. 
            if (Tail != null)
            {
                Tail.Next = newMyLinkedListNode;
                newMyLinkedListNode.Prev = Tail;
            }

            // 새로 추가되는 노드를 마지막 노드로 만들어준다. 
            Tail = newMyLinkedListNode;
            Count++;
            return newMyLinkedListNode;
        }

        public void Remove(MyLinkedListNode<T> MyLinkedListNode)
        {
            // 기존의 Next 노드를 Head로 만들어준다. 
            if (Head == MyLinkedListNode)
            {
                Head = Head.Next;
            }

            if (Tail == MyLinkedListNode)
            {
                Tail = Tail.Prev;
            }

            if (MyLinkedListNode.Prev != null)
            {
                MyLinkedListNode.Prev.Next = MyLinkedListNode.Next;
            }

            if (MyLinkedListNode.Next != null)
            {
                MyLinkedListNode.Next.Prev = MyLinkedListNode.Prev;
            }

            Count--;
        }
    }
    class Board
    {
        public int[] _data = new int[25];
        public List<int> _data2 = new List<int>();
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Initialize();
        }
    }
}

