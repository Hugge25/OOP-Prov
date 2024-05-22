using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace OOP_Prov
{
    public class Game
    {
        public void Meny() //Ville namn ge den Meny, men går inte eftersom då skapas en konstruktor.
        {
            Console.WriteLine("   - PLAY, P -");
            Console.WriteLine("- LEADERBOARD, L -");
            Console.WriteLine("   - QUIT, Q -");

            var input = Console.ReadKey();
            Console.Clear();
            
            switch(input.Key)
            {
                case ConsoleKey.P:
                    Play();
                    break;

                case ConsoleKey.L:
                    StreamReader sr = new StreamReader("Score.txt");
                    
                    Console.WriteLine(sr.ReadLine());
                    Console.WriteLine(sr.ReadLine());
                    Console.WriteLine(sr.ReadLine());
                    
                    sr.Close();
                    Meny();
                    break;
                
                case ConsoleKey.Q:
                    break;

                default:
                    Console.WriteLine("Write a single key.");
                    Meny();
                    break;
            }
        }

        public void Play()
        {
            Player player = new Player();
            Wizard wizard = new Wizard();
            Goblin goblin = new Goblin();

            bool PlayerWon;

            Random rnd = new Random();
            
            while(true)
            {
                int turn = rnd.Next(1, 7); //Bestämmer vems tur det är att anfalla

                if(turn == 1 || turn == 2 || turn == 3 || turn == 4) //De olika fallen då player attackerar
                {
                    player.Attack();
                    if(wizard.Hp < goblin.Hp)
                    {
                        goblin.TakeDamage(player.Damage);
                    }
                    else
                    {
                        wizard.TakeDamage(player.Damage);
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

                if(player.Hp <= 0)
                {
                    break;
                }
                else if(goblin.Hp <= 0 && wizard.Hp <= 0)
                {
                    break;
                }

                Thread.Sleep(500);
            }   
            if(player.Hp <= 0)
            {
                TG.Slow("Du förlorade");
                PlayerWon = false;
                
            }
            else
            {
                TG.Slow("Du vann!");
                PlayerWon = true;
            }

            

            string info = "";

            if(PlayerWon){
                info = "Vann";
            }
            else if(!PlayerWon)
            {
                info = "Förlorade";
            }

            //Console.WriteLine(lastScore);

            string[] place = new string [3];

            //for(int i = 0;)
            //{

            //}

            //if(player.Hp > lastScore)
            {
                
                place[1] = place[0];
            }


            Meny();      
        }

    }
}