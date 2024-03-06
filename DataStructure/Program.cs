using System.Diagnostics.CodeAnalysis;

namespace PriorityQueue
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public void Push(T data)
        {
            // 힙의 맨 끝에 데이터를 저장한다. 
            _heap.Add(data);

            int now = _heap.Count - 1;

            while (now > 0)
            {
                // 하나 위의 인덱스 구하는 공식 그냥 외우기
                int next = (now - 1) / 2;

                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 다음에 구할 순서를 바꾼다.
                now = next;
            }
        }

        public T Pop()
        {
            //최대값을 리턴
            T ret = _heap[0];

            // 비어버린 0번 인덱스를 맨 마지막 데이터로 채운다. (마지막 데이터를 루트로 이동한다.)
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            // 데이터를 삭제해주니까 인덱스도 삭제해주는 것 잊지말기 
            lastIndex--;

            //내려가면서 노드 데이터 크기 비교
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // 왼쪽값이 현재값보다 크면, 왼쪽으로 이동 
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;

                // 오른쪽값이 현재값보다 크면, 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // 왼쪽, 오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                //두 값을 교체한다.
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                //검사 위치를 이동한다.
                now = next;
            }

            return ret;
        }

        public int Count()
        {
            return _heap.Count;
        }
    }

    class Knight : IComparable<Knight>
    {
        public int Id { get; set; }
        public int CompareTo(Knight other)
        {
            if (Id != other.Id)
                return 0;

            return Id > other.Id ? 1 : -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<Knight> q = new PriorityQueue<Knight>();
            q.Push(new Knight(){Id = 20});
            q.Push(new Knight() { Id = 30 });
            q.Push(new Knight() { Id = 50 }); 
            q.Push(new Knight() { Id = 10 });
            q.Push(new Knight() { Id = 90 });
            q.Push(new Knight() { Id = 80 });

            while (q.Count() > 0)
            {
                Console.WriteLine(q.Pop());
            }

        }
    }
}

