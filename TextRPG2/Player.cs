using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer= 2,
        Mage = 3
    }
    class Player
    {
        protected PlayerType type = PlayerType.None;
        protected int hp = 0;
        protected int attack = 0;

        // 인자 있는 버전을 만드는 순간 인자 없는 생성자 사용 불가.
        // 생성시 꼭 타입이 있어야 할 경우.
        protected Player(PlayerType type)
        {
            this.type = type;
        }

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }

        public int GetHP() { return hp; }
        public int GetAttack() { return attack; }
    }
    class knight : Player
    {
        // 부모 생성자를 이용해서 타입 설정.
        public knight() : base(PlayerType.Knight)
        {
            SetInfo(100,10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(50,15);
        }
    }
}
