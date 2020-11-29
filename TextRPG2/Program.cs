using System;

namespace TextRPG2
{
    class Program
    {
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
        }
    }
}
