using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    class testArray
    {
        // 자료구조. 자료에 대한 구조. 데이터를 어떤식으로 저장 어떤식으로 뽑아 쓸지.
        // 몇백에서 몇천.. 몇만..어떻게 다룰 것인가? 변수 천개, 만개?
        // 몬스터 타입 오크, id  103 번인 개체 찾고 싶다.
        // 큰 규모의 데이터 다룰려면 꼭필요.
        class Player
        {

        }
        class Monster
        {

        }

        public void RunTestArray()
        {
            int a; // 일종의 바구니. a라는 이름의. int 크기만큼의.

            // 배열
            // int 형식의 데이터를 여러개 갖고 있다. 
            // new 를 해서 생성해 줘야 한다. 참조 타입.
            int[] scores = new int[5] { 10, 20, 30, 40, 50 };  // 명시적 방법. 추천.
            // int[] scores = new int[] { 10, 20, 30, 40, 50 };
            // int[] scores = { 10, 20, 30, 40, 50 };

            int[] scores2 = scores;
            scores2[0] = 9999;  // 같은 원본 소유. 둘다 값이 변함.


            // 0 1 2 3 4
            /*          scores[0] = 10;
                        scores[1] = 20;
                        scores[2] = 30;
                        scores[3] = 40;
                        scores[4] = 50;
            */
            // 배열의 크기 이용.
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }
            Console.WriteLine();

            foreach (int score in scores)
            {
                Console.WriteLine(score);
            }
        }
    }
}
