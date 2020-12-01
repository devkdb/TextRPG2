using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    class testDelegate
    {
        // delegate (대리자)
        // 업체 사장 - 사장님의 비서한테 연락했으나 바로 만날수없었다. 자리에 없다 등등.
        //              그래서 우리의 연락처/용건을 남겼다. 연락을달라고. 
        //              즉, 거꾸로 나중에 그쪽에서 우리한테 연락이 온다. 이게 콜백 패턴.

        // 한줄 요약. 함수 자체를 인자로 넘겨준다.


        delegate int OnClicked(); // 함수가 아니라 하나의 형식이다.
                                  // void, string,int 처럼 OnClicked() 자체가
                                  // 하나의 형식이다.
        // 분석. delegate 가 붙었으니깐 형식은 형식인데, 함수 자체를 인자로
        // 넘겨주는 그런 형식.
        // 반환은 inOnClickedt, 입력은 void
        // OnClicked 가 이 delegate 형식의 이름이다.


        // UI - 어떤 버튼을 눌렀을때 어떤 행동을 하는.
        // 게임에서도 공격 버튼을 누르면 공격을 시작한다.
        // 버튼이 눌리면 해당 버튼에 맞는 행동을 해야하지만
        // 실제로 많은 것들이 이미 고칠수 없는 것들이 많다.
        // 즉, 내가 많든 게 아니고, 제공 되는 것들일 경우가 많다.
        // 그래서 버튼을 누르면 실행할 함수 자체를 인자로 넘겨주고
        static void ButtonPressed(OnClicked clickedFunction /* 함수 자체를 인자로 넘겨주고 */)
        {
            // 함수를 호출();
            clickedFunction();
        }

        static int TestDelegate()
        {
            Console.WriteLine("hello Delegate 1");
            return 0;
        }
        static int TestDelegate2()
        {
            Console.WriteLine("hello Delegate 2");
            return 0;
        }

        public void Run()
        {
            Console.WriteLine(); // 함수 자체를 고칠수는 없는 경우가 많다.

            // 실제로 우리가 함수를 만들어서 인자로 넣어주면            
            // Unity 측에서 구현을 할때는 함수가 뭔지는 몰라도
            // 인자로 받을 함수가 있다고 가정하고 모든 코드를
            // 다 만들어 두고 우리한테 넘겨주면 되고
            // 우리가 사용할때는 실제로 그 인자를 넣어주고
            // 호출되는 부분만 잘 연결시켜주면 된다.
            // 
            // 이런식으로 함수 자체를 인자로 넘겨주고
            // 나중에 필요로 할때 이쪽 안쪽에서 우리를 역으로 호출하는 것을
            // 콜백 방식이라 한다.
            
            // ButtonPressed(TestDelegate);

            OnClicked clicked = new OnClicked(TestDelegate);
            // clicked();

            // 체이닝 가능.
            clicked += TestDelegate2;
            ButtonPressed(clicked);

            clicked(); // 아무데서나 불릴수 있다. Event 하자.
        }
    }
}
