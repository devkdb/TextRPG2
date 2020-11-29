using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    class TestList
    {
        public void Run()
        {
            // List <- 동적 배열
            // 1. List는 중간에 삽입 삭제 하는게 그렇게 효율적이지 않다.
            List<int> list = new List<int>();

            //list[0] = 1;  문법적으로는 맞지만, 크러쉬. weil 최소 한개 이상의 크기를
            //              가지고 있다고 보장이 되야한다.

            // 제일 처음엔 인자 추가 [0, 1, 2, 3, 4]
            for(int i = 0; i < 5; i++)
                list.Add(i);
            
            Console.WriteLine("add");
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
            Console.WriteLine();

            // 중간에 999 삽입. [0, 1, 999, 2, 3, 4]
            list.Insert(2, 999);    // 두번째 인덱스에 999 넣어주세요.
                        
            Console.WriteLine("insert(2,999)");
            for (int i =0; i< list.Count; i++)
                Console.WriteLine(list[i]);
            Console.WriteLine();

            // 값 삭제
            Console.WriteLine("remove(3) <-- value");
            bool success = list.Remove(3); // 처음 만난 3 삭제

            foreach (int num in list)
                Console.WriteLine(num);
            Console.WriteLine();

            // 인덱스 삭제
            Console.WriteLine("removeat(0) <-- index");
            list.RemoveAt(0);

            foreach (int num in list)
                Console.WriteLine(num);

            list.Clear(); // 전체 삭제.

        }
    }       
            
}
