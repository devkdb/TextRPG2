using System;

namespace TextRPG2  // Namespace 동일하다는 가정하에. 클래스 문서 사용 가능. 
                    // C++은 #include 필요. Player.cs, Monster.cs
{
    class Program
    {
        // 객체지향 프로그래밍
        // 1. 파일 분리. 클래스(객체) 생성.
        // 보이는 클래스: 생물, 몬스터, 플레이어
        // 게임에서 보이진 않지만 존재하는 클래스: 게임 스테이지나 로비 등
        //                                         공간을 관리하는....

        static void Main(string[] args)
        {
            Game game = new Game();

            while(true)
                game.Process();
        }
    }
}
