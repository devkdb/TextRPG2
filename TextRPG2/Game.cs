using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    // 게임 진행에 관련된 전반적인 사항들. 관리 주체.

    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }
    class Game
    {
        private GameMode mode = GameMode.Lobby;
        
        // 이렇게 들고 있으면 함수안에서 이렇게 함수끼리 넘기지 않아서 굉장히 편했다.
        // 즉, 게임 안에서 필요한 정보는 다 얘가 들고 있으면 된다.
        private Player player = null;
        private Monster monster = null;
        private Random rand = new Random();

        public void Process()
        {
            switch (mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessLobby()
        {
            Console.WriteLine("Wähle einen Job");
            Console.WriteLine("[1] Ritter");        // 기사
            Console.WriteLine("[2] Bogenschütze");  // 궁수
            Console.WriteLine("[3] Magier");        // 마법사
            
            string input = Console.ReadLine();
            Console.WriteLine();

            switch(input)
            {
                case "1":
                    player = new knight();
                    mode = GameMode.Town;
                    break;

                case "2":
                    player = new Archer();
                    mode = GameMode.Town;
                    break;

                case "3":
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("Du hast das Abenteurerdorf betreten.");
            Console.WriteLine("[1] Gehe aufs Feld (kämpfe gegen Monster)");        // 기사
            Console.WriteLine("[2] Kehre in die Lobby zurück (wähle einen Job)");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;

                case "2":
                    mode = GameMode.Lobby;
                    break;
            }

        }

        private void ProcessField()
        {
            Console.WriteLine("Du hast das Feld betreten.");

            CreateRandomMonster();
                        
            Console.WriteLine("[1] Kampf"); // 싸우기
            Console.WriteLine("[2] Renn weg"); // 도망치기
            Console.WriteLine();

            string input = Console.ReadLine();
            Console.WriteLine();

            switch(input)
            {
                case "1":
                    ProcessFight();
                    break;

                case "2":
                    TryEscape();
                    break;
            }

        }

        private void ProcessFight()
        {
            // 내가 치고 너가 치고.
            while (true)
            {
                // 내가 먼저 공격.
                int damage = player.GetAttack();
                monster.OnDamaged(damage);
                Console.WriteLine("Ich habe das Monster geschlagen.");                
                if (monster.IsDead())
                {
                    Console.WriteLine("Ich habe gewonnen. Das Monster rennt weg.");
                    Console.WriteLine($"Meine HP ist {player.GetHP()}."); 
                    break;
                }
                else
                {
                    Console.WriteLine($"Das Monster hat noch {monster.GetHP()} HP. Meine HP ist {player.GetHP()}.");
                }

                // 몬스터 공격.
                damage = monster.GetAttack();
                player.OnDamaged(damage);
                Console.WriteLine("Das Monster schlägt mich.");                
                if (player.IsDead())
                {
                    mode = GameMode.Lobby;
                    Console.WriteLine("Das Monster hat gewonnen. Es tut so weh. Ich renne weg.");
                    Console.WriteLine($"Das Monster HP ist {monster.GetHP()}.");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine($"Ich habe noch {player.GetHP()} HP. Das Monster HP ist {monster.GetHP()}.");
                }
                Console.WriteLine();
            }
        }

        private void TryEscape()
        {
            int randValue = rand.Next(0, 101);
            if (randValue < 33)
            {
                Console.WriteLine("Ich habe hart gespielt. Monster sind unsichtbar. Ich kehrte sicher ins Dorf zurück.");
                mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("Ich rannte hart, aber ein Monster folgte mir. Ich kämpfe gegen Monster.");
                ProcessFight();
            }
            Console.WriteLine();
        }

        // 몬스터 랜덤 생성
        private void CreateRandomMonster()
        {            
            int randValue = rand.Next(0, 3); // 0,1,2            
            switch (randValue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("Slime erschien. Er kommt zu mir.");
                    break;

                case 1:
                    monster = new Orc();
                    Console.WriteLine("Orc erschien. Er kommt zu mir.");
                    break;

                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("Skeleton erschien. Er kommt zu mir.");
                    break;
            }
            Console.WriteLine();
        }

    }
}
