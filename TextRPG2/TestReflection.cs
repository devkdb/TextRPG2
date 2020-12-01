using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TextRPG2
{
    // Reflection : X-Ray 를 찍는 것이다.
    // Monster가 가지고 있는 모든 정보를 런타임에,
    // 즉, 프로그램이 실행되는 도중에 다 띁어보고 분석해 볼 수 있다.
    class NPC
    {        
        class Important : System.Attribute
        {
            string message;
            public Important(string message) { this.message = message; }
        }

        // hp입니다. 중요한 정보입니다. <-- 이런식으로 주석을 남긴다. 프로그래머, 사람 용도.
        // Attribute : 컴퓨터가 런타임에 체크할 수 있는 주석.
        [Important("Very Important")]
        public int hp;
        protected int attack;
        private float speed;

        void Attack() { }
    }
    class TestReflection
    {
        public void Run()
        {
            NPC npc = new NPC();

            Type type = npc.GetType();

            var fields = type.GetFields(System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Static
                | System.Reflection.BindingFlags.Instance);

            Console.WriteLine();
            Console.WriteLine("Reflection Test");
            foreach(FieldInfo field in fields)
            {
                string access = "protected";
                if (field.IsPublic)
                    access = "public";
                else if (field.IsPrivate)
                    access = "private";

                var attributes = field.GetCustomAttributes();

                Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
            }
        }
    }
}
