using System;
using System.Collections.Generic;
using System.Text;

/*
  주석처리 단축키 Ctrl + / 로 재설정
    Tools -> Options -> Keyboard
    Edit.CommentSelection : Ctrl + K, Ctrl +C 를 Ctrl + /로 변경
    Global에는 Ctrl + / 이 어떤 명령의 단축키로 셋팅됨. C# Editor에서만 바꾼다.
 */

namespace TextRPG2
{
    // 추상 클래스 - 뭔가 클래스를 설계할 때 조금 더 행위에 그런 강요를 주는 문법
    abstract class Monster
    {
        // public virtual void Shout() { } // 자식함수는 오버라이드 안해도 됨.
        // 하지만, 몬스터라면 무조건 사우팅이라는 기능이 있어야 해!
        // Shout()함수를 무조건 overriding 해야돼!
        // 부모 클래스에 abstract 추가하면 된다.

        // 그러면 이 클래스는 추상 클래스가 된다. 추상. 말만 들어도 현실적이지 않고 
        // 그냥 뜬구름 잡는 개념만 잡는 그런 느낌.
        // 인스턴스 생성 못함. new 에러남. 
        // 즉 말 그대로 Monster는 추상적으로만 사용 됨.
        public abstract void Shout(); // 추상적이기 때문에 본문 사용 안됨.        
                                      // 추상함수도 개념적 사용.
    }

    //abstract class Flyable
    //{
    //    public abstract void Fly();
    //}

    // 의미: 나의 기능을 갖고 있는 얘라면 반드시 이 Fly() 라는
    // Interface 함수를 구현해야 한다. 하지만 딱히 이 Fly()라는 함수가
    // 어떻게 구현이 되야하는지는 물려주지 않는다.
    interface IFlyable
    {
        void Fly(); // public, private 키워드 불필요.
    }


    // 반드시 샤우팅하고 날아야 한다.
    //class FlyableOrc : Orc, Flyable // 기본 클래스를 여러개 품을 수 없다. 에러남.
    //                                // C++은 다중 상속 가능.
    /*
        C# 은 왜 다중 상속이 안되는가? 죽음의 다이아몬드 문제가 있다.

        class SkeletonOrc : Skeleton, Orc
        {
            // Shout() 함수 어떤걸 써야하나?
        }

        같은 시그니쳐로, 즉 같은 인터페이스로 각기 다른 구현부를 물려받았기 
        때문에 문제가 발생. 충돌!
            
        C#은 아예 막음.
        단점은 다중상속 못해서 필요한 상속 못받는다는것.
        그래서 발상의 전환으로 인터페이스는 물려주지만 구현부는 너가 알아서 해.
        새로운 문법을 만들어서 C++의 다이아몬드 문제 해결.
        그게 interface.   
        

     */
    class FlyableOrc : Orc, IFlyable
    {
        // implement interface member. 인터페이스 멤버 구현.
        public void Fly()
        {

        }
    }

    // 추상클래스의 자식함수는 상속된 추상 함수를 구현해야한다.
    class Orc : Monster
    {
        public override void Shout()
        {
            Console.WriteLine("록타르 오가르!");
        }
    }
    class Skeleton : Monster
    {

        // 부모 클래스에서 virtual 만 해서는 강요 안됨. 
        // shout함수 없어도 부모 shout 실행됨.
        // 하지만 추상클래스를 상속했으면 무조건 
        // 상속된 추상 함수를 구현해야한다.
        public override void Shout()
        {
            Console.WriteLine("꾸에에엑!");
        }
    }

    // 어떠한 기능을 반드시 추가하고 싶다.
    class testInterface
    {
        static void DoFly(IFlyable flyable)
        {
            flyable.Fly();
        }
        public void Run()
        {
            //  class FlyableOrc : Orc, IFlyable
            // FlyableOrc 는 IFlyable 인터페이스를 가지고 있기 때문에
            // 날라다니는 기능을 어떤식으로든 포함을 하고 있다. 라고 가정 할수 있다.
            // 그렇다는 것은 IFlyable 인터페이스로 선언된 변수에 FlyableOrc 저장 가능.
            IFlyable orc = new FlyableOrc();

            // 또 한번 더 응용을 하면은 날라다녀라 라는 아래함수의 인자로 
            // 내부 구현은 어떻게 되어 있는지 모르지만 IFlyable 이 인터페이스를
            // 내포하고 있는 얘만 이 DoFly() 함수로 호출 할 수 있다.
            // static void DoFly(IFlyable flyable)
            DoFly(orc);
        }
    }
}
