namespace Graph
{
    class Graph
    {
        int[,] adj = new int[6,6]
        {
            { 0, 1, 0, 1, 0, 0 },
            { 1, 0, 1, 1, 0, 0 },
            { 0, 1, 0, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0 },
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1 },
            new List<int>() { 5 },
            new List<int>() { 4 }
        };

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
            graph.SearchAll();
        }
    }
}
