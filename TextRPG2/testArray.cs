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

        public void Run()
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

    // 프로그램 실행 했는데, 무한루프 돌고 있다던지 하면. 멈춤 버튼을 클릭하면
    // 코드상의 해당 지점을 가리킨다. 디버깅 팁. j++ 이 i++로 잘못 쓰임.
    class ArrayPractice
    {
        static int GetHighesScore(int[] scores)
        {
            // 가장 큰 숫자 기억
            int maxValue = 0;

            foreach (int score in scores)
            {
                if (score > maxValue)
                    maxValue = score;
            }
            return maxValue;
        }

        // 평균
        static int GetAverageScore(int[] scores)
        {
            if (scores.Length == 0)
                return 0;

            int sum = 0;

            foreach(int score in scores)
            {
                sum += score;
            }

            // 75 / 2 = 37.5  --> 정수연산이기에 0.5 짤림. 37 리턴.
            return sum / scores.Length;
        }

        // 내가 찾고 싶은 값의 인덱스 리턴.
        static int GetindexOf(int[] scores, int value)
        {
            for(int i= 0; i < scores.Length; i++)
            {
                if(scores[i] == value)
                    return i;
            }

            // 찾지 못하면 -1 return.
            return -1;
        }

        // 복잡한 구현. 말로 잘 설명해본다. 그것을 코드로 구현.
        static void Sort(int[] scores)
        {
            // 1. 제일 작은 숫자를 찾는다.
            // 2. 0번째 인덱스와 교체. 시작위치에.
            // 3. 그다음 시작위치~마지막 인덱스 체크. 제일 작은 숫자 교체.

            for (int i = 0; i < scores.Length; i++)
            {
                // 1. i ~ [scores.Length-1] 제일 작은 숫자가 있는 index를 찾는다.
                int minIndex = i;
                for (int j = i; j < scores.Length; j++)
                {
                    if (scores[j] < scores[minIndex])
                        minIndex = j;
                }

                // swap
                int temp = scores[i];
                scores[i] = scores[minIndex];
                scores[minIndex] = temp;

                Console.WriteLine($"scores[{i}] = {scores[i]}");
            }
        }

        public void Run()
        {
            int[] scores = new int[5] { 40, 30, 10, 20, 50 };

            int highestScore = GetHighesScore(scores);
            Console.WriteLine($"highestScore = {highestScore}");

            int averageScore = GetAverageScore(scores);
            Console.WriteLine($"averageScore = {averageScore}");

            int index = GetindexOf(scores, 20);
            Console.WriteLine($"index = {index}");

            index = GetindexOf(scores, 15);
            Console.WriteLine($"index = {index}");

            Sort(scores);
        }
    }
}
