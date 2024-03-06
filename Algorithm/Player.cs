using System;
using System.Collections.Generic;


namespace Algorithm
{
    class Player
    {
        // 자기 자신만 위치 값을 변경하고 외부에서는 set하지 못하도록 
        public int PosY { get; private set; }
        public int PosX { get; private set; }
        Random _random = new Random();

        private Board _board;

        // 보드의 벽, 타일 여부를 판단하기 위해 외부에서 보드 정보를 받아옴
        public void Initialize(int posY, int posX, int destY, int destX, Board board)
        {
            PosY = posY;
            PosX = posX;

            _board = board;
        }

        const int MOVE_TICK = 100;
        int _sumTick = 0;

        public void Update(int deltaTick)
        {
            _sumTick += deltaTick;
            if (_sumTick > MOVE_TICK)
            {
                _sumTick = 0;

                // 0.1 초마다 실행될 로직
                int randValue = _random.Next(0, 5);
                switch (randValue)
                {
                    case 0: //상
                        if (PosY - 1 >= 0 && _board.Tile[PosY - 1, PosX] == Board.TileType.Empty)
                            PosY = PosY - 1;
                        break;
                    case 1: //하
                        if (PosY + 1 < _board.Size && _board.Tile[PosY + 1, PosX] == Board.TileType.Empty)
                            PosY = PosY + 1;
                        break;
                    case 2: //좌
                        if (PosX - 1 >= 0 && _board.Tile[PosY, PosX - 1] == Board.TileType.Empty)
                            PosX = PosX - 1;
                        break;
                    case 3: //우
                        if (PosX + 1 < _board.Size && _board.Tile[PosY, PosX + 1] == Board.TileType.Empty)
                            PosX = PosX + 1;
                        break;
                }
            }
        }
    }
}
