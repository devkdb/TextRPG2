using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    // Lambda : 일회용 함수를 만드는데 사용하는 문법이다.
    //          일회용 반창고. 딱 한번만 사용하는 함수가 필요할때가 있다.
    //          그럴때 굉장히 유용한 함수.
    class testLambda
    { 
        enum ItemType
        {
            Weapon,
            Armor,
            Amulet,
            Ring
        }
        enum Rarity
        {
            Normal,
            Uncommon,
            Rare,
        }
        class Item
        {
            public ItemType itemType;
            public Rarity rarity;
        }

        static List<Item> _items = new List<Item>();

        // 일반화 해서 사용. 입력형식이 하나 있고, 반환형식도 하나 있는 
        // 타입의 delegate는 모두 이 MyFunc 를 이용해서 넘겨줄 수 있다.
        // delegate Return MyFunc<T, Return>(T item);
        // delegate bool ItemSelector(Item item);
        //static Item FindItem(ItemSelector selector)
        //{
        //    foreach (Item item in _items)
        //    {
        //        if (selector(item))
        //            return item;
        //    }
        //    return null;
        //}
        //Item item = FindItem(delegate (Item item) { return item.itemType == ItemType.Weapon; });

        //static Item FindItem(MyFunc<Item, bool> selector)
        static Item FindItem(Func<Item, bool> selector)
        {
            foreach (Item item in _items)
            {
                if(selector(item))
                    return item;
            }
            return null;
        }

        static bool IsWeapon(Item item)
        {
            return item.itemType == ItemType.Weapon;
        }

        /*
        // 내가 어떤 아이템을 갖고 있는지 자주 검색. 무기찾기, 희귀 아이템 찾기 등등..
        // 계속해서 함수 새로 만드는 것은 무식한 방식.
        static Item FindWeapon()
        {
            foreach (Item item in _items)
            {
                if (item.itemType == ItemType.Weapon)
                    return item;
            }
            return null;
        }
        static Item FindRareItem()
        {
            foreach (Item item in _items)
            {
                if (item.rarity == Rarity.Rare)
                    return item;
            }
            return null;
        }
        */

        public void Run()
        {
            _items.Add(new Item() { itemType = ItemType.Weapon, rarity = Rarity.Normal});
            _items.Add(new Item() { itemType = ItemType.Armor, rarity = Rarity.Uncommon });
            _items.Add(new Item() { itemType = ItemType.Ring, rarity = Rarity.Rare });


            // 조건이 12가지 된다면 함수 안만들려고 했는데... 
            // 인자부분에서 함수를 결국 덕지덕지 12개 만들어야 한다. IsWeapon, IsRare...
            // Item item = FindItem(IsWeapon);

            //MyFunc<Item, bool> selector = (Item item) => { return item.itemType == ItemType.Weapon; };
            // ItemSelector selector = new ItemSelector((Item item) => { return item.itemType == ItemType.Weapon; });

            // 그래서 어쩌다 한번만 딱 사용하는 일회성 함수였다면.

            // 1. Anonymous Function : 무명 함수 / 익명 함수
            // Item item = FindItem(delegate (Item item) { return item.itemType == ItemType.Weapon; });

            // 2. 나중에 나온 방식. Rambda식. 입력값 => 반환값
            // Item item2 = FindItem((Item item) => { return item.itemType == ItemType.Weapon; });

            // 다양한 일반화 공용 MyFunc 가 이미 C#에 있다.
            // 그냥 Func delegate 사용하면 된다. 직접 안 만들어도 된다.
            // delegate Return MyFunc<Return>();
            // delegate Return MyFunc<T1, T2, Return>(T1 t1, T2 t2);
            //Func<Item, bool> selector = (Item item) => { return item.itemType == ItemType.Weapon; };

            // 즉, delegate를 직접 선언하지 않아도, 이미 만들어지 애들이 존재한다.
            // -> 반환 타입이 있을 경우 Func,
            // -> 반환 타입이 없으면 Action
            Item item = FindItem((Item item) => { return item.itemType == ItemType.Weapon; });
        }
    }
}
