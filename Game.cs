using System;
using System.Runtime.InteropServices;

namespace OOP_Prov
{
    public class Game
    {
        public static void Meny() //Ville namn ge den Meny, men går inte eftersom då skapas en konstruktor.
        {
            Console.WriteLine("- PLAY, P -");
            Console.WriteLine("- LEADERBOARD, L -");
            Console.WriteLine("- QUIT, Q -");

            var input = Console.ReadKey();
            
            switch(input.Key)
            {
                case ConsoleKey.P:
                    Play();
                    break;

                case ConsoleKey.L:
                
                    break;
                
                case ConsoleKey.Q:
                    break;

                default:
                    Console.WriteLine("Write a single key.");
                    Game.Meny();
                    break;
            }
        }

        public static void Play()
        {
            Player player = new Player();
            Wizard wizard = new Wizard();
            Goblin goblin = new Goblin();

            Random rnd = new Random();
            
            while(true)
            {
                int turn = rnd.Next(1, 7); //Bestämmer vems tur det är att anfalla
                Console.WriteLine(turn);

                if(turn == 1 || turn == 2 || turn == 3 || turn == 4) //De olika fallen då player attackerar
                {
                    player.Attack();
                    if(wizard.Hp < goblin.Hp)
                    {
                        goblin.TakeDamage(player.damage);
                    }
                    else
                    {
                        wizard.TakeDamage(player.damage);
                    }
                }
                else if(turn == 5) //Goblin attackerar
                {
                    goblin.Attack();
                    player.TakeDamage(goblin.Damage);
                }
                else if(turn == 6) //Wizard attackerar
                {
                    wizard.Attack();
                    player.TakeDamage(wizard.Damage);
                }

                if(player.hp <= 0)
                {
                    break;
                }
                else if(goblin.hp <= 0 && wizard.hp <= 0)
                {
                    break;
                }
            }   

            if(player.hp <= 0) //Gör en min max
            {
                Console.WriteLine("Du förlorade");
            }
            else
            {
                Console.WriteLine("Du vann!");
            }      
        }
    }
}