using System;
using System.Collections.Generic;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WAIT_TICK = 1000 / 30;
            Console.CursorVisible = false;

            Board board = new Board();
            board.Initialize(25);

            int lastTick = 0;
            while (true)
            {
                # region 프레임 관리

                int currentTick = System.Environment.TickCount;
                // 만약 경과한 시간이 1/30초보다 작다면
                if (currentTick - lastTick < WAIT_TICK)
                    continue;
                lastTick = currentTick;

                #endregion 프레임 관리

                Console.SetCursorPosition(0, 0);
                board.Render();
            }
        }
    }
}

