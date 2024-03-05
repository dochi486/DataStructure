using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace LinkedList
{
    class Node<T>
    {
        public T Data;
        public Node<T> Next;
        public Node<T> Prev;
    }

    class NodeList<T>
    {
        public Node<T> Head = null;
        public Node<T> Tail = null;
        public int Count = 0;

        public Node<T> AddLast(T data)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = data;

            // 만약 아무 노드도 없었다면 새로 추가한 노드가 head이다.
            if (Head == null)
            {
                Head = newNode;
            }

            // 기존의 마지막 노드와 새로 추가되는 노드를 연결해준다. 
            if (Tail != null)
            {
                Tail.Next = newNode;
                newNode.Prev = Tail;
            }

            // 새로 추가되는 노드를 마지막 노드로 만들어준다. 
            Tail = newNode;
            Count++;
            return newNode;
        }

        public void Remove(Node<T> node)
        {
            // 기존의 Next 노드를 Head로 만들어준다. 
            if (Head == node)
            {
                Head = Head.Next;
            }

            if (Tail == node)
            {
                Tail = Tail.Prev;
            }

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }

            Count--;
        }
    }

    class Program
    {
        public LinkedList<int> _data3 = new LinkedList<int>();
        static void Main(string[] args)
        {
               
        }
    }
}

