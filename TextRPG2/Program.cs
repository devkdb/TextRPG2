using System;

namespace TextRPG2
{
    class Program
    {
        static void OnInputTest()
        {
            Console.WriteLine();
            Console.WriteLine("Input Received!");
        }
        static void Main(string[] args)
        {
/*          testArray ArrayTest = new testArray();
            ArrayTest.Run();

            ArrayPractice arrayPractice = new ArrayPractice();
            arrayPractice.Run();
*/
            MultidimensionalArray multidimensionalArray = new MultidimensionalArray();
            multidimensionalArray.Run();

            TestList testList = new TestList();
            testList.Run();

            TestDictionary testDic = new TestDictionary();
            testDic.Run();

            // event, delegate
            InputManager inputManager = new InputManager();

            // 구독 신청
            inputManager.inputKey += OnInputTest;

            while(true)
            {
                // A키가 눌리면 inputKey() 호출되면서
                // 전체적인 안내방송을 하는데, 구독한
                // 얘들만 안내방송을 들을 수 있다.
                if (true == inputManager.Update())
                    break;
            }

            // inputManager.inputKey() <-- 멋대로 호출 금지.


            TestException testException = new TestException();
            testException.Run();

            TestReflection testReflection = new TestReflection();
            testReflection.Run();
        }
    }
}
