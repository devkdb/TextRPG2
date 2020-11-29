using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    // 일반화
    class testGeneric
    {
        // 일반화 클래스. 일반화 형식.
        // 이 T타입에 대해서 어떤 값을 넣어주더라도 작동을 한다.
        // int, float, Monster.. 어떤거라도
        class MyList<T> // 템플릿 oder 타입의 약자. T라는 매개변수 자체가 모든 타입에서 돌아가는.. 조커키 같은.
        {
            T[] arr = new T[10];

            public T GetItem(int i)
            {
                return arr[i];
            }
        }

        // C++은 없지만 C#에 있는 편리한 문법. 조건을 줄 수 있다.

        // class MyList<T> where T : struct <-- 어떠한 T값이든 상관 없지만 
        //                                      단 T는 값 형식이어야 한다.

        // class MyList<T> where T : class <-- 참조 형식이어야 한다.

        // class MyList<T> where T : new() <-- 반드시 어떠한 인자도 받지 않는
        //                                     기본 생성자가 있어야 한다.

        // class MyList<T> where T : Monster <-- 어떠한 T값이든 상관 없지만 
        //                                       단 T는 Monster 혹은 Monster를
        //                                       상속 받은 클래스여야 한다.

        class Monster
        {   
        }

        // 일반화 함수
        static void Test<T>(T input)
        {

        }

        public void Run()
        {
            // var는 object와 전혀 다르다. int,  string 명시하지 않아도 컴파일러가
            // 뒤의 값을 보고 대충 알아서 해당 타입으로 변환. var obj3 나 int obj3나 
            // 같다.
            var obj3 = 3;
            var obj4 = "hello world";


            // object는 정말로 타입이 object. 어떤 타입이든 다 소화 가능
            // int, string 등은 전부 object를 상속받아서 구현.
            object obj = 3;
            object obj2 = "hello world";

            // 그럼 다 object 쓰지? 아래 같은 경우 속도가 느리다.            
            int num = (int)obj;
            string str = (string)obj2;

            // 모든것을 object 사용하는 것은 무리가 있다.
            // object 생성하고 꺼내오는 작업은 무겁다. 아래예처럼.
            // object는 전부 참조 타입. 값 5만 넣으려고 시도 했지만,
            // 실제로는 힙에다가 메모리 할당 해가지고 거기다가 굳이 5를 넣은 
            // 다음에 
            object obj5 = 5;  //박싱.
            int num2 = (int)obj5; // 언박싱. 이렇게 꺼내올때는 힙에 있는 숫자를 빼와서
                                  // 스택에다가 저장. 복잡함.
            
            int number = 3;// 스택에 들어가는. 복사타입. 간편히 사용.


            MyList<int> myIntList = new MyList<int>();
            MyList<short> myShortList = new MyList<short>();
            MyList<Monster> myMonsterList = new MyList<Monster>();

            Test<int>(3);
            Test<float>(3.0f);
        }
    }
}
