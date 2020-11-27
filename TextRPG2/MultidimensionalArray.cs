using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{

    class MultidimensionalArray // 다차원 배열
    {
        class Map
        {
            // 5X5. 0 : Space to move, 
            // 1:A space like a wall that cannot be reached
            // 2 : Door
            int[,] tiles = {        // tiles.Length = 25
                { 1, 1, 1, 1, 1 },
                { 2, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1 }
            };
            public void Render()
            {
                // 타입이 궁금하지 않을 경우, var 사용. 즉, 신경쓰지 않아도 될경우.
                var defaultColor = Console.ForegroundColor;

                // y 값은 세로 값 <- 2차원 값
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    for(int x = 0; x < tiles.GetLength(0); x++)
                    {
                        if (tiles[y, x] == 1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (tiles[y, x] == 0)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.Write('\u25cf');
                    }
                    Console.WriteLine();
                }

                Console.ForegroundColor = defaultColor;
            }
        }
        public void Run()
        {
            // 오른쪽에서 왼쪽으로 읽는다.
            // int[2,3]  1차원 3, 2차원 2인 배열 two by three
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 1, 2, 3 } };

            arr[0, 0] = 1;
            arr[1, 0] = 1;

            // 아파트에 비유하면. 2층짜리 아파트인데, 각 3개의 집이 존재.
            // 2F[ . . .]
            // 1F[ . . .]

            // test
            Map map = new Map();
            map.Render();
        }
    }

    class VariableArray
    {
        public void Run()
        {
            // [ . . ]
            // [ . . . . . . ]
            // [ . . . ]

            // 가변 배열. 사용한 적 없다. 배열의 배열 만든 느낌.
            int[][] a = new int[3][];
            a[0] = new int[3];
            a[1] = new int[6];
            a[2] = new int[2];
        }
    }
}
