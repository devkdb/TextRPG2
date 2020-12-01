using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    // Observer Pattern

    // 사용자의 인풋을 캐치해서 다른 게임로직, 프로그램한테 알려주는
    // 역할을 하는, 중간 매개 역할을 하는 클래스.
    class InputManager
    {
        // delegate는 함수랑 유사. 함수 만든다는 느낌으로..
        public delegate void OnIputKey();
        public event OnIputKey inputKey;

        public bool Update()
        {
            if (Console.KeyAvailable == false)
                return false;

            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.A)
            {
                // 여기다가 코드를 강제로 뭔가 넣는 것은 굉장히 비효율적인 방식이다.
                // 뭔가 다른 코드랑 InputManager라는 코드에 의존성을 점점 증가시킨다.
                // 이때 사용 하는게 콜백 방식이다.

                // 모두한테 알려준다! 이때는 그냥 이벤트만 호출
                inputKey();  // 이 이벤트에 관심 있는 사람은 구독신청만 하면 된다.                
                return true;
            }
            else
                return false;
        }

        public void Run()
        {
            
        }
    }
}
