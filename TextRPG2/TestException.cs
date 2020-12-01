using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    // 게임에서는 try catch 를 이용해서 뭔가 처리하면 안됨.
    // 처음부터 이런 오류는 다 잡고 가야한다.
    // 즉, 크래쉬가 나면 크래쉬가 나도록 냅둔다.
    // 그리고 크래쉬가 난걸 보고 최대한 빠르게 로직 수정 한다.
    // 로그 찍는 용도, 또는 네트워크 상 접속 실패 같은 경우의 메시지 보여주는 용도..
    class TestException : Exception
    {
        //static void TestFunc()
        //{
        //    throw new TestException();
        //}
        public void Run()
        {
            // 어떤 예외라는 공을 던지면 포수가 캐치해서 처리한다. 야구 느낌.
            try 
            {
                // 1. 0으로 나눌때
                // 2. 잘못된 메모리를 참조 (null)
                // 3. 오버플로우 ex) 너무 많은 복사.
                int a = 10;
                int b = 0;

                int result = a / b; // 이 이하 코드는 실행 안된다.

                // TestFunc();

                int c = 0; 
                // ......
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("DivideByZeroException!");
            }
            catch (Exception e) // 첫번째 catch문이 이거면, 여기서 모든 예외사항 처리.
                                // 왜? Exception은 최상위 조상이니깐.
                                // 그래서 순서를 바꾸어야 한다. 
            {
                Console.WriteLine("Exception!");
            }
            finally // 최종적으로 무조건 실행되어야 한다.
            {
                // DB, 파일 정리 등등.
                Console.WriteLine("finally DB Rollback, File close, etc...");
            }
        }
    }
}
