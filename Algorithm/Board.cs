using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Board
    {
        public TileType[,] _tile;
        public int _size;

        private const char CIRCLE = '\u25CF';

        public enum TileType
        {
            Empty,
            Wall,
        }

        public void Initialize(int size)
        {
            // 짝수라면 보드 생성이 어려우므로 리턴
            if(size % 2 == 0)
                return;

            _tile = new TileType[size, size];
            _size = size;

            GenerateByBinaryTree();
        }

        private void GenerateByBinaryTree()
        {
            // 길을 일단 다 막는 작업
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    // 외곽일 때 Wall로 만들어줌
                    if (x % 2 == 0 || y % 2 == 0)
                        _tile[y, x] = TileType.Wall;
                    else
                        _tile[y, x] = TileType.Empty;
                }
            }

            Random random = new Random();

            // 랜덤으로 우측, 좌측을 뚫는 처리
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    // 외곽일 때 Wall로 만들어줌
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    // 출구가 아예 없도록 처리
                    if(y == _size - 2 && x == _size - 2)
                        continue;

                    // 맨 끝까지 갔다면 벽에 구멍 뚫지 않도록 처리
                    if (y == _size - 2)
                    {
                        _tile[y, x + 1] = TileType.Empty;
                        continue;
                    }

                    if (x == _size - 2)
                    {
                        _tile[y + 1, x] = TileType.Empty;
                        continue;
                    }


                    if (random.Next(0, 2) == 0)
                    {
                        // 우측 방향을 뚫어준다.
                        _tile[y, x + 1] = TileType.Empty;
                    }
                    else
                    {
                        // 아래 방향을 뚫어준다.
                        _tile[y + 1, x] = TileType.Empty;
                    }
                }
            }
        }

        public void Render()
        {
            ConsoleColor prevColor = Console.ForegroundColor;

            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    Console.ForegroundColor = GetTileColor(_tile[y, x]);
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
