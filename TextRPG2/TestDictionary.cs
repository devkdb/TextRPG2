using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    class TestDictionary
    {
        /*          
            몬스터 100만마리. id 103인 몬스터 어떻게 찾나?
            특정 키를 가지고 value를 찾는 뭔가가 필요하다.
            이런게 Dictionary.
            Dictionary 는 hashtable.
            
            아주 큰 박스 [ ............. ] 1만개 (1 ~ 1만)
            박스 여러개를 쪼개 놓는다. [1~10][11~20][21~30][][][] 1천개
            7777번 공은 어디에? 777번 박스에 있다.
            메모리 손해. -> 메모리를 내주고, 성능을 취한다.
         */
        class Monster
        {
            public int id;
            public Monster(int id) { this.id = id; }            
        }        

        public void Run()
        {
            Dictionary<int, Monster> dic = new Dictionary<int, Monster>();

            /*          dic.Add(1, new Monster(1));
                        dic[5] = new Monster(5);
            */
            for (int i = 0; i < 10000; i++)
                dic.Add(i, new Monster(i));

            //Monster mon = dic[5000];
            //Monster mon2 = dic[20000]; // crush!!

            Monster mon;
            bool found = dic.TryGetValue(20000, out mon);
            //if(found == true)
            //{ }

            dic.Remove(7777);
            dic.Clear();
        }
    }
}
