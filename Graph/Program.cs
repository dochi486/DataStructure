namespace Graph
{
    class Graph
    {
        int[,] adj = new int[6,6]
        {
            { -1, 15, -1, 35, -1, -1 },
            { 15, -1, 05, 10, -1, -1 },
            { -1, 05, -1, -1, -1, -1 },
            { 35, 10, -1, -1, 05, -1 },
            { -1, -1, -1, 05, -1, 05 },
            { -1, -1, -1, -1, 05, -1 },
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3, 5 },
            new List<int>() { 4 }
        };

        public void Dijikstra(int start)
        {
            bool[] visited = new bool[6];
            int[] distance = new int[6];
            int[] parent = new int[6];

            // 방문을 못해서 0인지 초기 값이 0인지 헷갈리니까 Int32의 최댓값을 채워줌
            Array.Fill(distance, Int32.MaxValue);

            distance[start] = 0;
            parent[start] = start;

            while (true)
            {
                // 제일 가까이에 있는 후보를 찾는다. 


                // 가장 유력한 후보의 거리와 번호를 저장
                int closest = Int32.MaxValue;
                int now = -1;

                for (int i = 0; i < 6; i++)
                {
                    // 이미 방문한 점은 스킵
                    if (visited[i])
                        continue;
                    // 아직 발견된 적이 없거나, 기존 후보보다 멀리 있으면 스킵
                    if (distance[i] == Int32.MaxValue || distance[i] >= closest)
                        continue;
                    // 지금까지 발견한 가장 적합한 후보이므로 정보를 갱신
                    closest = distance[i];
                    now = i;
                }

                // 적합한 후보가 하나도 없을 때 -> 종료
                if (now == -1)
                    break;

                // 제일 좋은 후보를 찾았으므로 이동한다. 
                visited[now] = true;

                // 방문한 정점과 인접한 점들을 조사해서 상황에 따라 발견한 최단거리를 갱신한다. 
                for (int next = 0; next < 6; next++)
                {
                    // 연결되지 않은 점은 스킵 
                    if (adj[now, next] == -1)
                        continue;
                    // 이미 방문했던 점도 스킵
                    if (!visited[next])
                        continue;

                    // 새로 조사된 점의 최단 거리를 계산한다. 
                    int nextDist = distance[now] + adj[now, next];

                    // 만약 기존에 발견한 최단 거리가 새로 조사한 거리보다 크면 정보를 갱신
                    if (nextDist < distance[next])
                    {
                        distance[next] = nextDist;
                        parent[next] = now;
                    }
                } 

            }
            
        }

        public void BFS(int start)
        {
            bool[] found = new bool[6];

            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            found[start] = true;

            while (q.Count > 0)
            {
                int now = q.Dequeue();

                for (int next = 0; next < 6; next++)
                {
                    // 인접하지 않았으면 스킵
                    if (adj[now, next] == 0)
                        continue;
                    // 이미 발견했어도 스킵
                    if (found[next])
                        continue;

                    q.Enqueue(next);
                    found[next] = true;
                }
            }
        }


        bool[] visited = new bool[6];
        public void DFS(int now)
        {
            // 1. now를 방문하고
            visited[now] = true;
            // 2. now와 연결된 vertex를 확인해서 아직 방문하지 않은 상태라면 방문한다.
            for (int next = 0; next < 6; next++)
            {
                // 연결되어 있지 않으면 스킵
                if (adj[now, next] == 0)
                    continue;
                // 이미 방문했으면 스킵
                if (visited[next])
                    continue;

                DFS(next);
            }
        }

        public void DFS2(int now)
        {
            // now를 방문하고 
            visited[now] = true;

            foreach (var next in adj2[now])
            {
                if (visited[next])
                    continue;

                DFS2(next);
            }
        }

        public void SearchAll()
        {
            visited = new bool[6];

            for (int now = 0; now < 6; now++)
            {
                if (visited[now] == false)
                    DFS(now);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            //graph.DFS(0);
            //graph.DFS2(0);
            //graph.SearchAll();
        }
    }
}
