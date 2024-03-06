using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Board
    {
        private const char CIRCLE = '\u25CF';
        public TileType[,] Tile { get; private set; }
        public int Size { get; private set; }

        public int DestY { get; private set; }
        public int DestX { get; private set; }

        Player _player;

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size, Player player)
        {
            // 짝수라면 보드 생성이 어려우므로 리턴
            if(size % 2 == 0)
                return;

            _player = player;

            Tile = new TileType[size, size];
            Size = size;

            DestY = Size - 2;
            DestX = Size - 2;

            //GenerateByBinaryTree();
            GenerateBySideWinder();
        }

        private void GenerateBySideWinder()
        {
            // 길을 일단 다 막는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 외곽일 때 Wall로 만들어줌
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            Random random = new Random();

            // 랜덤으로 우측, 좌측을 뚫는 처리
            for (int y = 0; y < Size; y++)
            {
                // 연속되는 좌표의 갯수이므로 1부터 시작
                int count = 1;

                for (int x = 0; x < Size; x++)
                {
                    // 외곽일 때 Wall로 만들어줌
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    // 출구가 아예 없도록 처리
                    if (y == Size - 2 && x == Size - 2)
                        continue;

                    // 맨 끝까지 갔다면 벽에 구멍 뚫지 않도록 처리
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }

                    if (random.Next(0, 2) == 0)
                    {
                        // 우측 방향을 뚫어준다.
                        Tile[y, x + 1] = TileType.Empty;
                        count++;
                    }
                    else
                    {
                        int randomIndex = random.Next(0, count);
                        Tile[y + 1, x - randomIndex * 2] = TileType.Empty;
                        // 카운트만큼 길을 뚫어줬으니 카운트 초기화
                        count = 1;
                    }
                }
            }
        }

        private void GenerateByBinaryTree()
        {
            // 길을 일단 다 막는 작업
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 외곽일 때 Wall로 만들어줌
                    if (x % 2 == 0 || y % 2 == 0)
                        Tile[y, x] = TileType.Wall;
                    else
                        Tile[y, x] = TileType.Empty;
                }
            }

            Random random = new Random();

            // 랜덤으로 우측, 좌측을 뚫는 처리
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 외곽일 때 Wall로 만들어줌
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    // 출구가 아예 없도록 처리
                    if(y == Size - 2 && x == Size - 2)
                        continue;

                    // 맨 끝까지 갔다면 벽에 구멍 뚫지 않도록 처리
                    if (y == Size - 2)
                    {
                        Tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == Size - 2)
                    {
                        Tile[y + 1, x] = TileType.Empty;
                        continue;
                    }


                    if (random.Next(0, 2) == 0)
                    {
                        // 우측 방향을 뚫어준다.
                        Tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        // 아래 방향을 뚫어준다.
                        Tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    // 플레이어 좌표와 현재 좌표가 일치하면 플레이어 색상으로 표시
                    if (y == _player.PosY && x == _player.PosX)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (y == DestY && x == DestX)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    else
                        Console.ForegroundColor = GetTileColor(Tile[y, x]);
                    
                    Console.Write(CIRCLE);
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = prevColor;
        }

        ConsoleColor GetTileColor(TileType type)
        {
            switch (type)
            {
                case TileType.Empty:
                    return ConsoleColor.Green;
                case TileType.Wall:
                    return ConsoleColor.Red;
                default:
                    return ConsoleColor.Green;
            }
        }
    }
}
