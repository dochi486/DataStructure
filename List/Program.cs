﻿
using System;
using System.Collections.Generic;

namespace List
{
    class MyList<T>
    {
        const int DEFAULTSize = 1;
        T[] _data = new T[DEFAULTSize];


        public int Count = 0; // 실제로 사용중인 데이터 갯수 

        public int Capacity
        {
            get { return _data.Length; }
        } // 예약된 데이터 갯수 

        public void Add(T item)
        {
            // 1. 공간이 충분한지 확인한다.
            if (Count >= Capacity)
            {
                // 공간이 충분하지 않다면 공간을 늘려서 확보한다.
                T[] newArray = new T[Count * 2];
                // 기존 데이터를 새 배열로 옮긴다.
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = _data[i];
                }

                // 기존 데이터를 새 데이터로 교체 
                _data = newArray;
            }

            // 2. 공간에다가 데이터를 넣어준다. 
            _data[Count] = item;
            Count++;
        }

        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1]; 
            }
            
            // 맨 마지막 자리에 있던 데이터를 0이나 null로 초기화
            _data[Count - 1] = default(T);
            Count--;
        }
    }


    class Board
    {
        public int[] _data = new int[25];
        public MyList<int> _data2 = new MyList<int>();
        public LinkedList<int> _data3 = new LinkedList<int>();

        public void Initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            _data2.RemoveAt(2);

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
