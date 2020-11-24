using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG2
{
    // 게임 진행에 관련된 전반적인 사항들

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
        private Player player = null;

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
    }
}
