using System;
using System.Collections.Generic;


namespace Algorithm
{
    class Pos
    {
        public Pos(int y, int x)
        {
            Y = y; X = x;
        }
        public int Y;
        public int X;
    }

    class Player
    {
        // 자기 자신만 위치 값을 변경하고 외부에서는 set하지 못하도록 
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        Random _random = new Random();

        private Board _board;

        enum Dir
        {
            Up,
            Left,
            Down,
            Right
        }

        int _dir = (int)Dir.Up;
        List<Pos> _points = new List<Pos>();

        // 보드의 벽, 타일 여부를 판단하기 위해 외부에서 보드 정보를 받아옴
        public void Initialize(int posY, int posX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;

            // 현재 바라보고 있는 방향을 기준으로, 좌표 변화를 나타낸다? 
            int[] frontY = new int[] { -1, 0, 1, 0 };
            int[] frontX = new int[] { 0, -1, 0, 1 };
            int[] rightY = new int[] { 0, -1, 0, 1 };
            int[] rightX = new int[] { 1, 0, -1, 0 };


            _points.Add(new Pos(PosY, PosX));

            // 둘 중 하나라도 다르면 목적지에 도달하지 못한 것
            while (PosY != board.DestY || PosX != board.DestX)
            {
                // 1. 현재 바라보는 방향을 기준으로 오른쪽으로 갈 수 있는지 확인
                if (_board.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    // 오른쪽 방향으로 90도 회전
                    _dir = (_dir - 1 + 4) % 4;

                    // 앞으로 한 보 전진
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _points.Add(new Pos(PosY, PosX));
                }
                // 2. 현재 바라보는 방향을 기준으로 전진할 수 있는지 확인
                else if (_board.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] == Board.TileType.Empty)
                {
                    // 앞으로 한 보 전진
                    PosY = PosY + frontY[_dir];
                    PosX = PosX + frontX[_dir];
                    _points.Add(new Pos(PosY, PosX));
                }
                else
                {
                    // 왼쪽 방향으로 90도 회전
                    _dir = (_dir + 1 + 4) % 4;
                }
            }
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;
        int _lastIndex = 0;

        public void Update(int deltaTick)
        {
            if(_lastIndex >= _points.Count)
                return;

            _sumTick += deltaTick;
            if (_sumTick > MOVE_TICK)
            {
                _sumTick = 0;

                PosY = _points[_lastIndex].Y;
                PosX = _points[_lastIndex].X;
                _lastIndex++;

                //// 0.1 초마다 실행될 로직
                //int randValue = _random.Next(0, 5);
                //switch (randValue)
                //{
                //    case 0: //상
                //        if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                //            PosY = PosY - 1;
                //        break;
                //    case 1: //하
                //        if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                //            PosY = PosY + 1;
                //        break;
                //    case 2: //좌
                //        if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                //            PosX = PosX - 1;
                //        break;
                //    case 3: //우
                //        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                //            PosX = PosX + 1;
                //        break;
                //}
            }
        }
    }
}
