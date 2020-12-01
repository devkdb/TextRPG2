using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{    
    class TestNullable
    {
        class Human
        {
            public int Id { get; set; }
        }
        static Human FindHuman(int Id)
        {
            // for ()
            // return monster;

            return null;
        }

        static int Find()
        {
            return 0; // 우리끼리 null의 의미로 사용. 뭐 약간 어거지.
        }

        public void Run()
        {
            Human human = FindHuman(91);
            if (human != null)
            {

            }

            // Nullable -> Null + able
            int? number = null; // ?를 추가하면 null도 될수있다는 의미.

            /*
            number = 3;
            int a = number;       // 에러 발생. Nullable 형식이랑 int형식이랑 변환할수 없다.
            int a = number.Value; // 이런식으로 명시적으로 사용.
            Console.WriteLine(a);
            */

            // 값이 없으면 에러 발생. 그래서 사용전에 값체크 해야한다.
            //아래 둘중 하나 사용.
            if (number != null)
            {
                int a = number.Value;
                Console.WriteLine(a);

            }

            if (number.HasValue)
            {
                int a = number.Value;
                Console.WriteLine(a);
            }

            // null 값이 생긴것은 좋지만 매번 사용할때마다 체크 불편.
            // 그래서 아래 문법 사용.
            // b에 number 값 입력. 없으면 0 입력.
            int b = number ?? 0;
            Console.WriteLine(b);

            // 참고
            int c = (number != null) ? number.Value : 0;
            Console.WriteLine(c);

            // 클래스
            Human human1 = null;
            if (human1 != null)
            {
                int humanId = human1.Id;
            }

            int? id = human1?.Id;
            /*
            if (human1 == null)
                id = null;
            else
                id = human1.Id;
            */

            // Nullable -> 형식에 ? 붙여서 만듬.
            // ??
            // ?.
        }
    }
}
