using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    // 주석 되돌리기. Ctrl + K, Ctrl + U

    // 객체지향 -> 은닉성
    class Knight
    {
        // 자동 완성 Property.
        public int Hp { get; set; } = 100;

        // 위의 자동 완성 Property의 내부적으로 일어난 일. 
        // 컴파일러가 이렇게 구현.
        //private int _hp;
        //public int GetHp() { return _hp; }
        //public void SetHp(int value) { _hp = value;  }
    }
    class TestProperty
    {
        public void Run()
        {
            // 프로퍼티
            Knight knight = new Knight();
            knight.Hp = 200;
            int hp = knight.Hp;
        }
    }

    // 프로퍼티 설명
    /*
    class Knight
    {
        protected int hp;
        public int hp
        {
            get { return hp; }
            //private set { hp = value; }
            set { hp = value; }
        }

        // Getter Get함수
        public int GetHp() { return hp; }

        // Setter Set함수
        public void SetHp(int hp) { this.hp = hp; }
    }

    public void Run()
    {
        Knight knight = new Knight();
        knight.Hp = 100; // set property. 100 이 value.
        int hp = knight.Hp; // get property.
    }
    */
}
